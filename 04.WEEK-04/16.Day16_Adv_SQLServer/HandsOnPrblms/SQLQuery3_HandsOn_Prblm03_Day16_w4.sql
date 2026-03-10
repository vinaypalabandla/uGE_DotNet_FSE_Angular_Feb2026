-- =============================================
-- Level-2 Problem 3: Stock Auto-Update Trigger
-- =============================================

/*?? Requirements 
- Create an AFTER INSERT trigger on order_items.
- Reduce the corresponding quantity in stocks table.
- Prevent stock from becoming negative.
- If stock is insufficient, rollback the transaction with a custom error message.
*/


--TRIIGGER CREATION
CREATE TRIGGER trg_UpdateStock
ON order_items
AFTER INSERT
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY

        -- Check if stock is insufficient
        IF EXISTS (
            SELECT 1
            FROM inserted i
            JOIN stocks s
                ON i.product_id = s.product_id
            WHERE s.quantity < i.quantity
        )
        BEGIN
            RAISERROR('Stock is not sufficient.',16,1);
            ROLLBACK TRANSACTION;
            RETURN;
        END

        -- Reduce stock quantity
        UPDATE s
        SET s.quantity = s.quantity - i.quantity
        FROM stocks s
        JOIN inserted i
            ON s.product_id = i.product_id;

    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END;
GO