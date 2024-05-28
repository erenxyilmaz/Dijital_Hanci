﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RfId
{
    public partial class lobyLoungecs : Form
    {
        private OleDbConnection connection = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\onur\\Desktop\\dijitalhancı.accdb");
        private OleDbDataAdapter dataAdapter;
        private DataTable dataTable;
        public lobyLoungecs()
        {
            InitializeComponent();
        }
        // Form yüklendiğinde verileri yüklemek için kullanılır.
        private void lobyLoungecs_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                connection.Open();
                string query = "SELECT * FROM lobi;";
                dataAdapter = new OleDbDataAdapter(query, connection);
                dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                dataGridView1.DataSource = dataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veri yüklenirken bir hata oluştu: " + ex.Message);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }


        private void label1_Click(object sender, EventArgs e)
        {

        }


    }
}
