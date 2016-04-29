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
    public partial class agregacliente : Form
    {
        public agregacliente()
        {
            InitializeComponent();
        }

        Medio_trabajo mt = new Medio_trabajo();
        private void button1_Click(object sender, EventArgs e)
        {
            
                mt.insertacliente(textBox1, textBox2,textBox3,textBox4);
            
            
        }

        private void agregacliente_Load(object sender, EventArgs e)
        {
            mt.loadprede();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
