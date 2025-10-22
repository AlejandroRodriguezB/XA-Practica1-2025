CREATE TABLE IF NOT EXISTS products (
    id SERIAL PRIMARY KEY,
    name VARCHAR(100),
    price NUMERIC(10,2),
    ammount INT DEFAULT 0
);

INSERT INTO products (name, price, ammount) VALUES
('Laptop', 999.99, 10),
('Mouse', 25.50, 50),
('Keyboard', 45.00, 30),
('Monitor', 150.75, 20),
('Printer', 120.00, 15),
('Desk Chair', 85.20, 25),
('USB Drive', 15.00, 100),
('Webcam', 70.00, 40),
('Headphones', 60.00, 35),
('Smartphone', 699.99, 12);

CREATE OR REPLACE FUNCTION GET_ALL_PRODUCT()
RETURNS TABLE (
    id INT,
    name VARCHAR,
    price NUMERIC
)
LANGUAGE plpgsql
AS $$
BEGIN
    RETURN QUERY
    SELECT p.id, p.name, p.price
    FROM products p
    ORDER BY p.id;
END;
$$;

CREATE OR REPLACE FUNCTION UPSERT_PRODUCT(
    p_id INT,
    p_name VARCHAR,
    p_price NUMERIC
)
RETURNS VOID
LANGUAGE plpgsql
AS $$
BEGIN
    IF EXISTS (SELECT 1 FROM products WHERE id = p_id) THEN
        UPDATE products
        SET name = p_name,
            price = p_price
        WHERE id = p_id;
    ELSE
        INSERT INTO products (name, price)
        VALUES (p_name, p_price);
    END IF;
END;
$$;

CREATE OR REPLACE FUNCTION DELETE_PRODUCT(p_id INT)
RETURNS VOID
LANGUAGE plpgsql
AS $$
DECLARE
    deleted_count INT;
BEGIN
    DELETE FROM products WHERE id = p_id;
END;
$$;

