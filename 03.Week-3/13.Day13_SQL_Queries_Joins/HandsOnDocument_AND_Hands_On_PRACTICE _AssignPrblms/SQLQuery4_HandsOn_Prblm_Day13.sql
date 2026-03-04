
--******** CREATE DAATBASE HERE********---
CREATE DATABASE StoreDbSales;

--USE THE DATABASES---
USE StoreDbSales;

--CREATE TABLE stores (
 --   store_id INT PRIMARY KEY IDENTITY(1,1),
 --   store_name VARCHAR(100)
--);

--CCREATING THE PRODUCTS--
CREATE TABLE products (
    product_id INT PRIMARY KEY IDENTITY(1,1),
    product_name VARCHAR(100)
);

---CREATING STOCKS TABLES--
CREATE TABLE stocks (
    store_id INT,
    product_id INT,
    quantity INT,
    PRIMARY KEY (store_id, product_id),
    FOREIGN KEY (store_id) REFERENCES stores(store_id),
    FOREIGN KEY (product_id) REFERENCES products(product_id)
);

--CREATING THE ORDERITMS----
CREATE TABLE order_itms (
    order_item_id INT PRIMARY KEY IDENTITY(1,1),
    product_id INT,
    quantity INT,
    FOREIGN KEY (product_id) REFERENCES products(product_id)
);

--INSERT INTO stores (store_name) VALUES('Hyderabad Store');
--INSERT INTO stores (store_name) VALUES('Bangalore Store');
--INSERT INTO stores (store_name) VALUES('Chennai Store');

INSERT INTO products (product_name) VALUES('Laptop');
INSERT INTO products (product_name) VALUES('Mobile');
INSERT INTO products (product_name) VALUES('Tablet');

INSERT INTO stocks (store_id, product_id, quantity) VALUES(1,1,50);
INSERT INTO stocks (store_id, product_id, quantity) VALUES(1,2,30);
INSERT INTO stocks (store_id, product_id, quantity) VALUES(2,1,40);
INSERT INTO stocks (store_id, product_id, quantity) VALUES(2,3,20);

INSERT INTO order_itms (product_id, quantity) VALUES(1,5);
INSERT INTO order_itms (product_id, quantity)VALUES(1,3);
INSERT INTO order_itms (product_id, quantity)VALUES(2,4);
--================================================================
SELECT * FROM stocks;
SELECT * FROM products;
SELECT * FROM order_items;
SELECT * FROM stores;
--==============================================================

--Query EXctued--

--Requirements
--1. Display product_name, store_name, available stock quantity, and total quantity sold.
--2. Include products even if they have not been sold (use appropriate join).
--3. Group results by product_name and store_name.
--4. Sort results by product_name.

SELECT 
    p.product_name,
    s.store_name,
    st.quantity AS stock_quantity,
    SUM(oi.quantity) AS total_quantity_sold
FROM stocks st
INNER JOIN products p
ON st.product_id = p.product_id
INNER JOIN stores s
ON st.store_id = s.store_id
LEFT JOIN order_itms oi
ON p.product_id = oi.product_id
GROUP BY p.product_name, s.store_name, st.quantity
ORDER BY p.product_name;

----===============================================
SELECT  SUM(quantity) AS total_quantity_sold
FROM order_itms ;

----================
SELECT 
    p.product_name
   FROM products st
   INNER JOIN products p
   ON st.product_id = p.product_id;
 --=========================
 SELECT product_name
 FROM products p
 LEFT JOIN order_itms oi
ON p.product_id = oi.order_item_id;
