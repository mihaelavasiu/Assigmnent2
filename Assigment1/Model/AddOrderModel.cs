using Assigment1.Presenter;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assigment1.Model
{
    public class AddOrderModel
    {
        MySqlConnection con;
        MySqlDataAdapter adapt;
        DataSet ds;
        int selectedRow;
        public AddOrderPresenter presenter1;
        int indexRow;
        private string connString = "datasource=127.0.0.1;port=3306;username=root;password=;database=assigment1;";
        public AddOrderModel(AddOrderPresenter presenter1)
        {
            this.presenter1 = presenter1;
           
        }


        public void AddOrder()
        {
            DataGridViewRow newDataRow = presenter1.addOrderView.dataGridView1.Rows[indexRow];
            newDataRow.Cells[0].Value = presenter1.addOrderView.txtID.Text;
            newDataRow.Cells[1].Value = presenter1.addOrderView.txtCustomer.Text;
            newDataRow.Cells[2].Value = presenter1.addOrderView.txtAddress.Text;
            newDataRow.Cells[3].Value = presenter1.addOrderView.dateTimePicker1.Text;
            newDataRow.Cells[4].Value = presenter1.addOrderView.txtStatus.Text;
            newDataRow.Cells[5].Value = presenter1.addOrderView.txtPieces.Text;
            newDataRow.Cells[6].Value = presenter1.addOrderView.txtValue.Text;
            newDataRow.Cells[7].Value = presenter1.addOrderView.txtProductID.Text;
            try
            {
                Order order = new Order();
                order.ID = Convert.ToInt32(presenter1.addOrderView.txtID.Text);
                order.Customer = presenter1.addOrderView.txtCustomer.Text;
                order.Address = presenter1.addOrderView.txtAddress.Text;
                order.DeliveryDate = presenter1.addOrderView.dateTimePicker1.Value;
                order.Status = presenter1.addOrderView.txtStatus.Text;
                order.Pieces = Convert.ToInt32(presenter1.addOrderView.txtPieces.Text);
                order.Value = Convert.ToInt32(presenter1.addOrderView.txtValue.Text);
                order.ProductID = Convert.ToInt32(presenter1.addOrderView.txtProductID.Text);


                IDBManager db = new MySQLDBManager();
                db.AddOrder(order);
                BindingSource bindingsource = new BindingSource();
                presenter1.addOrderView.dataGridView1.DataSource = null;
                presenter1.addOrderView.dataGridView1.DataSource = bindingsource;
                presenter1.addOrderView.dataGridView1.Refresh();
                con = new MySqlConnection();
                con.ConnectionString = @"datasource=127.0.0.1;port=3306;username=root;password=;database=assigment1;Convert Zero Datetime=True;";
                con.Open();
                adapt = new MySqlDataAdapter("SELECT `id`, `customer`, `address`, `delivery_date`, `status`, `pieces`, `value`, `product_id` FROM `order` ", con);
                ds = new System.Data.DataSet();
                adapt.Fill(ds, "Order_Details");
                presenter1.addOrderView.dataGridView1.DataSource = ds.Tables[0];
                MessageBox.Show("Added!", "Add", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }


        public void LoadAddOrder(){
            try
            {
                con = new MySqlConnection();
                con.ConnectionString = @"datasource=127.0.0.1;port=3306;username=root;password=;database=assigment1;Convert Zero Datetime=True;";
                con.Open();
                adapt = new MySqlDataAdapter("SELECT `id`, `customer`, `address`, `delivery_date`, `status`, `pieces`, `value`, `product_id` FROM `order` ", con);
                ds = new System.Data.DataSet();
                adapt.Fill(ds, "Order_Details");
                presenter1.addOrderView.dataGridView1.DataSource = ds.Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
