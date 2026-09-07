using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Sales_Inventory_Management
{
    public partial class AdminAddProducts : UserControl
    {
        private int getID = 0;

        public AdminAddProducts()
        {
            InitializeComponent();
            displayAllProducts();
            displayAllCategories();
        }

        public void refreshData()
        {
            if (InvokeRequired)
            {
                Invoke((MethodInvoker)refreshData);
                return;
            }
            displayAllProducts();
            displayAllCategories();
        }

        public void displayAllCategories()
        {
            try
            {
                addProducts_category.Items.Clear();
                string selectCategories = "SELECT category FROM categories";
                DataTable dt = Database.ExecuteQuery(selectCategories);

                foreach (DataRow row in dt.Rows)
                {
                    addProducts_category.Items.Add(row["category"].ToString());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error loading categories: " + ex.Message);
            }
        }

        public void displayAllProducts()
        {
            AddProductsData apData = new AddProductsData();
            List<AddProductsData> listData = apData.AllProductsData();
            addProducts_dgv.DataSource = listData;
        }

        public void clearFields()
        {
            addProducts_prodID.Clear();
            addProducts_prodName.Clear();
            addProducts_category.SelectedIndex = -1;
            addProducts_price.Clear();
            addProducts_stock.Clear();
            addProducts_status.SelectedIndex = -1;
            addProducts_imageView.ImageLocation = null;
            addProducts_imageView.Image = null;
            getID = 0;
        }

        public bool emptyFields()
        {
            return string.IsNullOrWhiteSpace(addProducts_prodID.Text)
                || string.IsNullOrWhiteSpace(addProducts_prodName.Text)
                || addProducts_category.SelectedIndex == -1
                || string.IsNullOrWhiteSpace(addProducts_price.Text)
                || string.IsNullOrWhiteSpace(addProducts_stock.Text)
                || addProducts_status.SelectedIndex == -1;
        }

        private void addProducts_addBtn_Click(object sender, EventArgs e)
        {
            if (emptyFields())
            {
                MessageBox.Show("Please fill all empty fields.", "Validation Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!float.TryParse(addProducts_price.Text.Trim(), out float price))
            {
                MessageBox.Show("Please enter a valid numeric price.", "Validation Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(addProducts_stock.Text.Trim(), out int stock))
            {
                MessageBox.Show("Please enter a valid integer stock quantity.", "Validation Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string prodId = addProducts_prodID.Text.Trim();
            string prodName = addProducts_prodName.Text.Trim();

            try
            {
                string checkProd = "SELECT COUNT(*) FROM products WHERE prod_id = @prodID";
                var checkParams = new Dictionary<string, object> { { "@prodID", prodId } };
                int count = Convert.ToInt32(Database.ExecuteScalar(checkProd, checkParams));

                if (count > 0)
                {
                    MessageBox.Show($"Product ID '{prodId}' already exists.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string destinationPath = "";
                if (!string.IsNullOrEmpty(addProducts_imageView.ImageLocation) && File.Exists(addProducts_imageView.ImageLocation))
                {
                    string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
                    string relativeDir = Path.Combine(baseDirectory, "Product_Directory");
                    if (!Directory.Exists(relativeDir))
                    {
                        Directory.CreateDirectory(relativeDir);
                    }

                    string extension = Path.GetExtension(addProducts_imageView.ImageLocation);
                    destinationPath = Path.Combine(relativeDir, prodId + extension);
                    File.Copy(addProducts_imageView.ImageLocation, destinationPath, true);
                }

                string insertData = @"INSERT INTO products (prod_id, prod_name, category, price, stock, image_path, status, date_insert) 
                                      VALUES (@prodID, @prodName, @cat, @price, @stock, @path, @status, @date)";

                var insertParams = new Dictionary<string, object>
                {
                    { "@prodID", prodId },
                    { "@prodName", prodName },
                    { "@cat", addProducts_category.SelectedItem?.ToString() },
                    { "@price", price },
                    { "@stock", stock },
                    { "@path", destinationPath },
                    { "@status", addProducts_status.SelectedItem?.ToString() },
                    { "@date", DateTime.Today }
                };

                Database.ExecuteNonQuery(insertData, insertParams);
                clearFields();
                displayAllProducts();

                MessageBox.Show("Product added successfully!", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding product: " + ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void addProducts_updateBtn_Click(object sender, EventArgs e)
        {
            if (emptyFields() || getID == 0)
            {
                MessageBox.Show("Please select a product from the table and fill all fields.", "Validation Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!float.TryParse(addProducts_price.Text.Trim(), out float price) || !int.TryParse(addProducts_stock.Text.Trim(), out int stock))
            {
                MessageBox.Show("Please enter valid numeric price and stock values.", "Validation Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show($"Are you sure you want to update Product ID: {addProducts_prodID.Text.Trim()}?", "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    string prodId = addProducts_prodID.Text.Trim();
                    string checkProd = "SELECT COUNT(*) FROM products WHERE prod_id = @prodID AND id <> @id";
                    var checkParams = new Dictionary<string, object>
                    {
                        { "@prodID", prodId },
                        { "@id", getID }
                    };
                    int count = Convert.ToInt32(Database.ExecuteScalar(checkProd, checkParams));

                    if (count > 0)
                    {
                        MessageBox.Show($"Product ID '{prodId}' is already assigned to another product.", "Validation Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    string destinationPath = "";
                    if (!string.IsNullOrEmpty(addProducts_imageView.ImageLocation) && File.Exists(addProducts_imageView.ImageLocation))
                    {
                        string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
                        string relativeDir = Path.Combine(baseDirectory, "Product_Directory");
                        if (!Directory.Exists(relativeDir))
                        {
                            Directory.CreateDirectory(relativeDir);
                        }

                        string extension = Path.GetExtension(addProducts_imageView.ImageLocation);
                        destinationPath = Path.Combine(relativeDir, prodId + extension);

                        if (!string.Equals(Path.GetFullPath(addProducts_imageView.ImageLocation), Path.GetFullPath(destinationPath), StringComparison.OrdinalIgnoreCase))
                        {
                            File.Copy(addProducts_imageView.ImageLocation, destinationPath, true);
                        }
                    }

                    string updateData = @"UPDATE products SET prod_id = @prodID, prod_name = @prodName, category = @cat, 
                                          price = @price, stock = @stock, 
                                          image_path = CASE WHEN @path <> '' THEN @path ELSE image_path END, 
                                          status = @status WHERE id = @id";

                    var parameters = new Dictionary<string, object>
                    {
                        { "@prodID", prodId },
                        { "@prodName", addProducts_prodName.Text.Trim() },
                        { "@cat", addProducts_category.SelectedItem?.ToString() },
                        { "@price", price },
                        { "@stock", stock },
                        { "@path", destinationPath },
                        { "@status", addProducts_status.SelectedItem?.ToString() },
                        { "@id", getID }
                    };

                    Database.ExecuteNonQuery(updateData, parameters);
                    clearFields();
                    displayAllProducts();

                    MessageBox.Show("Product updated successfully!", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error updating product: " + ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void addProducts_removeBtn_Click(object sender, EventArgs e)
        {
            if (getID == 0)
            {
                MessageBox.Show("Please select a product from the table to remove.", "Validation Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show($"Are you sure you want to remove Product ID: {addProducts_prodID.Text.Trim()}?", "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    string deleteData = "DELETE FROM products WHERE id = @id";
                    var parameters = new Dictionary<string, object> { { "@id", getID } };

                    Database.ExecuteNonQuery(deleteData, parameters);
                    clearFields();
                    displayAllProducts();

                    MessageBox.Show("Product removed successfully!", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error removing product: " + ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void addProducts_clearBtn_Click(object sender, EventArgs e)
        {
            clearFields();
        }

        private void addProducts_importBtn_Click(object sender, EventArgs e)
        {
            try
            {
                using (OpenFileDialog dialog = new OpenFileDialog())
                {
                    dialog.Filter = "Image Files (*.jpg;*.png)|*.jpg;*.png";
                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        addProducts_imageView.ImageLocation = dialog.FileName;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error importing image: " + ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void addProducts_dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < addProducts_dgv.Rows.Count)
            {
                DataGridViewRow row = addProducts_dgv.Rows[e.RowIndex];
                if (row.Cells[0].Value != null && int.TryParse(row.Cells[0].Value.ToString(), out int id))
                {
                    getID = id;
                    addProducts_prodID.Text = row.Cells[1].Value?.ToString() ?? "";
                    addProducts_prodName.Text = row.Cells[2].Value?.ToString() ?? "";
                    addProducts_category.Text = row.Cells[3].Value?.ToString() ?? "";
                    addProducts_price.Text = row.Cells[4].Value?.ToString() ?? "";
                    addProducts_stock.Text = row.Cells[5].Value?.ToString() ?? "";
                    addProducts_status.Text = row.Cells[7].Value?.ToString() ?? "";

                    string imagePath = row.Cells[6].Value?.ToString();
                    if (!string.IsNullOrEmpty(imagePath) && File.Exists(imagePath))
                    {
                        addProducts_imageView.ImageLocation = imagePath;
                    }
                    else
                    {
                        addProducts_imageView.ImageLocation = null;
                        addProducts_imageView.Image = null;
                    }
                }
            }
        }

        private void AdminAddProducts_Load(object sender, EventArgs e)
        {
            displayAllProducts();
            displayAllCategories();
        }

        private void AdminAddProducts_Enter(object sender, EventArgs e)
        {
            displayAllProducts();
            displayAllCategories();
        }
    }
}
