/*DAY-5 Hands On
Pre-Requisites: Before starting with problem solving, please make sure that you have created a database and restored data  
Level-1 Problem 1: Basic Setup and Data Retrieval in EcommDb

Scenario
You are assigned as a database developer to set up the EcommDb database for an automobile retail company. The company wants to verify basic operations such as inserting data and retrieving product and customer information.

📌 Requirements 
- Create EcommDb and all tables using the provided schema.
- Insert at least 5 records in categories, brands, products, customers, and stores.
- Write SELECT queries to retrieve all products with their brand and category names.
- Retrieve all customers from a specific city.
- Display total number of products available in each category.

🛠️ Technical Constraints 
- Use SQL Server.
- Use ANSI SQL queries wherever applicable.
- Do not modify the existing table structure.
- Ensure foreign key constraints are satisfied while inserting data.

Expectations
- Successful creation of database and tables.
- Accurate data insertion without constraint violations.
- Correct JOIN queries to retrieve relational data.

🎯 Learning Outcome 
- Understand database setup process.
- Learn basic SELECT, INSERT and JOIN operations.
- Gain understanding of relational data retrieval. */

-- 1)Create EcommDb and all tables using the provided schema.
CREATE DATABASE EcommDb;
USE EcommDb;

-- Create Tables
CREATE TABLE categories (
    category_id INT PRIMARY KEY,
    category_name VARCHAR(100) NOT NULL
);

CREATE TABLE brands (
    brand_id INT PRIMARY KEY,
    brand_name VARCHAR(100) NOT NULL
);

CREATE TABLE products (
    product_id INT PRIMARY KEY,
    product_name VARCHAR(100) NOT NULL,
    brand_id INT,
    category_id INT,
    price DECIMAL(10,2),
    FOREIGN KEY (brand_id) REFERENCES brands(brand_id),
    FOREIGN KEY (category_id) REFERENCES categories(category_id)
);

CREATE TABLE customers (
    customer_id INT PRIMARY KEY,
    customer_name VARCHAR(100) NOT NULL,
    city VARCHAR(100),
    email VARCHAR(100)
);

CREATE TABLE stores (
    store_id INT PRIMARY KEY,
    store_name VARCHAR(100),
    city VARCHAR(100)
);

--2)Insert at least 5 records in categories, brands, products, customers, and stores.
-- Insert Data into categories
INSERT INTO categories VALUES
(1, 'SUV'),
(2, 'Sedan'),
(3, 'Hatchback'),
(4, 'Electric'),
(5, 'Luxury');

-- Insert Data into brands
INSERT INTO brands VALUES
(1, 'Toyota'),
(2, 'Honda'),
(3, 'Hyundai'),
(4, 'Tesla'),
(5, 'BMW');

-- Insert Data into products
INSERT INTO products VALUES
(1, 'Fortuner', 1, 1, 3500000),
(2, 'City', 2, 2, 1500000),
(3, 'i20', 3, 3, 800000),
(4, 'Model 3', 4, 4, 5000000),
(5, 'X5', 5, 5, 7000000);

-- Insert Data into customers
INSERT INTO customers VALUES
(1, 'Ravi Kumar', 'Bangalore', 'ravi@gmail.com'),
(2, 'Anita Sharma', 'Hyderabad', 'anita@gmail.com'),
(3, 'Vikram Rao', 'Chennai', 'vikram@gmail.com'),
(4, 'Sneha Reddy', 'Bangalore', 'sneha@gmail.com'),
(5, 'Arjun Mehta', 'Mumbai', 'arjun@gmail.com');

-- Insert Data into stores
INSERT INTO stores VALUES
(1, 'AutoHub Bangalore', 'Bangalore'),
(2, 'CarZone Hyderabad', 'Hyderabad'),
(3, 'Speed Motors Chennai', 'Chennai'),
(4, 'Elite Cars Mumbai', 'Mumbai'),
(5, 'Premium Autos Delhi', 'Delhi');

--3) Write SELECT queries to retrieve all products with their brand and category names.
SELECT 
    p.product_name,
    b.brand_name,
    c.category_name
FROM products p
INNER JOIN brands b ON p.brand_id = b.brand_id
INNER JOIN categories c ON p.category_id = c.category_id;

-- 4)Retrieve all customers from a specific city.
SELECT *
FROM customers
WHERE city = 'Bangalore';

--5)Display total number of products available in each category 
SELECT 
    c.category_name,
    COUNT(p.product_id) AS total_products
FROM categories c
left join products p
ON c.category_id = p.category_id
GROUP BY c.category_name;
