﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace taller2base
{
    public partial class DataTableDisplay : Form
    {
        private BindingSource bindingSource = new BindingSource();
        private Boolean insertData = false; string[] columnas; string entidad;
        public DataTableDisplay(DataTable tabla, string titulo)
        {
            InitializeComponent();
            label.Text = titulo;
            bindingSource = new BindingSource();
            bindingSource.DataSource = tabla;
            this.Controls.Add(dataGridView);
        }
        /**
         * Sobrecarga del constructor para realizar querys de envio
         **/
        public DataTableDisplay(string[] columnas, string titulo, Boolean insertData=true, string entidad="")
        {
            InitializeComponent();
            label.Text = titulo;
            bindingSource = new BindingSource();
            DataTable tabla = new DataTable();
            this.columnas = columnas;
            for (int i = 0; i < columnas.Length; i++){tabla.Columns.Add(columnas[i]);}
            bindingSource.DataSource = tabla;
            this.Controls.Add(dataGridView);
            this.insertData = insertData;
            this.entidad = entidad;
        }
        private void DataTableDisplay_Load(object sender, EventArgs e)
        {
            dataGridView.Dock = DockStyle.Bottom;
            dataGridView.AutoGenerateColumns = true;
            dataGridView.DataSource = bindingSource;
            dataGridView.AutoSizeRowsMode =
                DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            dataGridView.BorderStyle = BorderStyle.Fixed3D;
            if (this.insertData)
            {
                dataGridView.EditMode = DataGridViewEditMode.EditOnEnter;
                sendButton.Show();
            }
            else sendButton.Hide();
        }
        ~DataTableDisplay(){}

        private void insertar()
        {
            DataTable tabla = convertirEnDataTable(this.dataGridView);
            string query = "INSERT INTO "+this.entidad+"(";
            for(int i = 0; i < tabla.Columns.Count; i++)
            {
                query += " " + tabla.Columns[i].ColumnName.ToString();

            }
            query += ") VALUES (";
            for (int i = 0; i < tabla.Columns.Count; i++)
            {
                query += " " + tabla.Rows[0][i];
            }
            query += "";
        }

        private DataTable convertirEnDataTable(DataGridView gridView)
        {
            DataTable dt = new DataTable();
            foreach (DataGridViewColumn column in gridView.Columns)
            {
                dt.Columns.Add(column.HeaderText, column.ValueType);
            }
            foreach (DataGridViewRow row in gridView.Rows)
            {
                dt.Rows.Add();
                foreach (DataGridViewCell cell in row.Cells)
                {
                    dt.Rows[dt.Rows.Count - 1][cell.ColumnIndex] = cell.Value.ToString();
                }
            }
            return dt;
        }

        private void exit(object sender, EventArgs e){this.Close();}

        private void label_Click(object sender, EventArgs e)
        {

        }
    }
}

