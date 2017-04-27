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
    public class CrudFormModel
    {
        public CrudFormPresenter presenter1;
        MySqlConnection con;
        MySqlDataAdapter adapt;
        DataSet ds;
        int selectedRow;
        int indexRow;
        public CrudFormModel(CrudFormPresenter presenter1)
           {
            this.presenter1 = presenter1;
           
           }
        public void CrudForm_Load()
        {
            try
            {
                con = new MySqlConnection();
                con.ConnectionString = @"datasource=127.0.0.1;port=3306;username=root;password=;database=assigment1;Convert Zero Datetime=True;";
                con.Open();
                adapt = new MySqlDataAdapter("select id,first_name,last_name,sex,age from employees", con);
                ds = new System.Data.DataSet();
                adapt.Fill(ds, "Employee_Details");
                presenter1.crudFormView.dataGridView1.DataSource = ds.Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void btnAdd_Click()
        {
            try
            {
                Employee employee = new Employee();
                employee.ID = Convert.ToInt32(presenter1.crudFormView.txtID.Text);
                employee.FistName = presenter1.crudFormView.txtFirstName.Text;
                employee.LastName = presenter1.crudFormView.txtLastName.Text;
                employee.Sex = presenter1.crudFormView.txtSex.Text;
                employee.Age = Convert.ToInt32(presenter1.crudFormView.txtAge.Text);

                IDBManager db = new MySQLDBManager();
                db.AddEmployee(employee);
                BindingSource bindingsource = new BindingSource();
                presenter1.crudFormView.dataGridView1.DataSource = null;
                presenter1.crudFormView.dataGridView1.DataSource = bindingsource;
                presenter1.crudFormView.dataGridView1.Refresh();
                con = new MySqlConnection();
                con.ConnectionString = @"datasource=127.0.0.1;port=3306;username=root;password=;database=assigment1;Convert Zero Datetime=True;";
                con.Open();
                adapt = new MySqlDataAdapter("select id,first_name,last_name,sex,age from employees", con);
                ds = new System.Data.DataSet();
                adapt.Fill(ds, "Employee_Details");
                presenter1.crudFormView.dataGridView1.DataSource = ds.Tables[0];
                MessageBox.Show("Created!", "Add", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void button3_Click()
        {
            DataGridViewRow newDataRow = presenter1.crudFormView.dataGridView1.Rows[indexRow];
            newDataRow.Cells[0].Value = presenter1.crudFormView.txtID.Text;
            newDataRow.Cells[1].Value = presenter1.crudFormView.txtFirstName.Text;
            newDataRow.Cells[2].Value = presenter1.crudFormView.txtLastName.Text;
            newDataRow.Cells[3].Value = presenter1.crudFormView.txtSex.Text;
            newDataRow.Cells[4].Value = presenter1.crudFormView.txtAge.Text;
            try
            {
                Employee employee = new Employee();
                employee.ID = Convert.ToInt32(presenter1.crudFormView.txtID.Text);
                employee.FistName = presenter1.crudFormView.txtFirstName.Text;
                employee.LastName = presenter1.crudFormView.txtLastName.Text;
                employee.Sex = presenter1.crudFormView.txtSex.Text;
                employee.Age = Convert.ToInt32(presenter1.crudFormView.txtAge.Text);


                IDBManager db = new MySQLDBManager();
                db.DeleteEmployee(employee);
                BindingSource bindingsource = new BindingSource();
                presenter1.crudFormView.dataGridView1.DataSource = null;
                presenter1.crudFormView.dataGridView1.DataSource = bindingsource;
                presenter1.crudFormView.dataGridView1.Refresh();
                con = new MySqlConnection();
                con.ConnectionString = @"datasource=127.0.0.1;port=3306;username=root;password=;database=assigment1;Convert Zero Datetime=True;";
                con.Open();
                adapt = new MySqlDataAdapter("select id,first_name,last_name,sex,age from employees", con);
                ds = new System.Data.DataSet();
                adapt.Fill(ds, "Employee_Details");
                presenter1.crudFormView.dataGridView1.DataSource = ds.Tables[0];
                MessageBox.Show("Deleted!", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void button1_Click()
        {
            try
            {

                BindingSource bindingsource = new BindingSource();
                presenter1.crudFormView.dataGridView1.DataSource = null;
                presenter1.crudFormView.dataGridView1.DataSource = bindingsource;
                presenter1.crudFormView.dataGridView1.Refresh();
                con = new MySqlConnection();
                con.ConnectionString = @"datasource=127.0.0.1;port=3306;username=root;password=;database=assigment1;Convert Zero Datetime=True;";
                con.Open();
                adapt = new MySqlDataAdapter("select id,first_name,last_name,sex,age from employees", con);
                ds = new System.Data.DataSet();
                adapt.Fill(ds, "Employee_Details");
                presenter1.crudFormView.dataGridView1.DataSource = ds.Tables[0];
                MessageBox.Show("Refreshed!", "Refresh", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public  void button2_Click()
        {
            DataGridViewRow newDataRow = presenter1.crudFormView.dataGridView1.Rows[indexRow];
            newDataRow.Cells[0].Value = presenter1.crudFormView.txtID.Text;
            newDataRow.Cells[1].Value = presenter1.crudFormView.txtFirstName.Text;
            newDataRow.Cells[2].Value = presenter1.crudFormView.txtLastName.Text;
            newDataRow.Cells[3].Value = presenter1.crudFormView.txtSex.Text;
            newDataRow.Cells[4].Value = presenter1.crudFormView.txtAge.Text;
            try
            {
                Employee employee = new Employee();
                employee.ID = Convert.ToInt32(presenter1.crudFormView.txtID.Text);
                employee.FistName = presenter1.crudFormView.txtFirstName.Text;
                employee.LastName = presenter1.crudFormView.txtLastName.Text;
                employee.Sex = presenter1.crudFormView.txtSex.Text;
                employee.Age = Convert.ToInt32(presenter1.crudFormView.txtAge.Text);


                IDBManager db = new MySQLDBManager();
                db.UpdateEmployee(employee);
                BindingSource bindingsource = new BindingSource();
                presenter1.crudFormView.dataGridView1.DataSource = null;
                presenter1.crudFormView.dataGridView1.DataSource = bindingsource;
                presenter1.crudFormView.dataGridView1.Refresh();
                con = new MySqlConnection();
                con.ConnectionString = @"datasource=127.0.0.1;port=3306;username=root;password=;database=assigment1;Convert Zero Datetime=True;";
                con.Open();
                adapt = new MySqlDataAdapter("select id,first_name,last_name,sex,age from employees", con);
                ds = new System.Data.DataSet();
                adapt.Fill(ds, "Employee_Details");
                presenter1.crudFormView.dataGridView1.DataSource = ds.Tables[0];
                MessageBox.Show("Updated!", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
