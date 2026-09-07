namespace Sales_Inventory_Management
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.btnexit = new Guna.UI2.WinForms.Guna2Button();
            this.movePanel = new Guna.UI2.WinForms.Guna2CustomGradientPanel();
            this.guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2CustomGradientPanel2 = new Guna.UI2.WinForms.Guna2CustomGradientPanel();
            this.guna2HtmlLabel2 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.user_username = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2CirclePictureBox1 = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.log = new Guna.UI2.WinForms.Guna2GradientButton();
            this.customers_btn = new Guna.UI2.WinForms.Guna2GradientButton();
            this.addProducts_btn = new Guna.UI2.WinForms.Guna2GradientButton();
            this.addCategories_btn = new Guna.UI2.WinForms.Guna2GradientButton();
            this.addUsers_btn = new Guna.UI2.WinForms.Guna2GradientButton();
            this.dashboard_btn = new Guna.UI2.WinForms.Guna2GradientButton();
            this.cashierCustomersForm1 = new Sales_Inventory_Management.CashierCustomersForm();
            this.adminAddProducts1 = new Sales_Inventory_Management.AdminAddProducts();
            this.adminAddCategories1 = new Sales_Inventory_Management.AdminAddCategories();
            this.adminAddUser1 = new Sales_Inventory_Management.AdminAddUser();
            this.adminDashboard1 = new Sales_Inventory_Management.AdminDashboard();
            this.movePanel.SuspendLayout();
            this.guna2CustomGradientPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2CirclePictureBox1)).BeginInit();
            this.SuspendLayout();
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
            // movePanel
            // 
            this.movePanel.Controls.Add(this.guna2HtmlLabel1);
            this.movePanel.Controls.Add(this.btnexit);
            this.movePanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.movePanel.FillColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.movePanel.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(117)))), ((int)(((byte)(67)))));
            this.movePanel.FillColor3 = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(117)))), ((int)(((byte)(67)))));
            this.movePanel.FillColor4 = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(117)))), ((int)(((byte)(67)))));
            this.movePanel.Location = new System.Drawing.Point(0, 0);
            this.movePanel.Name = "movePanel";
            this.movePanel.Size = new System.Drawing.Size(1355, 45);
            this.movePanel.TabIndex = 52;
            this.movePanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.movePanel_MouseDown);
            // 
            // guna2HtmlLabel1
            // 
            this.guna2HtmlLabel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel1.Font = new System.Drawing.Font("Rockwell", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.guna2HtmlLabel1.Location = new System.Drawing.Point(12, 7);
            this.guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            this.guna2HtmlLabel1.Size = new System.Drawing.Size(444, 33);
            this.guna2HtmlLabel1.TabIndex = 77;
            this.guna2HtmlLabel1.Text = "Pogi Sari-Sari Store | Admin\'s Portal";
            // 
            // guna2CustomGradientPanel2
            // 
            this.guna2CustomGradientPanel2.Controls.Add(this.guna2HtmlLabel2);
            this.guna2CustomGradientPanel2.Controls.Add(this.user_username);
            this.guna2CustomGradientPanel2.Controls.Add(this.guna2CirclePictureBox1);
            this.guna2CustomGradientPanel2.Controls.Add(this.log);
            this.guna2CustomGradientPanel2.Controls.Add(this.customers_btn);
            this.guna2CustomGradientPanel2.Controls.Add(this.addProducts_btn);
            this.guna2CustomGradientPanel2.Controls.Add(this.addCategories_btn);
            this.guna2CustomGradientPanel2.Controls.Add(this.addUsers_btn);
            this.guna2CustomGradientPanel2.Controls.Add(this.dashboard_btn);
            this.guna2CustomGradientPanel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.guna2CustomGradientPanel2.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(40)))), ((int)(((byte)(71)))));
            this.guna2CustomGradientPanel2.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(40)))), ((int)(((byte)(71)))));
            this.guna2CustomGradientPanel2.FillColor3 = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(123)))), ((int)(((byte)(60)))));
            this.guna2CustomGradientPanel2.FillColor4 = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(123)))), ((int)(((byte)(60)))));
            this.guna2CustomGradientPanel2.Location = new System.Drawing.Point(0, 45);
            this.guna2CustomGradientPanel2.Name = "guna2CustomGradientPanel2";
            this.guna2CustomGradientPanel2.Size = new System.Drawing.Size(250, 756);
            this.guna2CustomGradientPanel2.TabIndex = 53;
            // 
            // guna2HtmlLabel2
            // 
            this.guna2HtmlLabel2.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel2.Font = new System.Drawing.Font("Rockwell", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel2.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.guna2HtmlLabel2.Location = new System.Drawing.Point(15, 136);
            this.guna2HtmlLabel2.Name = "guna2HtmlLabel2";
            this.guna2HtmlLabel2.Size = new System.Drawing.Size(111, 28);
            this.guna2HtmlLabel2.TabIndex = 92;
            this.guna2HtmlLabel2.Text = "Welcome,";
            // 
            // user_username
            // 
            this.user_username.BackColor = System.Drawing.Color.Transparent;
            this.user_username.Font = new System.Drawing.Font("Rockwell", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.user_username.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.user_username.Location = new System.Drawing.Point(132, 136);
            this.user_username.Name = "user_username";
            this.user_username.Size = new System.Drawing.Size(73, 28);
            this.user_username.TabIndex = 78;
            this.user_username.Text = "Admin";
            // 
            // guna2CirclePictureBox1
            // 
            this.guna2CirclePictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.guna2CirclePictureBox1.Image = global::Sales_Inventory_Management.Properties.Resources.Pogi;
            this.guna2CirclePictureBox1.ImageRotate = 0F;
            this.guna2CirclePictureBox1.Location = new System.Drawing.Point(65, 20);
            this.guna2CirclePictureBox1.Name = "guna2CirclePictureBox1";
            this.guna2CirclePictureBox1.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.guna2CirclePictureBox1.Size = new System.Drawing.Size(105, 104);
            this.guna2CirclePictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.guna2CirclePictureBox1.TabIndex = 91;
            this.guna2CirclePictureBox1.TabStop = false;
            // 
            // log
            // 
            this.log.Animated = true;
            this.log.AutoRoundedCorners = true;
            this.log.BackColor = System.Drawing.Color.Transparent;
            this.log.BorderRadius = 29;
            this.log.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.log.Cursor = System.Windows.Forms.Cursors.Hand;
            this.log.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.log.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.log.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.log.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.log.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.log.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(117)))), ((int)(((byte)(67)))));
            this.log.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(117)))), ((int)(((byte)(67)))));
            this.log.Font = new System.Drawing.Font("Rockwell", 10.2F);
            this.log.ForeColor = System.Drawing.Color.White;
            this.log.HoverState.BorderColor = System.Drawing.Color.White;
            this.log.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(117)))), ((int)(((byte)(67)))));
            this.log.HoverState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.log.Location = new System.Drawing.Point(14, 683);
            this.log.Name = "log";
            this.log.Size = new System.Drawing.Size(223, 61);
            this.log.TabIndex = 90;
            this.log.Text = "Logout";
            this.log.Click += new System.EventHandler(this.log_Click);
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
            this.customers_btn.Location = new System.Drawing.Point(14, 503);
            this.customers_btn.Name = "customers_btn";
            this.customers_btn.Size = new System.Drawing.Size(223, 61);
            this.customers_btn.TabIndex = 89;
            this.customers_btn.Text = "Customers";
            this.customers_btn.Click += new System.EventHandler(this.customers_btn_Click_1);
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
            this.addProducts_btn.Location = new System.Drawing.Point(14, 425);
            this.addProducts_btn.Name = "addProducts_btn";
            this.addProducts_btn.Size = new System.Drawing.Size(223, 61);
            this.addProducts_btn.TabIndex = 88;
            this.addProducts_btn.Text = "Add Products";
            this.addProducts_btn.Click += new System.EventHandler(this.addProducts_btn_Click_1);
            // 
            // addCategories_btn
            // 
            this.addCategories_btn.Animated = true;
            this.addCategories_btn.AutoRoundedCorners = true;
            this.addCategories_btn.BackColor = System.Drawing.Color.Transparent;
            this.addCategories_btn.BorderRadius = 29;
            this.addCategories_btn.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.addCategories_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.addCategories_btn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.addCategories_btn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.addCategories_btn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.addCategories_btn.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.addCategories_btn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.addCategories_btn.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(117)))), ((int)(((byte)(67)))));
            this.addCategories_btn.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(117)))), ((int)(((byte)(67)))));
            this.addCategories_btn.Font = new System.Drawing.Font("Rockwell", 10.2F);
            this.addCategories_btn.ForeColor = System.Drawing.Color.White;
            this.addCategories_btn.HoverState.BorderColor = System.Drawing.Color.White;
            this.addCategories_btn.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(117)))), ((int)(((byte)(67)))));
            this.addCategories_btn.HoverState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.addCategories_btn.Location = new System.Drawing.Point(12, 348);
            this.addCategories_btn.Name = "addCategories_btn";
            this.addCategories_btn.Size = new System.Drawing.Size(223, 61);
            this.addCategories_btn.TabIndex = 87;
            this.addCategories_btn.Text = "Add Categories";
            this.addCategories_btn.Click += new System.EventHandler(this.addCategories_btn_Click);
            // 
            // addUsers_btn
            // 
            this.addUsers_btn.Animated = true;
            this.addUsers_btn.AutoRoundedCorners = true;
            this.addUsers_btn.BackColor = System.Drawing.Color.Transparent;
            this.addUsers_btn.BorderRadius = 29;
            this.addUsers_btn.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.addUsers_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.addUsers_btn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.addUsers_btn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.addUsers_btn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.addUsers_btn.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.addUsers_btn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.addUsers_btn.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(117)))), ((int)(((byte)(67)))));
            this.addUsers_btn.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(117)))), ((int)(((byte)(67)))));
            this.addUsers_btn.Font = new System.Drawing.Font("Rockwell", 10.2F);
            this.addUsers_btn.ForeColor = System.Drawing.Color.White;
            this.addUsers_btn.HoverState.BorderColor = System.Drawing.Color.White;
            this.addUsers_btn.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(117)))), ((int)(((byte)(67)))));
            this.addUsers_btn.HoverState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.addUsers_btn.Location = new System.Drawing.Point(12, 269);
            this.addUsers_btn.Name = "addUsers_btn";
            this.addUsers_btn.Size = new System.Drawing.Size(223, 61);
            this.addUsers_btn.TabIndex = 86;
            this.addUsers_btn.Text = "Add Users";
            this.addUsers_btn.Click += new System.EventHandler(this.addUsers_btn_Click);
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
            this.dashboard_btn.Location = new System.Drawing.Point(12, 191);
            this.dashboard_btn.Name = "dashboard_btn";
            this.dashboard_btn.Size = new System.Drawing.Size(223, 61);
            this.dashboard_btn.TabIndex = 85;
            this.dashboard_btn.Text = "Dashboard";
            this.dashboard_btn.Click += new System.EventHandler(this.dashboard_btn_Click);
            // 
            // cashierCustomersForm1
            // 
            this.cashierCustomersForm1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(117)))), ((int)(((byte)(67)))));
            this.cashierCustomersForm1.Location = new System.Drawing.Point(250, 45);
            this.cashierCustomersForm1.Name = "cashierCustomersForm1";
            this.cashierCustomersForm1.Size = new System.Drawing.Size(1105, 756);
            this.cashierCustomersForm1.TabIndex = 54;
            // 
            // adminAddProducts1
            // 
            this.adminAddProducts1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(117)))), ((int)(((byte)(67)))));
            this.adminAddProducts1.Location = new System.Drawing.Point(250, 45);
            this.adminAddProducts1.Name = "adminAddProducts1";
            this.adminAddProducts1.Size = new System.Drawing.Size(1105, 756);
            this.adminAddProducts1.TabIndex = 55;
            // 
            // adminAddCategories1
            // 
            this.adminAddCategories1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(117)))), ((int)(((byte)(67)))));
            this.adminAddCategories1.Location = new System.Drawing.Point(250, 45);
            this.adminAddCategories1.Name = "adminAddCategories1";
            this.adminAddCategories1.Size = new System.Drawing.Size(1105, 756);
            this.adminAddCategories1.TabIndex = 56;
            // 
            // adminAddUser1
            // 
            this.adminAddUser1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(117)))), ((int)(((byte)(67)))));
            this.adminAddUser1.Location = new System.Drawing.Point(250, 45);
            this.adminAddUser1.Name = "adminAddUser1";
            this.adminAddUser1.Size = new System.Drawing.Size(1105, 756);
            this.adminAddUser1.TabIndex = 57;
            // 
            // adminDashboard1
            // 
            this.adminDashboard1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(117)))), ((int)(((byte)(67)))));
            this.adminDashboard1.Location = new System.Drawing.Point(250, 45);
            this.adminDashboard1.Name = "adminDashboard1";
            this.adminDashboard1.Size = new System.Drawing.Size(1105, 756);
            this.adminDashboard1.TabIndex = 58;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1355, 801);
            this.Controls.Add(this.adminDashboard1);
            this.Controls.Add(this.adminAddUser1);
            this.Controls.Add(this.adminAddCategories1);
            this.Controls.Add(this.adminAddProducts1);
            this.Controls.Add(this.cashierCustomersForm1);
            this.Controls.Add(this.guna2CustomGradientPanel2);
            this.Controls.Add(this.movePanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.movePanel.ResumeLayout(false);
            this.movePanel.PerformLayout();
            this.guna2CustomGradientPanel2.ResumeLayout(false);
            this.guna2CustomGradientPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2CirclePictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Guna.UI2.WinForms.Guna2Button btnexit;
        private Guna.UI2.WinForms.Guna2CustomGradientPanel movePanel;
        private Guna.UI2.WinForms.Guna2CustomGradientPanel guna2CustomGradientPanel2;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
        private Guna.UI2.WinForms.Guna2GradientButton dashboard_btn;
        private Guna.UI2.WinForms.Guna2GradientButton addUsers_btn;
        private Guna.UI2.WinForms.Guna2GradientButton addCategories_btn;
        private Guna.UI2.WinForms.Guna2GradientButton addProducts_btn;
        private Guna.UI2.WinForms.Guna2GradientButton customers_btn;
        private Guna.UI2.WinForms.Guna2GradientButton log;
        private Guna.UI2.WinForms.Guna2HtmlLabel user_username;
        private Guna.UI2.WinForms.Guna2CirclePictureBox guna2CirclePictureBox1;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel2;
        private CashierCustomersForm cashierCustomersForm1;
        private AdminAddProducts adminAddProducts1;
        private AdminAddCategories adminAddCategories1;
        private AdminAddUser adminAddUser1;
        private AdminDashboard adminDashboard1;
    }
}