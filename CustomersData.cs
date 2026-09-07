using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;

namespace Sales_Inventory_Management
{
    internal class CustomersData
    {
        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Jarib\Documents\inventory.mdf;Integrated Security=True;Connect Timeout=30");

        public string CustomerID { set; get; }
        public string TotalPrice { set; get; }
        public string Amount { set; get; }
        public string Change { set; get; }
        public string Date { set; get; }

        public List<CustomersData> allCustomers()
        {
            List<CustomersData> listData = new List<CustomersData>();

            if (conn.State == ConnectionState.Closed)
            {
                try
                {
                    conn.Open();

                    string selectData = "SELECT * FROM customers";

                    using (SqlCommand cmd = new SqlCommand(selectData, conn))
                    {
                        SqlDataReader reader = cmd.ExecuteReader();

                        while (reader.Read())
                        {
                            CustomersData cData = new CustomersData();

                            cData.CustomerID = reader["customer_id"].ToString();
                            cData.TotalPrice = reader["total_price"].ToString();
                            cData.Amount = reader["amount"].ToString();
                            cData.Change = reader["change"].ToString();
                            cData.Date = reader["order_date"].ToString();

                            listData.Add(cData);
                        }
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Connection failed: " + ex, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    conn.Close();
                }
            }

            return listData;         
        }

        public List<CustomersData> allTodayCustomers()
        {
            List<CustomersData> listData = new List<CustomersData>();

            if (conn.State == ConnectionState.Closed)
            {
                try
                {
                    conn.Open();
                    DateTime today = DateTime.Today;

                    string selectData = "SELECT * FROM customers WHERE order_date = @date";

                    using (SqlCommand cmd = new SqlCommand(selectData, conn))
                    {
                        cmd.Parameters.AddWithValue("@date", today);

                        SqlDataReader reader = cmd.ExecuteReader();

                        while (reader.Read())
                        {
                            CustomersData cData = new CustomersData();

                            cData.CustomerID = reader["customer_id"].ToString();
                            cData.TotalPrice = reader["total_price"].ToString();
                            cData.Amount = reader["amount"].ToString();
                            cData.Change = reader["change"].ToString();
                            cData.Date = reader["order_date"].ToString();

                            listData.Add(cData);
                        }
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Connection failed: " + ex, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    conn.Close();
                }
            }

            return listData;
        }
    }
}
