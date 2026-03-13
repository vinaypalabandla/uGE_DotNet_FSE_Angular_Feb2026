/*SQL Server Case Study

Assignment Case Study: Stored Procedures & Transactions in SQL Server 
 Business Scenario – “BookMart Online Bookstore” (Simplified)
BookMart needs a reliable way to place customer orders without overselling books. When a customer orders a book:
•	Check if enough stock is available.
•	If yes → reduce stock and record the order.
•	If no → do not change anything (no partial updates).
Your task is to implement this safely using one stored procedure with transaction control and basic error handling.
Database Schema (Use this – create if needed)
SQL
CREATE TABLE Books (
    BookID  INT IDENTITY(1,1) PRIMARY KEY,
    Title   NVARCHAR(150) NOT NULL,
    Stock   INT NOT NULL CHECK (Stock >= 0),
    Price   DECIMAL(10,2) NOT NULL
);

CREATE TABLE Orders (
    OrderID    INT IDENTITY(1,1) PRIMARY KEY,
    BookID     INT NOT NULL,
    Quantity   INT NOT NULL CHECK (Quantity > 0),
    OrderDate  DATETIME2 DEFAULT SYSDATETIME(),
    FOREIGN KEY (BookID) REFERENCES Books(BookID)
);
Assignment Tasks  
Task 1: Stored Procedure to Add a Book  
Create a stored procedure named sp_AddNewBook that takes: @Title NVARCHAR(150), @Stock INT, @Price DECIMAL(10,2)
•	Insert the new book into the Books table.
•	Use TRY…CATCH to handle errors (e.g., invalid stock or price).
•	Print a success message or error message.
Task 2: Main Stored Procedure – Place Order with Transaction  
Create a stored procedure named sp_PlaceOrder with parameters: @BookID INT, @Quantity INT
Must include all of the following:
1.	SET XACT_ABORT ON; at the beginning.
2.	BEGIN TRY
o	BEGIN TRANSACTION
o	Check if book exists and Stock >= @Quantity
	If not → RAISERROR('Not enough stock or book not found.', 16, 1);
o	UPDATE Books SET Stock = Stock - @Quantity WHERE BookID = @BookID;
o	INSERT INTO Orders (BookID, Quantity) VALUES (@BookID, @Quantity);
o	COMMIT TRANSACTION;
o	Print success message: 'Order placed successfully.'
3.	END TRY
4.	BEGIN CATCH
o	If @@TRANCOUNT > 0 then ROLLBACK TRANSACTION;
o	Print error details: number + message (use ERROR_NUMBER(), ERROR_MESSAGE())
o	Example: 'Error ' + CAST(ERROR_NUMBER() AS VARCHAR) + ': ' + ERROR_MESSAGE()
5.	END CATCH
Task 3: Testing & Output  
Insert 3–5 sample books (you can do this manually or using sp_AddNewBook).
Run and show results (screenshots or text output) for at least these three cases:
1.	Successful order → stock decreases, order is inserted.
2.	Insufficient stock → error message, no change in stock or orders table.
3.	Invalid BookID (book does not exist) → error, rollback happens.
 
 
*/
CREATE DATABASE InterViewPre;
use InterViewpre;

CREATE TABLE Books (
    BookID  INT IDENTITY(1,1) PRIMARY KEY,
    Title   NVARCHAR(150) NOT NULL,
    Stock   INT NOT NULL CHECK (Stock >= 0),
    Price   DECIMAL(10,2) NOT NULL
);

CREATE TABLE Orders (
    OrderID    INT IDENTITY(1,1) PRIMARY KEY,
    BookID     INT NOT NULL,
    Quantity   INT NOT NULL CHECK (Quantity > 0),
    OrderDate  DATETIME2 DEFAULT SYSDATETIME(),
    FOREIGN KEY (BookID) REFERENCES Books(BookID)
);

-----TASK 1 Task 1: Stored Procedure to Add a Book  
CREATE PROCEDURE sp_AddNewBook
    @Title NVARCHAR(150),
    @Stock INT,
    @Price DECIMAL(10,2)
AS
BEGIN
    BEGIN TRY
        INSERT INTO Books (Title, Stock, Price)
        VALUES (@Title, @Stock, @Price);

        PRINT 'Book added successfully.';
    END TRY

    BEGIN CATCH
        PRINT 'Book is not add successfully';
    END CATCH
END

--Task 2 Main Stored Procedure – Place Order with Transaction  
CREATE PROCEDURE sp_PlaceOrder
    @BookID INT,
    @Quantity INT
AS
BEGIN
    SET XACT_ABORT ON;

    BEGIN TRY

        BEGIN TRANSACTION

        IF NOT EXISTS (
            SELECT 1
            FROM Books
            WHERE BookID = @BookID
            AND Stock >= @Quantity
        )
        BEGIN
            RAISERROR('Not enough stock or book not found.',16,1);
        END

        UPDATE Books
        SET Stock = Stock - @Quantity
        WHERE BookID = @BookID;

        INSERT INTO Orders (BookID, Quantity)
        VALUES (@BookID, @Quantity);

        COMMIT TRANSACTION;

        PRINT 'Order placed successfully.';

    END TRY

    BEGIN CATCH

        IF @@TRANCOUNT > 0
            ROLLBACK TRANSACTION;

        PRINT 'Error ' + CAST(ERROR_NUMBER() AS VARCHAR) + ': ' + ERROR_MESSAGE();

    END CATCH
END

--task -3 Task 3: Testing & Output  
EXEC sp_AddNewBook 'SQL', 10, 450; --title ,stock, price 
EXEC sp_AddNewBook 'Java', 5, 550;
EXEC sp_AddNewBook 'C# Basics', 8, 500;
EXEC sp_AddNewBook 'Python', 3, 400;
--1st Successful order
EXEC sp_PlaceOrder 1, 2;
--2nd Insufficient stock
EXEC sp_PlaceOrder 4, 10;
--3rd Invalid  BoodID 
EXEC sp_PlaceOrder 20, 1;

