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

namespace Sales_Inventory_Management
{
    public partial class AdminAddCategories : UserControl
    {
        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Jarib\Documents\inventory.mdf;Integrated Security=True;Connect Timeout=30");
        
        public AdminAddCategories()
        {
            InitializeComponent();
            displayCategoriesData();
        }

        public void refreshData()
        {
            if (InvokeRequired)
            {
                Invoke((MethodInvoker)refreshData);
                return;
            }
            displayCategoriesData();
        }

        public void displayCategoriesData()
        {
            CategoriesData cData = new CategoriesData();
            List<CategoriesData> listData = cData.AllCategoriesData();

            addCategory_dgv.DataSource = listData;
        }
        public bool checkConnection()
        {
            if (conn.State == ConnectionState.Closed)         
                return true;
            else           
                return false;           
        }

        public void clearFields()
        {
            addCategories_category.Text = "";
        }

        private int getID = 0;

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                DataGridViewRow row = addCategory_dgv.Rows[e.RowIndex];

                getID = (int)row.Cells[0].Value;

                addCategories_category.Text = row.Cells[1].Value.ToString();
            }
        }

        private void AdminAddCategories_Leave(object sender, EventArgs e)
        {
            AdminAddCategories_Load(this, null);
        }

        private void AdminAddCategories_Load(object sender, EventArgs e)
        {

        }

        private void AdminAddCategories_Enter(object sender, EventArgs e)
        {
            AdminAddCategories_Load(this, null);
        }

        private void addCategories_addBtn_Click(object sender, EventArgs e)
        {
            if (addCategories_category.Text == "")
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

                        string checkCat = "SELECT * FROM categories WHERE category = @cat";

                        using (SqlCommand cmd = new SqlCommand(checkCat, conn))
                        {
                            cmd.Parameters.AddWithValue("@cat", addCategories_category.Text.Trim());

                            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                            DataTable table = new DataTable();
                            adapter.Fill(table);

                            if (table.Rows.Count > 0)
                            {
                                MessageBox.Show("Category: " + addCategories_category.Text.Trim()
                                    + " is already exist.", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else
                            {
                                string insertData = "INSERT INTO categories (category, date) " + "VALUES (@cat, @date)";
                                using (SqlCommand insertD = new SqlCommand(insertData, conn))
                                {
                                    insertD.Parameters.AddWithValue("@cat", addCategories_category.Text.Trim());
                                    DateTime today = DateTime.Now;
                                    insertD.Parameters.AddWithValue("@date", today);

                                    insertD.ExecuteNonQuery();
                                    clearFields();
                                    displayCategoriesData();


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
        private void addCategories_updateBtns_Click(object sender, EventArgs e)
        {
            if (addCategories_category.Text == "")
            {
                MessageBox.Show("Empty fields", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (MessageBox.Show("Are you sure you want to Update Cat ID:" + getID + "?", "Confirmation Message"
                    , MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (checkConnection())
                    {
                        try
                        {
                            conn.Open();


                            string updateData = "UPDATE categories SET category = @cat WHERE id = @id";
                            using (SqlCommand updateD = new SqlCommand(updateData, conn))
                            {
                                updateD.Parameters.AddWithValue("@cat", addCategories_category.Text.Trim());
                                updateD.Parameters.AddWithValue("@id", getID);

                                updateD.ExecuteNonQuery();
                                clearFields();
                                displayCategoriesData();


                                MessageBox.Show("Updated successfully!", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
        private void addCategories_removeBtns_Click(object sender, EventArgs e)
        {
            if (addCategories_category.Text == "")
            {
                MessageBox.Show("Empty fields", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (MessageBox.Show("Are you sure you want to Remove Cat ID:" + getID + "?", "Confirmation Message"
                    , MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (checkConnection())
                    {
                        try
                        {
                            conn.Open();


                            string removeData = "DELETE FROM categories WHERE id = @id";
                            using (SqlCommand deleteD = new SqlCommand(removeData, conn))
                            {
                                deleteD.Parameters.AddWithValue("@id", getID);

                                deleteD.ExecuteNonQuery();
                                clearFields();
                                displayCategoriesData();


                                MessageBox.Show("Removed successfully!", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
        private void addCategories_clearBtns_Click(object sender, EventArgs e)
        {
            clearFields();
        }
    }
}
