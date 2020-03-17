namespace UartDataLogger
{
    partial class MainScreen
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainScreen));
            this.serialPort = new System.IO.Ports.SerialPort(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.cbPort = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbSpeed = new System.Windows.Forms.ComboBox();
            this.tbMonitor = new System.Windows.Forms.TextBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbStart = new System.Windows.Forms.ToolStripButton();
            this.tsbStop = new System.Windows.Forms.ToolStripButton();
            this.tsbtDelete = new System.Windows.Forms.ToolStripButton();
            this.label3 = new System.Windows.Forms.Label();
            this.mtbTime = new System.Windows.Forms.MaskedTextBox();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.cbEnableNewLine = new System.Windows.Forms.CheckBox();
            this.cbOutTimeType = new System.Windows.Forms.ComboBox();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // serialPort
            // 
            this.serialPort.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.SerialPort_DataReceived);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Port:";
            // 
            // cbPort
            // 
            this.cbPort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPort.FormattingEnabled = true;
            this.cbPort.Items.AddRange(new object[] {
            "4800",
            "9600",
            "14400",
            "19200",
            "38400",
            "57600",
            "115200",
            "128000",
            "256000"});
            this.cbPort.Location = new System.Drawing.Point(51, 34);
            this.cbPort.Name = "cbPort";
            this.cbPort.Size = new System.Drawing.Size(64, 21);
            this.cbPort.TabIndex = 1;
            this.cbPort.SelectedIndexChanged += new System.EventHandler(this.CbPort_SelectedIndexChanged);
            this.cbPort.MouseEnter += new System.EventHandler(this.CbPort_MouseEnter);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(124, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Baud Rate:";
            // 
            // cbSpeed
            // 
            this.cbSpeed.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSpeed.FormattingEnabled = true;
            this.cbSpeed.Items.AddRange(new object[] {
            "4800",
            "9600",
            "14400",
            "19200",
            "38400",
            "57600",
            "115200",
            "128000",
            "256000"});
            this.cbSpeed.Location = new System.Drawing.Point(190, 35);
            this.cbSpeed.Name = "cbSpeed";
            this.cbSpeed.Size = new System.Drawing.Size(63, 21);
            this.cbSpeed.TabIndex = 3;
            this.cbSpeed.SelectedIndexChanged += new System.EventHandler(this.CbSpeed_SelectedIndexChanged);
            // 
            // tbMonitor
            // 
            this.tbMonitor.Location = new System.Drawing.Point(12, 67);
            this.tbMonitor.Multiline = true;
            this.tbMonitor.Name = "tbMonitor";
            this.tbMonitor.Size = new System.Drawing.Size(367, 171);
            this.tbMonitor.TabIndex = 4;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbStart,
            this.tsbStop,
            this.tsbtDelete});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(392, 25);
            this.toolStrip1.TabIndex = 5;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbStart
            // 
            this.tsbStart.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbStart.Image = global::UartDataLogger.Properties.Resources.start;
            this.tsbStart.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbStart.Name = "tsbStart";
            this.tsbStart.Size = new System.Drawing.Size(23, 22);
            this.tsbStart.Text = "Start Datalogger";
            this.tsbStart.Click += new System.EventHandler(this.TsbStart_Click);
            // 
            // tsbStop
            // 
            this.tsbStop.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbStop.Image = global::UartDataLogger.Properties.Resources.salvar;
            this.tsbStop.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbStop.Name = "tsbStop";
            this.tsbStop.Size = new System.Drawing.Size(23, 22);
            this.tsbStop.Text = "Salvar Datalogger";
            this.tsbStop.ToolTipText = "Save Datalogger";
            this.tsbStop.Click += new System.EventHandler(this.TsbStop_Click);
            // 
            // tsbtDelete
            // 
            this.tsbtDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtDelete.Image = global::UartDataLogger.Properties.Resources.delete;
            this.tsbtDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtDelete.Name = "tsbtDelete";
            this.tsbtDelete.Size = new System.Drawing.Size(23, 22);
            this.tsbtDelete.Text = "toolStripButton1";
            this.tsbtDelete.ToolTipText = "Clear Screen";
            this.tsbtDelete.Click += new System.EventHandler(this.TsbtDelete_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(260, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Timer (min):";
            // 
            // mtbTime
            // 
            this.mtbTime.Location = new System.Drawing.Point(332, 36);
            this.mtbTime.Mask = "00000";
            this.mtbTime.Name = "mtbTime";
            this.mtbTime.Size = new System.Drawing.Size(46, 20);
            this.mtbTime.TabIndex = 7;
            this.mtbTime.Text = "10";
            this.mtbTime.ValidatingType = typeof(int);
            this.mtbTime.TextChanged += new System.EventHandler(this.MtbTime_TextChanged);
            // 
            // timer
            // 
            this.timer.Interval = 600000;
            this.timer.Tick += new System.EventHandler(this.Timer_Tick);
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.DefaultExt = "xls";
            this.saveFileDialog.FileName = "DataLoggerFile";
            this.saveFileDialog.Filter = "Planilha|*.xls";
            // 
            // cbEnableNewLine
            // 
            this.cbEnableNewLine.AutoSize = true;
            this.cbEnableNewLine.Location = new System.Drawing.Point(180, 247);
            this.cbEnableNewLine.Name = "cbEnableNewLine";
            this.cbEnableNewLine.Size = new System.Drawing.Size(71, 17);
            this.cbEnableNewLine.TabIndex = 8;
            this.cbEnableNewLine.Text = "New Line";
            this.cbEnableNewLine.UseVisualStyleBackColor = true;
            // 
            // cbOutTimeType
            // 
            this.cbOutTimeType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbOutTimeType.FormattingEnabled = true;
            this.cbOutTimeType.Items.AddRange(new object[] {
            "Millis",
            "Timestamp",
            "Time",
            "Time and Date"});
            this.cbOutTimeType.Location = new System.Drawing.Point(257, 245);
            this.cbOutTimeType.Name = "cbOutTimeType";
            this.cbOutTimeType.Size = new System.Drawing.Size(121, 21);
            this.cbOutTimeType.TabIndex = 9;
            this.cbOutTimeType.SelectedIndexChanged += new System.EventHandler(this.cbOutTimeType_SelectedIndexChanged);
            // 
            // MainScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(392, 273);
            this.Controls.Add(this.cbOutTimeType);
            this.Controls.Add(this.cbEnableNewLine);
            this.Controls.Add(this.mtbTime);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.tbMonitor);
            this.Controls.Add(this.cbSpeed);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbPort);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainScreen";
            this.Text = "Uart Data Logger";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainScreen_FormClosing);
            this.Load += new System.EventHandler(this.MainScreen_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.IO.Ports.SerialPort serialPort;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbPort;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbSpeed;
        private System.Windows.Forms.TextBox tbMonitor;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbStart;
        private System.Windows.Forms.ToolStripButton tsbStop;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.MaskedTextBox mtbTime;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.ToolStripButton tsbtDelete;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.CheckBox cbEnableNewLine;
        private System.Windows.Forms.ComboBox cbOutTimeType;
    }
}