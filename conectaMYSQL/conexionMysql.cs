using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;

namespace conectaMYSQL
{
    public class conexionMysql
    {

        
        public String rutaconexion { set; get; }

        public conexionMysql() { }

        public conexionMysql(String c)
        {
            rutaconexion = c;        
        }


        public MySqlConnection conexion(ref String m) 
        {
            MySqlConnection carretera = new MySqlConnection();
            carretera.ConnectionString = rutaconexion;
            try 
            {
                carretera.Open();
                m="conexion establecida correctamente";
            }
            catch(Exception d)
            {
                m = "Error de conexion"+d.Message;
                carretera = null;
            }
            return carretera;
        }




        public MySqlDataReader consultareader(MySqlConnection Cabierta, String query, ref String m)
        {
            MySqlDataReader resp = null;
            MySqlCommand carrito = new MySqlCommand();

            if (Cabierta != null)
            {
                carrito.Connection = Cabierta;
                carrito.CommandText = query;
                try
                {
                    resp = carrito.ExecuteReader();
                    m = "consulta correcta";
                }
                catch (Exception d)
                {
                    m = "Error" + d;
                    resp = null;
                }
            }
            else
            {
                m = "Error de conexion ";
            }
            return resp;
        }

        public DataSet consultaset(MySqlConnection cabierta, String query, ref String m)
        {
            DataSet res = new DataSet();
            MySqlCommand carrito = new MySqlCommand();
            MySqlDataAdapter trailer = new MySqlDataAdapter();
            if (cabierta != null)
            {
                carrito.Connection = cabierta;
                carrito.CommandText = query;
                trailer.SelectCommand = carrito;
                try
                {
                    trailer.Fill(res);
                    m = "consulta correcta";
                }
                catch (Exception d)
                {
                    m = "Error" + d;
                    res = null;
                }


                cabierta.Close();
                cabierta.Dispose();
            }
            else
            {
                m = "error de conexion ";
            }

            return res;

        }


        public void consultasetporreferencia(ref DataSet miset, MySqlConnection cabierta, String query,ref String m, String alias)
        {
            MySqlCommand carrito = new MySqlCommand();
            MySqlDataAdapter trailer = new MySqlDataAdapter();

            if (cabierta != null)
            {
                carrito.Connection = cabierta;
                carrito.CommandText = query;
                trailer.SelectCommand = carrito;
                try
                {
                    trailer.Fill(miset, alias);
                    m = "consulta correcta";
                }
                catch (Exception d)
                {
                    m = "Error" + d;
                    miset = null;
                }
                cabierta.Close();
                cabierta.Dispose();

            }
            else
            {
                m = "Error de conexion ";
            }
        }

        public void executequery(MySqlConnection caierta, String query, ref String m)
        {
            String verquery = "";
            verquery = query.Substring(0, 3);

            MySqlCommand spark = new MySqlCommand();
            if (caierta != null)
            {
                spark.Connection = caierta;
                spark.CommandText = query;
                try
                {
                    spark.ExecuteNonQuery();
                    if (verquery == "Ins")
                    {
                        m = "Inserccion Correcta";
                    }
                    if (verquery == "Del")
                    {
                        m = "Eliminación Correcta";
                    }
                    if (verquery == "Upd")
                    {
                        m = "Actualización Correcta";
                    }
                }
                catch (Exception d)
                {
                    m = "Error " + d;
                }
            }
            else
            {
                m = "Error de conexion ";
            }
        }




















    }
}
