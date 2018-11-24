/*
 * Created by SharpDevelop.
 * User: mo
 * Date: 14.11.2018
 * Time: 12:15
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.IO.Ports;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;


namespace motoHat
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		
		private SerialPort com;
		private Thread thread;

		
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
			}
			
			thread = new Thread(new ThreadStart(this.statusListener));
			thread.Start();
			
			buttonConnect.Enabled = false;
		}
		
		private void statusListener()
		{
			while (true) {
				switch ((byte) com.ReadByte()) {
					case (byte)'U':
						textStatus.BeginInvoke((MethodInvoker)(() => 
							textStatus.Text = "Непонятно"
						));
						panelStatus.BeginInvoke((MethodInvoker)(() => 
							panelStatus.BackColor = Color.LightYellow
						));
						break;
						
					case (byte)'C':
						textStatus.BeginInvoke((MethodInvoker)(() => 
							textStatus.Text = "Закрываю"
						));
						panelStatus.BeginInvoke((MethodInvoker)(() => 
							panelStatus.BackColor = Color.LightPink
						));
						break;
	
					case (byte)'c':
						textStatus.BeginInvoke((MethodInvoker)(() => 
							textStatus.Text = "Закрыто"
						));
						panelStatus.BeginInvoke((MethodInvoker)(() => 
							panelStatus.BackColor = Color.Pink
						));
						break;
	
					case (byte)'O':
						textStatus.BeginInvoke((MethodInvoker)(() => 
							textStatus.Text = "Открываю"
						));
						panelStatus.BeginInvoke((MethodInvoker)(() => 
							panelStatus.BackColor = Color.LightGreen
						));
						break;
	
					case (byte)'o':
						textStatus.BeginInvoke((MethodInvoker)(() => 
							textStatus.Text = "Открыто"
						));
						panelStatus.BeginInvoke((MethodInvoker)(() => 
							panelStatus.BackColor = Color.LightGreen
						));
						break;
				}
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
			if (thread != null && thread.IsAlive) {
				thread.Abort();
			}
			if (com != null && com.IsOpen) {
				com.Close();
			}
		}
		
	}
}
