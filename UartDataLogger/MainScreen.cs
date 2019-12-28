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

namespace UartDataLogger
{

    public partial class MainScreen : Form
    {
        private readonly Stopwatch stopWatch = new Stopwatch();
        delegate void delegateAppendText(String text);
        private readonly delegateAppendText monitorAppendText;

        public MainScreen()
        {
            InitializeComponent();
            monitorAppendText = new delegateAppendText(tbMonitor.AppendText);
        }

        private void CbPort_MouseEnter(object sender, EventArgs e)
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
            String text = Convert.ToString(stopWatch.ElapsedMilliseconds);
            text += "\t" + serialPort.ReadExisting();
            tbMonitor.Invoke(monitorAppendText, text);
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
            if (serialPort.IsOpen)
            {
                tsbStart.Image = global::UartDataLogger.Properties.Resources.stop;
                tsbStart.ToolTipText = "Parar Data Logger";
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
                serialPort.Close();
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
            DialogResult r = MessageBox.Show("Tem certeza que deseja limpar o datalogger?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
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
    }
}
