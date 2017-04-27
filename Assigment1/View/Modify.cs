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
    public partial class Modify : Form
    {
        MySqlConnection con;
        MySqlDataAdapter adapt;
        DataSet ds;
        int indexRow;
        public Modify()
        {
            InitializeComponent();
        }

        private void Modify_Load(object sender, EventArgs e)
        {
            try
            {
                con = new MySqlConnection();
                con.ConnectionString = @"datasource=127.0.0.1;port=3306;username=root;password=;database=assigment1;Convert Zero Datetime=True;";
                con.Open();
                adapt = new MySqlDataAdapter("SELECT `id`, `customer`, `address`, `delivery_date`, `status`, `pieces`, `value`, `product_id` FROM `order`", con);
                ds = new System.Data.DataSet();
                adapt.Fill(ds, "Order_Details");
                dataGridView1.DataSource = ds.Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            indexRow = e.RowIndex; // get the selected Row Index
            DataGridViewRow row = dataGridView1.Rows[indexRow];

            txtID.Text = row.Cells[0].Value.ToString();
            txtCustomer.Text = row.Cells[1].Value.ToString();
            txtAddress.Text = row.Cells[2].Value.ToString();
            txtDeliveryDate.Text = row.Cells[3].Value.ToString();
            txtStatus.Text = row.Cells[4].Value.ToString();
            txtPieces.Text = row.Cells[5].Value.ToString();
            txtValue.Text = row.Cells[6].Value.ToString();
            txtProductID.Text = row.Cells[7].Value.ToString();
        }

        private void btnAdd_Click_1(object sender, EventArgs e)
        {
            DataGridViewRow newDataRow = dataGridView1.Rows[indexRow];
            newDataRow.Cells[0].Value = txtID.Text;
            newDataRow.Cells[1].Value = txtCustomer.Text;
            newDataRow.Cells[2].Value = txtAddress.Text;
            newDataRow.Cells[3].Value = txtDeliveryDate.Text;
            newDataRow.Cells[4].Value = txtStatus.Text;
            newDataRow.Cells[5].Value = txtPieces.Text;
            newDataRow.Cells[6].Value = txtValue.Text;
            newDataRow.Cells[7].Value = txtProductID.Text;
            try
            {
                Order order = new Order();
                order.ID = Convert.ToInt32(txtID.Text);
                order.Customer = txtCustomer.Text;
                order.Address = txtAddress.Text;
                order.DeliveryDate = Convert.ToDateTime(txtDeliveryDate.Text);
                order.Status = txtStatus.Text;
                order.Pieces = Convert.ToInt32(txtPieces.Text);
                order.Value = Convert.ToInt32(txtValue.Text);
                order.ProductID = Convert.ToInt32(txtProductID.Text);
                int nrProducts = Convert.ToInt32(txtNr.Text);

                IDBManager db = new MySQLDBManager();
                db.ModifyOrder(order,nrProducts);
                BindingSource bindingsource = new BindingSource();
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = bindingsource;
                dataGridView1.Refresh();
                con = new MySqlConnection();
                con.ConnectionString = @"datasource=127.0.0.1;port=3306;username=root;password=;database=assigment1;Convert Zero Datetime=True;";
                con.Open();
                adapt = new MySqlDataAdapter("SELECT `id`, `customer`, `address`, `delivery_date`, `status`, `pieces`, `value`, `product_id` FROM `order` ", con);
                ds = new System.Data.DataSet();
                adapt.Fill(ds, "Order_Details");
                dataGridView1.DataSource = ds.Tables[0];
                MessageBox.Show("Updated!", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
