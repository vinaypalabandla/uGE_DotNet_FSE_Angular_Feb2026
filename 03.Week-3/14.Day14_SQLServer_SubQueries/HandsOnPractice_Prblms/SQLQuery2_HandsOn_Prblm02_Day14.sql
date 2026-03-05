/*Level-1: Problem 2 – Customer Activity Classification

Scenario:
The company wants to classify customers based on their total order value and identify customers who have placed orders versus those who have not.

📌 Requirements
1. Use nested query to calculate total order value per customer.
2. Classify customers using conditional logic:
   - 'Premium' if total order value > 10000
   - 'Regular' if total order value between 5000 and 10000
   - 'Basic' if total order value < 5000
3. Use UNION to display customers with orders and customers without orders.
4. Display full name using string concatenation.
5. Handle NULL cases appropriately.


🛠️ Technical Constraints
• Use CASE statement for classification.
• Use UNION operator.
• Use subquery for total calculation.
• Use JOIN between customers and orders tables.

Expectations:
• Proper implementation of UNION.
• Correct usage of CASE expression.
• Accurate total value calculation.

🎯 Learning Outcome 
• Apply conditional logic in SQL.
• Combine results using set operators.
• Work with nested aggregation queries.*/

CREATE DATABASE AutoDb;

USE AutoDb;

CREATE TABLE customers (
    customer_id INT PRIMARY KEY,
    first_name VARCHAR(50),
    last_name VARCHAR(50)
);

CREATE TABLE orders (
    order_id INT PRIMARY KEY,
    customer_id INT,
    order_value DECIMAL(10,2),
    FOREIGN KEY (customer_id) REFERENCES customers(customer_id)
);

INSERT INTO customers VALUES(1,'vini','kumar');
INSERT INTO customers VALUES(2,'ravi','varma');
INSERT INTO customers VALUES(3,'raju','bai');
INSERT INTO customers VALUES(4,'shivam','dube');
INSERT INTO customers VALUES(5,'David','varner');

INSERT INTO orders VALUES(101,1,6000);
INSERT INTO orders VALUES(102,1,5000);
INSERT INTO orders VALUES(103,2,3000);
INSERT INTO orders VALUES(104,2,1500);
INSERT INTO orders VALUES(105,3,12000);



--1. Use nested query to calculate total order value per customer.
   SELECT 
     c.customer_id,
    (SELECT SUM(order_value)  --calculate total order value for each customer
     FROM orders o
     WHERE o.customer_id = c.customer_id) AS total_order_value
   FROM customers c;

   --2. Classify customers using conditional logic:
 --  - 'Premium' if total order value > 10000
 --  - 'Regular' if total order value between 5000 and 10000
 --  - 'Basic' if total order value < 5000
 SELECT 
    c.customer_id,
    (SELECT SUM(order_value)
     FROM orders o
     WHERE o.customer_id = c.customer_id) AS total_order_value,
     
    CASE
        WHEN (SELECT SUM(order_value) FROM orders o WHERE o.customer_id = c.customer_id) > 10000 THEN 'Premium'
        WHEN (SELECT SUM(order_value) FROM orders o WHERE o.customer_id = c.customer_id) BETWEEN 5000 AND 10000 THEN 'Regular'
        WHEN (SELECT SUM(order_value) FROM orders o WHERE o.customer_id = c.customer_id) < 5000 THEN 'Basic'
    END AS customer_type
       FROM customers c;

--3. Use UNION to display customers with orders and customers without orders.
   SELECT customer_id
        FROM orders   ---- who placed the orders
        UNION
        SELECT customer_id
        FROM customers
        WHERE customer_id NOT IN (SELECT customer_id FROM orders); -- who not placed the orders

--4. Display full name using string concatenation.
SELECT CONCAT(first_name,' ',last_name) AS full_name
FROM customers;

--5. Handle NULL cases appropriately.
SELECT 
    c.customer_id,
    ISNULL(SUM(o.order_value),0) AS total_order_value
FROM customers c
LEFT JOIN orders o
ON c.customer_id = o.customer_id
GROUP BY c.customer_id;

--2. Classify customers using conditional logic:
 --  - 'Premium' if total order value > 10000
 --  - 'Regular' if total order value between 5000 and 10000
 --  - 'Basic' if total order value < 5000

      

--************************WORK Pending -------


SELECT 
    CONCAT(c.first_name,' ',c.last_name) AS full_name,
    total_amount,
    CASE 
        WHEN total_amount > 10000 THEN 'Premium'
        WHEN total_amount BETWEEN 5000 AND 10000 THEN 'Regular'
        WHEN total_amount < 5000 THEN 'Basic'
    END AS customer_type
FROM customers c
JOIN
(
    SELECT customer_id, SUM(order_value) AS total_amount
    FROM orders
    GROUP BY customer_id
) t
ON c.customer_id = t.customer_id

UNION

SELECT 
    CONCAT(first_name,' ',last_name) AS full_name,
    NULL AS total_amount,
    'No Orders' AS customer_type
FROM customers
WHERE customer_id NOT IN
(
    SELECT customer_id FROM orders
);

