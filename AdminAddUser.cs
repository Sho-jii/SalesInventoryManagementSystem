using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Sales_Inventory_Management
{
    public partial class AdminAddUser : UserControl
    {
        public AdminAddUser()
        {
            InitializeComponent();
            displayAllUsersData();
        }

        public void refreshData()
        {
            if (InvokeRequired)
            {
                Invoke((MethodInvoker)refreshData);
                return;
            }
            displayAllUsersData();
        }

        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Jarib\Documents\inventory.mdf;Integrated Security=True;Connect Timeout=30");

        public void displayAllUsersData()
        {
            UsersData uData = new UsersData();

            List<UsersData> listdata = uData.AllUsersData();

            addUser_dgv.DataSource = listdata;
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

        public void clearFields()
        {
            addUsers_username.Text = "";
            addUsers_password.Text = "";
            addUsers_role.SelectedIndex = -1;
            addUsers_status.SelectedIndex = -1;
        }
        private int getID = 0;

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                DataGridViewRow row = addUser_dgv.Rows[e.RowIndex];

                getID = (int)row.Cells[0].Value;
                string username = row.Cells[1].Value.ToString();
                string password = row.Cells[2].Value.ToString();
                string status = row.Cells[3].Value.ToString();

                addUsers_username.Text = username;
                addUsers_password.Text = password;
                addUsers_status.Text = status;
            }
        }
        private void addUsers_addBtns_Click(object sender, EventArgs e)
        {
            if (addUsers_username.Text == "" || addUsers_password.Text == ""
                || addUsers_role.SelectedIndex == -1 || addUsers_status.SelectedIndex == -1)
            {
                MessageBox.Show("Empty fields", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                            cmd.Parameters.AddWithValue("@usern", addUsers_username.Text.Trim());

                            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                            DataTable table = new DataTable();
                            adapter.Fill(table);

                            if (table.Rows.Count > 0)
                            {
                                MessageBox.Show(addUsers_username.Text.Trim()
                                    + " is already taken.", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else
                            {
                                string insertData = "INSERT INTO userss (username, password, role, status, date) " +
                                                    "VALUES (@usern, @pass, @role, @status, @date)";
                                using (SqlCommand insertD = new SqlCommand(insertData, conn))
                                {
                                    insertD.Parameters.AddWithValue("@usern", addUsers_username.Text.Trim());
                                    insertD.Parameters.AddWithValue("@pass", addUsers_password.Text.Trim());
                                    insertD.Parameters.AddWithValue("@role", addUsers_role.SelectedItem.ToString());
                                    insertD.Parameters.AddWithValue("@status", addUsers_status.SelectedItem.ToString());

                                    DateTime today = DateTime.Now;
                                    insertD.Parameters.AddWithValue("@date", today);

                                    insertD.ExecuteNonQuery();
                                    clearFields();
                                    displayAllUsersData();

                                    MessageBox.Show("Added successfully!", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Connection failed: " + ex, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        conn.Close();
                    }
                }
            }
        }
        private void addUsers_updateBtns_Click(object sender, EventArgs e)
        {
            if (addUsers_username.Text == "" || addUsers_password.Text == ""
               || addUsers_role.SelectedIndex == -1 || addUsers_status.SelectedIndex == -1)
            {
                MessageBox.Show("Empty fields", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (MessageBox.Show("Are you sure you want to Update User ID:" + getID + "?", "Confirmation Message"
                    , MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (checkConnection())
                    {
                        try
                        {
                            conn.Open();

                            string updateData = "UPDATE userss SET username = @usern, " +
                                "password = @pass, role = @role, status = @status WHERE id = @id";

                            using (SqlCommand updateD = new SqlCommand(updateData, conn))
                            {
                                updateD.Parameters.AddWithValue("@usern", addUsers_username.Text.Trim());
                                updateD.Parameters.AddWithValue("@pass", addUsers_password.Text.Trim());
                                updateD.Parameters.AddWithValue("@role", addUsers_role.SelectedItem);
                                updateD.Parameters.AddWithValue("@status", addUsers_status.SelectedItem);
                                updateD.Parameters.AddWithValue("@id", getID);

                                updateD.ExecuteNonQuery();
                                clearFields();
                                displayAllUsersData();

                                MessageBox.Show("Updated Successfully!", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Connection failed: " + ex, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        finally
                        {
                            conn.Close();
                        }
                    }
                }
            }
        }
        private void addUsers_removeBtns_Click(object sender, EventArgs e)
        {
            if (addUsers_username.Text == "" || addUsers_password.Text == ""
             || addUsers_role.SelectedIndex == -1 || addUsers_status.SelectedIndex == -1)
            {
                MessageBox.Show("Empty fields", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (MessageBox.Show("Are you sure you want to Remove User ID:" + getID + "?", "Confirmation Message"
                    , MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (checkConnection())
                    {
                        try
                        {
                            conn.Open();

                            string updateData = "DELETE FROM userss WHERE id = @id";

                            using (SqlCommand updateD = new SqlCommand(updateData, conn))
                            {
                                updateD.Parameters.AddWithValue("@id", getID);
                                updateD.ExecuteNonQuery();

                                clearFields();
                                displayAllUsersData();

                                MessageBox.Show("Removed Successfully!", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Connection failed: " + ex, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        finally
                        {
                            conn.Close();
                        }
                    }
                }
            }
        }
        private void clear_btn_Click(object sender, EventArgs e)
        {
            clearFields();
        }
    }
}
