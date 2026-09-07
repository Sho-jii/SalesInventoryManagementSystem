using System;
using System.Collections.Generic;
using System.Data;

namespace Sales_Inventory_Management
{
    public class CategoriesData
    {
        public int ID { set; get; }
        public string Category { set; get; }
        public string Date { set; get; }

        public List<CategoriesData> AllCategoriesData()
        {
            List<CategoriesData> listData = new List<CategoriesData>();
            string selectData = "SELECT id, category, date FROM categories";
            DataTable table = Database.ExecuteQuery(selectData);

            foreach (DataRow row in table.Rows)
            {
                CategoriesData cData = new CategoriesData
                {
                    ID = Convert.ToInt32(row["id"]),
                    Category = row["category"]?.ToString(),
                    Date = row["date"]?.ToString()
                };
                listData.Add(cData);
            }

            return listData;
        }
    }
}
