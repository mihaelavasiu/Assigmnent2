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
using Assigment1.Presenter;

namespace Assigment1
{
    public partial class CrudForm : Form
    {
        public CrudFormPresenter Presenter { get; set; }
        int indexRow;
        
        public CrudForm()
        {
            InitializeComponent();
            Presenter = new CrudFormPresenter(this);
        }

        private void lblPassword_Click(object sender, EventArgs e)
        {

        }

        private void txtSize_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void CrudForm_Load(object sender, EventArgs e)
        {
            Presenter.CrudForm_Load();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Presenter.btnAdd_Click();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Presenter.button3_Click();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Presenter.button1_Click();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Presenter.button2_Click();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            indexRow = e.RowIndex; // get the selected Row Index
            DataGridViewRow row = dataGridView1.Rows[indexRow];

            txtID.Text = row.Cells[0].Value.ToString();
            txtFirstName.Text = row.Cells[1].Value.ToString();
            txtLastName.Text = row.Cells[2].Value.ToString();
            txtSex.Text = row.Cells[3].Value.ToString();
            txtAge.Text = row.Cells[4].Value.ToString();
        }
    }
}
