/*
 * Created by SharpDevelop.
 * User: mo
 * Date: 14.11.2018
 * Time: 12:15
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections;
using System.IO.Ports;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;


namespace motoHat
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		
		private SerialPort com;

		
		public MainForm()
		{
			InitializeComponent();
		}


		void MainFormLoad(object sender, EventArgs e)
		{
        	comport.DataSource = SerialPort.GetPortNames();
		}


		void ButtonConnectClick(object sender, EventArgs e)
		{
			com = new SerialPort(comport.SelectedItem.ToString());
        	
			if (!com.IsOpen) {
            	com.BaudRate = 9600;
            	com.Open();
            	com.DataReceived += com_DataReceived;
			}
			
			buttonConnect.Enabled = false;
		}


		private byte status1, status2;
		private Stack<byte> comBuf = new Stack<byte>();

		void com_DataReceived(object sender, SerialDataReceivedEventArgs e)
		{
			int i;

			int dataLength = com.BytesToRead;
    		byte[] data = new byte[dataLength];
    		
    		int nbrDataRead = com.Read(data, 0, dataLength);
    		if (nbrDataRead == 0) {
        		return;
    		}
    		
    		for (i = 0; i < nbrDataRead; i++) {
    			if (data[i] != 10) {
    				comBuf.Push(data[i]);
    			}
    			else {
    				if (comBuf.Count > 1) {
    					status2 = comBuf.Pop();
    					status1 = comBuf.Pop();
    					
    					comBuf.Clear();
    				}
    			}
    		}
    		

    		switch (status1) {
				case (byte)'E':
					textStatus1.BeginInvoke((MethodInvoker)(() => 
						textStatus1.Text = "Ошибка"
					));
					panelStatus1.BeginInvoke((MethodInvoker)(() => 
						panelStatus1.BackColor = Color.LightYellow
					));
    				break;
    				
				case (byte)'U':
					textStatus1.BeginInvoke((MethodInvoker)(() => 
						textStatus1.Text = "Непонятно"
					));
					panelStatus1.BeginInvoke((MethodInvoker)(() => 
						panelStatus1.BackColor = Color.LightYellow
					));
					break;
					
				case (byte)'C':
					textStatus1.BeginInvoke((MethodInvoker)(() => 
						textStatus1.Text = "Закрываю"
					));
					panelStatus1.BeginInvoke((MethodInvoker)(() => 
						panelStatus1.BackColor = Color.LightPink
					));
					break;

				case (byte)'c':
					textStatus1.BeginInvoke((MethodInvoker)(() => 
						textStatus1.Text = "Закрыто"
					));
					panelStatus1.BeginInvoke((MethodInvoker)(() => 
						panelStatus1.BackColor = Color.Pink
					));
					break;

				case (byte)'O':
					textStatus1.BeginInvoke((MethodInvoker)(() => 
						textStatus1.Text = "Открываю"
					));
					panelStatus1.BeginInvoke((MethodInvoker)(() => 
						panelStatus1.BackColor = Color.LightGreen
					));
					break;

				case (byte)'o':
					textStatus1.BeginInvoke((MethodInvoker)(() => 
						textStatus1.Text = "Открыто"
					));
					panelStatus1.BeginInvoke((MethodInvoker)(() => 
						panelStatus1.BackColor = Color.LightGreen
					));
					break;
			}

			// TODO один мотор не будет работать, только два :(    		
			switch (status2) {
				case (byte)'E':
					textStatus2.BeginInvoke((MethodInvoker)(() => 
						textStatus2.Text = "Ошибка"
					));
					panelStatus2.BeginInvoke((MethodInvoker)(() => 
						panelStatus2.BackColor = Color.LightYellow
					));
					break;

				case (byte)'U':
					textStatus2.BeginInvoke((MethodInvoker)(() => 
						textStatus2.Text = "Непонятно"
					));
					panelStatus2.BeginInvoke((MethodInvoker)(() => 
						panelStatus2.BackColor = Color.LightYellow
					));
					break;
					
				case (byte)'C':
					textStatus2.BeginInvoke((MethodInvoker)(() => 
						textStatus2.Text = "Закрываю"
					));
					panelStatus2.BeginInvoke((MethodInvoker)(() => 
						panelStatus2.BackColor = Color.LightPink
					));
					break;

				case (byte)'c':
					textStatus2.BeginInvoke((MethodInvoker)(() => 
						textStatus2.Text = "Закрыто"
					));
					panelStatus2.BeginInvoke((MethodInvoker)(() => 
						panelStatus2.BackColor = Color.Pink
					));
					break;

				case (byte)'O':
					textStatus2.BeginInvoke((MethodInvoker)(() => 
						textStatus2.Text = "Открываю"
					));
					panelStatus2.BeginInvoke((MethodInvoker)(() => 
						panelStatus2.BackColor = Color.LightGreen
					));
					break;

				case (byte)'o':
					textStatus2.BeginInvoke((MethodInvoker)(() => 
						textStatus2.Text = "Открыто"
					));
					panelStatus2.BeginInvoke((MethodInvoker)(() => 
						panelStatus2.BackColor = Color.LightGreen
					));
					break;
			}
		}
		
		
		void ButtonOpenClick(object sender, EventArgs e)
		{
			com.Write("O");
		}
		void ButtonCloseClick(object sender, EventArgs e)
		{
			com.Write("C");
		}
		void MainFormFormClosing(object sender, FormClosingEventArgs e)
		{
			if (com != null && com.IsOpen) {
				com.DataReceived -= com_DataReceived;
				com.Close();
			}
		}
		
	}
}
