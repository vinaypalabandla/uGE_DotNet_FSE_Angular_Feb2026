
-- CREATE DATABASE
CREATE DATABASE CompanyDB;

USE CompanyDB;

CREATE TABLE brands (
    brand_id INT PRIMARY KEY,
    brand_name VARCHAR(100) NOT NULL
);

CREATE TABLE categories (
    category_id INT PRIMARY KEY,
    category_name VARCHAR(100) NOT NULL
);

CREATE TABLE products (
    product_id INT PRIMARY KEY,
    product_name VARCHAR(150) NOT NULL,
    brand_id INT,
    category_id INT,
    model_year INT,
    list_price DECIMAL(10,2),
    FOREIGN KEY (brand_id) REFERENCES brands(brand_id),
    FOREIGN KEY (category_id) REFERENCES categories(category_id)
);


CREATE TABLE stores (
    store_id INT PRIMARY KEY,
    store_name VARCHAR(150),
    phone VARCHAR(20),
    email VARCHAR(100),
    street VARCHAR(200),
    city VARCHAR(100),
    state VARCHAR(50),
    zip_code VARCHAR(10)
);

CREATE TABLE customers (
    customer_id INT PRIMARY KEY,
    first_name VARCHAR(100),
    last_name VARCHAR(100),
    phone VARCHAR(20),
    email VARCHAR(150),
    street VARCHAR(200),
    city VARCHAR(100),
    state VARCHAR(50),
    zip_code VARCHAR(10)
);

CREATE TABLE staffs (
    staff_id INT PRIMARY KEY,
    first_name VARCHAR(100),
    last_name VARCHAR(100),
    email VARCHAR(150),
    phone VARCHAR(20),
    active BIT,
    store_id INT,
    manager_id INT NULL,
    FOREIGN KEY (store_id) REFERENCES stores(store_id)
);

CREATE TABLE orders (
    order_id INT PRIMARY KEY,
    customer_id INT,
    order_status INT,
    order_date DATE,
    required_date DATE,
    shipped_date DATE,
    store_id INT,
    staff_id INT,
    FOREIGN KEY (customer_id) REFERENCES customers(customer_id),
    FOREIGN KEY (store_id) REFERENCES stores(store_id),
    FOREIGN KEY (staff_id) REFERENCES staffs(staff_id)
);

CREATE TABLE order_items (
    order_id INT,
    item_id INT,
    product_id INT,
    quantity INT,
    list_price DECIMAL(10,2),
    discount DECIMAL(5,2),
    PRIMARY KEY (order_id, item_id),
    FOREIGN KEY (order_id) REFERENCES orders(order_id),
    FOREIGN KEY (product_id) REFERENCES products(product_id)
);

-- BRANDS
INSERT INTO brands VALUES
(1, 'Dell'),
(2, 'Samsung');

-- CATEGORIES
INSERT INTO categories VALUES
(1, 'Electronics'),
(2, 'Accessories');

-- PRODUCTS
INSERT INTO products VALUES
(1, 'Laptop', 1, 1, 2023, 50000),
(2, 'Mobile', 2, 1, 2023, 20000),
(3, 'Headphones', 2, 2, 2023, 3000),
(4, 'Keyboard', 1, 2, 2023, 1500),
(5, 'Mouse', 1, 2, 2023, 800),
(6, 'Monitor', 1, 1, 2023, 12000);

-- STORES
INSERT INTO stores VALUES
(1, 'Hyderabad Store', '9000000001', 'hyd@store.com', 'Street 1', 'Hyderabad', 'TS', '500001'),
(2, 'Bangalore Store', '9000000002', 'blr@store.com', 'Street 2', 'Bangalore', 'KA', '560001');

-- CUSTOMERS
INSERT INTO customers VALUES
(1, 'Vinay', 'Kumar', '9999999991', 'vinay@email.com', 'Road 1', 'Hyderabad', 'TS', '500001'),
(2, 'Rahul', 'Sharma', '9999999992', 'rahul@email.com', 'Road 2', 'Hyderabad', 'TS', '500002'),
(3, 'Anjali', 'Reddy', '9999999993', 'anjali@email.com', 'Road 3', 'Bangalore', 'KA', '560001'),
(4, 'Kiran', 'Das', '9999999994', 'kiran@email.com', 'Road 4', 'Bangalore', 'KA', '560002');

-- STAFFS
INSERT INTO staffs VALUES
(1, 'Admin', 'User', 'admin@store.com', '8888888888', 1, 1, NULL);

-- ORDERS
INSERT INTO orders VALUES
(101, 1, 1, '2026-03-01', '2026-03-05', '2026-03-03', 1, 1),
(102, 2, 1, '2026-03-02', '2026-03-06', '2026-03-04', 1, 1),
(103, 3, 1, '2026-03-03', '2026-03-07', '2026-03-05', 2, 1),
(104, 4, 1, '2026-03-04', '2026-03-08', '2026-03-06', 2, 1);

-- ORDER ITEMS
INSERT INTO order_items VALUES
(101, 1, 1, 2, 50000, 0.10),
(101, 2, 3, 3, 3000, 0.05),
(102, 1, 2, 1, 20000, 0.00),
(102, 2, 4, 5, 1500, 0.10),
(103, 1, 1, 1, 50000, 0.15),
(103, 2, 5, 10, 800, 0.05),
(104, 1, 6, 2, 12000, 0.10),
(104, 2, 2, 4, 20000, 0.05);


--1)Create a stored procedure to generate total sales amount per store.
CREATE PROCEDURE usp_GetTotalSalesByStore
      AS
	  BEGIN
	      SELECT
		  s.store_id,
		  s.store_name,
		  SUM(oi.quantity * oi.list_price * (1-oi.discount)) AS totalSales
		  FROM stores s
		  JOIN orders o
		  ON s.store_id = o.store_id
		  JOIN order_items oi
		  ON o.order_id = oi.order_id
		  GROUP BY s.store_name,s.store_id;
	  END;

DROP PROCEDURE usp_GetTotalSalesByStore

EXEC usp_GetTotalSalesByStore;

--2)Create a stored procedure to retrieve orders by date range.
CREATE PROCEDURE usp_GetOrdersByDateRange
    @StartDate DATE,
	@EndDate DATE
AS
BEGIN
     SELECT * 
	 FROM orders
	 where order_date BETWEEN @StartDate AND @EndDate;
END;
---EXCUTE
EXECUTE usp_GetOrdersByDateRange
    @StartDate = '2026-03-01',
	@EndDate = '2026-03-05';


--3)Create a scalar function to calculate total price after discount.
CREATE FUNCTION fn_CalculateTotalDiscount
(
  @Quantity INT,
  @ListPrice DECIMAL(10,2),
  @Discount DECIMAL(5,2)
  )
RETURNS DECIMAL(18,2)
AS
BEGIN
   RETURN(@Quantity * @ListPrice*(1-@Discount));
END;

--EXCUTE
SELECT dbo.fn_CalculateTotalDiscount(2, 50000, 0.10) AS Total_Price_After_Discount;

--4) Create a table-valued function to return top 5 selling products.
CREATE FUNCTION fn_GetTop5SellingProducts()
RETURNS TABLE
AS
RETURN
(
    SELECT TOP 5
        product_id,
        SUM(quantity) AS total_quantity_sold
    FROM order_items
    GROUP BY product_id
    ORDER BY total_quantity_sold DESC
);

--EXCUTE
SELECT *  FROM dbo.fn_GetTop5SellingProducts();