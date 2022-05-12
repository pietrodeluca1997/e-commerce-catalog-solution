CREATE SEQUENCE products_seq;

CREATE TABLE Products
(
	product_id INT NOT NULL DEFAULT nextval('products_seq'),
	name VARCHAR(50),
	summary VARCHAR(100),
	description VARCHAR(100),
	image_file VARCHAR(200),
	price DECIMAL(10,2)	
);