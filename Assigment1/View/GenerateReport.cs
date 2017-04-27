using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using MySql.Data.MySqlClient;
using System.Security.Cryptography;
using System.Data.SqlClient;
using Assigment1.Factory;

namespace Assigment1
{
    public partial class GenerateReport : Form
    {
        private string connString = "datasource=127.0.0.1;port=3306;username=root;password=;database=assigment1;";
        public GenerateReport()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
                int id=Convert.ToInt32(txtID.Text);
                DateTime d1 = dateTimePicker1.Value;
                DateTime d2 = dateTimePicker2.Value;
                IGenerateRaports raport = null;
                Activity activity = new Activity(id, d1, d2);
                GenerateReportFactory factory = new GenerateReportFactory();
                factory.GenerateReports(1, activity);
                factory.GenerateReports(2, activity);

        }

        private void GenerateReport_Load(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
