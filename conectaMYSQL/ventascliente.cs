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
    public partial class ventascliente : Form
    {
        public ventascliente()
        {
            InitializeComponent();
        }
        Medio_trabajo mt = new Medio_trabajo();

        private void ventascliente_Load(object sender, EventArgs e)
        {
            mt.loadprede();
            mt.ver_comprasCliente(dataGridView1, dataGridView2);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
