using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Drawing.Printing;
using System.Drawing;
using System.Linq;

namespace Sales_Inventory_Management
{
    public partial class CashierOrder : UserControl
    {
        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Jarib\Documents\inventory.mdf;Integrated Security=True;Connect Timeout=30");
        public CashierOrder()
        {
            InitializeComponent();
            displayAllAvailabeProducts();
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
            displayAllAvailabeProducts();
            displayAllCategories();
            displayOrders();
            displayTotalPrice();
        }

        public void displayAllAvailabeProducts()
        {
            AddProductsData apData = new AddProductsData();
            List<AddProductsData> listData = apData.allAvailableProducts();

            availableProducts_dgv.DataSource = listData;
        }
        public void displayOrders()
        {
            OrdersData oData = new OrdersData();
            List<OrdersData> listData = oData.allOrdersData();

            allOrders_dgv.DataSource = listData;
        }
        public bool checkConnection()
        {
            if (conn.State == ConnectionState.Closed)
                return true;
            else
                return false;
        }
        public void displayAllCategories()
        {
            if (checkConnection())
            {
                try
                {
                    conn.Open();

                    string selectData = "SELECT * FROM categories";

                    using (SqlCommand cmd = new SqlCommand(selectData, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            cashierOrder_category.Items.Clear();

                            while (reader.Read())
                            {
                                string item = reader.GetString(1);
                                cashierOrder_category.Items.Add(item);
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
        private void cashierOrder_category_SelectedIndexChanged(object sender, EventArgs e)
        {
            cashierOrder_prodID.SelectedIndex = -1;
            cashierOrder_prodID.Items.Clear();
            cashierOrder_prodName.Text = "";
            cashierOrder_price.Text = "";

            string selectedValue = cashierOrder_category.SelectedItem as string;

            if (selectedValue != null)
            {
                if (checkConnection())
                {
                    try
                    {
                        conn.Open();

                        string selectData = $"SELECT * FROM products WHERE category = '{selectedValue}' AND status = @status";

                        using (SqlCommand cmd = new SqlCommand(selectData, conn))
                        {
                            cmd.Parameters.AddWithValue("@status", "Available");

                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    string value = reader["prod_id"].ToString();
                                    cashierOrder_prodID.Items.Add(value);
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

        private void cashierOrder_prodID_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedValue = cashierOrder_prodID.SelectedItem as string;

            if (selectedValue != null)
            {
                if (checkConnection())
                {
                    try
                    {
                        conn.Open();

                        string selectData = $"SELECT * FROM products WHERE prod_id = '{selectedValue}' AND status = @status";

                        using (SqlCommand cmd = new SqlCommand(selectData, conn))
                        {
                            cmd.Parameters.AddWithValue("@status", "Available");

                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    string prodName = reader["prod_name"].ToString();
                                    float prodPrice = Convert.ToSingle(reader["price"]);

                                    cashierOrder_prodName.Text = prodName;
                                    cashierOrder_price.Text = prodPrice.ToString("0.00");
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

        private float totalPrice = 0;

        public void displayTotalPrice()
        {
            IDGenerator();

            if (checkConnection())
            {
                try
                {
                    conn.Open();

                    string selectData = "SELECT SUM(total_price) FROM orders WHERE customer_id = @cID";

                    using (SqlCommand cmd = new SqlCommand(selectData, conn))
                    {
                        cmd.Parameters.AddWithValue("@cID", idGen);

                        object result = cmd.ExecuteScalar();

                        if (result != DBNull.Value)
                        {
                            totalPrice = Convert.ToSingle(result);

                            cashierOrder_totalPrice.Text = totalPrice.ToString("0.00");
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

        private int idGen;
        public void IDGenerator()
        {
            using (SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Jarib\Documents\inventory.mdf;Integrated Security=True;Connect Timeout=30"))
            {
                conn.Open();

                string selectData = "SELECT MAX(customer_id) FROM customers";

                using (SqlCommand cmd = new SqlCommand(selectData, conn))
                {
                    object result = cmd.ExecuteScalar();

                    if (result != DBNull.Value)
                    {
                        int temp = Convert.ToInt32(result);

                        if (temp == 0)
                        {
                            idGen = 1;
                        }
                        else
                        {
                            idGen = temp + 1;
                        }
                    }
                    else
                    {
                        idGen = 1;
                    }
                }
            }
        }

        private int prodID = 0;      
        private void allOrders_dgv_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = allOrders_dgv.Rows[e.RowIndex];
            prodID = (int)row.Cells[0].Value;
        }

        public void clearFields()
        {
            cashierOrder_category.SelectedIndex = -1;
            cashierOrder_prodID.SelectedIndex = -1;
            cashierOrder_prodName.Text = "";
            cashierOrder_price.Text = "";
            cashierOrder_qty.Value = 0;
        }

        private void cashierOrder_amount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    float getAmount = Convert.ToSingle(cashierOrder_amount.Text);
                    float getChange = (getAmount - totalPrice);

                    if (getChange <= -1)
                    {
                        cashierOrder_amount.Text = "";
                        cashierOrder_change.Text = "";
                    }
                    else
                    {
                        cashierOrder_change.Text = getChange.ToString("0.00");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Something went wrong :3", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cashierOrder_amount.Text = "";
                    cashierOrder_change.Text = "";
                }
            }
        }
        private int rowIndex = 0;

        private void printOrder_BeginPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            rowIndex = 0;
        }

        private void printOrder_PrintPage(object sender, PrintPageEventArgs e)
        {

            displayTotalPrice();

            float y = 0;
            int count = 0;
            int colWidth = 100; 
            int headerMargin = 5;
            int tableMargin = 5;

            Font font = new Font("Tahoma", 12);
            Font bold = new Font("tahoma", 12, FontStyle.Bold);
            Font headerFont = new Font("Tahoma", 16, FontStyle.Bold);
            Font labelFont = new Font("Tahoma", 14, FontStyle.Bold);

            float margin = e.MarginBounds.Top;
            StringFormat alignCenter = new StringFormat();
            alignCenter.Alignment = StringAlignment.Center;
            alignCenter.LineAlignment = StringAlignment.Center;
            string headerText = "Pogi Sari-Sari Store";
            y = (margin + count * headerFont.GetHeight(e.Graphics) + headerMargin);
            e.Graphics.DrawString(headerText, headerFont, Brushes.Black, e.MarginBounds.Left + (allOrders_dgv.Columns.Count / 2) * colWidth, y, alignCenter);

            count++;

            y += tableMargin;

            string[] header = { "ID", "CID", "PID", "Category", "OrigPrice", "QTY", "TotalPrice" };

            for (int q = 0; q < header.Length; q++)
            {
                y = margin + count * bold.GetHeight(e.Graphics) + tableMargin;
                e.Graphics.DrawString(header[q], bold, Brushes.Black, e.MarginBounds.Left + q * colWidth, y, alignCenter);
            }

            count++;

            float rSpace = e.MarginBounds.Bottom - y;

            while (rowIndex < allOrders_dgv.Rows.Count)
            {
                DataGridViewRow row = allOrders_dgv.Rows[rowIndex];

                for (int q = 0; q < allOrders_dgv.Columns.Count; q++)
                {
                    object cellValue = row.Cells[q].Value;
                    string cell = (cellValue != null) ? cellValue.ToString(): string.Empty;

                    y = margin + count * font.GetHeight(e.Graphics) + tableMargin;
                    e.Graphics.DrawString(cell, font, Brushes.Black, e.MarginBounds.Left + q * colWidth, y, alignCenter);
                }
                count++;
                rowIndex++;

                if (y + font.GetHeight(e.Graphics) > e.MarginBounds.Bottom)
                {
                    e.HasMorePages = true;
                    return;
                }
            }

            int labelmargin = (int)Math.Min(rSpace, 200);
            DateTime today = DateTime.Now;

            float labelx = e.MarginBounds.Right - e.Graphics.MeasureString("-------------------------------", labelFont).Width;

            y = e.MarginBounds.Bottom - labelmargin - labelFont.GetHeight(e.Graphics);
            e.Graphics.DrawString("Total Price: \t₱" + totalPrice + "\nAmount: \t₱" + cashierOrder_amount.Text.Trim() 
                + "\n\t\t------------\nChange: \t₱" + cashierOrder_change.Text.Trim(), labelFont, Brushes.Black, labelx, y);

            labelmargin = (int) Math.Min(rSpace, -40);

            string labelText = today.ToString();
            y = e.MarginBounds.Bottom - labelmargin - labelFont.GetHeight(e.Graphics);
            e.Graphics.DrawString(labelText, labelFont, Brushes.Black, e.MarginBounds.Right - e.Graphics.MeasureString("-----------------", labelFont).Width, y);
        }

        private void cashierOrder_addBtn_Click(object sender, EventArgs e)
        {
            IDGenerator();

            if (cashierOrder_category.SelectedIndex == -1 || cashierOrder_prodID.SelectedIndex == -1
                || cashierOrder_prodName.Text == "" || cashierOrder_price.Text == "" || cashierOrder_qty.Value == 0)
            {
                MessageBox.Show("Please select item first", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (checkConnection())
                {
                    try
                    {
                        conn.Open();

                        float getPrice = 0;
                        int currentStock = 0;
                        string selectOrder = $"SELECT price, stock FROM products WHERE prod_id = @prodID";

                        using (SqlCommand getOrder = new SqlCommand(selectOrder, conn))
                        {
                            getOrder.Parameters.AddWithValue("@prodID", cashierOrder_prodID.SelectedItem);

                            using (SqlDataReader reader = getOrder.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    object rawPrice = reader["price"];
                                    object rawStock = reader["stock"];

                                    if (rawPrice != DBNull.Value)
                                    {
                                        getPrice = Convert.ToSingle(rawPrice);
                                    }

                                    if (rawStock != DBNull.Value)
                                    {
                                        currentStock = Convert.ToInt32(rawStock);
                                    }
                                }
                            }
                        }
                        if (currentStock - (int)cashierOrder_qty.Value == 0)
                        {
                            MessageBox.Show($"This purchase will make the stock of {cashierOrder_prodName.Text} reach 0. The product will be marked as 'Not Available'.", "Stock Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }

                        string insertData = "INSERT INTO orders (customer_id, prod_id, prod_name, category, qty, orig_price, total_price, order_date) " +
                             "VALUES(@CID, @prodID, @prodName, @cat, @qty, @origPrice, @totalprice, @date)";

                        using (SqlCommand cmd = new SqlCommand(insertData, conn))
                        {
                            cmd.Parameters.AddWithValue("@cID", idGen);
                            cmd.Parameters.AddWithValue("@prodID", cashierOrder_prodID.SelectedItem);
                            cmd.Parameters.AddWithValue("@prodName", cashierOrder_prodName.Text.Trim());
                            cmd.Parameters.AddWithValue("@cat", cashierOrder_category.SelectedItem);
                            cmd.Parameters.AddWithValue("@qty", cashierOrder_qty.Value);
                            cmd.Parameters.AddWithValue("@origPrice", getPrice);

                            float totalIP = (getPrice * (int)cashierOrder_qty.Value);

                            cmd.Parameters.AddWithValue("@totalprice", totalIP);

                            DateTime today = DateTime.Now;
                            cmd.Parameters.AddWithValue("@date", today);

                            cmd.ExecuteNonQuery();
                        }

                        if (currentStock - (int)cashierOrder_qty.Value == 0)
                        {
                            string updateStatusQuery = "UPDATE products SET status = 'Not Available' WHERE prod_id = @prodID";
                            using (SqlCommand updateCmd = new SqlCommand(updateStatusQuery, conn))
                            {
                                updateCmd.Parameters.AddWithValue("@prodID", cashierOrder_prodID.SelectedItem);
                                updateCmd.ExecuteNonQuery();
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
            displayOrders();
            displayTotalPrice();
        }
        private void cashierOrder_removeBtn_Click(object sender, EventArgs e)
        {
            if (prodID == 0)
            {
                MessageBox.Show("Please select item first", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (MessageBox.Show("Are you sure you want to Remove ID:" + prodID + "?", "Confirmation Message"
                    , MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (checkConnection())
                    {
                        try
                        {
                            conn.Open();

                            string deleteData = "DELETE FROM orders WHERE id = @id";

                            using (SqlCommand cmd = new SqlCommand(deleteData, conn))
                            {
                                cmd.Parameters.AddWithValue("@id", prodID);

                                cmd.ExecuteNonQuery();

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

            displayOrders();
            displayTotalPrice();
        }
        private void cashierOrder_clearBtn_Click(object sender, EventArgs e)
        {
            clearFields();
        }

        private void cashierOrder_payOrders_Click(object sender, EventArgs e)
        {
            IDGenerator();

            if (cashierOrder_amount.Text == "" || allOrders_dgv.Rows.Count < 0)
            {
                MessageBox.Show("Something went wrong", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (string.IsNullOrEmpty(cashierOrder_change.Text))
            {
                MessageBox.Show("Please enter the amount and calculate the change before proceeding with payment.", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (MessageBox.Show("Are you sure to pay your orders?",
                    "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (checkConnection())
                    {
                        try
                        {
                            conn.Open();                           
                            string insertData = "INSERT INTO customers (customer_id, total_price, amount, change, order_date) " +
                                "VALUES (@CID, @totalPrice, @amount, @change, @date)";

                            using (SqlCommand cmd = new SqlCommand(insertData, conn))
                            {
                                cmd.Parameters.AddWithValue("@cID", idGen);
                                cmd.Parameters.AddWithValue("@totalPrice", cashierOrder_totalPrice.Text);
                                cmd.Parameters.AddWithValue("@amount", cashierOrder_amount.Text);
                                cmd.Parameters.AddWithValue("@change", cashierOrder_change.Text);

                                DateTime today = DateTime.Now;
                                cmd.Parameters.AddWithValue("@date", today);

                                cmd.ExecuteNonQuery();
                            }

                            foreach (DataGridViewRow row in allOrders_dgv.Rows)
                            {
                                string productName = row.Cells["PName"].Value.ToString(); 
                                int quantity = Convert.ToInt32(row.Cells["QTY"].Value); 

                                string updateStockQuery = "UPDATE products SET stock = stock - @quantity WHERE prod_name = @productName";

                                using (SqlCommand cmd = new SqlCommand(updateStockQuery, conn))
                                {
                                    cmd.Parameters.AddWithValue("@quantity", quantity);
                                    cmd.Parameters.AddWithValue("@productName", productName);

                                    cmd.ExecuteNonQuery();
                                }
                            }
                            string updateStatusQuery = "UPDATE products SET status = 'Not Available' WHERE stock <= 0";
                            using (SqlCommand updateCmd = new SqlCommand(updateStatusQuery, conn))
                            {
                                updateCmd.ExecuteNonQuery();
                            }

                            displayAllAvailabeProducts();
                            clearFields();

                            MessageBox.Show("Paid successfully!", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

            displayTotalPrice();
        }
        private void cashierOrder_receipt_Click(object sender, EventArgs e)
        {
            if (cashierOrder_amount.Text == "" || allOrders_dgv.Rows.Count < 0)
            {
                MessageBox.Show("Pleaase order first.", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                printOrder.PrintPage += new PrintPageEventHandler(printOrder_PrintPage);
                printOrder.BeginPrint += new PrintEventHandler(printOrder_BeginPrint);

                printPreviewOrder.Document = printOrder;
                printPreviewOrder.ShowDialog();


                cashierOrder_amount.Text = "";
                cashierOrder_change.Text = "";
            }
        }
    }
}
