namespace Sales_Inventory_Management
{
    partial class CashierMainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CashierMainForm));
            this.movePanel = new Guna.UI2.WinForms.Guna2CustomGradientPanel();
            this.guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.btnexit = new Guna.UI2.WinForms.Guna2Button();
            this.guna2CustomGradientPanel2 = new Guna.UI2.WinForms.Guna2CustomGradientPanel();
            this.guna2CirclePictureBox1 = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.guna2HtmlLabel2 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.user_username = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.order_btn = new Guna.UI2.WinForms.Guna2GradientButton();
            this.cashierForm_logout = new Guna.UI2.WinForms.Guna2GradientButton();
            this.customers_btn = new Guna.UI2.WinForms.Guna2GradientButton();
            this.addProducts_btn = new Guna.UI2.WinForms.Guna2GradientButton();
            this.dashboard_btn = new Guna.UI2.WinForms.Guna2GradientButton();
            this.guna2CustomGradientPanel3 = new Guna.UI2.WinForms.Guna2CustomGradientPanel();
            this.adminDashboard1 = new Sales_Inventory_Management.AdminDashboard();
            this.adminAddProducts1 = new Sales_Inventory_Management.AdminAddProducts();
            this.cashierCustomersForm1 = new Sales_Inventory_Management.CashierCustomersForm();
            this.cashierOrder1 = new Sales_Inventory_Management.CashierOrder();
            this.movePanel.SuspendLayout();
            this.guna2CustomGradientPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2CirclePictureBox1)).BeginInit();
            this.guna2CustomGradientPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // movePanel
            // 
            this.movePanel.Controls.Add(this.guna2HtmlLabel1);
            this.movePanel.Controls.Add(this.btnexit);
            this.movePanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.movePanel.FillColor = System.Drawing.Color.Black;
            this.movePanel.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(117)))), ((int)(((byte)(67)))));
            this.movePanel.FillColor3 = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(117)))), ((int)(((byte)(67)))));
            this.movePanel.FillColor4 = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(117)))), ((int)(((byte)(67)))));
            this.movePanel.Location = new System.Drawing.Point(0, 0);
            this.movePanel.Name = "movePanel";
            this.movePanel.Size = new System.Drawing.Size(1355, 45);
            this.movePanel.TabIndex = 53;
            this.movePanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.movePanel_MouseDown);
            // 
            // guna2HtmlLabel1
            // 
            this.guna2HtmlLabel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel1.Font = new System.Drawing.Font("Rockwell", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.guna2HtmlLabel1.Location = new System.Drawing.Point(18, 6);
            this.guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            this.guna2HtmlLabel1.Size = new System.Drawing.Size(458, 33);
            this.guna2HtmlLabel1.TabIndex = 78;
            this.guna2HtmlLabel1.Text = "Pogi Sari-Sari Store | Cashier\'s Portal";
            // 
            // btnexit
            // 
            this.btnexit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnexit.FillColor = System.Drawing.Color.Black;
            this.btnexit.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnexit.ForeColor = System.Drawing.Color.White;
            this.btnexit.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnexit.Location = new System.Drawing.Point(1300, 0);
            this.btnexit.Name = "btnexit";
            this.btnexit.PressedColor = System.Drawing.Color.DarkGray;
            this.btnexit.Size = new System.Drawing.Size(55, 45);
            this.btnexit.TabIndex = 48;
            this.btnexit.Text = "X";
            this.btnexit.Click += new System.EventHandler(this.btnexit_Click);
            // 
            // guna2CustomGradientPanel2
            // 
            this.guna2CustomGradientPanel2.Controls.Add(this.guna2CirclePictureBox1);
            this.guna2CustomGradientPanel2.Controls.Add(this.guna2HtmlLabel2);
            this.guna2CustomGradientPanel2.Controls.Add(this.user_username);
            this.guna2CustomGradientPanel2.Controls.Add(this.order_btn);
            this.guna2CustomGradientPanel2.Controls.Add(this.cashierForm_logout);
            this.guna2CustomGradientPanel2.Controls.Add(this.customers_btn);
            this.guna2CustomGradientPanel2.Controls.Add(this.addProducts_btn);
            this.guna2CustomGradientPanel2.Controls.Add(this.dashboard_btn);
            this.guna2CustomGradientPanel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.guna2CustomGradientPanel2.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(40)))), ((int)(((byte)(71)))));
            this.guna2CustomGradientPanel2.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(40)))), ((int)(((byte)(71)))));
            this.guna2CustomGradientPanel2.FillColor3 = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(123)))), ((int)(((byte)(60)))));
            this.guna2CustomGradientPanel2.FillColor4 = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(123)))), ((int)(((byte)(60)))));
            this.guna2CustomGradientPanel2.Location = new System.Drawing.Point(0, 45);
            this.guna2CustomGradientPanel2.Name = "guna2CustomGradientPanel2";
            this.guna2CustomGradientPanel2.Size = new System.Drawing.Size(250, 756);
            this.guna2CustomGradientPanel2.TabIndex = 54;
            // 
            // guna2CirclePictureBox1
            // 
            this.guna2CirclePictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.guna2CirclePictureBox1.Image = global::Sales_Inventory_Management.Properties.Resources.Pogi;
            this.guna2CirclePictureBox1.ImageRotate = 0F;
            this.guna2CirclePictureBox1.Location = new System.Drawing.Point(66, 25);
            this.guna2CirclePictureBox1.Name = "guna2CirclePictureBox1";
            this.guna2CirclePictureBox1.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.guna2CirclePictureBox1.Size = new System.Drawing.Size(105, 104);
            this.guna2CirclePictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.guna2CirclePictureBox1.TabIndex = 98;
            this.guna2CirclePictureBox1.TabStop = false;
            // 
            // guna2HtmlLabel2
            // 
            this.guna2HtmlLabel2.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel2.Font = new System.Drawing.Font("Rockwell", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel2.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.guna2HtmlLabel2.Location = new System.Drawing.Point(18, 135);
            this.guna2HtmlLabel2.Name = "guna2HtmlLabel2";
            this.guna2HtmlLabel2.Size = new System.Drawing.Size(111, 28);
            this.guna2HtmlLabel2.TabIndex = 97;
            this.guna2HtmlLabel2.Text = "Welcome,";
            // 
            // user_username
            // 
            this.user_username.BackColor = System.Drawing.Color.Transparent;
            this.user_username.Font = new System.Drawing.Font("Rockwell", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.user_username.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.user_username.Location = new System.Drawing.Point(135, 135);
            this.user_username.Name = "user_username";
            this.user_username.Size = new System.Drawing.Size(86, 28);
            this.user_username.TabIndex = 96;
            this.user_username.Text = "Cashier";
            // 
            // order_btn
            // 
            this.order_btn.Animated = true;
            this.order_btn.AutoRoundedCorners = true;
            this.order_btn.BackColor = System.Drawing.Color.Transparent;
            this.order_btn.BorderRadius = 29;
            this.order_btn.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.order_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.order_btn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.order_btn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.order_btn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.order_btn.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.order_btn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.order_btn.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(117)))), ((int)(((byte)(67)))));
            this.order_btn.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(117)))), ((int)(((byte)(67)))));
            this.order_btn.Font = new System.Drawing.Font("Rockwell", 10.2F);
            this.order_btn.ForeColor = System.Drawing.Color.White;
            this.order_btn.HoverState.BorderColor = System.Drawing.Color.White;
            this.order_btn.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(117)))), ((int)(((byte)(67)))));
            this.order_btn.HoverState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.order_btn.Location = new System.Drawing.Point(12, 431);
            this.order_btn.Name = "order_btn";
            this.order_btn.Size = new System.Drawing.Size(223, 61);
            this.order_btn.TabIndex = 95;
            this.order_btn.Text = "Order";
            this.order_btn.Click += new System.EventHandler(this.order_btn_Click);
            // 
            // cashierForm_logout
            // 
            this.cashierForm_logout.Animated = true;
            this.cashierForm_logout.AutoRoundedCorners = true;
            this.cashierForm_logout.BackColor = System.Drawing.Color.Transparent;
            this.cashierForm_logout.BorderRadius = 29;
            this.cashierForm_logout.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.cashierForm_logout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cashierForm_logout.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.cashierForm_logout.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.cashierForm_logout.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.cashierForm_logout.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.cashierForm_logout.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.cashierForm_logout.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(117)))), ((int)(((byte)(67)))));
            this.cashierForm_logout.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(117)))), ((int)(((byte)(67)))));
            this.cashierForm_logout.Font = new System.Drawing.Font("Rockwell", 10.2F);
            this.cashierForm_logout.ForeColor = System.Drawing.Color.White;
            this.cashierForm_logout.HoverState.BorderColor = System.Drawing.Color.White;
            this.cashierForm_logout.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(117)))), ((int)(((byte)(67)))));
            this.cashierForm_logout.HoverState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.cashierForm_logout.Location = new System.Drawing.Point(12, 683);
            this.cashierForm_logout.Name = "cashierForm_logout";
            this.cashierForm_logout.Size = new System.Drawing.Size(223, 61);
            this.cashierForm_logout.TabIndex = 94;
            this.cashierForm_logout.Text = "Logout";
            this.cashierForm_logout.Click += new System.EventHandler(this.cashierForm_logout_Click);
            // 
            // customers_btn
            // 
            this.customers_btn.Animated = true;
            this.customers_btn.AutoRoundedCorners = true;
            this.customers_btn.BackColor = System.Drawing.Color.Transparent;
            this.customers_btn.BorderRadius = 29;
            this.customers_btn.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.customers_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.customers_btn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.customers_btn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.customers_btn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.customers_btn.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.customers_btn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.customers_btn.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(117)))), ((int)(((byte)(67)))));
            this.customers_btn.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(117)))), ((int)(((byte)(67)))));
            this.customers_btn.Font = new System.Drawing.Font("Rockwell", 10.2F);
            this.customers_btn.ForeColor = System.Drawing.Color.White;
            this.customers_btn.HoverState.BorderColor = System.Drawing.Color.White;
            this.customers_btn.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(117)))), ((int)(((byte)(67)))));
            this.customers_btn.HoverState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.customers_btn.Location = new System.Drawing.Point(12, 355);
            this.customers_btn.Name = "customers_btn";
            this.customers_btn.Size = new System.Drawing.Size(223, 61);
            this.customers_btn.TabIndex = 93;
            this.customers_btn.Text = "Customers";
            this.customers_btn.Click += new System.EventHandler(this.customers_btn_Click);
            // 
            // addProducts_btn
            // 
            this.addProducts_btn.Animated = true;
            this.addProducts_btn.AutoRoundedCorners = true;
            this.addProducts_btn.BackColor = System.Drawing.Color.Transparent;
            this.addProducts_btn.BorderRadius = 29;
            this.addProducts_btn.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.addProducts_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.addProducts_btn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.addProducts_btn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.addProducts_btn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.addProducts_btn.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.addProducts_btn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.addProducts_btn.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(117)))), ((int)(((byte)(67)))));
            this.addProducts_btn.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(117)))), ((int)(((byte)(67)))));
            this.addProducts_btn.Font = new System.Drawing.Font("Rockwell", 10.2F);
            this.addProducts_btn.ForeColor = System.Drawing.Color.White;
            this.addProducts_btn.HoverState.BorderColor = System.Drawing.Color.White;
            this.addProducts_btn.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(117)))), ((int)(((byte)(67)))));
            this.addProducts_btn.HoverState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.addProducts_btn.Location = new System.Drawing.Point(12, 277);
            this.addProducts_btn.Name = "addProducts_btn";
            this.addProducts_btn.Size = new System.Drawing.Size(223, 61);
            this.addProducts_btn.TabIndex = 92;
            this.addProducts_btn.Text = "Add Products";
            this.addProducts_btn.Click += new System.EventHandler(this.addProducts_btn_Click);
            // 
            // dashboard_btn
            // 
            this.dashboard_btn.Animated = true;
            this.dashboard_btn.AutoRoundedCorners = true;
            this.dashboard_btn.BackColor = System.Drawing.Color.Transparent;
            this.dashboard_btn.BorderRadius = 29;
            this.dashboard_btn.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.dashboard_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dashboard_btn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.dashboard_btn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.dashboard_btn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.dashboard_btn.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.dashboard_btn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.dashboard_btn.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(117)))), ((int)(((byte)(67)))));
            this.dashboard_btn.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(117)))), ((int)(((byte)(67)))));
            this.dashboard_btn.Font = new System.Drawing.Font("Rockwell", 10.2F);
            this.dashboard_btn.ForeColor = System.Drawing.Color.White;
            this.dashboard_btn.HoverState.BorderColor = System.Drawing.Color.White;
            this.dashboard_btn.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(117)))), ((int)(((byte)(67)))));
            this.dashboard_btn.HoverState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.dashboard_btn.Location = new System.Drawing.Point(12, 200);
            this.dashboard_btn.Name = "dashboard_btn";
            this.dashboard_btn.Size = new System.Drawing.Size(223, 61);
            this.dashboard_btn.TabIndex = 91;
            this.dashboard_btn.Text = "Dashboard";
            this.dashboard_btn.Click += new System.EventHandler(this.dashboard_btn_Click);
            // 
            // guna2CustomGradientPanel3
            // 
            this.guna2CustomGradientPanel3.Controls.Add(this.adminDashboard1);
            this.guna2CustomGradientPanel3.Controls.Add(this.adminAddProducts1);
            this.guna2CustomGradientPanel3.Controls.Add(this.cashierCustomersForm1);
            this.guna2CustomGradientPanel3.Controls.Add(this.cashierOrder1);
            this.guna2CustomGradientPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.guna2CustomGradientPanel3.FillColor = System.Drawing.Color.Silver;
            this.guna2CustomGradientPanel3.FillColor2 = System.Drawing.Color.DimGray;
            this.guna2CustomGradientPanel3.FillColor3 = System.Drawing.Color.Black;
            this.guna2CustomGradientPanel3.FillColor4 = System.Drawing.Color.WhiteSmoke;
            this.guna2CustomGradientPanel3.Location = new System.Drawing.Point(250, 45);
            this.guna2CustomGradientPanel3.Name = "guna2CustomGradientPanel3";
            this.guna2CustomGradientPanel3.Size = new System.Drawing.Size(1105, 756);
            this.guna2CustomGradientPanel3.TabIndex = 55;
            // 
            // adminDashboard1
            // 
            this.adminDashboard1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(117)))), ((int)(((byte)(67)))));
            this.adminDashboard1.Location = new System.Drawing.Point(0, 0);
            this.adminDashboard1.Name = "adminDashboard1";
            this.adminDashboard1.Size = new System.Drawing.Size(1105, 756);
            this.adminDashboard1.TabIndex = 3;
            // 
            // adminAddProducts1
            // 
            this.adminAddProducts1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(117)))), ((int)(((byte)(67)))));
            this.adminAddProducts1.Location = new System.Drawing.Point(0, 0);
            this.adminAddProducts1.Name = "adminAddProducts1";
            this.adminAddProducts1.Size = new System.Drawing.Size(1105, 756);
            this.adminAddProducts1.TabIndex = 2;
            // 
            // cashierCustomersForm1
            // 
            this.cashierCustomersForm1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(117)))), ((int)(((byte)(67)))));
            this.cashierCustomersForm1.Location = new System.Drawing.Point(0, 0);
            this.cashierCustomersForm1.Name = "cashierCustomersForm1";
            this.cashierCustomersForm1.Size = new System.Drawing.Size(1105, 756);
            this.cashierCustomersForm1.TabIndex = 1;
            // 
            // cashierOrder1
            // 
            this.cashierOrder1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(117)))), ((int)(((byte)(67)))));
            this.cashierOrder1.Location = new System.Drawing.Point(0, 0);
            this.cashierOrder1.Name = "cashierOrder1";
            this.cashierOrder1.Size = new System.Drawing.Size(1105, 756);
            this.cashierOrder1.TabIndex = 0;
            // 
            // CashierMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1355, 801);
            this.Controls.Add(this.guna2CustomGradientPanel3);
            this.Controls.Add(this.guna2CustomGradientPanel2);
            this.Controls.Add(this.movePanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CashierMainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CashierMainForm";
            this.Load += new System.EventHandler(this.CashierMainForm_Load);
            this.movePanel.ResumeLayout(false);
            this.movePanel.PerformLayout();
            this.guna2CustomGradientPanel2.ResumeLayout(false);
            this.guna2CustomGradientPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2CirclePictureBox1)).EndInit();
            this.guna2CustomGradientPanel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2CustomGradientPanel movePanel;
        private Guna.UI2.WinForms.Guna2Button btnexit;
        private Guna.UI2.WinForms.Guna2CustomGradientPanel guna2CustomGradientPanel2;
        private Guna.UI2.WinForms.Guna2CustomGradientPanel guna2CustomGradientPanel3;
        private CashierOrder cashierOrder1;
        private Guna.UI2.WinForms.Guna2GradientButton cashierForm_logout;
        private Guna.UI2.WinForms.Guna2GradientButton customers_btn;
        private Guna.UI2.WinForms.Guna2GradientButton addProducts_btn;
        private Guna.UI2.WinForms.Guna2GradientButton dashboard_btn;
        private Guna.UI2.WinForms.Guna2GradientButton order_btn;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel2;
        private Guna.UI2.WinForms.Guna2HtmlLabel user_username;
        private Guna.UI2.WinForms.Guna2CirclePictureBox guna2CirclePictureBox1;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
        private CashierCustomersForm cashierCustomersForm1;
        private AdminDashboard adminDashboard1;
        private AdminAddProducts adminAddProducts1;
    }
}