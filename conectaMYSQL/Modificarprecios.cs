using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace conectaMYSQL
{
    public partial class Modificarprecios : Form
    {
        public Modificarprecios()
        {
            InitializeComponent();
        }

        Medio_trabajo mt = new Medio_trabajo();
        claseVista cv = new claseVista();
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" )               
                mt.insertapintura(comboBox1, textBox1);
            else MessageBox.Show("Inserta todos los campos de Pintura");

            textBox1.Clear();
            
        }

        private void Modificarprecios_Load(object sender, EventArgs e)
        {
            mt.loadprede();
           
        }

        private void label2_Click(object sender, EventArgs e)
        {


        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox6.Text != "")
            {
                mt.insertagancho(textBox6);
            }
            else MessageBox.Show("Inserta todos los campos Gancho");
            textBox6.Clear();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox3.Text != "")
                mt.insertacarton(textBox3);
            else
                MessageBox.Show("Insertar todos los campos Carton");
            textBox3.Clear();
            
        }
    }
}
