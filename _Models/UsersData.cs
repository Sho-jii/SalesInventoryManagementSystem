using System;
using System.Collections.Generic;
using System.Data;

namespace Sales_Inventory_Management
{
    public class UsersData
    {
        public int ID { set; get; }
        public string Username { set; get; }
        public string Password { set; get; }
        public string Role { set; get; }
        public string Status { set; get; }
        public string Date { set; get; }

        public List<UsersData> AllUsersData()
        {
            List<UsersData> listData = new List<UsersData>();
            string selectData = "SELECT id, username, password, role, status, date FROM userss";
            DataTable table = Database.ExecuteQuery(selectData);

            foreach (DataRow row in table.Rows)
            {
                UsersData uData = new UsersData
                {
                    ID = Convert.ToInt32(row["id"]),
                    Username = row["username"]?.ToString(),
                    Password = row["password"]?.ToString(),
                    Role = row["role"]?.ToString(),
                    Status = row["status"]?.ToString(),
                    Date = row["date"]?.ToString()
                };
                listData.Add(uData);
            }

            return listData;
        }
    }
}
