/*
 * Created by SharpDevelop.
 * User: Tele01
 * Date: 19/04/2023
 * Time: 11:24
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Data;
using MySql.Data.MySqlClient;
using System.Text;
using System.Configuration;
using System.IO;

namespace comunicazione_seriale_arduino
{
	/// <summary>
	/// Description of HelperMySql.
	/// </summary>
public class HelperMySql
{
    
    private string _connectionStr = "Server=localhost;Port=3306;Database=rfid;user=root;Pwd= ;";

    public void ExecuteNonQuery(string sqlText)
    {
        using (MySqlConnection con = new MySqlConnection(_connectionStr))
        {
            //open
            con.Open();

            using (MySqlCommand cmd = new MySqlCommand(sqlText, con))
            {
                //execute
                cmd.ExecuteNonQuery();
            }
        }
    }

    public byte[] GetImageAsByteArray(string filename)
    {
        //reads image from file and returns as byte[]

        if (String.IsNullOrEmpty(filename))
            throw new Exception("Error (GetImageAsByteArray) - Filename not specified.");
        else if(!File.Exists(filename))
            throw new Exception("Error (GetImageAsByteArray) - File '{filename}' doesn't exist.");
        
        return System.IO.File.ReadAllBytes(filename);
    }


    public void TblImmagineInsert(string id, string filename)
    {
        if (String.IsNullOrEmpty(filename))
            throw new Exception("Error (TblImmagineInsert) - Filename not specified.");
        else if (!File.Exists(filename))
            throw new Exception("Error (TblImmagineInsert) - File '{filename}' doesn't exist.");

        byte[] imageBytes = File.ReadAllBytes(filename);

        TblImmagineInsert(id, imageBytes);
    }

    public void TblImmagineInsert(string id, byte[] imageBytes)
    {
        string sqlText = "INSERT INTO immagini (id, immagine) VALUES (@id, @imageBytes);";

        using (MySqlConnection con = new MySqlConnection(_connectionStr))
        {
            //open
            con.Open();

            using (MySqlCommand cmd = new MySqlCommand(sqlText, con))
            {
                //add parameters

                //id
                if (!String.IsNullOrEmpty(id))
                    cmd.Parameters.Add("@id", MySqlDbType.VarChar).Value = id;
                else
                    cmd.Parameters.Add("@id", MySqlDbType.VarChar).Value = DBNull.Value;
                
                //Immagine
                if (imageBytes != null)
                    cmd.Parameters.Add("@imageBytes", MySqlDbType.LongBlob).Value = imageBytes;
                else
                    cmd.Parameters.Add("@imageBytes", MySqlDbType.LongBlob).Value = DBNull.Value;

                //execute
                cmd.ExecuteNonQuery();
            }
        }
    }

    public byte[] GetPersonaleImage(string id)
    {
        string sqlText = "SELECT immagine FROM immagini WHERE id = @id;";

        using (MySqlConnection con = new MySqlConnection(_connectionStr))
        {
            //open
            con.Open();

            using (MySqlCommand cmd = new MySqlCommand(sqlText, con))
            {
                cmd.Parameters.Add("@id", MySqlDbType.VarChar).Value = id;
                
                //execute
                using (MySqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.HasRows)
                    {
                        while(dr.Read())
                        {
                            //get image from database and return as byte[]
                            if (dr["immagine"] != null && dr["immagine"] != DBNull.Value)
                                return (byte[])dr["immagine"];
                        }
                    }
                }
            }
        }

        return null;
    }
}
}
