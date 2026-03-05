--1ST CREATE DATA BASE NAME AutoDb 
CREATE DATABASE AutoDb;

--USE DATA BASE
USE AutoDb;


--CREATE TABLE 1ST CATEGORIES BASED ON ID , NAME LIKE THAT
CREATE TABLE categories (
    category_id INT PRIMARY KEY IDENTITY(1,1),
    category_name VARCHAR(50)
);


--CRETE TABLE FOR PRODUCTS  BASED ON id  , name, model year, price
CREATE TABLE products (
    product_id INT PRIMARY KEY IDENTITY(1,1),
    product_name VARCHAR(50),
    category_id INT,
    model_year INT,
    list_price DECIMAL(10,2),
    FOREIGN KEY (category_id) REFERENCES categories(category_id)
);

---Inserting DATA HERE INTO THE CATEGORIES
INSERT INTO categories VALUES('KIA');
INSERT INTO categories VALUES('SUV');
INSERT INTO categories VALUES('TATA');

--=============================
SELECT * FROM categories;
SELECT * FROM products;
--=============================

--INSERTING DATA INTO THE CATEGORIES
INSERT INTO products VALUES('Honda City',1,2017,15000);
INSERT INTO products VALUES('Hyundai Verna',1,2018,18000);
INSERT INTO products VALUES('Toyota Camry',1,2019,25000);
INSERT INTO products VALUES('Ford EcoSport',2,2017,20000);
INSERT INTO products VALUES('Hyundai Creta',2,2018,22000);
INSERT INTO products VALUES('Toyota Fortuner',2,2019,35000);
INSERT INTO products VALUES('Audi R8',3,2017,90000);
INSERT INTO products VALUES('BMW Z4',3,2018,75000);
INSERT INTO products VALUES('Porsche 911',3,2019,120000);

--Requirements
--1. Retrieve product details (product_name, model_year, list_price).
SELECT 
  product_name, 
  model_year, 
  list_price
  FROM products;
--2. Compare each product’s price with the average price of products in the same category using a nested query.
SELECT 
    product_name,
    model_year,
    list_price
FROM products p1
WHERE list_price >
(
    SELECT AVG(list_price)
    FROM products p2
    WHERE p2.category_id = p1.category_id
);
--3. Display only those products whose price is greater than the category average.
SELECT product_name, model_year, list_price
    FROM products p1
    WHERE list_price >
        (
    SELECT AVG(list_price)
    FROM products p2
    WHERE p2.category_id = p1.category_id
	);
--4. Show calculated difference between product price and category average.
SELECT 
    product_name,
    model_year,
    list_price,
    list_price - (
        SELECT AVG(list_price)
        FROM products p2
        WHERE p2.category_id = p1.category_id
               ) AS pricediffernce
                  FROM products p1;
--5. Concatenate product name and model year as a single column (e.g., 'ProductName (2017)').
          SELECT 
             CONCAT(product_name, ' (',model_year,' )') AS product_details
             FROM products;
 




--1. Retrieve product details (product_name, model_year, list_price).
--2. Compare each product’s price with the average price of products in the same category using a nested query.
--3. Display only those products whose price is greater than the category average.
--4. Show calculated difference between product price and category average.
--5. Concatenate product name and model year as a single column (e.g., 'ProductName (2017)').

 ---ENTIRE QUERY---
SELECT 
    CONCAT(product_name,' (',model_year,')') AS product_details,
    product_name,
    model_year,
    list_price,
    list_price - (
        SELECT AVG(list_price)
        FROM products p2
        WHERE p2.category_id = p1.category_id
    ) AS price_difference
      FROM products p1
WHERE list_price >
(
    SELECT AVG(list_price)
    FROM products p2
    WHERE p2.category_id = p1.category_id
);

--*******************************************************************************************

--ERROR occured this
-- this error occured when Auto icreement passed no need mention here again id or we below error
--An explicit value for the identity 
--column in table 'categories' can only
--be specified when a column list is used and 
--IDENTITY_INSERT is ON.
