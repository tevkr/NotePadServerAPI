use NotePadDB;

CREATE TABLE IF NOT EXISTS users (
	id INT AUTO_INCREMENT PRIMARY KEY,
	name varchar(50)
);

CREATE TABLE IF NOT EXISTS purchases (
    id INT AUTO_INCREMENT PRIMARY KEY,
    userId INT,
    purchaseTime DATETIME,
    name varchar(50),
    cost DOUBLE
);