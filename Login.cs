using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Runtime.InteropServices;
namespace Sales_Inventory_Management
{
    public partial class Login : Form
    {
        public static string usernameData;
        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Jarib\Documents\inventory.mdf;Integrated Security=True;Connect Timeout=30");
        public Login()
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
        public bool checkConnection()
        {
            if (conn.State == ConnectionState.Closed)
            {
                return true;
            }
            else
            {
                return false;
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

        private void showl_CheckedChanged(object sender, EventArgs e)
        {
            txtpass1.PasswordChar = showl.Checked ? '\0' : '*';
        }

        private void btnlogin_Click(object sender, EventArgs e)
        {
            if (checkConnection())
            {
                try
                {
                    conn.Open();

                    string selectData = "SELECT COUNT(*) FROM userss WHERE username = @usern AND password = @pass AND status = @status";

                    using (SqlCommand cmd = new SqlCommand(selectData, conn))
                    {
                        cmd.Parameters.AddWithValue("@usern", txtlogin.Text.Trim());
                        cmd.Parameters.AddWithValue("@pass", txtpass1.Text.Trim());
                        cmd.Parameters.AddWithValue("@status", "Active");

                        int rowCount = (int)cmd.ExecuteScalar();

                        if (rowCount > 0)
                        {
                            string selectRole = "SELECT role FROM userss WHERE username = @usern AND password = @pass";

                            using (SqlCommand getRole = new SqlCommand(selectRole, conn))
                            {
                                getRole.Parameters.AddWithValue("@usern", txtlogin.Text.Trim());
                                getRole.Parameters.AddWithValue("@pass", txtpass1.Text.Trim());
                                string userRole = getRole.ExecuteScalar() as string;

                                MessageBox.Show("Login Successfully!"
                                   , "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                if (userRole == "Admin")
                                {
                                    usernameData = txtlogin.Text;
                                    MainForm mfrm = new MainForm(usernameData);
                                    mfrm.Show();
                                    this.Hide();
                                }
                                else if (userRole == "Cashier")
                                {
                                    usernameData = txtlogin.Text;
                                    CashierMainForm cmForm = new CashierMainForm(usernameData);
                                    cmForm.Show();
                                    this.Hide();
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("Incorrect username/password or there's no admin approval."
                                    , "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Connection Failed." + ex
                                    , "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    conn.Close();
                }
            }
        }
        private void btnclear_Click(object sender, EventArgs e)
        {
            txtlogin.Text = "";
            txtpass1.Text = "";
        }
        private void signup_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Register RegisterForm = new Register();
            RegisterForm.Show();
            this.Hide();
        }
    }
}
