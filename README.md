# 🛒 Sales & Inventory Management System (POS)

[![C#](https://img.shields.io/badge/Language-C%23-239120?style=for-the-badge&logo=c-sharp&logoColor=white)](https://docs.microsoft.com/en-us/dotnet/csharp/)
[![.NET Framework](https://img.shields.io/badge/.NET_Framework-4.8-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)](https://dotnet.microsoft.com/)
[![Windows Forms](https://img.shields.io/badge/GUI-Windows_Forms-blue?style=for-the-badge&logo=windows&logoColor=white)](https://docs.microsoft.com/en-us/dotnet/desktop/winforms/)
[![SQL Server LocalDB](https://img.shields.io/badge/Database-SQL_Server_LocalDB-CC292B?style=for-the-badge&logo=microsoftsqlserver&logoColor=white)](https://www.microsoft.com/sql-server)
[![UI Library](https://img.shields.io/badge/UI_Components-Guna.UI2_%7C_ReaLTaiizor-007ACC?style=for-the-badge)](https://github.com/)

> 💼 **Project Origin & Milestone**:
> Originally designed and developed during my **1st Year of College** as a premier course requirement. Recognizing its practical real-world utility, I marketed and customized this full-fledged POS and Inventory platform for student clients, successfully landing my **very first paid commissioned freelance software project**.

---

## 📋 Overview

The **Sales & Inventory Management System** is a robust desktop Point-of-Sale (POS) and inventory control solution built using **C# Windows Forms**, **Guna UI2 / ReaLTaiizor**, and **Microsoft SQL Server (LocalDB)**. 

Engineered with role-based access control (Admin & Cashier), it provides store owners and cashiers with real-time stock monitoring, automated POS transaction workflows, receipt printing, and income analytics.

---

## ✨ Key Features & Modules

### 👑 Admin Management
- 📊 **Executive Dashboard**: Real-time sales metrics (Total Income, Today's Income, Total Customer count, Total Active Staff).
- 👥 **User Account Control**: Create and manage staff credentials (Admin vs. Cashier roles) with active/inactive status toggles.
- 🏷️ **Category Management**: Organize inventory hierarchy with categorization.
- 📦 **Product Catalog**: Add, edit, remove, and track product inventory levels, pricing, status, and product thumbnail images (saved locally in `Product_Directory`).

### 💳 Cashier & POS Terminal
- 🛍️ **Interactive Order Terminal**: Fast category filtering, product selection, live stock validation, and dynamic order cart calculation.
- 💵 **Payment Processing**: Automated calculation for total cost, customer cash tendered, and exact change return.
- 🧾 **Receipt Generation & Printing**: Integrated `PrintDocument` receipt layout generating professional itemized paper/PDF receipts.
- 📜 **Customer Transaction Ledger**: Comprehensive history tracking customer order IDs, purchase amounts, and timestamps.

---

## 🏗️ Architecture & OOP / DRY Design

The project follows a clean **3-Tier modular architecture** ensuring separation of concerns:

```
Sales_Inventory_Management/
├── _Forms/                    # Top-level window forms & navigation
│   ├── Login.cs               # Multi-role authentication portal
│   ├── Register.cs            # User registration form
│   ├── MainForm.cs            # Admin management shell
│   └── CashierMainForm.cs     # Cashier POS workspace shell
├── _UserControls/             # Modular reusable UI views
│   ├── AdminDashboard.cs      # Sales KPI analytics view
│   ├── AdminAddUser.cs        # User administration view
│   ├── AdminAddCategories.cs  # Inventory category management
│   ├── AdminAddProducts.cs    # Product stock & image management
│   ├── CashierOrder.cs        # Real-time POS checkout terminal
│   └── CashierCustomersForm.cs# Customer order transaction history
├── _Models/                   # Business data models & Data Access Layer
│   ├── Database.cs            # Centralized DAL (DRY, parameterized queries)
│   ├── UsersData.cs           # User entity & database mapper
│   ├── CategoriesData.cs      # Category entity & mapper
│   ├── AddProductsData.cs     # Product entity & mapper
│   ├── OrdersData.cs          # Active cart order entity & mapper
│   └── CustomersData.cs       # Transaction ledger entity & mapper
├── Resources/                 # Icons, badges, and UI graphic assets
├── Product_Directory/         # File repository for product images
├── inventory.mdf              # LocalDB relational database
├── SQLQuery3.sql              # Database creation & initialization script
└── Program.cs                 # Application entry point
```

### 🔒 Centralized Data Access Layer (`Database.cs`)
- **DRY (Don't Repeat Yourself)**: Replaced repeated `SqlConnection` boilerplate across forms with centralized helper methods (`ExecuteQuery`, `ExecuteNonQuery`, `ExecuteScalar`).
- **SQL Injection Prevention**: All queries utilize parameterized `SqlParameter` arrays.
- **Dynamic Path Resolution**: Automatically traverses directories to locate `inventory.mdf` dynamically, eliminating machine-specific hardcoded file paths.

---

## 🗄️ Database Schema

The system relies on five relational tables in SQL Server:
- `userss`: User credentials, roles (`Admin` / `Cashier`), and account status.
- `categories`: Product category definitions.
- `products`: Product ID, name, category, price, available stock, image path, and status.
- `orders`: Transaction order lines linked to customer IDs with quantity and subtotal.
- `customers`: Finalized customer transactions with total price, cash tendered, change, and transaction date.

---

## 🚀 Getting Started

### Prerequisites
- **Visual Studio 2019 / 2022** with *.NET Desktop Development* workload.
- **.NET Framework 4.8**.
- **Microsoft SQL Server LocalDB** (included by default with Visual Studio).

### Installation & Setup
1. **Clone the Repository**:
   ```bash
   git clone https://github.com/Sho-jii/SalesInventoryManagement.git
   ```
2. **Open the Solution**:
   - Double-click `Sales_Inventory_Management.sln` in Visual Studio.
3. **Run Database Initialization (Optional)**:
   - If setting up a fresh database, execute `SQLQuery3.sql` in SQL Server Management Studio (SSMS) or Visual Studio SQL Server Object Explorer.
4. **Build & Run**:
   - Press `F5` or click **Start** in Visual Studio.
   - The embedded `inventory.mdf` is automatically discovered and attached at runtime.

### Default Login Credentials
| Role | Username | Password |
| :--- | :--- | :--- |
| **Admin** | `admin` | `admin123` |

---

## 👨‍💻 Author

**Jarib**
- GitHub: [@Sho-jii](https://github.com/Sho-jii)
- Portfolio / Commissioned Projects: *C# .NET Desktop Applications, POS Systems & Database Architectures*

## 📄 License
This project is open-source and available under the [MIT License](LICENSE).
