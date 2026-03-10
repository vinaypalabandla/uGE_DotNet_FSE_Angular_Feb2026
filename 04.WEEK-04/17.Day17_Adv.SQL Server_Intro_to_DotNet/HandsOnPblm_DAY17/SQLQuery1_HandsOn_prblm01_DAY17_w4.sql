/*Level-2 Problem 1: Transactions and Trigger Implementation
Scenario
Auto retail company wants to ensure stock consistency while placing orders. Whenever an order is placed, stock should reduce automatically and transaction should rollback if stock is insufficient.

📌 Requirements 
- Write a transaction to insert data into orders and order_items tables.
- Check stock availability before confirming order.
- Create a trigger to reduce stock quantity after order insertion.
- Rollback transaction if stock quantity is insufficient.
*/

USE CompanyDB;

DROP TRIGGER trg_AutoRedcueStock

--Create trigger
CREATE TRIGGER trg_AutoRedcueStock
ON order_items
AFTER INSERT
AS
BEGIN
 
 IF EXISTS (
 SELECT 1
 FROM stocks s
 JOIN (
    SELECT product_id, SUM(quantity) AS totalqty
	FROM inserted i
	GROUP BY product_id)
	i ON s.product_id =i.product_id
	WHERE s.quantity<i.totalqty
	)

	BEGIN
	RAISERROR('Insufficent stock.',16,1);
	ROLLBACK TRANSACTION;
	RETURN;
	END

	UPDATE s
	SET s.quantity = s.quantity-i.totalqty
	from stocks s
	JOIN (
	SELECT product_id, SUM(quantity) AS totalqty
	FROM inserted
	GROUP BY product_id
	) i ON s.product_id =i.product_id
	END;
	--palce new orderes
	BEGIN TRY
	    BEGIN TRANSACTION;

		INSERT INTO orders
		VALUES (107,1,1, GETDATE(), DATEADD(DAY,5,GETDATE()),NULL,1,1);

		INSERT INTO order_items VALUES
		(107,1,1,5,50000, 0.10),
		(107,2,2,3,20000,0.05);

		COMMIT TRANSACTION;
		PRINT 'order Succuess';
	END TRY
BEGIN CATCH
		ROLLBACK TRANSACTION;
END CATCH;


---==============
SELECT * FROM stocks;
select * FROM  order_items;
SELECT * FROM order_items WHERE order_id = 107;

UPDATE stocks
SET quantity = 40
WHERE product_id = 2;






