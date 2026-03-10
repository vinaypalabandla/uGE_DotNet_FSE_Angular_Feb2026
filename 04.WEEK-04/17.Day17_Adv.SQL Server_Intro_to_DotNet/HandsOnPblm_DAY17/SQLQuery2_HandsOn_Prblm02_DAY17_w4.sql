-------------------PRBLM 02---
/*📌 Requirements 
- Begin a transaction when cancelling an order.
- Restore stock quantities based on order_items.
- Update order_status to 3.
- Use SAVEPOINT before stock restoration.
- If stock restoration fails, rollback to SAVEPOINT.
- Commit transaction only if all operations succeed.
*/

USE CompanyDB;
--- create transction 
BEGIN TRY
    BEGIN TRANSACTION;

    --Create Savepoint HERE
    SAVE TRANSACTION SavePoint;
    --Restore Stock
    UPDATE s
    SET s.quantity = s.quantity + oi.quantity
    FROM stocks s
    JOIN order_items oi 
        ON s.product_id = oi.product_id
    WHERE oi.order_id = 106;  

    -- Update Order Status to Rejected 2
    UPDATE orders
    SET order_status =5
    WHERE order_id = 106;

    COMMIT TRANSACTION;
    PRINT 'Order Cancelled Successfully';

END TRY
BEGIN CATCH
    -- Rollback to Savepoint if error occurs
    ROLLBACK TRANSACTION SavePoint;
    -- Rollback full transaction
    ROLLBACK TRANSACTION;

    PRINT 'Cancellation Failed';

END CATCH;

----checking==
SELECT order_id, order_status
FROM orders
WHERE order_id = 106;

select *  from orders;