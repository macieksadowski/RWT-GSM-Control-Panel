using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;

namespace RWT_GSM_Control_Panel
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            if (serialPort1.IsOpen)
            {
                StatusLabel.Text = "Connected";
                ConnectButton.Text = "Disconnect";
                
            }
            else
            {
                StatusLabel.Text = "Disconnected";
                ConnectButton.Text = "Connect";
            }
            statusStrip1.Refresh();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                serialPort1.Close();
                MessageBox.Show(this, "Connection with port " + serialPort1.PortName + " closed.", "Info", MessageBoxButtons.OK);
            }
            else
            {
                try
                {
                    serialPort1.Open();
                    MessageBox.Show("Succesfully connected with port " + serialPort1.PortName + " !", "Info", MessageBoxButtons.OK);

                }
                catch(Exception exc)
                {
                    MessageBox.Show(this, "Connection error:\n" + exc.Message, "Info", MessageBoxButtons.OK);
                }
                
            }
            
        }

        private void portToolStripMenuItem_Click(object sender, EventArgs e)
        {
            portToolStripMenuItem.DropDownItems.Clear();
            foreach (String s in SerialPort.GetPortNames()) portToolStripMenuItem.DropDownItems.Add(s);
            statusStrip1.Refresh();

        }

        private void maToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void portToolStripMenuItem_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            PortLabel.Text = e.ClickedItem.Text;
            serialPort1.PortName = e.ClickedItem.Text;
            statusStrip1.Refresh();
        }

        private void speedToolStripMenuItem_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            SpeedLabel.Text = e.ClickedItem.Text;
            serialPort1.BaudRate = Convert.ToInt32(e.ClickedItem.Text);
        }
    }
}
