CREATE TABLE Brands(
Id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
BrandName VARCHAR(50))

CREATE TABLE Colors(
Id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
ColorName VARCHAR(50))


CREATE TABLE Cars(
Id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
BrandId INT FOREIGN KEY REFERENCES dbo.Brands(Id),
ColorId INT FOREIGN KEY REFERENCES dbo.Colors(Id),
ModelYear VARCHAR(50),
DailyPrice DECIMAL,
Description NVARCHAR(300)
)

INSERT INTO dbo.Brands
(
    BrandName
)
VALUES
('AUDIA5' -- BrandName - varchar(50)
    ),
    ('BMW' -- BrandName - varchar(50)
    ),
    ('VOLKSWAGEN' -- BrandName - varchar(50)
    ),
    ('OPEL' -- BrandName - varchar(50)
    )

INSERT INTO dbo.Colors
(
    ColorName
)
VALUES
('Beyaz' -- ColorName - varchar(50)
    ),
    ('Siyah' -- ColorName - varchar(50)
    ),
    ('Gri' -- ColorName - varchar(50)
    ),
    ('Mavi' -- ColorName - varchar(50)
    )

INSERT INTO dbo.Cars
(
    BrandId,
    ColorId,
    ModelYear,
    DailyPrice,
    Description
)
VALUES
(   1,    -- BrandId - int
    1,    -- ColorId - int
    '2001',   -- ModelYear - varchar(50)
    23000, -- DailyPrice - decimal
    N'AudiA5'   -- Description - nvarchar(300)
    ),
    (   1,    -- BrandId - int
    2,    -- ColorId - int
    '2015',   -- ModelYear - varchar(50)
    35000, -- DailyPrice - decimal
    N'BMW'   -- Description - nvarchar(300)
    ),
    (   2,    -- BrandId - int
    3,    -- ColorId - int
    '2018',   -- ModelYear - varchar(50)
    111000, -- DailyPrice - decimal
    N'Volkswagen'   -- Description - nvarchar(300)
    ),
    (   3,    -- BrandId - int
    4,    -- ColorId - int
    '2013',   -- ModelYear - varchar(50)
    80000, -- DailyPrice - decimal
    N'Opel'   -- Description - nvarchar(300)
    )
