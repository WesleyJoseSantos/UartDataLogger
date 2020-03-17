using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;
using System.Diagnostics;
using UartDataLogger.Common;
using System.IO;
using System.Runtime.Serialization;

namespace UartDataLogger
{

    public partial class MainScreen : Form
    {
        string appCfgFile = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\UartDataLogger\\UartDataLogger.json";
        private AppSettings appSettings = new AppSettings();

        private static readonly DateTime epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        private readonly Stopwatch stopWatch = new Stopwatch();
        delegate void delegateAppendText(String text);
        private readonly delegateAppendText monitorAppendText;
        bool closeSerialPortFlag, closeApp = false;
        int selectedIndex = 0;

        public MainScreen()
        {
            InitializeComponent();
            monitorAppendText = new delegateAppendText(tbMonitor.AppendText);
        }

        private void CbPort_MouseEnter(object sender, EventArgs e)
        {
            updateCbPort();
        }

        private void updateCbPort()
        {
            object bkp = cbPort.SelectedItem;
            cbPort.Items.Clear();
            cbPort.Items.AddRange(SerialPort.GetPortNames());
            try
            {
                cbPort.SelectedItem = bkp;
            }
            catch (Exception)
            {

            }
        }

        private void CbPort_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!serialPort.IsOpen)
                serialPort.PortName = Convert.ToString(cbPort.SelectedItem);
        }

        private void CbSpeed_SelectedIndexChanged(object sender, EventArgs e)
        {
            serialPort.BaudRate = Convert.ToInt32(cbSpeed.SelectedItem);
        }

        private void SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            String text = getOutputTime();
            text += "\t" + serialPort.ReadLine();
            if (cbEnableNewLine.Checked) text += "\n";
            tbMonitor.Invoke(monitorAppendText, text);
            if (closeSerialPortFlag) {
                serialPort.Close();
                closeSerialPortFlag = false;
            }
            if (closeApp) Application.Exit();
        }

        String getOutputTime()
        {
            DateTime today = DateTime.Now;
            TimeSpan time = today - epoch;
            switch (selectedIndex)
            {
                case 0:
                    return Convert.ToString(stopWatch.ElapsedMilliseconds);
                case 1:
                    return time.TotalSeconds.ToString();
                case 2:
                    return (today.Hour + ":" + today.Minute + ":" + today.Second);
                case 3:
                    return (today.ToString());
                default:
                    return Convert.ToString(stopWatch.ElapsedMilliseconds);
            }
        }

        private void TsbStart_Click(object sender, EventArgs e)
        {
            if (serialPort.IsOpen)
            {
                ClosePort();
            }
            else
            {
                OpenPort();
            }
            if (!closeSerialPortFlag)
            {
                tsbStart.Image = global::UartDataLogger.Properties.Resources.stop;
                tsbStart.ToolTipText = "Stop Data Logger";
            }
            else
            {
                tsbStart.Image = global::UartDataLogger.Properties.Resources.start;
                tsbStart.ToolTipText = "Start Data Logger";
            }
        }

        void OpenPort()
        {
            try
            {
                serialPort.Open();
                timer.Start();
                stopWatch.Start();
            }
            catch (Exception ex)
            {
                CommonFunctions.showError(ex);
            }
        }

        void ClosePort()
        {
            try
            {
                closeSerialPortFlag = true;
                timer.Stop();
                stopWatch.Stop();
                stopWatch.Reset();
            }
            catch (Exception ex)
            {
                CommonFunctions.showError(ex);
            }
        }
       
        private void TsbtDelete_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("Are you sure?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r == DialogResult.Yes)
            {
                tbMonitor.Clear();
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            ClosePort();
            tsbStart.Image = global::UartDataLogger.Properties.Resources.start;
            tsbStart.ToolTipText = "Start Data Logger";
        }

        private void MtbTime_TextChanged(object sender, EventArgs e)
        {
            timer.Interval = (Convert.ToInt32(mtbTime.Text) * 60 * 1000);
        }

        private void TsbStop_Click(object sender, EventArgs e)
        {
            DialogResult r = saveFileDialog.ShowDialog();
            if (r == DialogResult.OK)
            {
                File.WriteAllText(saveFileDialog.FileName, tbMonitor.Text);
            }
        }

        private void cbOutTimeType_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedIndex = cbOutTimeType.SelectedIndex;
        }

        private void MainScreen_Load(object sender, EventArgs e)
        {
            updateCbPort();
            appSettings.loadSettings(ref appSettings, appCfgFile);
            cbPort.SelectedItem = appSettings.Port;
            cbSpeed.SelectedItem = appSettings.BaudRate;
            mtbTime.Text = appSettings.Timer;
            cbEnableNewLine.Checked = appSettings.NewLine;
            cbOutTimeType.SelectedItem = appSettings.OutputTimeType;
        }

        private void MainScreen_FormClosing(object sender, FormClosingEventArgs e)
        {
            appSettings.Port = cbPort.SelectedItem.ToString();
            appSettings.BaudRate = cbSpeed.SelectedItem.ToString();
            appSettings.Timer = mtbTime.Text;
            appSettings.NewLine = cbEnableNewLine.Checked;
            appSettings.OutputTimeType = cbOutTimeType.SelectedItem.ToString();
            appSettings.saveSettings(appCfgFile);
            if (serialPort.IsOpen)
            {
                closeSerialPortFlag = true;
                closeApp = true;
                e.Cancel = true;
            }
        }
    }
}
