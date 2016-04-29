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

        List<int> listapintura = new List<int>();
        List<int> listagancho = new List<int>();
        List<int> listacarton = new List<int>();
        List<double> prelistapintura = new List<double>();
        List<double> prelistagancho = new List<double>();
        List<double> prelistacarton = new List<double>();


        public void loadprede()
        {
            ms = new conexionMysql("server=www.db4free.net; database=cristalh; Uid=aledancit; pwd=123456789;Port=3306;");
            Mysqlconect = new MySqlConnection();
            Mysqlconect = ms.conexion(ref m);
            //MessageBox.Show(m);  
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

        public void cargapintura(ComboBox cb1)
        {
            listapintura.Clear();
            MySqlDataReader leer;
            String op = "select * from pintura";
            leer = ms.consultareader(ms.conexion(ref m), op, ref m);
            // MessageBox.Show(m);
            if (leer != null)
            {
                vista.mostrarencombo(cb1, leer, 1, ref listapintura);
                ms.conexion(ref m).Close();
                ms.conexion(ref m).Dispose();
                if (cb1.Items.Count >= 0)
                {
                    cb1.SelectedIndex = 0;
                }
            }
        }

        public void cargacarton(ComboBox cb1)
        {
            listacarton.Clear();
            MySqlDataReader leer;
            String op = "select * from carton";
            leer = ms.consultareader(ms.conexion(ref m), op, ref m);
            // MessageBox.Show(m);
            if (leer != null)
            {
                vista.mostrarencombo(cb1, leer, 2, ref listacarton);
                ms.conexion(ref m).Close();
                ms.conexion(ref m).Dispose();
                if (cb1.Items.Count >= 0)
                {
                    cb1.SelectedIndex = 0;
                }
            }
        }

        public void cargagancho(ComboBox cb1)
        {
            listagancho.Clear();
            MySqlDataReader leer;
            String op = "select * from gancho";
            leer = ms.consultareader(ms.conexion(ref m), op, ref m);
            // MessageBox.Show(m);
            if (leer != null)
            {
                vista.mostrarencombo(cb1, leer, 1, ref listagancho);
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
            String op = "select * from empleado";
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
        public void insertacliente(TextBox nombre, TextBox app, TextBox apm,TextBox rfc)
        {
            String query = "Insert into cliente (Nombre,Apellidos_P,Apellidos_M,RFC) values('" + nombre.Text + "','" + app.Text + "','" + apm.Text + "','" + rfc.Text + "');";
            ms.executequery(ms.conexion(ref m), query, ref m);
            MessageBox.Show(m);
        }


        

        public void insertaempleado(TextBox nombre, TextBox app, TextBox apm, TextBox tel)
        {
            String query = "Insert into empleado (Nombre,Apellidos_P,Apellidos_M,Telefono) values('" + nombre.Text + "','" + app.Text + "','" + apm.Text + "','" + tel.Text + "');";
            ms.executequery(ms.conexion(ref m), query, ref m);
            MessageBox.Show(m);
        }

        public void insertaesferas(ComboBox exis, TextBox idlote,String precio)
        {
            String query = "Insert into esferas (Existencia,Id_lote,precio_unitario) values(" + exis.Text + "," + idlote.Text + ",'" + precio + "');";
            ms.executequery(ms.conexion(ref m), query, ref m);
            MessageBox.Show(m);
        }
        
        public void insertafactura(TextBox idfac, ComboBox idemple, ComboBox idcliente,String fecha)
        {
            String query = "Insert into factura (Id_Fatura,Id_Empleado,Id_cliente,Fecha,Subtotal,Total) values("+idfac.Text+"," + listavende[idemple.SelectedIndex] + "," + listacliente[idcliente.SelectedIndex] + ",'" + fecha + "',0,0);";
            ms.executequery(ms.conexion(ref m), query, ref m);
            MessageBox.Show(m);
        }

        

        public void obteninversion(ref double pintura, ref double carton, ref double gancho,ComboBox p,ComboBox c,ComboBox g)
        {
            prelistacarton.Clear();
            MySqlDataReader leer;
            String op = "select Precio from carton";
            leer = ms.consultareader(ms.conexion(ref m), op, ref m);
            // MessageBox.Show(m);
            if (leer != null)
            {
                vista.obtenprecios(leer, ref prelistacarton);
                ms.conexion(ref m).Close();
                ms.conexion(ref m).Dispose();
            }
                    

            prelistapintura.Clear();
            MySqlDataReader leer1;
            String op1 = "select Precio from pintura";
            leer1 = ms.consultareader(ms.conexion(ref m), op1, ref m);
            // MessageBox.Show(m);
            if (leer1 != null)
            {
                vista.obtenprecios(leer1, ref prelistapintura);
                ms.conexion(ref m).Close();
                ms.conexion(ref m).Dispose();
            }

            prelistagancho.Clear();
            MySqlDataReader leer2;
            String op2 = "select Precio_unidad from gancho";
            leer2 = ms.consultareader(ms.conexion(ref m), op2, ref m);
            // MessageBox.Show(m);
            if (leer2 != null)
            {
                vista.obtenprecios(leer2, ref prelistagancho);
                ms.conexion(ref m).Close();
                ms.conexion(ref m).Dispose();
            }

            
            pintura = prelistapintura[p.SelectedIndex];
            carton = prelistacarton[c.SelectedIndex];
            gancho = prelistagancho[g.SelectedIndex];
        }
                

        public void insertalote(TextBox idlote, ComboBox idpintura, ComboBox idcarton, ComboBox idgancho ,String cantidad,ComboBox tamaño, String inversion)
        {
            double pint=0,ganc=0,cart=0,gastos=0;
            obteninversion(ref pint,ref cart,ref ganc,idpintura,idcarton,idgancho);
            gastos = pint + ganc + cart;
            inversion = gastos.ToString();

            String query = "Insert into lote (Id_lote,Id_pintura,id_carton,Id_gancho,Cantidad_esferas,Tamaño_cm,Invercion) values("+idlote.Text+"," + listapintura[idpintura.SelectedIndex] + "," + listacarton[idcarton.SelectedIndex] + "," + listagancho[idgancho.SelectedIndex] + "," +Convert.ToInt32( cantidad) + "," + tamaño.Text + "," + inversion + ");";
            ms.executequery(ms.conexion(ref m), query, ref m);
            MessageBox.Show(m);
        }

        public void insertapintura(ComboBox color, TextBox precio)
        {
            String query = "Insert into pintura (Color,Precio) values('" + color.Text + "'," + precio.Text + ");";
            ms.executequery(ms.conexion(ref m), query, ref m);
            MessageBox.Show(m);
        }
        public void insertacarton(TextBox precio)
        {
            String query = "Insert into carton  (Precio) values('" + precio.Text + "');";
            ms.executequery(ms.conexion(ref m), query, ref m);
            MessageBox.Show(m);
        }
        public void insertagancho(TextBox precio)
        {
            String query = "Insert into gancho (Precio_unidad) values(" + precio.Text + ");";
            ms.executequery(ms.conexion(ref m), query, ref m);
            MessageBox.Show(m);
        }   
      
        public void insertacarrito(DataGridView d1, TextBox idfact, String costo, String cantidad)
        {
            double cosT = 0;

            cosT =Convert.ToDouble(d1.CurrentRow.Cells[1].Value) *Convert.ToDouble(cantidad);
            
            String query = "Insert into relacion (id_esfera,id_fact,costo_compra,cantidad) values(" + d1.CurrentRow.Cells[0].Value.ToString() + "," + idfact.Text + ","+cosT+","+cantidad+");";
            ms.executequery(ms.conexion(ref m), query, ref m);
            MessageBox.Show(m);
        }


        public void ver_esferas(DataGridView d1)
        {
            string query = "select es.Id_esferas,es.precio_unitario,lo.Tamaño_cm,p.Color from esferas es inner join lote lo on lo.Id_lote=es.Id_lote inner join pintura p on p.Id_pintura=lo.Id_pintura";
            DataSet set = ms.consultaset(ms.conexion(ref m), query, ref m);
            vista.muestradataset(d1, set, 0);
        }

        public void ver_compras(DataGridView d1,TextBox fac)
        {

            string query = "select p.Color,lo.Tamaño_cm,r.cantidad,r.costo_compra from relacion r inner join esferas es on es.Id_esferas=r.id_esfera inner join lote lo on lo.Id_lote=es.Id_lote inner join pintura p on p.Id_pintura=lo.Id_pintura where id_fact=" + fac.Text + "";
            DataSet set = ms.consultaset(ms.conexion(ref m), query, ref m);
            vista.muestradataset(d1, set, 0);
        }

        public double calculatotal(DataGridView d1)
        {
            double total = 0;

                foreach (DataGridViewRow row in d1.Rows)
                {
                    //Aquí seleccionaremos la columna que contiene los datos numericos.
                    total += Convert.ToDouble(row.Cells[3].Value);
                }
            
            return total;
        }



        public void actualizafact(TextBox idfac,TextBox total)
        {
            String query = "Update factura set Subtotal='"+total.Text+"',Total='"+total.Text+"' where Id_Fatura='" + idfac.Text + "'";
            ms.executequery(ms.conexion(ref m), query, ref m);
             MessageBox.Show(m);
            
        }


        public void ver_compras(DataGridView d1, DataGridView d2)
        {
            String m = "";
            String fat = "select re.id_fact,re.costo_compra,re.cantidad,es.precio_unitario,lo.Tamaño_cm,p.Color from relacion re inner join esferas es on es.Id_esferas=re.id_esfera inner join lote lo on lo.Id_lote=es.Id_lote inner join pintura p on p.Id_pintura=lo.Id_pintura inner join factura fa on fa.Id_Fatura=re.id_fact";
            
            String ven = "select Id_Fatura,Fecha,Total from factura";

            ms.consultasetporreferencia(ref setglobal, ms.conexion(ref m), fat, ref m, "detalle");
            MessageBox.Show(m);         
            ms.consultasetporreferencia(ref setglobal, ms.conexion(ref m), ven, ref m, "venta");
            MessageBox.Show(m);
            

            
            System.Data.DataColumn mesclavo = setglobal.Tables["detalle"].Columns["id_fact"];
            System.Data.DataColumn maestro = setglobal.Tables["venta"].Columns["Id_Fatura"];
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

        public void ver_comprasCliente(DataGridView d1, DataGridView d2)
        {
            String m = "";
            String fat = "select re.id_fact,cl.Id_cliente,re.costo_compra,re.cantidad,es.precio_unitario,lo.Tamaño_cm,p.Color from relacion re inner join esferas es on es.Id_esferas=re.id_esfera inner join lote lo on lo.Id_lote=es.Id_lote inner join pintura p on p.Id_pintura=lo.Id_pintura inner join factura fa on fa.Id_Fatura=re.id_fact inner join cliente cl on cl.Id_cliente=fa.Id_cliente";
            String ven = "select * from cliente";

            ms.consultasetporreferencia(ref setglobal, ms.conexion(ref m), fat, ref m, "detalle");
            MessageBox.Show(m);
            ms.consultasetporreferencia(ref setglobal, ms.conexion(ref m), ven, ref m, "venta");
            MessageBox.Show(m);
            //d1.DataSource = setglobal.Tables["detalle"];


            System.Data.DataColumn mesclavo = setglobal.Tables["detalle"].Columns["Id_cliente"];
            System.Data.DataColumn maestro = setglobal.Tables["venta"].Columns["Id_cliente"];
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

        
    }
}
