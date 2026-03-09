use CompanyDB;

CREATE TABLE stocks (
    product_id INT PRIMARY KEY,
    quantity INT NOT NULL
);

INSERT INTO stocks VALUES
(1,50),
(2,40),
(3,60),
(4,30),
(5,100),
(6,25);
--trigger insert
CREATE TRIGGER trg_UpdateStock
ON order_items
AFTER INSERT
AS
BEGIN
    BEGIN TRY

        -- Check if stock is less than ordered quantity
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

        -- Reduce stock
        UPDATE s
        SET s.quantity = s.quantity - i.quantity
        FROM stocks s
        JOIN inserted i
            ON s.product_id = i.product_id;

    END TRY

    BEGIN CATCH
        ROLLBACK TRANSACTION;
    END CATCH
END;
----1)Exute
INSERT INTO order_items 
VALUES (105, 1, 2, 4, 50000, 0.05);
---2)
SELECT * FROM stocks WHERE product_id = 2;

