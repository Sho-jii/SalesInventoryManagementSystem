using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace Sales_Inventory_Management
{
    public partial class CashierOrder : UserControl
    {
        private float totalPrice = 0;
        private int idGen = 1;
        private int prodID = 0;
        private int rowIndex = 0;

        public CashierOrder()
        {
            InitializeComponent();
            if (Database.IsDesignMode()) return;
            displayAllAvailableProducts();
            displayAllCategories();
            displayOrders();
            displayTotalPrice();
        }

        public void refreshData()
        {
            if (InvokeRequired)
            {
                Invoke((MethodInvoker)refreshData);
                return;
            }
            displayAllAvailableProducts();
            displayAllCategories();
            displayOrders();
            displayTotalPrice();
        }

        public void displayAllAvailableProducts()
        {
            AddProductsData apData = new AddProductsData();
            List<AddProductsData> listData = apData.AllAvailableProducts();
            availableProducts_dgv.DataSource = listData;
        }

        public void displayOrders()
        {
            IDGenerator();
            OrdersData oData = new OrdersData();
            List<OrdersData> listData = oData.AllOrdersData(idGen);
            allOrders_dgv.DataSource = listData;
        }

        public void displayAllCategories()
        {
            try
            {
                cashierOrder_category.Items.Clear();
                string selectData = "SELECT category FROM categories";
                DataTable dt = Database.ExecuteQuery(selectData);

                foreach (DataRow row in dt.Rows)
                {
                    cashierOrder_category.Items.Add(row["category"].ToString());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error loading categories: " + ex.Message);
            }
        }

        private void cashierOrder_category_SelectedIndexChanged(object sender, EventArgs e)
        {
            cashierOrder_prodID.SelectedIndex = -1;
            cashierOrder_prodID.Items.Clear();
            cashierOrder_prodName.Text = "";
            cashierOrder_price.Text = "";

            string selectedValue = cashierOrder_category.SelectedItem as string;

            if (!string.IsNullOrEmpty(selectedValue))
            {
                try
                {
                    string selectData = "SELECT prod_id FROM products WHERE category = @cat AND status = 'Available' AND stock > 0";
                    var parameters = new Dictionary<string, object> { { "@cat", selectedValue } };
                    DataTable dt = Database.ExecuteQuery(selectData, parameters);

                    foreach (DataRow row in dt.Rows)
                    {
                        cashierOrder_prodID.Items.Add(row["prod_id"].ToString());
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error loading product IDs: " + ex.Message);
                }
            }
        }

        private void cashierOrder_prodID_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedValue = cashierOrder_prodID.SelectedItem as string;

            if (!string.IsNullOrEmpty(selectedValue))
            {
                try
                {
                    string selectData = "SELECT prod_name, price FROM products WHERE prod_id = @prodID AND status = 'Available'";
                    var parameters = new Dictionary<string, object> { { "@prodID", selectedValue } };
                    DataTable dt = Database.ExecuteQuery(selectData, parameters);

                    if (dt.Rows.Count > 0)
                    {
                        string prodName = dt.Rows[0]["prod_name"].ToString();
                        float prodPrice = Convert.ToSingle(dt.Rows[0]["price"]);

                        cashierOrder_prodName.Text = prodName;
                        cashierOrder_price.Text = prodPrice.ToString("0.00");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error loading product details: " + ex.Message);
                }
            }
        }

        public void displayTotalPrice()
        {
            IDGenerator();

            try
            {
                string selectData = "SELECT SUM(total_price) FROM orders WHERE customer_id = @cID";
                var parameters = new Dictionary<string, object> { { "@cID", idGen } };
                object result = Database.ExecuteScalar(selectData, parameters);

                if (result != null && result != DBNull.Value && float.TryParse(result.ToString(), out float price))
                {
                    totalPrice = price;
                    cashierOrder_totalPrice.Text = totalPrice.ToString("0.00");
                }
                else
                {
                    totalPrice = 0;
                    cashierOrder_totalPrice.Text = "0.00";
                }
            }
            catch
            {
                totalPrice = 0;
                cashierOrder_totalPrice.Text = "0.00";
            }
        }

        public void IDGenerator()
        {
            try
            {
                string selectData = "SELECT MAX(customer_id) FROM customers";
                object result = Database.ExecuteScalar(selectData);

                if (result != null && result != DBNull.Value && int.TryParse(result.ToString(), out int temp))
                {
                    idGen = (temp == 0) ? 1 : temp + 1;
                }
                else
                {
                    idGen = 1;
                }
            }
            catch
            {
                idGen = 1;
            }
        }

        private void cashierOrder_addBtn_Click(object sender, EventArgs e)
        {
            IDGenerator();

            if (cashierOrder_category.SelectedIndex == -1
                || cashierOrder_prodID.SelectedIndex == -1
                || string.IsNullOrWhiteSpace(cashierOrder_prodName.Text)
                || string.IsNullOrWhiteSpace(cashierOrder_price.Text)
                || cashierOrder_qty.Value <= 0)
            {
                MessageBox.Show("Please select all product fields and a quantity greater than zero.", "Validation Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string prodId = cashierOrder_prodID.SelectedItem.ToString();
                string selectOrder = "SELECT price, stock FROM products WHERE prod_id = @prodID";
                var checkParams = new Dictionary<string, object> { { "@prodID", prodId } };
                DataTable dt = Database.ExecuteQuery(selectOrder, checkParams);

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Product not found.", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                float getPrice = Convert.ToSingle(dt.Rows[0]["price"]);
                int currentStock = Convert.ToInt32(dt.Rows[0]["stock"]);
                int requestedQty = (int)cashierOrder_qty.Value;

                if (requestedQty > currentStock)
                {
                    MessageBox.Show($"Insufficient stock. Only {currentStock} item(s) available.", "Validation Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (currentStock - requestedQty == 0)
                {
                    MessageBox.Show($"This purchase will reduce stock of {cashierOrder_prodName.Text} to 0.", "Stock Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                float totalIP = getPrice * requestedQty;
                string insertData = @"INSERT INTO orders (customer_id, prod_id, prod_name, category, qty, orig_price, total_price, order_date) 
                                      VALUES (@CID, @prodID, @prodName, @cat, @qty, @origPrice, @totalprice, @date)";

                var insertParams = new Dictionary<string, object>
                {
                    { "@CID", idGen },
                    { "@prodID", prodId },
                    { "@prodName", cashierOrder_prodName.Text.Trim() },
                    { "@cat", cashierOrder_category.SelectedItem?.ToString() },
                    { "@qty", requestedQty },
                    { "@origPrice", getPrice },
                    { "@totalprice", totalIP },
                    { "@date", DateTime.Today }
                };

                Database.ExecuteNonQuery(insertData, insertParams);

                displayOrders();
                displayTotalPrice();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding order item: " + ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cashierOrder_removeBtn_Click(object sender, EventArgs e)
        {
            if (prodID == 0)
            {
                MessageBox.Show("Please select an item from the order list first.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show($"Are you sure you want to remove Order Item ID: {prodID}?", "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    string deleteData = "DELETE FROM orders WHERE id = @id";
                    var parameters = new Dictionary<string, object> { { "@id", prodID } };
                    Database.ExecuteNonQuery(deleteData, parameters);

                    MessageBox.Show("Item removed successfully!", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    prodID = 0;
                    displayOrders();
                    displayTotalPrice();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error removing order item: " + ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void cashierOrder_clearBtn_Click(object sender, EventArgs e)
        {
            clearFields();
        }

        public void clearFields()
        {
            cashierOrder_category.SelectedIndex = -1;
            cashierOrder_prodID.SelectedIndex = -1;
            cashierOrder_prodName.Text = "";
            cashierOrder_price.Text = "";
            cashierOrder_qty.Value = 0;
            prodID = 0;
        }

        private void allOrders_dgv_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < allOrders_dgv.Rows.Count)
            {
                DataGridViewRow row = allOrders_dgv.Rows[e.RowIndex];
                if (row.Cells[0].Value != null && int.TryParse(row.Cells[0].Value.ToString(), out int id))
                {
                    prodID = id;
                }
            }
        }

        private void cashierOrder_amount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    if (float.TryParse(cashierOrder_amount.Text.Trim(), out float getAmount))
                    {
                        float getChange = getAmount - totalPrice;

                        if (getChange < 0)
                        {
                            MessageBox.Show("Amount tendered is less than total price.", "Payment Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            cashierOrder_change.Text = "";
                        }
                        else
                        {
                            cashierOrder_change.Text = getChange.ToString("0.00");
                        }
                    }
                    else
                    {
                        cashierOrder_amount.Text = "";
                        cashierOrder_change.Text = "";
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Invalid amount entered: " + ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cashierOrder_amount.Text = "";
                    cashierOrder_change.Text = "";
                }
            }
        }

        private void cashierOrder_payOrders_Click(object sender, EventArgs e)
        {
            IDGenerator();

            if (string.IsNullOrWhiteSpace(cashierOrder_amount.Text) || allOrders_dgv.Rows.Count == 0)
            {
                MessageBox.Show("Please add items to the order and enter the payment amount.", "Validation Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!float.TryParse(cashierOrder_amount.Text.Trim(), out float getAmount))
            {
                MessageBox.Show("Please enter a valid numeric payment amount.", "Validation Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            float calculatedChange = getAmount - totalPrice;
            if (calculatedChange < 0)
            {
                MessageBox.Show("Amount tendered is less than the total price.", "Payment Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            cashierOrder_change.Text = calculatedChange.ToString("0.00");

            if (MessageBox.Show("Confirm payment for this order?", "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    string insertData = @"INSERT INTO customers (customer_id, total_price, amount, change, order_date) 
                                          VALUES (@CID, @totalPrice, @amount, @change, @date)";

                    var custParams = new Dictionary<string, object>
                    {
                        { "@CID", idGen },
                        { "@totalPrice", Convert.ToSingle(cashierOrder_totalPrice.Text) },
                        { "@amount", getAmount },
                        { "@change", calculatedChange },
                        { "@date", DateTime.Today.Date }
                    };

                    Database.ExecuteNonQuery(insertData, custParams);

                    foreach (DataGridViewRow row in allOrders_dgv.Rows)
                    {
                        if (row.Cells["PName"].Value != null && row.Cells["QTY"].Value != null)
                        {
                            string productName = row.Cells["PName"].Value.ToString();
                            int quantity = Convert.ToInt32(row.Cells["QTY"].Value);

                            string updateStockQuery = "UPDATE products SET stock = stock - @quantity WHERE prod_name = @productName";
                            var stockParams = new Dictionary<string, object>
                            {
                                { "@quantity", quantity },
                                { "@productName", productName }
                            };
                            Database.ExecuteNonQuery(updateStockQuery, stockParams);
                        }
                    }

                    string updateStatusQuery = "UPDATE products SET status = 'Not Available' WHERE stock <= 0";
                    Database.ExecuteNonQuery(updateStatusQuery);

                    displayAllAvailableProducts();
                    clearFields();
                    cashierOrder_amount.Text = "";
                    cashierOrder_change.Text = "";

                    MessageBox.Show("Payment processed successfully!", "Transaction Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    displayOrders();
                    displayTotalPrice();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error processing payment: " + ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void cashierOrder_receipt_Click(object sender, EventArgs e)
        {
            if (allOrders_dgv.Rows.Count == 0)
            {
                MessageBox.Show("Please place an order before viewing/printing a receipt.", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                printPreviewOrder.Document = printOrder;
                printPreviewOrder.ShowDialog();

                cashierOrder_amount.Text = "";
                cashierOrder_change.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error displaying receipt: " + ex.Message, "Print Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void printOrder_BeginPrint(object sender, PrintEventArgs e)
        {
            rowIndex = 0;
        }

        private void printOrder_PrintPage(object sender, PrintPageEventArgs e)
        {
            displayTotalPrice();

            int startX = e.MarginBounds.Left;
            int startY = e.MarginBounds.Top;
            int tableWidth = e.MarginBounds.Width;

            Font font = new Font("Tahoma", 9);
            Font bold = new Font("Tahoma", 9, FontStyle.Bold);
            Font headerFont = new Font("Tahoma", 14, FontStyle.Bold);

            StringFormat centerFormat = new StringFormat
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };
            StringFormat leftFormat = new StringFormat
            {
                Alignment = StringAlignment.Near,
                LineAlignment = StringAlignment.Center
            };
            StringFormat rightFormat = new StringFormat
            {
                Alignment = StringAlignment.Far,
                LineAlignment = StringAlignment.Center
            };

            float y = startY;

            // Store Header
            e.Graphics.DrawString("Sales & Inventory Management", headerFont, Brushes.Black, new RectangleF(startX, y, tableWidth, 25), centerFormat);
            y += 25;
            e.Graphics.DrawString("Official Transaction Receipt", bold, Brushes.Black, new RectangleF(startX, y, tableWidth, 20), centerFormat);
            y += 20;
            e.Graphics.DrawString($"Date: {DateTime.Now:yyyy-MM-dd HH:mm:ss} | Customer ID: {idGen}", font, Brushes.DarkSlateGray, new RectangleF(startX, y, tableWidth, 18), centerFormat);
            y += 25;

            // Divider
            e.Graphics.DrawLine(Pens.Black, startX, y, startX + tableWidth, y);
            y += 5;

            // Column definitions
            int[] colWidths = { 40, 150, 90, 70, 50, 80 };
            string[] headers = { "ID", "Product", "Category", "Price", "Qty", "Total" };

            float currentX = startX;
            for (int i = 0; i < headers.Length; i++)
            {
                e.Graphics.DrawString(headers[i], bold, Brushes.Black, new RectangleF(currentX, y, colWidths[i], 20), (i >= 3) ? rightFormat : leftFormat);
                currentX += colWidths[i];
            }
            y += 22;
            e.Graphics.DrawLine(Pens.Gray, startX, y, startX + tableWidth, y);
            y += 5;

            while (rowIndex < allOrders_dgv.Rows.Count)
            {
                DataGridViewRow row = allOrders_dgv.Rows[rowIndex];
                currentX = startX;

                string[] values = {
                    row.Cells[0].Value?.ToString() ?? "",
                    row.Cells[2].Value?.ToString() ?? "",
                    row.Cells[3].Value?.ToString() ?? "",
                    row.Cells[4].Value?.ToString() ?? "",
                    row.Cells[5].Value?.ToString() ?? "",
                    row.Cells[6].Value?.ToString() ?? ""
                };

                for (int i = 0; i < values.Length; i++)
                {
                    e.Graphics.DrawString(values[i], font, Brushes.Black, new RectangleF(currentX, y, colWidths[i], 18), (i >= 3) ? rightFormat : leftFormat);
                    currentX += colWidths[i];
                }

                y += 20;
                rowIndex++;

                if (y + 60 > e.MarginBounds.Bottom)
                {
                    e.HasMorePages = true;
                    return;
                }
            }

            y += 5;
            e.Graphics.DrawLine(Pens.Black, startX, y, startX + tableWidth, y);
            y += 10;

            e.Graphics.DrawString($"Grand Total: ₱{totalPrice:N2}", new Font("Tahoma", 11, FontStyle.Bold), Brushes.Black, new RectangleF(startX, y, tableWidth, 22), rightFormat);
            y += 30;
            e.Graphics.DrawString("Thank you for your business!", font, Brushes.Gray, new RectangleF(startX, y, tableWidth, 18), centerFormat);

            e.HasMorePages = false;
        }
    }
}
