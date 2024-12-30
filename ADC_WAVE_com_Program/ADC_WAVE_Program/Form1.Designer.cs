
namespace CH341_com_Program
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea5 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend5 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            this.btn_uart_connect = new System.Windows.Forms.Button();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.lbl_uart_status = new System.Windows.Forms.Label();
            this.cb_uart_portname = new System.Windows.Forms.ComboBox();
            this.cb_uart_baudrate = new System.Windows.Forms.ComboBox();
            this.lbl_uart_comport = new System.Windows.Forms.Label();
            this.lbl_uart_baudrate = new System.Windows.Forms.Label();
            this.tb_uart_receive = new System.Windows.Forms.TextBox();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_uart_connect
            // 
            this.btn_uart_connect.Location = new System.Drawing.Point(242, 53);
            this.btn_uart_connect.Name = "btn_uart_connect";
            this.btn_uart_connect.Size = new System.Drawing.Size(98, 25);
            this.btn_uart_connect.TabIndex = 0;
            this.btn_uart_connect.Text = "connect";
            this.btn_uart_connect.UseVisualStyleBackColor = true;
            this.btn_uart_connect.Click += new System.EventHandler(this.uart_connect_btn_Click);
            // 
            // lbl_uart_status
            // 
            this.lbl_uart_status.AutoSize = true;
            this.lbl_uart_status.Location = new System.Drawing.Point(240, 30);
            this.lbl_uart_status.Name = "lbl_uart_status";
            this.lbl_uart_status.Size = new System.Drawing.Size(38, 12);
            this.lbl_uart_status.TabIndex = 1;
            this.lbl_uart_status.Text = "label1";
            // 
            // cb_uart_portname
            // 
            this.cb_uart_portname.FormattingEnabled = true;
            this.cb_uart_portname.Location = new System.Drawing.Point(101, 27);
            this.cb_uart_portname.Name = "cb_uart_portname";
            this.cb_uart_portname.Size = new System.Drawing.Size(91, 20);
            this.cb_uart_portname.TabIndex = 2;
            this.cb_uart_portname.Click += new System.EventHandler(this.cb_uart_portname_Click);
            // 
            // cb_uart_baudrate
            // 
            this.cb_uart_baudrate.FormattingEnabled = true;
            this.cb_uart_baudrate.Items.AddRange(new object[] {
            "100",
            "300",
            "600",
            "1200",
            "2400",
            "4800",
            "9600",
            "14400",
            "19200",
            "38400",
            "57600",
            "115200",
            "230400",
            "460800",
            "921600"});
            this.cb_uart_baudrate.Location = new System.Drawing.Point(101, 58);
            this.cb_uart_baudrate.Name = "cb_uart_baudrate";
            this.cb_uart_baudrate.Size = new System.Drawing.Size(91, 20);
            this.cb_uart_baudrate.TabIndex = 3;
            this.cb_uart_baudrate.Text = "115200";
            // 
            // lbl_uart_comport
            // 
            this.lbl_uart_comport.AutoSize = true;
            this.lbl_uart_comport.Location = new System.Drawing.Point(30, 30);
            this.lbl_uart_comport.Name = "lbl_uart_comport";
            this.lbl_uart_comport.Size = new System.Drawing.Size(51, 12);
            this.lbl_uart_comport.TabIndex = 4;
            this.lbl_uart_comport.Text = "comport";
            // 
            // lbl_uart_baudrate
            // 
            this.lbl_uart_baudrate.AutoSize = true;
            this.lbl_uart_baudrate.Location = new System.Drawing.Point(31, 61);
            this.lbl_uart_baudrate.Name = "lbl_uart_baudrate";
            this.lbl_uart_baudrate.Size = new System.Drawing.Size(54, 12);
            this.lbl_uart_baudrate.TabIndex = 5;
            this.lbl_uart_baudrate.Text = "baudrate";
            // 
            // tb_uart_receive
            // 
            this.tb_uart_receive.Location = new System.Drawing.Point(32, 84);
            this.tb_uart_receive.Multiline = true;
            this.tb_uart_receive.Name = "tb_uart_receive";
            this.tb_uart_receive.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tb_uart_receive.Size = new System.Drawing.Size(473, 49);
            this.tb_uart_receive.TabIndex = 7;
            // 
            // chart1
            // 
            chartArea5.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea5);
            legend5.Name = "Legend1";
            this.chart1.Legends.Add(legend5);
            this.chart1.Location = new System.Drawing.Point(33, 150);
            this.chart1.Name = "chart1";
            this.chart1.Size = new System.Drawing.Size(632, 307);
            this.chart1.TabIndex = 9;
            this.chart1.Text = "chart1";
            this.chart1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.chart1_MouseMove);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 10;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(686, 469);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.tb_uart_receive);
            this.Controls.Add(this.lbl_uart_baudrate);
            this.Controls.Add(this.lbl_uart_comport);
            this.Controls.Add(this.cb_uart_baudrate);
            this.Controls.Add(this.cb_uart_portname);
            this.Controls.Add(this.lbl_uart_status);
            this.Controls.Add(this.btn_uart_connect);
            this.Name = "Form1";
            this.Text = "ADC_WAVE_Program";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_uart_connect;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Label lbl_uart_status;
        private System.Windows.Forms.ComboBox cb_uart_portname;
        private System.Windows.Forms.ComboBox cb_uart_baudrate;
        private System.Windows.Forms.Label lbl_uart_comport;
        private System.Windows.Forms.Label lbl_uart_baudrate;
        private System.Windows.Forms.TextBox tb_uart_receive;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Timer timer1;
    }
}

