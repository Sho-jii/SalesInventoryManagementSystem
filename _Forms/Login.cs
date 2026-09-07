using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Sales_Inventory_Management
{
    public partial class Login : Form
    {
        public static string usernameData;

        public Login()
        {
            InitializeComponent();
        }

        [DllImport("user32.Dll", EntryPoint = "ReleaseCapture")]
        private static extern void ReleaseCapture();
        [DllImport("user32.Dll", EntryPoint = "SendMessage")]
        private static extern void SendMessage(IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void movePanel_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnexit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to exit?", "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void showl_CheckedChanged(object sender, EventArgs e)
        {
            txtpass1.PasswordChar = showl.Checked ? '\0' : '*';
        }

        private void btnlogin_Click(object sender, EventArgs e)
        {
            string username = txtlogin.Text.Trim();
            string password = txtpass1.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please fill all empty fields.", "Validation Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string selectData = "SELECT role, status FROM userss WHERE username = @usern AND password = @pass AND status = 'Active'";
                var parameters = new Dictionary<string, object>
                {
                    { "@usern", username },
                    { "@pass", password }
                };

                DataTable dt = Database.ExecuteQuery(selectData, parameters);

                if (dt.Rows.Count > 0)
                {
                    string userRole = dt.Rows[0]["role"]?.ToString();
                    usernameData = username;

                    MessageBox.Show("Login Successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    if (string.Equals(userRole, "Admin", StringComparison.OrdinalIgnoreCase))
                    {
                        MainForm mfrm = new MainForm(usernameData);
                        mfrm.Show();
                        this.Hide();
                    }
                    else if (string.Equals(userRole, "Cashier", StringComparison.OrdinalIgnoreCase))
                    {
                        CashierMainForm cmForm = new CashierMainForm(usernameData);
                        cmForm.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Unknown user role assigned.", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Incorrect username/password or your account is not yet approved.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtpass1.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database connection error: " + ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnclear_Click(object sender, EventArgs e)
        {
            txtlogin.Clear();
            txtpass1.Clear();
        }

        private void signup_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Register registerForm = new Register();
            registerForm.Show();
            this.Hide();
        }
    }
}
