Create Table Users(
Id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
FirstName varchar(50),
LastName varchar(50),
EMail varchar(50),
Password varchar(50))


CREATE TABLE Customers(
Id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
UserId INT FOREIGN KEY REFERENCES Users(Id),
CompanyName VARCHAR(50))

    CREATE TABLE Rentals(
Id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
CarId INT FOREIGN KEY REFERENCES dbo.Cars(Id),
CustomerId INT FOREIGN KEY REFERENCES dbo.Customers(Id),
RentDate Datetime,
ReturnDate Datetime null
)

Insert Into Users(
FirstName,
LastName,
EMail,
Password) Values
('Merve','Can','mervecn172@gmail.com','1234'),
('Melek','Şahin','meleksahin@gmail.com','12345'),
('Süm','Yılmaz','sumyilmaz@gmail.com','123'),
('Gürrü','Kal','gurrukal@gmail.com','123456')


INSERT INTO dbo.Customers
(
    UserId,   
    CompanyName
)
VALUES
(1,'Opel Şirket'),
(2,'Bmw Şirket'),
(3,'Renault Şirket'),
(4,'Opel Şirket')

Insert Into Rentals
(
CarId,
CustomerId,
RentDate,
ReturnDate) values (1,2,'03/21/2020','03/22/2020'),
(2,3,'02/14/2021','02/16/2021')