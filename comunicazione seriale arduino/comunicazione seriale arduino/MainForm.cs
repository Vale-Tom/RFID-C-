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
			String[] arraydati = new string[3];
			arraydati[0]=datiRicevuti.ToString();
			arraydati[1]=datiRicevuti.ToString();
			arraydati[2]=datiRicevuti.ToString();
			if(datiRicevuti.Length==11 && !listBox1.Items.Contains(datiRicevuti.ToString())){
				timer1.Enabled=true;
				panRead.BackColor=Color.Green;
				tabellaletture.Rows.Add(arraydati); //object[] values
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
				  	   sb.AppendLine(" SELECT * ");
				       sb.AppendLine(" FROM personale ");
				       sb.AppendLine(" WHERE ID='");
				       sb.Append(datiRicevuti);
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
			
			
			
		}

		
		
	}
	


