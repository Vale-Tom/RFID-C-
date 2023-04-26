/*
 * Creato da SharpDevelop.
 * Utente: Utente
 * Data: 14/02/2023
 * Ora: 20:24
 * 
 * Per modificare questo modello usa Strumenti | Opzioni | Codice | Modifica Intestazioni Standard
 */
namespace comunicazione_seriale_arduino
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.ComboBox cmbSERIALE;
		private System.Windows.Forms.Button btnOPEN;
		private System.Windows.Forms.Button btnCLOSE;
		private System.IO.Ports.SerialPort serialPort1;
		public System.Windows.Forms.Timer timer1;
		private System.Windows.Forms.Panel panRead;
		private System.Windows.Forms.Button clrBtn;
		private System.Windows.Forms.DataGridView tabellaletture;
		private System.Windows.Forms.ListBox listBox1;
		private System.Windows.Forms.Button btnTest;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btnLoad;
		private System.Windows.Forms.PictureBox pictureBox1;
		
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
			this.components = new System.ComponentModel.Container();
			this.cmbSERIALE = new System.Windows.Forms.ComboBox();
			this.btnOPEN = new System.Windows.Forms.Button();
			this.btnCLOSE = new System.Windows.Forms.Button();
			this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.panRead = new System.Windows.Forms.Panel();
			this.clrBtn = new System.Windows.Forms.Button();
			this.tabellaletture = new System.Windows.Forms.DataGridView();
			this.listBox1 = new System.Windows.Forms.ListBox();
			this.btnTest = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.btnLoad = new System.Windows.Forms.Button();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			((System.ComponentModel.ISupportInitialize)(this.tabellaletture)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// cmbSERIALE
			// 
			this.cmbSERIALE.FormattingEnabled = true;
			this.cmbSERIALE.Location = new System.Drawing.Point(23, 23);
			this.cmbSERIALE.Margin = new System.Windows.Forms.Padding(2);
			this.cmbSERIALE.Name = "cmbSERIALE";
			this.cmbSERIALE.Size = new System.Drawing.Size(135, 21);
			this.cmbSERIALE.TabIndex = 0;
			// 
			// btnOPEN
			// 
			this.btnOPEN.Location = new System.Drawing.Point(167, 23);
			this.btnOPEN.Margin = new System.Windows.Forms.Padding(2);
			this.btnOPEN.Name = "btnOPEN";
			this.btnOPEN.Size = new System.Drawing.Size(53, 19);
			this.btnOPEN.TabIndex = 1;
			this.btnOPEN.Text = "APRI";
			this.btnOPEN.UseVisualStyleBackColor = true;
			this.btnOPEN.Click += new System.EventHandler(this.BtnOPENClick);
			// 
			// btnCLOSE
			// 
			this.btnCLOSE.Location = new System.Drawing.Point(228, 23);
			this.btnCLOSE.Margin = new System.Windows.Forms.Padding(2);
			this.btnCLOSE.Name = "btnCLOSE";
			this.btnCLOSE.Size = new System.Drawing.Size(53, 19);
			this.btnCLOSE.TabIndex = 2;
			this.btnCLOSE.Text = "CHIUDI";
			this.btnCLOSE.UseVisualStyleBackColor = true;
			this.btnCLOSE.Click += new System.EventHandler(this.BtnCLOSEClick);
			// 
			// serialPort1
			// 
			this.serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.SerialPort1DataReceived);
			// 
			// timer1
			// 
			this.timer1.Enabled = true;
			this.timer1.Interval = 200;
			this.timer1.Tick += new System.EventHandler(this.Timer1Tick);
			// 
			// panRead
			// 
			this.panRead.BackColor = System.Drawing.Color.Red;
			this.panRead.Location = new System.Drawing.Point(25, 301);
			this.panRead.Name = "panRead";
			this.panRead.Size = new System.Drawing.Size(27, 24);
			this.panRead.TabIndex = 6;
			// 
			// clrBtn
			// 
			this.clrBtn.Location = new System.Drawing.Point(436, 301);
			this.clrBtn.Name = "clrBtn";
			this.clrBtn.Size = new System.Drawing.Size(82, 20);
			this.clrBtn.TabIndex = 8;
			this.clrBtn.Text = "PULISCI";
			this.clrBtn.UseVisualStyleBackColor = true;
			this.clrBtn.Click += new System.EventHandler(this.ClrBtnClick);
			// 
			// tabellaletture
			// 
			this.tabellaletture.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.tabellaletture.Location = new System.Drawing.Point(23, 56);
			this.tabellaletture.Name = "tabellaletture";
			this.tabellaletture.Size = new System.Drawing.Size(496, 226);
			this.tabellaletture.TabIndex = 11;
			// 
			// listBox1
			// 
			this.listBox1.FormattingEnabled = true;
			this.listBox1.Location = new System.Drawing.Point(31, 63);
			this.listBox1.Name = "listBox1";
			this.listBox1.Size = new System.Drawing.Size(487, 147);
			this.listBox1.TabIndex = 12;
			// 
			// btnTest
			// 
			this.btnTest.Location = new System.Drawing.Point(346, 301);
			this.btnTest.Name = "btnTest";
			this.btnTest.Size = new System.Drawing.Size(75, 20);
			this.btnTest.TabIndex = 13;
			this.btnTest.Text = "TEST";
			this.btnTest.UseVisualStyleBackColor = true;
			this.btnTest.Click += new System.EventHandler(this.BtnTestClick);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(120, 302);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(220, 94);
			this.label1.TabIndex = 14;
			this.label1.Text = "label1";
			// 
			// btnLoad
			// 
			this.btnLoad.Location = new System.Drawing.Point(550, 305);
			this.btnLoad.Name = "btnLoad";
			this.btnLoad.Size = new System.Drawing.Size(172, 20);
			this.btnLoad.TabIndex = 15;
			this.btnLoad.Text = "Carica Immagine";
			this.btnLoad.UseVisualStyleBackColor = true;
			this.btnLoad.Click += new System.EventHandler(this.BtnLoadClick);
			// 
			// pictureBox1
			// 
			this.pictureBox1.Location = new System.Drawing.Point(550, 56);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(172, 226);
			this.pictureBox1.TabIndex = 16;
			this.pictureBox1.TabStop = false;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(739, 350);
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.btnLoad);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.btnTest);
			this.Controls.Add(this.tabellaletture);
			this.Controls.Add(this.listBox1);
			this.Controls.Add(this.clrBtn);
			this.Controls.Add(this.panRead);
			this.Controls.Add(this.btnCLOSE);
			this.Controls.Add(this.btnOPEN);
			this.Controls.Add(this.cmbSERIALE);
			this.Margin = new System.Windows.Forms.Padding(2);
			this.Name = "MainForm";
			this.Text = "comunicazione seriale arduino";
			this.Load += new System.EventHandler(this.MainFormLoad);
			((System.ComponentModel.ISupportInitialize)(this.tabellaletture)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.ResumeLayout(false);

		}
	}
}
