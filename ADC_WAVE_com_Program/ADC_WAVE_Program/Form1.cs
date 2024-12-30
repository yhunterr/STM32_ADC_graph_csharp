using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace CH341_com_Program
{
    public partial class Form1 : Form
    {
        private Uart uart;
        private string vol_val;
        public Form1()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            uart = new Uart(serialPort1,Uart.DataReceiveMode.EventBased);
            uart.DataReceived += OnDataReceived;

            ui_cb_uart_portname();
            ConfigureChart();
        }


        void ui_cb_uart_portname()
        {
            string[] ports = uart.uartGetPortname();
            cb_uart_portname.Items.Clear();
            cb_uart_portname.Items.AddRange(ports);
        }

        private void OnDataReceived(string data)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => OnDataReceived(data)));
            }
            else
            {
                tb_uart_receive.Text += data;
                tb_uart_receive.SelectionStart = tb_uart_receive.Text.Length;
                tb_uart_receive.ScrollToCaret();
                if (data.Contains("mV"))
                {
                    vol_val = GetMiddleString(data, "VOL: ", " mV");
                }
                else
                {
                    vol_val = "pass";
                }
                
            }
        }
        private void uart_connect_btn_Click(object sender, EventArgs e)
        {
            if (uart.uartConnectCheck())
            {
                btn_uart_connect.Text = "connect";

                if (uart.uartDisconnect())
                {
                    lbl_uart_status.Text = "disconnect~";
                }
            }
            else
            {
                try
                {
                    if (uart.uartConnect(int.Parse(cb_uart_baudrate.Text), cb_uart_portname.Text))
                    {
                        lbl_uart_status.Text = "connect!";
                        btn_uart_connect.Text = "disconnect";
                    }
                    else
                    {
                        lbl_uart_status.Text = "connect try fail!";
                        btn_uart_connect.Text = "connect";
                    }
                }
                catch
                {
                    lbl_uart_status.Text = "error!";
                }
            }  
        }



        private void cb_uart_portname_Click(object sender, EventArgs e)
        {
            ui_cb_uart_portname();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(timer1.Enabled)
            {
                timer1.Stop();
            }
            else
            {
                timer1.Start();
            }
        }

        private void ConfigureChart()
        {
            // Chart init
            chart1.Series.Clear();
            chart1.ChartAreas.Clear();
            chart1.ChartAreas.Add(new ChartArea("MainArea"));

            var series = new Series("mV")
            {
                ChartType = SeriesChartType.Line,
                XValueType = ChartValueType.DateTime
            };
            chart1.Series.Add(series);

            // X settings
            var axisX = chart1.ChartAreas["MainArea"].AxisX;
            axisX.LabelStyle.Format = "HH:mm:ss"; // time format
            axisX.Interval = 1; // 1seconds
            axisX.IntervalType = DateTimeIntervalType.Seconds;
            //axisX.ScrollBar.Enabled = true;
            //axisX.ScaleView.Zoomable = true;
            axisX.ScaleView.Position = 0;

            chart1.BackColor = Color.Black;
            chart1.ChartAreas[0].BackColor = Color.Black;
            chart1.ChartAreas[0].AxisX.LabelStyle.ForeColor = Color.White;
            chart1.ChartAreas[0].AxisY.LabelStyle.ForeColor = Color.White;
            chart1.ChartAreas[0].AxisX.LineColor = Color.White;
            chart1.ChartAreas[0].AxisY.LineColor = Color.White;
            chart1.Series["mV"].Color = Color.Lime;
            chart1.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.Gray;
            chart1.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.Gray;
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            
            if (vol_val != "pass")
            {
                var series = chart1.Series["mV"];
                series.Points.AddXY(DateTime.Now, vol_val); 
                var axisX = chart1.ChartAreas["MainArea"].AxisX;
                axisX.Minimum = DateTime.Now.AddSeconds(-10).ToOADate();
                axisX.Maximum = DateTime.Now.ToOADate();
                //chart1.Invalidate();
            }

            vol_val = "pass";
            
        }

        public string GetMiddleString(string str, string begin, string end)
        {
            if (string.IsNullOrEmpty(str))
            {
                return null;
            }

            string result = null;
            if (str.IndexOf(begin) > -1)
            {
                str = str.Substring(str.IndexOf(begin) + begin.Length);
                if (str.IndexOf(end) > -1) result = str.Substring(0, str.IndexOf(end));
                else result = str;
            }
            return result;
        }

        ToolTip chartToolTip = new ToolTip();
        private void chart1_MouseMove(object sender, MouseEventArgs e)
        {
            var result = chart1.HitTest(e.X, e.Y);

            if (result.ChartElementType == ChartElementType.DataPoint)
            {
                var point = result.Series.Points[result.PointIndex];
                double xValue = point.XValue;
                double yValue = point.YValues[0];

                chartToolTip.Show($"X: {DateTime.FromOADate(xValue):HH:mm:ss}, Y: {yValue}", chart1, e.Location.X, e.Location.Y - 15);
            }
            else
            {
                chartToolTip.Hide(chart1);
            }
        }
    }
}
