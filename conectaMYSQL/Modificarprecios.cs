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
        private void button1_Click(object sender, EventArgs e)
        {
            if ((textBox1.Text != "") && (textBox2.Text != "") && (textBox3.Text != ""))
                mt.modificaprecios(textBox1, textBox2, textBox3);
            else MessageBox.Show("Modifica todos los precios");
        }

        private void Modificarprecios_Load(object sender, EventArgs e)
        {
            mt.loadprede();
        }
    }
}
