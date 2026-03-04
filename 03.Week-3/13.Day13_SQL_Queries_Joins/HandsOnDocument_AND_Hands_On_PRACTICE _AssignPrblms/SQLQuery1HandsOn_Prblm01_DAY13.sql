
----------------CREATING DATA BASE FIRST HERE--

CREATE DATABASE StoreDB;

USE StoreDB;

--CREATING CUSTOMER TABLE--- 

CREATE TABLE  customers (
   customerid INT IDENTiTY(1,1) PRIMARY KEY,
   firstname VARCHAR(50),
   lastname VARCHAR(50)
   );

   ---CREAITNG ORDERS TABLE----

CREATE TABLE orders (
    orderid INT  PRIMARY KEY,
	customerid INT,
	orderdate DATE,
	orderstatus INT,
	FOREIGN KEY (customerid) REFERENCES customers(customerid)
	);

---*********CROSS CHECK PURPOSE ******
SELECT * FROM customers;
SELECT * FROM orders;

--DROP TABLE customers;
--DROP TABLE orders;

---INSERTING DATA INTO  DATA INTO CUSTOMERS TABLES----

INSERT INTO customers(firstname,lastname) VALUES ('Vinay','Palabandla');
INSERT INTO customers(firstname,lastname) VALUES ('Ravi','Kumar');
INSERT INTO customers(firstname,lastname) VALUES ('Raja','Verma');
INSERT INTO customers(firstname,lastname) VALUES ('Varun','Reddy');
INSERT INTO customers(firstname,lastname) VALUES ('Krishna','Sai');

---INSERTING DATA INTO ORDERS TABLES--

INSERT INTO orders(customerid,orderdate,orderstatus) VALUES(1,'2026-03-01',1);
INSERT INTO orders(customerid,orderdate,orderstatus) VALUES(2,'2026-03-02',4);
INSERT INTO orders(customerid,orderdate,orderstatus) VALUES(3,'2026-03-03',6);
INSERT INTO orders(customerid,orderdate,orderstatus) VALUES(4,'2026-03-04',3);
INSERT INTO orders(customerid,orderdate,orderstatus) VALUES(5,'2026-03-05',1);

---QUERY EXCUTED----
--Requirements
--1. Retrieve customer first name, last name, order_id, order_date, and order_status.
--2. Display only orders with status Pending (1) or Completed (4).
--3. Sort the results by order_date in descending order.

SELECT 
firstname,lastname, orderid,orderdate,orderstatus
FROM customers
INNER JOIN
orders  ON
customers.customerid = orders.customerid
WHERE orders.orderstatus =1  or orders.orderstatus =4
ORDER BY orders.orderdate DESC;

----====================================================