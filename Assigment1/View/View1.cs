using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;

namespace Assigment1
{
    public partial class View1 : Form
    {
        MySqlConnection con;
        MySqlDataAdapter adapt;
        DataSet ds;
        public View1()
        {
            InitializeComponent();
        }

        private void View1_Load(object sender, EventArgs e)
        {
            try
            {
                con = new MySqlConnection();
                con.ConnectionString = @"datasource=127.0.0.1;port=3306;username=root;password=;database=assigment1;Convert Zero Datetime=True;";
                con.Open();
                adapt = new MySqlDataAdapter("SELECT `id`, `customer`, `address`, `delivery_date`, `status`, `pieces`, `value`, `product_id` FROM `order` ", con);
                ds = new System.Data.DataSet();
                adapt.Fill(ds, "Order_Details");
                dataGridView1.DataSource = ds.Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
