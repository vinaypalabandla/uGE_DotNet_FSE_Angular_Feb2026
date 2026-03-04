
--CREATING THE DATABASE--
CREATE DATABASE StoreDbSales;

---USING THE DATABASE---
USE StoreDbSales;

--CREATING THE STORES TABLE--

CREATE TABLE stores (
    store_id INT PRIMARY KEY IDENTITY(1,1),
    store_name VARCHAR(100)
);

--CREATING THE ORDERS TABLE_-

CREATE TABLE orders (
    order_id INT PRIMARY KEY IDENTITY(1,1),
    store_id INT,
    order_status INT,
    FOREIGN KEY (store_id) REFERENCES stores(store_id)
);


--CREATING THE ORDERS ITEMS TABLE--
CREATE TABLE order_items (
    item_id INT PRIMARY KEY IDENTITY(1,1),
    order_id INT,
    quantity INT,
    list_price DECIMAL(10,2),
    discount DECIMAL(4,2),
    FOREIGN KEY (order_id) REFERENCES orders(order_id)
);

---INSERTING DATA INSIDE STORES TABLES

INSERT INTO stores (store_name) VALUES('Hyderabad Store');
INSERT INTO stores (store_name) VALUES('Bangalore Store');
INSERT INTO stores (store_name) VALUES('Chennai Store');

--INSERTING DATA INSIDE THE ORDERS TABLES

INSERT INTO orders (store_id, order_status) VALUES(1,4);
INSERT INTO orders (store_id, order_status) VALUES(2,4);
INSERT INTO orders (store_id, order_status) VALUES(3,1);
INSERT INTO orders (store_id, order_status) VALUES(1,4);
INSERT INTO orders (store_id, order_status) VALUES(2,2);

--INSERTING THE DATA INOT THE ORDER ITEMS
INSERT INTO order_items (order_id, quantity, list_price, discount) VALUES(1,2,500,0.10);
INSERT INTO order_items (order_id, quantity, list_price, discount) VALUES(1,1,700,0.05);
INSERT INTO order_items (order_id, quantity, list_price, discount) VALUES(2,3,400,0.00);
INSERT INTO order_items (order_id, quantity, list_price, discount) VALUES(4,2,800,0.15);
INSERT INTO order_items (order_id, quantity, list_price, discount) VALUES(3,1,600,0.10);

--=======================================================================================
SELECT *FROM order_items;
SELECT * FROM orders;
SELECT * FROM stores;


--Requirements
--1. Display store_name and total sales amount.
--2. Calculate total sales using (quantity * list_price * (1 - discount)).
--3. Include only completed orders (order_status = 4).
--4. Group results by store_name.
--5. Sort total sales in descending order.
   SELECT 
    s.store_name,
    SUM(oi.quantity * oi.list_price * (1 - oi.discount)) AS total_sales
      FROM stores s
      INNER JOIN orders o
      ON s.store_id = o.store_id
      INNER JOIN order_items oi
      ON o.order_id = oi.order_id
      WHERE o.order_status = 4
      GROUP BY s.store_name
      ORDER BY total_sales DESC;




