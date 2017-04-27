using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Assigment1
{
    public partial class Register : Form
    {
         MySqlConnection con;
        public Register()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try{
                User user = new User();
                user.UserName = txtUserName.Text;
                user.Password = txtPassword.Text;
                user.FistName = txtFirstName.Text;
                user.LastName = textBox1.Text;
                if (!(user.UserName.Equals("admin")))
                {
                    IDBManager db = new MySQLDBManager();
                    db.RegisterUser(user);
                    MessageBox.Show("Successfully registered!", "Register", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Invalid username!!!", "Register", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
    }
}
