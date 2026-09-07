using System;
using System.Collections.Generic;
using System.Data;

namespace Sales_Inventory_Management
{
    public class AddProductsData
    {
        public int ID { set; get; }
        public string ProdID { set; get; }
        public string ProdName { set; get; }
        public string Category { set; get; }
        public string Price { set; get; }
        public string Stock { set; get; }
        public string ImagePath { set; get; }
        public string Status { set; get; }
        public string Date { set; get; }

        public List<AddProductsData> AllProductsData()
        {
            List<AddProductsData> listData = new List<AddProductsData>();
            string selectData = "SELECT id, prod_id, prod_name, category, price, stock, image_path, status, date_insert FROM products";
            DataTable table = Database.ExecuteQuery(selectData);

            foreach (DataRow row in table.Rows)
            {
                AddProductsData apData = new AddProductsData
                {
                    ID = Convert.ToInt32(row["id"]),
                    ProdID = row["prod_id"]?.ToString(),
                    ProdName = row["prod_name"]?.ToString(),
                    Category = row["category"]?.ToString(),
                    Price = row["price"]?.ToString(),
                    Stock = row["stock"]?.ToString(),
                    ImagePath = row["image_path"]?.ToString(),
                    Status = row["status"]?.ToString(),
                    Date = row["date_insert"]?.ToString()
                };
                listData.Add(apData);
            }

            return listData;
        }

        public List<AddProductsData> AllAvailableProducts()
        {
            List<AddProductsData> listData = new List<AddProductsData>();
            string selectData = "SELECT id, prod_id, prod_name, category, price, stock, image_path, status, date_insert FROM products WHERE status = @status AND stock > 0";
            var parameters = new Dictionary<string, object> { { "@status", "Available" } };
            DataTable table = Database.ExecuteQuery(selectData, parameters);

            foreach (DataRow row in table.Rows)
            {
                AddProductsData apData = new AddProductsData
                {
                    ID = Convert.ToInt32(row["id"]),
                    ProdID = row["prod_id"]?.ToString(),
                    ProdName = row["prod_name"]?.ToString(),
                    Category = row["category"]?.ToString(),
                    Price = row["price"]?.ToString(),
                    Stock = row["stock"]?.ToString(),
                    ImagePath = row["image_path"]?.ToString(),
                    Status = row["status"]?.ToString(),
                    Date = row["date_insert"]?.ToString()
                };
                listData.Add(apData);
            }

            return listData;
        }
    }
}
