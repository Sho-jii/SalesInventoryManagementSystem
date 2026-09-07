using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace Sales_Inventory_Management
{   
    public partial class Register : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Jarib\Documents\inventory.mdf;Integrated Security=True;Connect Timeout=30");

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
        private void btnregister_Click_1(object sender, EventArgs e)
        {
            if (txtsignin.Text == "" || txtspass.Text == "" || txtspass2.Text == "")
            {
                MessageBox.Show("Please fill empty fields.", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (checkConnection())
                {
                    try
                    {
                        conn.Open();

                        string checkUsername = "SELECT * FROM userss WHERE username = @usern";

                        using (SqlCommand cmd = new SqlCommand(checkUsername, conn))
                        {
                            cmd.Parameters.AddWithValue("@usern", txtsignin.Text.Trim());

                            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                            DataTable table = new DataTable();
                            adapter.Fill(table);

                            if (table.Rows.Count > 0)
                            {
                                MessageBox.Show(txtsignin.Text.Trim()
                                    + " is already taken.", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else if (txtspass.Text.Length < 8)
                            {
                                MessageBox.Show("Invalid Password, at least 8 characters are needed."
                                    , "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else if (txtspass.Text.Trim() != txtspass2.Text.Trim())
                            {
                                MessageBox.Show("Password does not match."
                                    , "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else
                            {
                                string insertData = "INSERT INTO userss (username, password, role, status, date) " +
                            "VALUES(@usern, @pass, @role, @status, @date)";

                                using (SqlCommand insertD = new SqlCommand(insertData, conn))
                                {
                                    insertD.Parameters.AddWithValue("@usern", txtsignin.Text.Trim());
                                    insertD.Parameters.AddWithValue("@pass", txtspass.Text.Trim());
                                    insertD.Parameters.AddWithValue("@role", "Cashier");
                                    insertD.Parameters.AddWithValue("@status", "Approval");

                                    DateTime today = DateTime.Today;
                                    insertD.Parameters.AddWithValue("@date", today);

                                    insertD.ExecuteNonQuery();

                                    MessageBox.Show("Registered Successfully!"
                                    , "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                    Login LoginForm = new Login();
                                    LoginForm.Show();

                                    this.Hide();
                                }
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
        }

        private void btnclear_Click(object sender, EventArgs e)
        {
            txtsignin.Text = "";
            txtspass.Text = "";
            txtspass2.Text = "";
        }

        private void signin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Login LoginForm = new Login();
            LoginForm.Show();
            this.Hide();
        }
        private void showr_CheckedChanged(object sender, EventArgs e)
        {
            txtspass.PasswordChar = showr.Checked ? '\0' : '*';
            txtspass2.PasswordChar = showr.Checked ? '\0' : '*';
        }
    }
}
