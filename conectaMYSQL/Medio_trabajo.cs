using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace conectaMYSQL
{
    public class Medio_trabajo
    {
        conexionMysql ms;
        claseVista vista = new claseVista();
        String m = "";
        DataSet setglobal=new DataSet();
        MySqlConnection Mysqlconect;

        List<int> listacliente = new List<int>();
        List<int> listavende = new List<int>();
        List<int> listaproducto = new List<int>();
        List<double> listainsumo = new List<double>();


        public void loadprede()
        {
            ms = new conexionMysql("server=db4free.net; database=cristalh; Uid=aledancit; pwd=123456789;");
            Mysqlconect = new MySqlConnection();
            Mysqlconect = ms.conexion(ref m);
            MessageBox.Show(m);  
        }

        public void cargacliente(ComboBox cb1)
        {
            listacliente.Clear();
            MySqlDataReader leer;
            String op = "select * from cliente";
            leer = ms.consultareader(ms.conexion(ref m), op, ref m);
            // MessageBox.Show(m);
            if (leer != null)
            {
                vista.mostrarencombo(cb1, leer, 1, ref listacliente);
                ms.conexion(ref m).Close();
                ms.conexion(ref m).Dispose();
                if (cb1.Items.Count >= 0)

                {
                    cb1.SelectedIndex = 0;
                }
            }
        }

        public void cargavendedor(ComboBox cb1)
        {
            listavende.Clear();
            MySqlDataReader leer;
            String op = "select * from vendedor";
            leer = ms.consultareader(ms.conexion(ref m), op, ref m);
            // MessageBox.Show(m);
            if (leer != null)
            {
                vista.mostrarencombo(cb1, leer, 1, ref listavende);
                ms.conexion(ref m).Close();
                ms.conexion(ref m).Dispose();
                if (cb1.Items.Count >= 0)
                {
                    cb1.SelectedIndex = 0;
                }
            }
        }

        public void caragaproducto(ComboBox cb1)
        {
            listaproducto.Clear();
            MySqlDataReader leer;
            String op = "select * from producto";
            leer = ms.consultareader(ms.conexion(ref m), op, ref m);
            // MessageBox.Show(m);
            if (leer != null)
            {
                vista.mostrarencombo(cb1, leer, 2, ref listaproducto);
                ms.conexion(ref m).Close();
                ms.conexion(ref m).Dispose();
                if (cb1.Items.Count >= 0)
                {
                    cb1.SelectedIndex = 0;
                }
            }
        }
       
        public void generaprecios(ref double pintura,ref double carton,ref double gancho)
        {
            listainsumo.Clear();
            MySqlDataReader leer;
            String op = "select * from insumo";
            leer = ms.consultareader(ms.conexion(ref m), op, ref m);
            // MessageBox.Show(m);
            if (leer != null)
            {
                vista.obtenprecios(leer, ref listainsumo);
                ms.conexion(ref m).Close();
                ms.conexion(ref m).Dispose();              
            }

            pintura=listainsumo[0];
            carton=listainsumo[1];
            gancho=listainsumo[2];
        }

        public void crearventa(TextBox cant, TextBox total, ComboBox id_prod,ComboBox cbcliente,ComboBox cbvendedor,String fecha)
        {
            String query = "Insert into venta (cantidad,total,id_prod,factura) values('" + cant.Text + "','" + total.Text + "'," + listaproducto[id_prod.SelectedIndex] + ",(SELECT MAX(id_fact) FROM factura));";
            //MessageBox.Show(""+fecha);
            String infact="Insert into factura (fecha,subtotal,id_vencedor,id_cliente) values('"+fecha+"','"+total.Text+"',"+listavende[cbvendedor.SelectedIndex]+","+listacliente[cbcliente.SelectedIndex]+");";
            ms.executequery(ms.conexion(ref m), infact, ref m);
            MessageBox.Show("factura     "+m);
            ms.executequery(ms.conexion(ref m), query, ref m);            
            MessageBox.Show("venta   "+m);

            String insumos = "Insert into insumo_prod (id_venta,id_insumo,cantidad_utiliza) values((SELECT MAX(id_venta) AS id_ven FROM venta),1,'"+cant.Text+"')";
            String insumos2 = "Insert into insumo_prod (id_venta,id_insumo,cantidad_utiliza) values((SELECT MAX(id_venta) AS id_ven FROM venta),3,'" + cant.Text + "')";
            String insumos1 = "Insert into insumo_prod (id_venta,id_insumo,cantidad_utiliza) values((SELECT MAX(id_venta) AS id_ven FROM venta),2,'" + cant.Text + "')";

            ms.executequery(ms.conexion(ref m), insumos, ref m);
            MessageBox.Show("insumo 1    "+m);
            ms.executequery(ms.conexion(ref m), insumos2, ref m);

            MessageBox.Show("insumo 2    " + m);
            if(cant.Text=="6")
            {
                ms.executequery(ms.conexion(ref m), insumos1, ref m);  
            }
            if(cant.Text=="12")
            {
                ms.executequery(ms.conexion(ref m), insumos1, ref m);  

            }
            if (cant.Text == "24")
            {

                ms.executequery(ms.conexion(ref m), insumos1, ref m);  
            }

        }


        public void insertacliente(TextBox nombre,TextBox RFC)
        {
            String query = "Insert into cliente (nombre,RFC) values('" + nombre.Text + "','"+RFC.Text+"');";
            ms.executequery(ms.conexion(ref m), query, ref m);
            MessageBox.Show(m);
        }
        

        public void operaciones_costos(ComboBox cbveri, ComboBox tamaño_caja,TextBox cantidad,ComboBox tamaño_E,TextBox T_total) 
        {
            String vertamaño = "";
            vertamaño = (tamaño_E.Text).Substring(4,4);
            Double subtotal = 0, iva = 0, total = 0, totalcompleto = 0;
            Double caja=0, pintura=0, gancho=0;
            generaprecios(ref pintura, ref caja, ref gancho);

            if (cbveri.Text == "Caja")
            {
                if (tamaño_caja.Text == "6")
                {
                    if (vertamaño == "5 cm")
                    {
                        subtotal = (pintura * 0.0037) + (gancho * 0.001);
                    }
                    if (vertamaño == "3 cm")
                    {
                        subtotal = (pintura * 0.0033) + (gancho * 0.001);
                    }

                    iva = subtotal * 0.16;
                    total = subtotal * 0.30;
                    totalcompleto = ((caja / 30))+((total + subtotal) + iva) * 6;
                }

                if (tamaño_caja.Text == "12")
                {
                    if (vertamaño == "5 cm")
                    {
                        subtotal = (pintura * 0.0037) + (gancho * 0.001);
                    }
                    if (vertamaño == "3 cm")
                    {
                        subtotal = (pintura * 0.0033) + (gancho * 0.001);
                    }

                    iva = subtotal * 0.16;
                    total = subtotal * 0.30;
                    totalcompleto = ((caja/20))+(((total + subtotal) + iva) * 12);                   
                
                }
                if (tamaño_caja.Text == "24")
                {
                    if (vertamaño == "5 cm")
                    {
                        subtotal = (pintura * 0.0037) + (gancho * 0.001);
                    }
                    if (vertamaño == "3 cm")
                    {
                        subtotal = (pintura * 0.0033) + (gancho * 0.001);
                    }

                    iva = subtotal * 0.16;
                    total = subtotal * 0.30;
                    totalcompleto = ((caja / 15)) + ((total + subtotal) + iva) * 24;
                
                }

            }
            else
            {
                if (vertamaño == "5 cm")
                {
                    subtotal = (pintura * 0.0037) + (gancho * 0.001);
                }
                if (vertamaño== "3 cm")
                {
                    subtotal = (pintura * 0.0033) + (gancho * 0.001);
                }

                iva = subtotal * 0.16;
                total = subtotal * 0.30;
                totalcompleto = ((total + subtotal) + iva) * Convert.ToInt32(cantidad.Text);
            }

          //  MessageBox.Show("" + subtotal);
          //  MessageBox.Show("" + iva);
            //MessageBox.Show("Total a pagar "+totalcompleto.ToString("0.00"));           
            T_total.Text=totalcompleto.ToString("0.00");       
            
        }


        public void modificaprecios(TextBox pintura, TextBox carton,TextBox gancho)
        {
            String query = "Update insumo set cantidad="+pintura.Text+" where id_insumo=1";
            String query1 = "Update insumo set cantidad=" + carton.Text + " where id_insumo=2";
            String query2 = "Update insumo set cantidad=" + gancho.Text + " where id_insumo=3";
            ms.executequery(ms.conexion(ref m), query, ref m);
            ms.executequery(ms.conexion(ref m), query1, ref m);
            ms.executequery(ms.conexion(ref m), query2, ref m);
            MessageBox.Show(m);
        }




        public void vista_detalle(DataGridView d1, DataGridView d2)
        {
            String m = "";
            String fat = "SELECT ven.id_venta,fa.fecha,pr.tamaño as Tamaño,pr.color as Color,ven.total,v.nombre as vendedor,cl.nombre as cliente,cl.RFC from venta ven INNER join producto pr on pr.id_producto=ven.id_prod INNER join factura fa on fa.id_fact=ven.factura INNER join vendedor v on v.id_vendedor=fa.id_vencedor INNER join cliente cl on cl.id_cliente=fa.id_cliente";
            String ven = "select id_venta,total,factura from venta";

            ms.consultasetporreferencia(ref setglobal, ms.conexion(ref m), fat, ref m, "detalle"); 
            MessageBox.Show(m);
            ms.consultasetporreferencia(ref setglobal, ms.conexion(ref m), ven, ref m, "venta");
            MessageBox.Show(m);

            System.Data.DataColumn mesclavo = setglobal.Tables["detalle"].Columns["id_venta"];
            System.Data.DataColumn maestro = setglobal.Tables["venta"].Columns["id_venta"];
            DataRelation muchos = new System.Data.DataRelation("factura_venta", maestro, mesclavo);

            setglobal.Relations.Add(muchos);

            BindingSource relacionfactura = new BindingSource();
            relacionfactura.DataSource = setglobal;
            relacionfactura.DataMember = "venta";

            BindingSource relacionventa = new BindingSource();
            relacionventa.DataSource = relacionfactura;
            relacionventa.DataMember = "factura_venta";

            d1.DataSource = relacionfactura;
            d2.DataSource = relacionventa;

        }
        
        public void impfactura (DataGridView d )
        {

            String Nombre = d.CurrentRow.Cells[0].Value.ToString(); //Para obtener el nombre
            String Direccion = d.CurrentRow.Cells[1].Value.ToString(); //Para obtener la dirección
            String Telefono = d.CurrentRow.Cells[2].Value.ToString(); //Para obtener el telefóno
            
        }
        






        

    }
}
