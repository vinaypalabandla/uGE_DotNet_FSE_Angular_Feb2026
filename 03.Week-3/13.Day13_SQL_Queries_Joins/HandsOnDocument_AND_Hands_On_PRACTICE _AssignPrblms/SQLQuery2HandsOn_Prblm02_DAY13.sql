

USE StoreDB;

CREATE TABLE brands (
        brandId INT PRIMARY KEY,
		brandName VARCHAR(50)
);


CREATE TABLE categories (
      categoryId INT PRIMARY KEY,
	  categoryName VARCHAR(50)
	  );

CREATE table products (
     productId INT PRIMARY KEY,
	 productName VARCHAR(50),
	 brandId INT,
	 categoryId INT,
	 modelYear INT,
	 listPrice DECIMAL(10,2),
	 FOREIGN KEY (brandId) REFERENCES  brands(brandId),
	 FOREIGN KEY (categoryId) REFERENCES categories(categoryId)
	 );


 INSERT INTO brands VALUES(101,'Samsung');
 INSERT INTO brands VALUES(102,'Apple');
 INSERT INTO brands VALUES(103,'OnePlus');
 INSERT INTO brands VALUES(104,'Dell');
 INSERT INTO brands VALUES(105,'HP');
 INSERT INTO brands VALUES(106,'Noise');

 SELECT * FROM brands;
 
 INSERT INTO categories values(1,'Moblie');
 INSERT INTO categories values(2,'Laptop');
 INSERT INTO categories values(3,'Tablet');
 INSERT INTO categories values(4,'Watches');

 SELECT * FROM categories;

 INSERT INTO products VALUES(501,'GalaxyM31',101,1,2023,1200);
 INSERT INTO products VALUES(502,'iphone',102,1,2024,1000);
 INSERT INTO products VALUES(503,'Dell Inspiron',103,2,2025,600);
 INSERT INTO products VALUES(504,'HP Pavilion',104,2,2026,700);
 INSERT INTO products VALUES(505,'OnePlus TAB',105,3,2026,1500);
 INSERT INTO products VALUES(506,'noisewatch',106,4,2024,400);

 SELECT * FROM products;


-- Requirements
-- 1. Display product_name, brand_name, category_name, model_year, and list_price.
-- 2. Filter products with list_price greater than 500.
-- 3. Sort results by list_price in ascending order.



 SELECT 
     productName,
	 brandName,
	 categoryName,
	 modelYear,
	 listPrice
	 from products
	 INNER JOIN brands
	 ON products.brandId = brands.brandId
	 INNER JOIN categories 
	 ON products.categoryId=categories.categoryId
	 where products.listPrice>500
	 order by products.listPrice ASC;


select productName 
	 from products
	 where productId =502;





