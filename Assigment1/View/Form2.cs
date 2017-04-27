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
    public partial class Form2 : Form
    {
        MySqlConnection con;
        MySqlDataAdapter adapt;
        DataSet ds;
        public Form2()
        {
            InitializeComponent();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.Show();
            this.Hide();
            MessageBox.Show("Successfully logged out!", "Register", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            View v = new View();
            v.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
           DeleteProduct d = new DeleteProduct();
            d.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            AddForm a = new AddForm();
            a.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            UpdateProduct u = new UpdateProduct();
            u.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            View1 v = new View1();
            v.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UpdateOrder o = new UpdateOrder();
            o.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AddOrder a = new AddOrder();
            a.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Modify m = new Modify();
            m.Show();
        }
    }
}
