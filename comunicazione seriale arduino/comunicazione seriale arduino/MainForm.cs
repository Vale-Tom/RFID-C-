/*
 * Creato da SharpDevelop.
 * Utente: Utente
 * Data: 14/02/2023
 * Ora: 20:24
 * 
 * Per modificare questo modello usa Strumenti | Opzioni | Codice | Modifica Intestazioni Standard
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.IO.Ports;
using System.IO;
using System.Data;
using MySql.Data.MySqlClient;
using System.Text;

namespace comunicazione_seriale_arduino
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		string datiRicevuti;
		int valori;
		
		private HelperMySql helper = new HelperMySql();
		
		
		SerialPort[] openports = new SerialPort[20];
		public MainForm()
		{
			
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		void MainFormLoad(object sender, EventArgs e)
		{
			string[] porte = SerialPort.GetPortNames();
			cmbSERIALE.Items.AddRange(porte);
			cmbSERIALE.SelectedIndex=0;
		}
		void BtnOPENClick(object sender, EventArgs e)
		{
			
			try{
				serialPort1.PortName=cmbSERIALE.SelectedItem.ToString();
				serialPort1.Open();
			}catch(Exception ex){
				MessageBox.Show("errore");
			}
			btnCLOSE.Enabled=true;
			btnOPEN.Enabled=false;
		}
		void BtnCLOSEClick(object sender, EventArgs e)
		{
			try{
				if(serialPort1.IsOpen){
					serialPort1.Close();
				}
			}catch(Exception ex){
				MessageBox.Show("errore");
			}
			btnCLOSE.Enabled=false;
			btnOPEN.Enabled=true;
		}
		

		
		private void scriviDati(object sender, EventArgs e)
		{

			if(datiRicevuti.Length==11 && !listBox1.Items.Contains(datiRicevuti.ToString())){
				timer1.Enabled=true;
				panRead.BackColor=Color.Green;

				listBox1.Items.Add(datiRicevuti.ToString());
			}
			
			
			
			
		}//private void scriviDati
		
		void SerialPort1DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
		{
			
			timer1.Enabled=false;
			datiRicevuti= serialPort1.ReadLine();
			this.Invoke( new EventHandler(scriviDati));
			
			
		}
		
		void Timer1Tick(object sender, EventArgs e)
		{
			panRead.BackColor=Color.Red;
		}
		void ClrBtnClick(object sender, EventArgs e)
		{
			tabellaletture.Rows.Clear();
			listBox1.Items.Clear();
			
		}
		
	
		
				
		void BtnTestClick(object sender, EventArgs e)
		{
			try
				   {
				       // Apertura connessione
			       
				       if (!gestionesql.ApriConnessione())
				           throw new Exception("Errore nell'apertura della connessione.");
				
				       DataTable dt = new DataTable();
				
				       // Query da eseguire
				       StringBuilder sb = new StringBuilder();
				  //     sb.AppendLine(" SELECT ID, nome, cognome ");
				  //     sb.AppendLine(" FROM rfid_general ");
				  	   sb.Append(" SELECT * ");
				       sb.Append(" FROM personale ");
				       sb.Append(" WHERE ID='");
				       sb.Append(datiRicevuti.TrimEnd('\r'));
				       sb.Append("'");
				
				       label1.Text= sb.ToString();
				
				       using (MySqlCommand cmd = new MySqlCommand(sb.ToString(), gestionesql.Connessione))
				       {
				           using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
				           {
				               da.Fill(dt);
				               
				               tabellaletture.AutoGenerateColumns = true;
							   tabellaletture.DataSource = dt;
							   tabellaletture.Refresh();
				           }
				       }
				    
							       
					byte[] imageBytes = helper.GetPersonaleImage(datiRicevuti.TrimEnd('\r'));

                    

                    using (MemoryStream ms = new MemoryStream(imageBytes))

                    {

                        pictureBox1.Image = Image.FromStream(ms);

                        pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage; //fit to size

                        pictureBox1.Refresh();

                    }
				       
				
				       // Chiusura connessione
				       if (!gestionesql.ChiudiConnessione())
				           throw new Exception("Errore nella chiusura della connessione.");
				   }
				   catch (Exception ex)
				   {
				       gestionesql.ChiudiConnessione();
				       MessageBox.Show("Errore: " + ex.Message);
				   }
			
		}
		void BtnLoadClick(object sender, EventArgs e)
		{
			helper.TblImmagineInsert(datiRicevuti.TrimEnd('\r'),@"C:/uniCorno.jpg");
		}  
	}
	
}

