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
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            agregacliente agc = new agregacliente();
            agc.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            formventas fv = new formventas();
            fv.Show();
            //venta ve = new venta();
            //ve.Show();
        }

        private void insertaClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Modificarprecios mp = new Modificarprecios();
            mp.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            vistamaestro vmd = new vistamaestro();
            vmd.ShowDialog();
        }

        private void Menu_Load(object sender, EventArgs e)
        {

        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            ventascliente v = new ventascliente();
            v.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Lote l = new Lote();
            l.Show();
        }
    }
}
