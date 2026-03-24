CREATE DATABASE ProductDB;
USE ProductDB;

CREATE TABLE Products (
ProductId INT PRIMARY KEY IDENTITY(1,1),
ProductName VARCHAR(100),
Category VARCHAR(50),
Price DECIMAL(10,2)
);

ALTER TABLE Products ADD Stock INT;
ALTER TABLE Products
DROP COLUMN Stock;
---insert
CREATE PROCEDURE sp_InsertProduct
     @ProductName VARCHAR(100),
	 @Category VARCHAR(50),
	 @Price DECIMAL(10,2)
	 AS
	 BEGIN
	 INSERT INTO Products(ProductName, Category, Price)
	 VALUES (@ProductName, @Category,@Price);
	 END;

--get all products
CREATE PROCEDURE sp_GetAllProducts
AS
BEGIN
    SELECT * FROM Products;
END


--update
CREATE PROCEDURE sp_UpdateProduct
    @ProductId INT,
    @ProductName VARCHAR(100),
    @Category VARCHAR(50),
    @Price DECIMAL(10,2)
AS
BEGIN
    UPDATE Products
    SET ProductName = @ProductName,
        Category = @Category,
        Price = @Price
    WHERE ProductId = @ProductId;
END
--delete
CREATE PROCEDURE sp_DeleteProduct
    @ProductId INT
AS
BEGIN
    DELETE FROM Products WHERE ProductId = @ProductId;
END

--===============get product by id=====
CREATE PROCEDURE GetProductByID
    @ProductID INT
AS
BEGIN
   
    SELECT *
    FROM Products
    WHERE ProductID = @ProductID;
END

EXEC GetProductByID 1;




---testing
select * from Products;