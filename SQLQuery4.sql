CREATE TABLE [dbo].[CarImages]
(
	Id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
   CarId INT FOREIGN KEY REFERENCES dbo.Cars(Id),
   ImagePath varchar(Max),
   Date Datetime
)