using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace conectaMYSQL
{
    public partial class venta : Form
    {
        public venta()
        {
            InitializeComponent();
            textBox1.Hide();
            comboBox5.Hide();
            label2.Hide();
            label6.Hide();
        }
        Medio_trabajo mt = new Medio_trabajo();

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox4.SelectedIndex = 0;
            comboBox5.SelectedIndex = 0;
            mt.loadprede();
            mt.caragaproducto(comboBox1);
            mt.cargacliente(comboBox2);
            mt.cargavendedor(comboBox3);

            //mt.generaprecios();
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            String fecha="";
            fecha=dateTimePicker1.Value.Year.ToString()+"/"+dateTimePicker1.Value.Month+"/"+dateTimePicker1.Value.Day;         
           // ms = new conexionMysql("server=mysql11.000webhost.com; database=a1946121_mio; Uid=a1946121_mio; pwd=123456789;");      
            mt.crearventa(textBox1,textBox2,comboBox1,comboBox2,comboBox3,fecha);  
        }

        public void ver(DataGridView d1)
        {
           
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox4.Text == "Caja")
            {
                comboBox5.Show();
                textBox1.Hide();
                label2.Hide();
                label6.Show();
            }
            else 
            {
                textBox1.Text = "";
                label6.Hide();
                textBox1.Show();
                label2.Show();
                comboBox5.Hide();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            mt.operaciones_costos(comboBox4,comboBox5,textBox1,comboBox1,textBox2);
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox5.Text=="6")
            {
                textBox1.Text = "6";

            } if (comboBox5.Text == "12")
            {
                textBox1.Text = "12";

            } if (comboBox5.Text == "24")
            {
                textBox1.Text = "24";

            }
        }

    }
}
