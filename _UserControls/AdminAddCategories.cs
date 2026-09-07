using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace Sales_Inventory_Management
{
    public partial class AdminAddCategories : UserControl
    {
        private int getID = 0;

        public AdminAddCategories()
        {
            InitializeComponent();
            if (Database.IsDesignMode()) return;
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

        public void clearFields()
        {
            addCategories_category.Clear();
            getID = 0;
        }

        private void addCategories_addBtn_Click(object sender, EventArgs e)
        {
            string categoryName = addCategories_category.Text.Trim();

            if (string.IsNullOrEmpty(categoryName))
            {
                MessageBox.Show("Please enter a category name.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string checkCat = "SELECT COUNT(*) FROM categories WHERE category = @cat";
                var checkParams = new Dictionary<string, object> { { "@cat", categoryName } };
                int count = Convert.ToInt32(Database.ExecuteScalar(checkCat, checkParams));

                if (count > 0)
                {
                    MessageBox.Show($"Category '{categoryName}' already exists.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string insertData = "INSERT INTO categories (category, date) VALUES (@cat, @date)";
                var insertParams = new Dictionary<string, object>
                {
                    { "@cat", categoryName },
                    { "@date", DateTime.Today }
                };

                Database.ExecuteNonQuery(insertData, insertParams);
                clearFields();
                displayCategoriesData();

                MessageBox.Show("Category added successfully!", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding category: " + ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void addCategories_updateBtns_Click(object sender, EventArgs e)
        {
            string categoryName = addCategories_category.Text.Trim();

            if (string.IsNullOrEmpty(categoryName) || getID == 0)
            {
                MessageBox.Show("Please select a category from the table to update.", "Validation Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Are you sure you want to update this category?", "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    string checkCat = "SELECT COUNT(*) FROM categories WHERE category = @cat AND id <> @id";
                    var checkParams = new Dictionary<string, object>
                    {
                        { "@cat", categoryName },
                        { "@id", getID }
                    };
                    int count = Convert.ToInt32(Database.ExecuteScalar(checkCat, checkParams));

                    if (count > 0)
                    {
                        MessageBox.Show($"Category '{categoryName}' already exists.", "Validation Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    string updateData = "UPDATE categories SET category = @cat WHERE id = @id";
                    var parameters = new Dictionary<string, object>
                    {
                        { "@cat", categoryName },
                        { "@id", getID }
                    };

                    Database.ExecuteNonQuery(updateData, parameters);
                    clearFields();
                    displayCategoriesData();

                    MessageBox.Show("Category updated successfully!", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error updating category: " + ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void addCategories_removeBtns_Click(object sender, EventArgs e)
        {
            if (getID == 0)
            {
                MessageBox.Show("Please select a category from the table to remove.", "Validation Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Are you sure you want to remove this category?", "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    string removeData = "DELETE FROM categories WHERE id = @id";
                    var parameters = new Dictionary<string, object> { { "@id", getID } };

                    Database.ExecuteNonQuery(removeData, parameters);
                    clearFields();
                    displayCategoriesData();

                    MessageBox.Show("Category removed successfully!", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error removing category: " + ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void addCategories_clearBtns_Click(object sender, EventArgs e)
        {
            clearFields();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < addCategory_dgv.Rows.Count)
            {
                DataGridViewRow row = addCategory_dgv.Rows[e.RowIndex];
                if (row.Cells[0].Value != null && int.TryParse(row.Cells[0].Value.ToString(), out int id))
                {
                    getID = id;
                    addCategories_category.Text = row.Cells[1].Value?.ToString() ?? "";
                }
            }
        }

        private void AdminAddCategories_Load(object sender, EventArgs e)
        {
            displayCategoriesData();
        }

        private void AdminAddCategories_Enter(object sender, EventArgs e)
        {
            displayCategoriesData();
        }

        private void AdminAddCategories_Leave(object sender, EventArgs e)
        {
            clearFields();
        }
    }
}
