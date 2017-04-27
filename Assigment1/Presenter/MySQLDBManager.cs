using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Security.Cryptography;

namespace Assigment1
{
    public class MySQLDBManager : IDBManager
    {
        private string connString;

        public MySQLDBManager()
        {
            connString = "datasource=127.0.0.1;port=3306;username=root;password=;database=assigment1;";
        }
        private string GetHashedText(string inputData)
        {
            byte[] tmpSource;
            byte[] tmpData;
            tmpSource = ASCIIEncoding.ASCII.GetBytes(inputData);
            tmpData = new MD5CryptoServiceProvider().ComputeHash(tmpSource);
            return Convert.ToBase64String(tmpData);
        }
        public void RegisterUser(User user)
        {
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "INSERT INTO users(username, password, first_name, last_name) VALUES(@username, @password, @first_name, @last_name)";
                cmd.Prepare();

                cmd.Parameters.AddWithValue("@username", user.UserName);
                cmd.Parameters.AddWithValue("@password", GetHashedText(user.Password));
                cmd.Parameters.AddWithValue("@first_name",user.FistName );
                cmd.Parameters.AddWithValue("@last_name",user.LastName );
                cmd.ExecuteNonQuery();
            }
        }
        public void Create(Product product)
        {
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "INSERT INTO product(title ,description,color,size,price,stock) VALUES(@title ,@description,@color,@size,@price,@stock)";
                cmd.Prepare();

                cmd.Parameters.AddWithValue("@title", product.Title);
                cmd.Parameters.AddWithValue("@description", product.Description);
                cmd.Parameters.AddWithValue("@color", product.Color);
                cmd.Parameters.AddWithValue("@size", product.Size);
                cmd.Parameters.AddWithValue("@price", product.Price);
                cmd.Parameters.AddWithValue("@stock", product.Stock);
                cmd.ExecuteNonQuery();
            }
        }
        public void Update(Product product)
        {
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "UPDATE product SET description='" + product.Description + "',color='" + product.Color + "',size='" + product.Size 
                    + "',price='" + product.Price + "',stock='" + product.Stock + "' WHERE title='" + product.Title +"';"; 
                cmd.Prepare();
                cmd.ExecuteNonQuery();
            }
        }
        public void UpdateOrder(Order order)
        {
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "UPDATE `order` SET `value`=" + order.Value + ",delivery_date='" + order.DeliveryDate + "',pieces=" + order.Pieces + ",customer='" + order.Customer
                    + "',address='" + order.Address + "',status='" + order.Status + "'where`id`=" + order.ID + ";"; 
                cmd.ExecuteNonQuery();
            }
        }
        public void AddOrder(Order order)
        {
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "INSERT INTO `order`(`id`, `customer`, `address`, `delivery_date`, `status`, `pieces`, `value`, `product_id`) VALUES (@id,@customer,@address,@delivery_date,@status,@pieces,@value,@product_id)";
                cmd.Prepare();

                cmd.Parameters.AddWithValue("@id",order.ID);
                cmd.Parameters.AddWithValue("@customer", order.Customer);
                cmd.Parameters.AddWithValue("@address", order.Address);
                cmd.Parameters.AddWithValue("@delivery_date",order.DeliveryDate);
                cmd.Parameters.AddWithValue("@status", order.Status);
                cmd.Parameters.AddWithValue("@pieces", order.Pieces);
                cmd.Parameters.AddWithValue("@value", order.Value);
                cmd.Parameters.AddWithValue("@product_id", order.ProductID);
                cmd.ExecuteNonQuery();
            }
        }
        public void ModifyOrder(Order order, int addedPieces)
        {
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                int newPieces = order.Pieces + addedPieces;
                int newValue = order.Value + (order.Value / order.Pieces) * addedPieces;
                cmd.CommandText = "UPDATE `order` SET `pieces`=" + newPieces + ",`value`=" + newValue + " WHERE id=" + order.ID;
                cmd.ExecuteNonQuery();
            }
        }
        public void AddEmployee(Employee employee)
        {
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "INSERT INTO `employees`(`id`, `first_name`, `last_name`, `sex`, `age`) VALUES(@id,@first_name,@last_name,@sex,@age)";
                cmd.Prepare();

                cmd.Parameters.AddWithValue("@id", employee.ID);
                cmd.Parameters.AddWithValue("@first_name", employee.FistName);
                cmd.Parameters.AddWithValue("@last_name", employee.LastName);
                cmd.Parameters.AddWithValue("@sex", employee.Sex);
                cmd.Parameters.AddWithValue("@age", employee.Age);
                cmd.ExecuteNonQuery();
            }
        }
        public void UpdateEmployee(Employee employee)
        {
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "UPDATE `employees` SET `first_name`='" + employee.FistName + "',`last_name`='" + employee.LastName + "',`sex`='" + employee.Sex + "',`age`=" + employee.Age + " WHERE id=" + employee.ID + ";";
                cmd.ExecuteNonQuery();
            }
        }
        public void DeleteEmployee(Employee employee)
        {
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "DELETE from `employees` WHERE id=" + employee.ID + ";";
                cmd.ExecuteNonQuery();
            }
        }
        public Product SelectProduct(Product product)
        {
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "SELECT `id`, `title`, `description`, `color`, `size`, `price`, `stock` FROM `product` where title='Test product' ;";
                cmd.Prepare();

                var reader = cmd.ExecuteReader();
                reader.Read();
                string title = reader["title"].ToString();
                string description = reader["description"].ToString();
                string color = reader["color"].ToString();
                double size = reader.GetDouble(reader.GetOrdinal("size"));
                double price = reader.GetDouble(reader.GetOrdinal("price"));
                int stock = reader.GetInt32(reader.GetOrdinal("stock"));
                Product p = new Product();
                p.Title = title;
                p.Description = description;
                p.Color = color;
                p.Size = size;
                p.Price = price;
                p.Stock = stock;
                return p;
            }
        }
    }
}
