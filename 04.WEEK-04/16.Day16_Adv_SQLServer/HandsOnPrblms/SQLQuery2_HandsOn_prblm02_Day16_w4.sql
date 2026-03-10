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

/* - Create an AFTER INSERT trigger on order_items.
- Reduce the corresponding quantity in stocks table.
- Prevent stock from becoming negative.
- If stock is insufficient, rollback the transaction with a custom error message.

 */
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
-===============
select * from orders;
select * from order_items;
select * from stocks;

----1)Exute
INSERT INTO orders (order_id, customer_id, order_status, order_date, required_date, shipped_date, store_id, staff_id)
VALUES (106, 1, 2, '2026-03-09', '2026-03-12', '2026-03-10', 1, 1);

INSERT INTO order_items VALUES (106, 1, 2, 4, 5000, 0.05);
---2)
SELECT * FROM stocks WHERE product_id = 2;