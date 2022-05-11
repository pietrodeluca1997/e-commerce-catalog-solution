CREATE TABLE Products
(
	product_id INT PRIMARY KEY IDENTITY(1,1),
	name VARCHAR(50),
	summary VARCHAR(100),
	description VARCHAR(100),
	image_file VARCHAR(200),
	price DECIMAL(10,2)	
);