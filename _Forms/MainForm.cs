using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Sales_Inventory_Management
{
    public partial class MainForm : Form
    {
        public MainForm(string usernameData)
        {
            InitializeComponent();       
            user_username.Text = usernameData.ToUpper();
        }
       
        private void btnexit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to close?", "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
        [DllImport("user32.Dll", EntryPoint = "ReleaseCapture")]
        private static extern void ReleaseCapture();
        [DllImport("user32.Dll", EntryPoint = "SendMessage")]
        private static extern void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void movePanel_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            adminDashboard1.Visible = false;
            adminAddUser1.Visible = false;
            adminAddCategories1.Visible = false;
            adminAddProducts1.Visible = false;
            cashierCustomersForm1.Visible = false;
            dashboard_btn.PerformClick();
        }
        private void dashboard_btn_Click(object sender, EventArgs e)
        {
            adminDashboard1.Visible = true;
            adminDashboard1.BringToFront();

            AdminDashboard adForm = adminDashboard1 as AdminDashboard;
            if (adForm != null)
            {
                adForm.refreshData();
            }
        }
        private void addUsers_btn_Click(object sender, EventArgs e)
        {     
            adminAddUser1.Visible = true;
            adminAddUser1.BringToFront();

            AdminAddUser aauForm = adminAddUser1 as AdminAddUser;
            if (aauForm != null)
            {
                aauForm.refreshData();
            }
        }

        private void addCategories_btn_Click(object sender, EventArgs e)
        { 
            adminAddCategories1.Visible = true;
            adminAddCategories1.BringToFront();

            AdminAddCategories aacForm = adminAddCategories1 as AdminAddCategories;
            if (aacForm != null)
            {
                aacForm.refreshData();
            }
        }

        private void addProducts_btn_Click_1(object sender, EventArgs e)
        {
            adminAddProducts1.Visible = true;
            adminAddProducts1.BringToFront();

            AdminAddProducts aapForm = adminAddProducts1 as AdminAddProducts;
            if (aapForm != null)
            {
                aapForm.refreshData();
            }
        }

        private void customers_btn_Click_1(object sender, EventArgs e)
        {
            cashierCustomersForm1.Visible = true;
            cashierCustomersForm1.BringToFront();

            CashierCustomersForm ccfForm = cashierCustomersForm1 as CashierCustomersForm;
            if (ccfForm != null)
            {
                ccfForm.refreshData();
            }
        }
        private void log_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to logout?", "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Login loginform = new Login();
                loginform.Show();
                this.Hide();
            }
        }
    }
}
