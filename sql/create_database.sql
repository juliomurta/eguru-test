-- Author: Júlio Murta
-- Date: 09/07/2017

CREATE DATABASE EGURU;

USE EGURU;

CREATE SCHEMA ECOMMERCE;

CREATE TABLE [ECOMMERCE].[PRODUCT]
(
	ID INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	NAME VARCHAR(50) NOT NULL,
	DESCRIPTION VARCHAR(250) NOT NULL,
	QUANTITY INT NOT NULL,
	PRICE DECIMAL NOT NULL,
	IMAGEPATH VARCHAR(50) NOT NULL
);

CREATE TABLE [ECOMMERCE].[ORDER]
(
	ID INT NOT NULL IDENTITY(1, 1) PRIMARY KEY,
	TOTAL DECIMAL NOT NULL,
	FORMOFPAYMENT INT NOT NULL
);

CREATE TABLE [ECOMMERCE].[ITEM]
(
	ORDERID INT NOT NULL,
	PRODUCTID INT NOT NULL,
	QUANTITY INT NOT NULL,
	PRICE DECIMAL NOT NULL
);

INSERT INTO 
	[ECOMMERCE].[PRODUCT] (NAME, DESCRIPTION, PRICE, QUANTITY, IMAGEPATH) 
VALUES ('Aspirador de pó', 
		'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aliquam quis turpis sit amet mi rhoncus malesuada vitae quis eros. Sed venenatis, sem ut aliquam luctus, ante ex placerat justo, ut tincidunt tellus risus sed quam.',
		300,
		5, 
		'~/Content/img/aspirador.jpg');

INSERT INTO 
	[ECOMMERCE].[PRODUCT] (NAME, DESCRIPTION, PRICE, QUANTITY, IMAGEPATH) 
VALUES ('Microondas', 
		'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aliquam quis turpis sit amet mi rhoncus malesuada vitae quis eros. Sed venenatis, sem ut aliquam luctus, ante ex placerat justo, ut tincidunt tellus risus sed quam.',
		200,		
		5, 
		'~/Content/img/microondas.jpg');

INSERT INTO 
	[ECOMMERCE].[PRODUCT] (NAME, DESCRIPTION, PRICE, QUANTITY, IMAGEPATH) 
VALUES ('Geladeira',		 
		'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aliquam quis turpis sit amet mi rhoncus malesuada vitae quis eros. Sed venenatis, sem ut aliquam luctus, ante ex placerat justo, ut tincidunt tellus risus sed quam.',
		500,
		5, 
		'~/Content/img/geladeira.jpg');
