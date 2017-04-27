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
    public partial class DeleteProduct : Form
    {
        MySqlConnection con;
        MySqlDataAdapter adapt;
        DataSet ds;
        int selectedRow;
        private string connString = "datasource=127.0.0.1;port=3306;username=root;password=;database=assigment1;";
        public DeleteProduct()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
                    
            
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
             {
                 DataGridViewRow delrow = dataGridView1.Rows[i];
                 if (delrow.Selected == true)
                  {
                   dataGridView1.Rows.RemoveAt(i);
                     try
                     {
                         using (MySqlConnection conn = new MySqlConnection(connString))
                         {
                             conn.Open();
                             MySqlCommand cmd = new MySqlCommand();
                             cmd.Connection = conn;
                             i = i + 5;
                             cmd.CommandText = "DELETE FROM product WHERE id=" + i + "";
                             
                             cmd.Prepare();

                             cmd.ExecuteNonQuery();
                             MessageBox.Show("Deleted!", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                         }
                       }
                     catch (Exception ex)
                      {
                         MessageBox.Show(ex.ToString());
                      }
                   }
                }
            }
        

        private void DeleteProduct_Load(object sender, EventArgs e)
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }
    }
}
