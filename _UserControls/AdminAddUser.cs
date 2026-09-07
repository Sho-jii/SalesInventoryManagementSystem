using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace Sales_Inventory_Management
{
    public partial class AdminAddUser : UserControl
    {
        private UsersData uData = new UsersData();
        private int getID = 0;

        public AdminAddUser()
        {
            InitializeComponent();
            if (Database.IsDesignMode()) return;
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

        public void displayAllUsersData()
        {
            List<UsersData> listdata = uData.AllUsersData();
            addUser_dgv.DataSource = listdata;
        }

        public void clearFields()
        {
            addUsers_username.Clear();
            addUsers_password.Clear();
            addUsers_role.SelectedIndex = -1;
            addUsers_status.SelectedIndex = -1;
            getID = 0;
        }

        private bool emptyFields()
        {
            return string.IsNullOrWhiteSpace(addUsers_username.Text)
                || string.IsNullOrWhiteSpace(addUsers_password.Text)
                || addUsers_role.SelectedIndex == -1
                || addUsers_status.SelectedIndex == -1;
        }

        private void addUsers_addBtns_Click(object sender, EventArgs e)
        {
            if (emptyFields())
            {
                MessageBox.Show("Please fill all empty fields.", "Validation Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string username = addUsers_username.Text.Trim();
            string password = addUsers_password.Text.Trim();
            string role = addUsers_role.SelectedItem?.ToString();
            string status = addUsers_status.SelectedItem?.ToString();

            try
            {
                string checkUsername = "SELECT COUNT(*) FROM userss WHERE username = @usern";
                var checkParams = new Dictionary<string, object> { { "@usern", username } };
                int count = Convert.ToInt32(Database.ExecuteScalar(checkUsername, checkParams));

                if (count > 0)
                {
                    MessageBox.Show($"Username '{username}' is already taken.", "Validation Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string insertData = "INSERT INTO userss (username, password, role, status, date) VALUES (@usern, @pass, @role, @status, @date)";
                var insertParams = new Dictionary<string, object>
                {
                    { "@usern", username },
                    { "@pass", password },
                    { "@role", role },
                    { "@status", status },
                    { "@date", DateTime.Today }
                };

                Database.ExecuteNonQuery(insertData, insertParams);
                clearFields();
                displayAllUsersData();

                MessageBox.Show("User added successfully!", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding user: " + ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void addUsers_updateBtns_Click(object sender, EventArgs e)
        {
            if (emptyFields() || getID == 0)
            {
                MessageBox.Show("Please select a user from the table and fill all fields.", "Validation Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Are you sure you want to update this user?", "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    string username = addUsers_username.Text.Trim();
                    string checkUsername = "SELECT COUNT(*) FROM userss WHERE username = @usern AND id <> @id";
                    var checkParams = new Dictionary<string, object>
                    {
                        { "@usern", username },
                        { "@id", getID }
                    };
                    int count = Convert.ToInt32(Database.ExecuteScalar(checkUsername, checkParams));

                    if (count > 0)
                    {
                        MessageBox.Show($"Username '{username}' is already taken by another account.", "Validation Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    string updateData = "UPDATE userss SET username = @usern, password = @pass, role = @role, status = @status WHERE id = @id";
                    var parameters = new Dictionary<string, object>
                    {
                        { "@usern", username },
                        { "@pass", addUsers_password.Text.Trim() },
                        { "@role", addUsers_role.SelectedItem?.ToString() },
                        { "@status", addUsers_status.SelectedItem?.ToString() },
                        { "@id", getID }
                    };

                    Database.ExecuteNonQuery(updateData, parameters);
                    clearFields();
                    displayAllUsersData();

                    MessageBox.Show("User updated successfully!", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error updating user: " + ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void addUsers_removeBtns_Click(object sender, EventArgs e)
        {
            if (getID == 0)
            {
                MessageBox.Show("Please select a user to remove.", "Validation Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Are you sure you want to remove this user?", "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    string deleteData = "DELETE FROM userss WHERE id = @id";
                    var parameters = new Dictionary<string, object> { { "@id", getID } };

                    Database.ExecuteNonQuery(deleteData, parameters);
                    clearFields();
                    displayAllUsersData();

                    MessageBox.Show("User removed successfully!", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error removing user: " + ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void clear_btn_Click(object sender, EventArgs e)
        {
            clearFields();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < addUser_dgv.Rows.Count)
            {
                DataGridViewRow row = addUser_dgv.Rows[e.RowIndex];
                if (row.Cells[0].Value != null && int.TryParse(row.Cells[0].Value.ToString(), out int id))
                {
                    getID = id;
                    addUsers_username.Text = row.Cells[1].Value?.ToString() ?? "";
                    addUsers_password.Text = row.Cells[2].Value?.ToString() ?? "";
                    addUsers_role.Text = row.Cells[3].Value?.ToString() ?? "";
                    addUsers_status.Text = row.Cells[4].Value?.ToString() ?? "";
                }
            }
        }
    }
}
