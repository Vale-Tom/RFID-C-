/*
 * Created by SharpDevelop.
 * User: Tele01
 * Date: 05/04/2023
 * Time: 12:45
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Data;
using MySql.Data.MySqlClient;

namespace comunicazione_seriale_arduino
{
	/// <summary>
	/// Description of gestionesql.
	/// </summary>
	public static class gestionesql
	{
		public static string StringaConnessione =
           "Data Source=localhost;Database=rfid;userid=root;password=;";
       public static MySqlConnection Connessione = new MySqlConnection(StringaConnessione);

       public static bool ApriConnessione()
       {
           try
           {
               if (Connessione.State != ConnectionState.Open)
               {
                   Connessione.ConnectionString = gestionesql.StringaConnessione;
                   Connessione.Open();
               }
               return true;
           }
           catch (Exception ex)
           {
               return false;
           }
       }

       public static bool ChiudiConnessione()
       {
           try
           {
               if (Connessione.State != System.Data.ConnectionState.Closed)
               {
                   Connessione.Close();
               }
               return true;
           }
           catch
           {
               return false;
           }
       }

       // Le transazioni solo con database di tipo INNODB
       private static MySqlTransaction Transazione = null;

       public static void TransazioneBegin()
       {
           Transazione = Connessione.BeginTransaction();
       }

       public static void TransazioneCommit()
       {
           Transazione.Commit();
       }

       public static void TransazioneRollback()
       {
           Transazione.Rollback();
       }
	}
}
