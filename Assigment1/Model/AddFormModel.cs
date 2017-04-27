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
    public class AddFormModel
    {
        MySqlConnection con;
        MySqlDataAdapter adapt;
        DataSet ds;
        int selectedRow;
        public AddFormPresenter presenter1;

        public AddFormModel(AddFormPresenter presenter1)
        {
            this.presenter1 = presenter1;
           
        }


        public void AddForm()
        {
            try
            {
                Product product = new Product();
                product.Title = presenter1.addFormView.txtTitle.Text;
                product.Description = presenter1.addFormView.txtDescription.Text;
                product.Color = presenter1.addFormView.txtColor.Text;
                product.Size = Convert.ToDouble(presenter1.addFormView.txtSize.Text);
                product.Price = Convert.ToDouble(presenter1.addFormView.txtPrice.Text);
                product.Stock = Convert.ToInt32(presenter1.addFormView.txtSize.Text);

                IDBManager db = new MySQLDBManager();
                db.Create(product);
                BindingSource bindingsource = new BindingSource();
                presenter1.addFormView.dataGridView1.DataSource = null;
                presenter1.addFormView.dataGridView1.DataSource = bindingsource;
                presenter1.addFormView.dataGridView1.Refresh();
                con = new MySqlConnection();
                con.ConnectionString = @"datasource=127.0.0.1;port=3306;username=root;password=;database=assigment1;Convert Zero Datetime=True;";
                con.Open();
                adapt = new MySqlDataAdapter("select title ,description,color,size,price,stock from product", con);
                ds = new System.Data.DataSet();
                adapt.Fill(ds, "Product_Details");
                presenter1.addFormView.dataGridView1.DataSource = ds.Tables[0];
                MessageBox.Show("Created!", "Add", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        public void LoadAddForm(){
            try
            {
                con = new MySqlConnection();
                con.ConnectionString = @"datasource=127.0.0.1;port=3306;username=root;password=;database=assigment1;Convert Zero Datetime=True;";
                con.Open();
                adapt = new MySqlDataAdapter("select title ,description,color,size,price,stock from product", con);
                ds = new System.Data.DataSet();
                adapt.Fill(ds, "Product_Details");
                presenter1.addFormView.dataGridView1.DataSource = ds.Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
