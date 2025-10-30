using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace AccesoDatos
{
    public class Base
    {
        MySqlConnection conn;

        //CONSTRUCTOR DE CONEXION
        public Base(string servidor, string usuario, string password, string baseDatos, int port=3310)
        {
            conn = new MySqlConnection($"server={servidor}; user={usuario}; password={password}; database={baseDatos}; port={port};");
        }


        //REALIZAR UNA QUERY O COMANDO
        public void Comando(string comando) 
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand(comando, conn);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"ERROR: Error al mandar comando.",MessageBoxButtons.OK, MessageBoxIcon.Error);
                conn.Close();
            }
        }


        //REALIZAR UNA CONSULTA Y DEVOLVER DATOS
        public DataSet Consulta(string consulta, string tabla) 
        {
            DataSet ds = new DataSet();
            try
            {
                MySqlDataAdapter da = new MySqlDataAdapter(consulta, conn);
                conn.Open();
                da.Fill(ds, tabla);
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"ERROR: Error al realizar la consulta.",MessageBoxButtons.OK,MessageBoxIcon.Error);
                conn.Close();
            }
            return ds;
        }
    }
}
