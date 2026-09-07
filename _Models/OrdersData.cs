using System;
using System.Collections.Generic;
using System.Data;

namespace Sales_Inventory_Management
{
    public class OrdersData
    {
        public int ID { set; get; }
        public string CID { set; get; }
        public string PName { set; get; }
        public string Category { set; get; }
        public string OrigPrice { set; get; }
        public string QTY { set; get; }
        public string TotalPrice { set; get; }

        public List<OrdersData> AllOrdersData(int? customerId = null)
        {
            List<OrdersData> listData = new List<OrdersData>();
            int custID = customerId ?? 0;

            if (custID <= 0)
            {
                string selectCustData = "SELECT MAX(customer_id) FROM orders";
                object result = Database.ExecuteScalar(selectCustData);

                if (result != null && result != DBNull.Value && int.TryParse(result.ToString(), out int temp))
                {
                    custID = (temp == 0) ? 1 : temp;
                }
                else
                {
                    custID = 1;
                }
            }

            string selectData = "SELECT id, customer_id, prod_name, category, orig_price, qty, total_price FROM orders WHERE customer_id = @cID";
            var parameters = new Dictionary<string, object> { { "@cID", custID } };
            DataTable table = Database.ExecuteQuery(selectData, parameters);

            foreach (DataRow row in table.Rows)
            {
                OrdersData oData = new OrdersData
                {
                    ID = Convert.ToInt32(row["id"]),
                    CID = row["customer_id"]?.ToString(),
                    PName = row["prod_name"]?.ToString(),
                    Category = row["category"]?.ToString(),
                    OrigPrice = row["orig_price"]?.ToString(),
                    QTY = row["qty"]?.ToString(),
                    TotalPrice = row["total_price"]?.ToString()
                };
                listData.Add(oData);
            }

            return listData;
        }
    }
}
