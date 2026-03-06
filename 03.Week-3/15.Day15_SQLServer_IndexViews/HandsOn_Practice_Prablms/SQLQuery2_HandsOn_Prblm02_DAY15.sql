/* HANDSON DAY-5 2nd prblm
Scenario
The management team frequently accesses product and order summary reports. To simplify access and improve performance, they require database views and indexing.

📌 Requirements 
- Create a view that shows product name, brand name, category name, model year and list price.
- Create a view that shows order details with customer name, store name and staff name.
- Create appropriate indexes on foreign key columns.
- Test performance improvement using execution plan.*/
--=====================================================================================
--2))=====================================================================================
USE EcommDb;

--1)Create a view that shows product name, brand name, category name, model year and list price.
CREATE VIEW vw_ProductDetails AS
SELECT
    p.product_name,
	b.brand_name,
	c.category_name,
	p.price
 FROM products p
 Join brands b  ON p.brand_id = b.brand_id
 Join categories c on p.category_id=c.category_id;

---2)Create a view that shows order details with customer name, store name and staff name.
CREATE VIEW vw_OrderDetails AS
SELECT 
     o.order_id,
	 c.customers_name
	 s.store_name
	 FROM orders o --not create order table still 
	 join  customers c on o.customer_id = c.customer_id;
	 join stores s ON o.store_id =s.store_id;

--TESTING VEIWS RETRIVE
select * from vw_ProductDetails; ---1st one retrive
select * FROM vw_OrderDetails;  -- 2nd 

--3)Create appropriate indexes on foreign key columns.
---INDEXES----
CREATE NONCLUSTERED
INDEX idx_products_brand_id
ON products(brand_id);

-- Test performance improvement using execution plan.

     sp_helpindex products;

CREATE NONCLUSTERED 
INDEX idx_products_category_id
ON products(category_id);
-- Test performance improvement using execution plan.
    sp_helpindex products;

CREATE NONCLUSTERED INDEX 
idx_orders_customer_id
ON orders(customer_id);

-- Test performance improvement using execution plan.

sp_helpindex orders;

