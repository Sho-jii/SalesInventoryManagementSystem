using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Sales_Inventory_Management
{
    public partial class AdminDashboard : UserControl
    {
        public AdminDashboard()
        {
            InitializeComponent();
            if (Database.IsDesignMode()) return;
            displayAllTodayCustomers();
            displayAllCashier();
            displayAllAdmin();
            displayTodaysRevenue();
            displayTotalRevenue();
        }

        public void refreshData()
        {
            if (InvokeRequired)
            {
                Invoke((MethodInvoker)refreshData);
                return;
            }

            displayAllTodayCustomers();
            displayAllCashier();
            displayAllAdmin();
            displayTodaysRevenue();
            displayTotalRevenue();
        }

        public void displayAllTodayCustomers()
        {
            CustomersData cData = new CustomersData();
            List<CustomersData> listData = cData.AllTodayCustomers();
            allTodaysCustomers_dgv.DataSource = listData;
        }

        public void displayAllCashier()
        {
            try
            {
                string selectData = "SELECT COUNT(id) FROM userss WHERE role = 'Cashier' AND status = 'Active'";
                object result = Database.ExecuteScalar(selectData);
                dashboard_AC.Text = (result != null && result != DBNull.Value) ? result.ToString() : "0";
            }
            catch
            {
                dashboard_AC.Text = "0";
            }
        }

        public void displayAllAdmin()
        {
            try
            {
                string selectData = "SELECT COUNT(id) FROM userss WHERE role = 'Admin' AND status = 'Active'";
                object result = Database.ExecuteScalar(selectData);
                dashboard_AU.Text = (result != null && result != DBNull.Value) ? result.ToString() : "0";
            }
            catch
            {
                dashboard_AU.Text = "0";
            }
        }

        public void displayTodaysRevenue()
        {
            try
            {
                string selectData = "SELECT SUM(total_price) FROM customers WHERE order_date = @date";
                var parameters = new Dictionary<string, object> { { "@date", DateTime.Today.Date } };
                object result = Database.ExecuteScalar(selectData, parameters);

                if (result != null && result != DBNull.Value && float.TryParse(result.ToString(), out float rev))
                {
                    dashboard_TI.Text = "₱" + rev.ToString("N2");
                }
                else
                {
                    dashboard_TI.Text = "₱0.00";
                }
            }
            catch
            {
                dashboard_TI.Text = "₱0.00";
            }
        }

        public void displayTotalRevenue()
        {
            try
            {
                string selectData = "SELECT SUM(total_price) FROM customers";
                object result = Database.ExecuteScalar(selectData);

                if (result != null && result != DBNull.Value && float.TryParse(result.ToString(), out float rev))
                {
                    dashboard_totalIncome.Text = "₱" + rev.ToString("N2");
                }
                else
                {
                    dashboard_totalIncome.Text = "₱0.00";
                }
            }
            catch
            {
                dashboard_totalIncome.Text = "₱0.00";
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            // Optional periodic timer tick
        }
    }
}
