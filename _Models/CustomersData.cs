using System;
using System.Collections.Generic;
using System.Data;

namespace Sales_Inventory_Management
{
    public class CustomersData
    {
        public int ID { set; get; }
        public string CustomerID { set; get; }
        public string TotalPrice { set; get; }
        public string Amount { set; get; }
        public string Change { set; get; }
        public string Date { set; get; }

        public List<CustomersData> AllCustomers()
        {
            List<CustomersData> listData = new List<CustomersData>();
            string selectData = "SELECT id, customer_id, total_price, amount, change, order_date FROM customers";
            DataTable table = Database.ExecuteQuery(selectData);

            foreach (DataRow row in table.Rows)
            {
                CustomersData cData = new CustomersData
                {
                    ID = Convert.ToInt32(row["id"]),
                    CustomerID = row["customer_id"]?.ToString(),
                    TotalPrice = row["total_price"]?.ToString(),
                    Amount = row["amount"]?.ToString(),
                    Change = row["change"]?.ToString(),
                    Date = row["order_date"]?.ToString()
                };
                listData.Add(cData);
            }

            return listData;
        }

        public List<CustomersData> AllTodayCustomers()
        {
            List<CustomersData> listData = new List<CustomersData>();
            string selectData = "SELECT id, customer_id, total_price, amount, change, order_date FROM customers WHERE order_date = @date";
            var parameters = new Dictionary<string, object> { { "@date", DateTime.Today.Date } };
            DataTable table = Database.ExecuteQuery(selectData, parameters);

            foreach (DataRow row in table.Rows)
            {
                CustomersData cData = new CustomersData
                {
                    ID = Convert.ToInt32(row["id"]),
                    CustomerID = row["customer_id"]?.ToString(),
                    TotalPrice = row["total_price"]?.ToString(),
                    Amount = row["amount"]?.ToString(),
                    Change = row["change"]?.ToString(),
                    Date = row["order_date"]?.ToString()
                };
                listData.Add(cData);
            }

            return listData;
        }
    }
}
