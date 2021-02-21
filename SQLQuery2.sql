CREATE TABLE Customers(
Id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
CompanyName VARCHAR(50))


INSERT INTO dbo.Customers
(
    CompanyName
)
VALUES
('Merve' -- ColorName - varchar(50)
    ),
    ('Mavi' -- ColorName - varchar(50)
    ),
    ('Kader' -- ColorName - varchar(50)
    ),
    ('Cennet' -- ColorName - varchar(50)
    )

    CREATE TABLE Rentals(
Id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
CarId INT FOREIGN KEY REFERENCES dbo.Cars(Id),
CustomerId INT FOREIGN KEY REFERENCES dbo.Customers(Id),
CreatedDate Datetime,
EndDate Datetime
)

Insert Into Rentals
(
CarId,
CustomerId,
CreatedDate,
EndDate) values (1,2,'03/21/2020','03/22/2020')