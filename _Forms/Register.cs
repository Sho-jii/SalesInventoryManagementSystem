using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Sales_Inventory_Management
{
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }

        private void btnexit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to exit?", "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
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

        private void btnregister_Click_1(object sender, EventArgs e)
        {
            string username = txtsignin.Text.Trim();
            string password = txtspass.Text.Trim();
            string confirmPassword = txtspass2.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(confirmPassword))
            {
                MessageBox.Show("Please fill all empty fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (password.Length < 8)
            {
                MessageBox.Show("Invalid Password: at least 8 characters are needed.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (password != confirmPassword)
            {
                MessageBox.Show("Passwords do not match.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string checkUsername = "SELECT COUNT(*) FROM userss WHERE username = @usern";
                var checkParams = new Dictionary<string, object> { { "@usern", username } };
                int userCount = Convert.ToInt32(Database.ExecuteScalar(checkUsername, checkParams));

                if (userCount > 0)
                {
                    MessageBox.Show($"Username '{username}' is already taken.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string insertData = "INSERT INTO userss (username, password, role, status, date) VALUES (@usern, @pass, @role, @status, @date)";
                var insertParams = new Dictionary<string, object>
                {
                    { "@usern", username },
                    { "@pass", password },
                    { "@role", "Cashier" },
                    { "@status", "Approval" },
                    { "@date", DateTime.Today }
                };

                Database.ExecuteNonQuery(insertData, insertParams);

                MessageBox.Show("Registered Successfully! Your account is pending admin approval.", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Login loginForm = new Login();
                loginForm.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Registration error: " + ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnclear_Click(object sender, EventArgs e)
        {
            txtsignin.Clear();
            txtspass.Clear();
            txtspass2.Clear();
        }

        private void signin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Login loginForm = new Login();
            loginForm.Show();
            this.Hide();
        }

        private void showr_CheckedChanged(object sender, EventArgs e)
        {
            txtspass.PasswordChar = showr.Checked ? '\0' : '*';
            txtspass2.PasswordChar = showr.Checked ? '\0' : '*';
        }
    }
}
