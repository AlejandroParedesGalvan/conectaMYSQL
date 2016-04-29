using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace conectaMYSQL
{
    public class claseVista
    {
        public void mostrarenlis(ListBox lis, MySqlDataReader datos, int campos)
        {
            lis.Items.Clear();
            String temp = "";
            while (datos.Read())
            {
                temp = "";
                for (int i = 1; i <= campos; i++)
                {
                    temp += datos[i];
                }
                lis.Items.Add(temp);
            }
        }
        public void mensaje(String m, String t)
        {
            MessageBox.Show(m, t, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        public void mostrarencombo(ComboBox lis, MySqlDataReader datos, int campos, ref List<int> losides)
        {
            lis.Items.Clear();
            String temp = "";
            while (datos.Read())
            {
                temp = "";
                for (int i = 0; i <= campos; i++)
                {
                    temp += datos[i] + " ° ";
                }

                losides.Add((int)datos[0]);
                lis.Items.Add(temp);
            }
        }


        public void obtenprecios(MySqlDataReader datos, ref List<double> losides)
        {
            while (datos.Read())
            {                
                losides.Add(Convert.ToDouble(datos[0]));               
            }
        }

        public void muestradataset(DataGridView ver, System.Data.DataSet datos, int numtabla)
        {
            ver.DataSource = datos.Tables[numtabla];
        }

       
    }
}
