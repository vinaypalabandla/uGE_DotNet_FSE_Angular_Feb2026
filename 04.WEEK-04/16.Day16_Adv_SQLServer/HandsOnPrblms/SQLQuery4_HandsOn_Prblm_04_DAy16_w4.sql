
------------SQL 4 TH  Problm-----------
/*- Use a cursor to iterate through completed orders (order_status = 4).
- Calculate total revenue per order using order_items.
- Store computed revenue in a temporary table.
- Display store-wise revenue summary.
*/


use CompanyDB

CREATE TABLE #temp_rev (
order_id INT,
store_id INT,
revenue DECIMAL(10,2)
);

DECLARE @order_id INT;
DECLARE @store_id INT;
DECLARE @revenue DECIMAL(10,2);
-- Use a cursor to iterate through completed orders (order_status = 4).

DECLARE order_cursor CURSOR FOR
SELECT order_id, store_id
FROM orders
WHERE order_status = 4;
-- Store computed revenue in a temporary table.

BEGIN TRY
    BEGIN TRANSACTION;
	OPEN order_cursor;
	FETCH NEXT FROM order_cursor INTO @order_id,@store_id;

	WHILE @@FETCH_STATUS =0
	BEGIN
	SELECT @revenue =ISNULL(SUM(quantity * list_price),0)
	from order_items
	WHERE order_id = @order_id;

	INSERT INTO #temp_rev
	VALUES (@order_id, @store_id, @revenue);

	FETCH NEXT FROM order_cursor INTO @order_id, @store_id;
	END;
CLOSE order_cursor;
DEALLOCATE order_cursor;

COMMIT TRANSACTION;
END TRY
BEGIN CATCH
   ROLLBACK TRANSACTION;
PRINT 'Error occured';
END CATCH;

-- Store-wise revenue summary
SELECT store_id,
   SUM(revenue) AS total_rev
   FROM #temp_rev
  GROUP BY store_id;




