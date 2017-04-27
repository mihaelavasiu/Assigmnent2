using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using MySql.Data.MySqlClient;

namespace Assigment1
{
    public partial class Form1 : Form
    {
        bool first = false;
        private string connString;
        private string GetHashedText(string inputData)
        {
            byte[] tmpSource;
            byte[] tmpData;
            tmpSource = ASCIIEncoding.ASCII.GetBytes(inputData);
            tmpData = new MD5CryptoServiceProvider().ComputeHash(tmpSource);
            return Convert.ToBase64String(tmpData);
        }
        public Form1()
        {
           InitializeComponent();
           textBox2.PasswordChar = '*';
           connString = "datasource=127.0.0.1;port=3306;username=root;password=;database=assigment1;";
           if (first)
           {
               using (MySqlConnection conn = new MySqlConnection(connString))
               {
                   conn.Open();
                   MySqlCommand cmd = new MySqlCommand();
                   cmd.Connection = conn;
                   cmd.CommandText = "INSERT INTO users(username, password,first_name,last_name) VALUES(@user, @pass, @first_name,@last_name)";
                   cmd.Prepare();

                   cmd.Parameters.AddWithValue("@user", "Admin");
                   cmd.Parameters.AddWithValue("@pass", GetHashedText("admin"));
                   cmd.Parameters.AddWithValue("@first_name", "Vasiu");
                   cmd.Parameters.AddWithValue("@last_name", "Mihaela");
                   cmd.ExecuteNonQuery();
               }
           } 
        }

        private void label1_Click(object sender, EventArgs e)
        {
            connString = "datasource=127.0.0.1;port=3306;username=root;password=;database=assigment1;";
           
        }
        

        private void button1_Click(object sender, EventArgs e)
        {
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "SELECT * FROM users where username=@username and password=@password";
                cmd.Prepare();
                cmd.Parameters.AddWithValue("@username", textBox1.Text);
                cmd.Parameters.AddWithValue("@password", GetHashedText(textBox2.Text));
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {               
                    if (textBox1.Text.Equals("admin"))
                    {
                        Admin a = new Admin();
                        a.Show();
                        this.Hide();
                    }
                    else
                    {
                        Form2 f = new Form2();
                        f.Show();
                        this.Hide();
                    }

                }
                else
                {
                    MessageBox.Show("Invalid username or password!", "Login", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Register r = new Register();
            r.Show(); 
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
           // Form2 f = new Form2();
            //f.Show();
            //this.Hide();
        }
    }

