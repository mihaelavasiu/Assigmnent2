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
    public partial class AddOrder : Form
    {
        public AddOrderPresenter Presenter { get; set; }
        MySqlConnection con;
        MySqlDataAdapter adapt;
        DataSet ds;
        int selectedRow;
        int indexRow;
       
        public AddOrder()
        {
            InitializeComponent();
            Presenter = new AddOrderPresenter(this);
        }

        private void btnAdd_Click_1(object sender, EventArgs e)
        {
            Presenter.AddOrder();

        }

        private void AddOrder_Load(object sender, EventArgs e)
        {
            Presenter.LoadAddOrder();
        }
    }
}
