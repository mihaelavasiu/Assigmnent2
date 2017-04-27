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
    public partial class UpdateProduct : Form
    {
        MySqlConnection con;
        MySqlDataAdapter adapt;
        DataSet ds;
        int selectedRow;
        private string connString = "datasource=127.0.0.1;port=3306;username=root;password=;database=assigment1;";
        public UpdateProduct()
        {
            InitializeComponent();
        }
        int indexRow;

        private void UpdateProduct_Load(object sender, EventArgs e)
        {
            try
            {
                con = new MySqlConnection();
                con.ConnectionString = @"datasource=127.0.0.1;port=3306;username=root;password=;database=assigment1;Convert Zero Datetime=True;";
                con.Open();
                adapt = new MySqlDataAdapter("select title ,description,color,size,price,stock from product", con);
                ds = new System.Data.DataSet();
                adapt.Fill(ds, "Product_Details");
                dataGridView1.DataSource = ds.Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtTitle_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblFirstName_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void lblPassword_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txtStock_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtDescription_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtColor_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtSize_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPrice_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblUserName_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            DataGridViewRow newDataRow = dataGridView1.Rows[indexRow];
            newDataRow.Cells[0].Value = txtTitle.Text;
            newDataRow.Cells[1].Value = txtDescription.Text;
            newDataRow.Cells[2].Value = txtColor.Text;
            newDataRow.Cells[3].Value = txtSize.Text;
            newDataRow.Cells[4].Value = txtPrice.Text;
            newDataRow.Cells[5].Value = txtStock.Text;
            try
            {
                Product product = new Product();
                product.Title = txtTitle.Text;
                product.Description = txtDescription.Text;
                product.Color = txtColor.Text;
                product.Size = Convert.ToDouble(txtSize.Text);
                product.Price = Convert.ToDouble(txtPrice.Text);
                product.Stock = Convert.ToInt32(txtSize.Text);

                IDBManager db = new MySQLDBManager();
                db.Update(product);
                BindingSource bindingsource = new BindingSource();
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = bindingsource;
                dataGridView1.Refresh();
                con = new MySqlConnection();
                con.ConnectionString = @"datasource=127.0.0.1;port=3306;username=root;password=;database=assigment1;Convert Zero Datetime=True;";
                con.Open();
                adapt = new MySqlDataAdapter("select title ,description,color,size,price,stock from product", con);
                ds = new System.Data.DataSet();
                adapt.Fill(ds, "Product_Details");
                dataGridView1.DataSource = ds.Tables[0];
                MessageBox.Show("Updated!", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            indexRow = e.RowIndex; // get the selected Row Index
            DataGridViewRow row = dataGridView1.Rows[indexRow];

            txtTitle.Text = row.Cells[0].Value.ToString();
            txtDescription.Text = row.Cells[1].Value.ToString();
            txtColor.Text = row.Cells[2].Value.ToString();
            txtSize.Text = row.Cells[3].Value.ToString();
            txtPrice.Text = row.Cells[4].Value.ToString();
            txtStock.Text = row.Cells[5].Value.ToString();
        }

        private void txtDescription_TextChanged_1(object sender, EventArgs e)
        {

        }
    }
}
