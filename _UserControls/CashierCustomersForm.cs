using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Sales_Inventory_Management
{
    public partial class CashierCustomersForm : UserControl
    {
        public CashierCustomersForm()
        {
            InitializeComponent();
            displayCustomers();
        }

        public void refreshData()
        {
            if (InvokeRequired)
            {
                Invoke((MethodInvoker)refreshData);
                return;
            }
            displayCustomers();
        }

        public void displayCustomers()
        {
            CustomersData cData = new CustomersData();
            List<CustomersData> listData = cData.AllCustomers();
            allCustomers_dgv.DataSource = listData;
        }
    }
}
