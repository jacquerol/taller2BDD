﻿
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1;
using DatabaseUtil;

namespace taller2base
{
    public partial class ConsultaDatos : Form
    {

        private DatabaseUtils util;
        public string receivedData;
        public ConsultaDatos()
        {
            InitializeComponent();
            this.util = new DatabaseUtils();
        }

        public void DatosPorRut(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != ((char)Keys.Enter)) return;
            string mensaje = "";
            DataTable cliente = util.GetTabla("SELECT * FROM CLIENTE c WHERE c.rut = '" + rutTextBox.Text + "'");
            for (int i = 0; i < cliente.Columns.Count; i++)
            {
                mensaje += cliente.Columns[i].ColumnName + ": " + cliente.Rows[0][i] + "\n";
            }
            MessageBox.Show(mensaje);

            /*
            try
            {
                ConexMySQL conex = new ConexMySQL(); conex.open();
                string query = "SELECT * FROM CLIENTE c WHERE c.rut = '" + rutTextBox.Text + "'";
                DataTable cliente = conex.selectQuery(query);
                conex.close();
                for (int i = 0; i < cliente.Columns.Count; i++)
                {
                    mensaje += cliente.Columns[i].ColumnName + ": " + cliente.Rows[0][i] + "\n";
                }
                MessageBox.Show(mensaje);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrido un error de tipo " + ex.Message, "Error");
            }
            //DataTable cliente = this.util.GetTabla("SELECT * FROM CLIENTE WHERE (cliente.rut = " + rutTextBox.Text + ")");
            */
        }
        public void DatosVendedor(object sender, EventArgs e)
        {

        }
        public void DatosCompra(object sender, EventArgs e)
        {

        } 
        public void OrdenesCliente(object sender, EventArgs e)
        {

        }
        public void ProductosCompradosAnual(object sender, EventArgs e)
        {

        }
        public void CantProductosProveedor(object sender, EventArgs e)
        {

        }
        public void ListadoUniversal(object sender, EventArgs e)
        {

        }
        public void ProductosDeProveedor(object sender, EventArgs e)
        {

        }
        public void ProveedoresDeProducto(object sender, EventArgs e)
        {

        }
        public void ProductosCompradosPorCategoria(object sender, EventArgs e)
        {

        }
        public void ProductosCompradosPorDia(object sender, EventArgs e)
        {

        }
        public void ProductosCategoria(object sender, EventArgs e)
        {

        }
        public void CategoriaProducto(object sender, EventArgs e)
        {

        }
        public void ProveedoresProducto(object sender, EventArgs e)
        {

        }
        public void VendedoresAntiguedad(object sender, EventArgs e)
        {

        }
        public void Top5Semana(object sender, EventArgs e)
        {

        }
        public void ProductosSinDemanda(object sender, EventArgs e)
        {

        }





        /// <summary>
        /// función que trabaja con los datos del cliente para poder consultar los datos correspondientes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void clientData(object sender, KeyEventArgs e)
        {
            if(e.KeyCode != Keys.Enter) return;
            string rut = ""; string nombre; string email; string saldo; string precioNeto;
            using (var form = new ModularForm("cliente", "Datos de un cliente", "Ingrese el rut del cliente"))
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    rut = form.ReturnValue;
                }
                if (result == DialogResult.Cancel) return;
            }
            try
            {
                ConexMySQL conex = new ConexMySQL(); conex.open();
                string query = "SELECT nombre, email, saldo FROM CLIENTE c INNER JOIN VENTA v on c.rut = v.rutCliente WHERE v.fecha > CURDATE()-90 and c.rut = '" + rut + "'";
                DataTable data = conex.selectQuery(query);
                nombre = data.Rows[0]["nombre"].ToString();
                email = data.Rows[0]["email"].ToString();
                saldo = data.Rows[0]["saldo"].ToString();
                MessageBox.Show("Nombre: " + nombre + "\nCorreo: " + email + "\nSaldo: " + saldo, "Estadísticas del cliente");
                conex.close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrido un error de tipo " + ex.Message, "Error");
            }
        }
        


        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void clientData(object sender, KeyPressEventArgs e)
        {

        }
    }
}
