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
    public partial class Lote : Form
    {
        public Lote()
        {
            InitializeComponent();
        }
        Medio_trabajo mt = new Medio_trabajo();
        String inver = "50";
        String canitdad = "";
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void Lote_Load(object sender, EventArgs e)
        {
            mt.loadprede();
            mt.cargacarton(cmbIDCarton);
            mt.cargapintura(cmbIdPintura);
            mt.cargagancho(cmbIdGancho);
            comboBox1.SelectedIndex = 0;

        }

        

        private void button1_Click_1(object sender, EventArgs e)
        {
            Double pin = 0, car = 0, gan = 0, subtotal = 0;
            String couni = "";
            mt.obteninversion(ref pin, ref car, ref gan, cmbIdPintura, cmbIDCarton, cmbIdGancho);

            if (comboBox1.Text == "5")
            {
                subtotal = (pin * 0.0037) + (gan * 0.001);
            }
            if (comboBox1.Text == "3")
            {
                subtotal = (pin * 0.0033) + (gan * 0.001);
            }

            mt.insertalote(textBox4, cmbIdPintura, cmbIDCarton, cmbIdGancho, canitdad, comboBox1, inver);

            couni = subtotal.ToString();
            mt.insertaesferas(comboBox1, textBox4, couni);
        }

        private void cmbIdPintura_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "3")
            {
                canitdad = "300";
                label2.Text = "300";
            }
            else
            { 
            canitdad="265";
            label2.Text = "265";
            }
        }
    }
}
