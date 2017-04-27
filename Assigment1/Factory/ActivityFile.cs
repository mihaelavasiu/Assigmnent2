using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assigment1.Factory
{
    public class ActivityFile : IGenerateRaports
    {
        private string connString = "datasource=127.0.0.1;port=3306;username=root;password=;database=assigment1;";
        public void generateReports(Activity activity)
        {
            try
            {
                int id = Convert.ToInt32(activity.id);
                DateTime d1 = activity.d1;
                DateTime d2 = activity.d2;
                StreamWriter File = new StreamWriter("ActivityReport.txt");
                // File.Write("HI\r\n");
                // File.Write("YOu\r\n");

                using (MySqlConnection conn = new MySqlConnection(connString))
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandText = "SELECT `id`, `name`, `description`, `date`, `employee_id` FROM `activities` WHERE employee_id=@id AND date>@d1 AND date<@d2;";
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@d1", d1);
                    cmd.Parameters.AddWithValue("@d2", d2);
                    cmd.Prepare();


                    using (MySqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            string idc = rdr["id"].ToString();
                            string namec = rdr["name"].ToString();
                            string descriptionc = rdr["description"].ToString();
                            File.Write(idc);
                            File.Write("\r\n");
                            File.Write(namec);
                            File.Write("\r\n");
                            File.Write(descriptionc);
                            File.Write("\r\n");
                          

                        }
                    }


                    File.Close();
                }
                MessageBox.Show("Report generated!", "Generate", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
