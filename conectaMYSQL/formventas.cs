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
    public partial class formventas : Form
    {
        public formventas()
        {
            
            InitializeComponent();
            textBox1.Hide();
            comboBox5.Hide();
            label2.Hide();
            label6.Hide();
            button7.Hide();
        }
        Medio_trabajo mt = new Medio_trabajo();
        String costo = "0", cantidad = "0";

        private void formventas_Load(object sender, EventArgs e)
        {
            comboBox4.SelectedIndex = 0;
            comboBox5.SelectedIndex = 0;
            mt.loadprede();
            mt.cargacliente(comboBox2);
            mt.cargavendedor(comboBox3);
            mt.ver_esferas(dataGridView1);
            comboBox1.SelectedIndex = 0;
            label22.Hide();
            comboBox1.Hide();
        }
        

        private void button1_Click_1(object sender, EventArgs e)
        {
            String fecha = "";
            fecha = fe.Value.Year.ToString() + "/" + fe.Value.Month + "/" + fe.Value.Day;

            mt.actualizafact(textBox3, textBox2);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            String tipo = "1";
            if (comboBox1.Text == "Nota")
            {
                tipo = "1";
            }
            else tipo = "0";

            MessageBox.Show(""+tipo);
            String fecha = "";
            fecha = fe.Value.Year + "/" + fe.Value.Month + "/" + fe.Value.Day;
            mt.insertafactura(textBox3, comboBox3, comboBox2, fecha,tipo);
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
                cantidad = textBox1.Text;
            }
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox5.Text == "6")
            {
                textBox1.Text = "6";
                cantidad = "6";

            } if (comboBox5.Text == "12")
            {
                textBox1.Text = "12";
                cantidad = "12";

            } if (comboBox5.Text == "24")
            {
                textBox1.Text = "24";
                cantidad = "24";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (comboBox4.Text == "Unidad")
            {
                cantidad = textBox1.Text;
            
            }
            MessageBox.Show(cantidad+"");
            MessageBox.Show(costo + "");


            mt.insertacarrito(dataGridView1, textBox3, costo, cantidad);
            mt.ver_compras(compraDataGridView, textBox3);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox2.Text = mt.calculatotal(compraDataGridView,label24).ToString();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            label20.Hide();
            label13.Text = textBox3.Text;
            label14.Text = fe.Value.ToShortDateString();
            label17.Text = comboBox2.Text;
            label19.Text = comboBox3.Text;
            label15.Text = textBox2.Text;
            mt.ver_compras(dataGridView2, textBox3);
            this.dataGridView2.Columns[1].Name = "Tamanio";
            tabControl1.SelectTab(tabPage2);
            button7.Visible = true;
        }
        

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(memoryImage, 0, 0);
        }
        [System.Runtime.InteropServices.DllImport("gdi32.dll")]
        public static extern long BitBlt(IntPtr hdcDest, int nXDest, int nYDest, int nWidth, int nHeight, IntPtr hdcSrc, int nXSrc, int nYSrc, int dwRop);
        private Bitmap memoryImage;
        private void CaptureScreen()
        {
            Graphics mygraphics = this.CreateGraphics();
            Size s = this.Size;
            memoryImage = new Bitmap(s.Width, s.Height, mygraphics);
            Graphics memoryGraphics = Graphics.FromImage(memoryImage);
            IntPtr dc1 = mygraphics.GetHdc();
            IntPtr dc2 = memoryGraphics.GetHdc();
            BitBlt(dc2, 0, 0, this.ClientRectangle.Width, this.ClientRectangle.Height, dc1, 0, 0, 13369376);
            mygraphics.ReleaseHdc(dc1);
            memoryGraphics.ReleaseHdc(dc2);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            CaptureScreen();
            printDocument1.Print();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            label10.Text = "Id Factura";
            label13.Text = textBox3.Text;
            label14.Text = fe.Value.ToShortDateString();
            label17.Text = comboBox2.Text;
            label19.Text = comboBox3.Text;
            label15.Text = textBox2.Text;
            mt.ver_compras(dataGridView2, textBox3);
            tabControl1.SelectTab(tabPage2);
            button7.Visible = true;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click_1(object sender, EventArgs e)
        {

            mt.ver_esferas(dataGridView1);
        }

        
        
    }
}
