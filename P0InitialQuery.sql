CREATE TABLE Customers(
ID INT PRIMARY KEY IDENTITY (1,1),
FirstName VARCHAR(100) NOT NULL,
LastName VARCHAR (100) NOT NULL
);

CREATE TABLE VendorBranches (
ID INT PRIMARY KEY IDENTITY (1,1),
Name VARCHAR(100) NOT NULL,
CityState VARCHAR (100) NOT NULL
);

CREATE TABLE Orders (
ID INT PRIMARY KEY IDENTITY (1,1),
CustomerID INT FOREIGN KEY REFERENCES Customers(ID),
VendorID INT FOREIGN KEY REFERENCES VendorBranches(ID),
);

CREATE TABLE Products (
ID INT PRIMARY KEY IDENTITY (1,1),
Name VARCHAR (100),
Price DECIMAL (5,2),
Description TEXT
);

CREATE TABLE LineItem (
ProductsID INT FOREIGN KEY REFERENCES Products(ID),
OrdersID INT FOREIGN KEY REFERENCES Orders(ID),
Quantity INT
);



CREATE TABLE Inventory (
ProductID INT FOREIGN KEY REFERENCES Products(ID),
VendorID INT FOREIGN KEY REFERENCES VendorBranches(ID),
Quantity INT 
);



INSERT INTO Customers (FirstName, LastName) VALUES
('Ryne' , 'Waters'),
('Alisaie' , 'Leveilluer'),
('Noctis' , 'Lucius Caelum')

INSERT INTO VendorBranches (Name , CityState) VALUES
('Twin Adders', 'Gridania'),
('Maelstrom' , 'Limsa Lominsa'),
('Immortal Flames' , 'Uldah')

INSERT INTO Products (Name, Price, Description) VALUES
('Vegetable Feed' , 25.99 , 'A simple blend of leafy greens that all chocobos will enjoy'),
('Ultimate Training Guide' , 50.00 , 'A comprehensive manual detailing training methods from experts all across the realm '),
('Grooming Kit' , 20.00 , 'A one time use supply bag with everything you need to keep your chocobo looking great' ),
('Cute Poncho' , 15.00 , 'Keep your feathered friend warm with this cute and comfy poncho')

INSERT INTO Inventory (ProductID, VendorID, Quantity) VALUES
(1,1,30),
(2,3, 20),
(1, 2,30),
(3, 2, 20),
(1, 3,30),
(4, 1, 10)