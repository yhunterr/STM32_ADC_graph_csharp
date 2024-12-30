using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using System.Threading;

namespace CH341_com_Program
{
    public class Uart
    {
        private SerialPort _serialPort;
        private DataReceiveMode _mode;

        public event Action<string> DataReceived;
        public enum DataReceiveMode
        {
            EventBased,
            Manual
        }
        public Uart(SerialPort serialPort, DataReceiveMode mode)
        {
            _serialPort = serialPort;
            _mode = mode;
        }
        public void uartWrite(string data)
        {
            if(_serialPort.IsOpen)
            {
                _serialPort.Write(data);
            }
        }
        public string uartReceive()
        {
            if(_serialPort.IsOpen)
            {
                return _serialPort.ReadExisting();
            }
            return string.Empty;
        }
        public bool uartConnect(int baudRate, string portName)
        {
            try
            {
                _serialPort.BaudRate = baudRate;
                _serialPort.PortName = portName;
                if (_mode == DataReceiveMode.EventBased)
                {
                    _serialPort.DataReceived += SerialPort_DataReceived;
                }
                _serialPort.Open();
                uartBufClear();
            }
            catch
            {
                return false;
            }
            return true;
        }
        private void SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            Thread.Sleep(2);
            if (_serialPort.IsOpen)
            {
                string data = _serialPort.ReadExisting();
                DataReceived?.Invoke(data);
                Console.WriteLine("uart_data_received : " + data);
            }
        }
        public bool uartDisconnect()
        {
            try
            {
                _serialPort.DataReceived -= SerialPort_DataReceived;
                _serialPort.Close();
                uartBufClear();
            }
            catch
            {
                return false;
            }
            return true;
        }
        public bool uartConnectCheck()
        {
            return _serialPort.IsOpen;
        }
        public string[] uartGetPortname()
        {
            return SerialPort.GetPortNames();
        }
        public void uartBufClear()
        {
            Console.WriteLine("BUF CLEAR");
            _serialPort.DiscardInBuffer();
            _serialPort.DiscardOutBuffer();
        }

    }
}
