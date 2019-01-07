/*
 * Created by SharpDevelop.
 * User: mo
 * Date: 14.11.2018
 * Time: 12:15
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace motoHat
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.ComboBox comport;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Panel panelStatus1;
		private System.Windows.Forms.Label textStatus1;
		private System.Windows.Forms.Button buttonConnect;
		private System.Windows.Forms.Button buttonClose;
		private System.Windows.Forms.Button buttonOpen;
		private System.Windows.Forms.Panel panelStatus2;
		private System.Windows.Forms.Label textStatus2;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.comport = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.panelStatus1 = new System.Windows.Forms.Panel();
			this.textStatus1 = new System.Windows.Forms.Label();
			this.buttonConnect = new System.Windows.Forms.Button();
			this.buttonClose = new System.Windows.Forms.Button();
			this.buttonOpen = new System.Windows.Forms.Button();
			this.panelStatus2 = new System.Windows.Forms.Panel();
			this.textStatus2 = new System.Windows.Forms.Label();
			this.panelStatus1.SuspendLayout();
			this.panelStatus2.SuspendLayout();
			this.SuspendLayout();
			// 
			// comport
			// 
			this.comport.FormattingEnabled = true;
			this.comport.Location = new System.Drawing.Point(131, 15);
			this.comport.Name = "comport";
			this.comport.Size = new System.Drawing.Size(251, 24);
			this.comport.TabIndex = 0;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(25, 18);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(87, 23);
			this.label1.TabIndex = 1;
			this.label1.Text = "COM-порт";
			// 
			// panelStatus1
			// 
			this.panelStatus1.Controls.Add(this.textStatus1);
			this.panelStatus1.Location = new System.Drawing.Point(131, 56);
			this.panelStatus1.Name = "panelStatus1";
			this.panelStatus1.Size = new System.Drawing.Size(115, 38);
			this.panelStatus1.TabIndex = 2;
			// 
			// textStatus1
			// 
			this.textStatus1.Location = new System.Drawing.Point(10, 9);
			this.textStatus1.Name = "textStatus1";
			this.textStatus1.Size = new System.Drawing.Size(102, 23);
			this.textStatus1.TabIndex = 0;
			this.textStatus1.Text = "Непонятно";
			// 
			// buttonConnect
			// 
			this.buttonConnect.Location = new System.Drawing.Point(388, 9);
			this.buttonConnect.Name = "buttonConnect";
			this.buttonConnect.Size = new System.Drawing.Size(113, 34);
			this.buttonConnect.TabIndex = 3;
			this.buttonConnect.Text = "Подключить";
			this.buttonConnect.UseVisualStyleBackColor = true;
			this.buttonConnect.Click += new System.EventHandler(this.ButtonConnectClick);
			// 
			// buttonClose
			// 
			this.buttonClose.Location = new System.Drawing.Point(388, 56);
			this.buttonClose.Name = "buttonClose";
			this.buttonClose.Size = new System.Drawing.Size(113, 34);
			this.buttonClose.TabIndex = 5;
			this.buttonClose.Text = "Закрыть";
			this.buttonClose.UseVisualStyleBackColor = true;
			this.buttonClose.Click += new System.EventHandler(this.ButtonCloseClick);
			// 
			// buttonOpen
			// 
			this.buttonOpen.Location = new System.Drawing.Point(12, 56);
			this.buttonOpen.Name = "buttonOpen";
			this.buttonOpen.Size = new System.Drawing.Size(113, 34);
			this.buttonOpen.TabIndex = 6;
			this.buttonOpen.Text = "Открыть";
			this.buttonOpen.UseVisualStyleBackColor = true;
			this.buttonOpen.Click += new System.EventHandler(this.ButtonOpenClick);
			// 
			// panelStatus2
			// 
			this.panelStatus2.Controls.Add(this.textStatus2);
			this.panelStatus2.Location = new System.Drawing.Point(267, 56);
			this.panelStatus2.Name = "panelStatus2";
			this.panelStatus2.Size = new System.Drawing.Size(115, 38);
			this.panelStatus2.TabIndex = 7;
			// 
			// textStatus2
			// 
			this.textStatus2.Location = new System.Drawing.Point(10, 9);
			this.textStatus2.Name = "textStatus2";
			this.textStatus2.Size = new System.Drawing.Size(102, 23);
			this.textStatus2.TabIndex = 0;
			this.textStatus2.Text = "Непонятно";
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSize = true;
			this.ClientSize = new System.Drawing.Size(513, 106);
			this.Controls.Add(this.panelStatus2);
			this.Controls.Add(this.buttonOpen);
			this.Controls.Add(this.buttonClose);
			this.Controls.Add(this.buttonConnect);
			this.Controls.Add(this.panelStatus1);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.comport);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
			this.MaximizeBox = false;
			this.Name = "MainForm";
			this.Text = "motoHat";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainFormFormClosing);
			this.Load += new System.EventHandler(this.MainFormLoad);
			this.panelStatus1.ResumeLayout(false);
			this.panelStatus2.ResumeLayout(false);
			this.ResumeLayout(false);

		}
	}
}
