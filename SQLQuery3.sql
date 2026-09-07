CREATE TABLE userss
(
	id int PRIMARY KEY IDENTITY(1,1),
	username VARCHAR(MAX) NULL,
	password VARCHAR(MAX) NULL, 
	role VARCHAR(MAX) NULL, 
	status VARCHAR(MAX) NULL,
	date DATE NULL
)

SELECT * FROM userss

INSERT INTO userss(username, password, role, status, date) VALUES('admin', 'admin123', 'Admin', 'Active', '2024-05-15')

CREATE TABLE categories
(
	id INT PRIMARY KEY IDENTITY(1,1),
	category VARCHAR(MAX) NULL,
	date DATE NULL
)	

SELECT * FROM categories

CREATE TABLE products
(
	id INT PRIMARY KEY IDENTITY(1,1),
	prod_id VARCHAR(MAX) NULL,
	prod_name VARCHAR(MAX) NULL,
	category VARCHAR(MAX) NULL,
	price FLOAT NULL,
	stock INT NULL,
	image_path VARCHAR(MAX) NULL,
	status VARCHAR(MAX) NULL,
	date_insert DATE NULL
)

SELECT * FROM products

CREATE TABLE orders
(
	id int PRIMARY KEY IDENTITY(1,1),
	prod_id VARCHAR(MAX) NULL,
	prod_name VARCHAR(MAX) NULL,
	category VARCHAR (MAX) NULL,
	qty INT NULL,
	orig_price FLOAT NULL,
	total_price FLOAT NULL,
	order_date DATE NULL
)

ALTER TABLE orders
ADD customer_id INT NULL

SELECT * FROM orders

CREATE TABLE customers
(
	id INT PRIMARY KEY IDENTITY(1,1),
	customer_id INT NULL,
	prod_id VARCHAR(MAX) NULL,
	total_price FLOAT NULL,
	amount FLOAT NULL,
	change FLOAT NULL,
	order_date DATE NULL
)

SELECT * FROM customers

ALTER TABLE customers
DROP COLUMN prod_id