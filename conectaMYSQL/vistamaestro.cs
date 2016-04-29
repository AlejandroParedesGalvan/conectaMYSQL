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
    public partial class vistamaestro : Form
    {
        public vistamaestro()
        {
            InitializeComponent();
        }

        Medio_trabajo mt = new Medio_trabajo();
        private void vistamaestro_Load(object sender, EventArgs e)
        {
            mt.loadprede();
            mt.ver_compras(dataGridView1, dataGridView2);

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
