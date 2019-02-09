
/*--01--*/
CREATE DATABASE Minions

/*--02--*/
CREATE TABLE Minions(
Id INT PRIMARY KEY,
[Name] NVARCHAR(50) NOT NULL,
Age INT
)

CREATE TABLE Towns(
Id INT PRIMARY KEY,
[Name] NVARCHAR(50) NOT NULL
)

/*--03--*/
ALTER TABLE Minions
ADD TownId INT

ALTER TABLE Minions
ADD FOREIGN KEY(TownId) REFERENCES Towns(Id)

/*--04--*/
INSERT INTO Towns(Id,[Name]) VALUES
(1, 'Sofia'),
(2, 'Plovdiv'),
(3, 'Varna')

INSERT INTO Minions (Id, [Name], Age, TownId) VALUES
(1, 'Kevin', 22, 1),
(2, 'Bob', 15, 3),
(3, 'Steward',NULL , 2)

/*--5--*/
TRUNCATE TABLE Minions

/*--6--*/
DROP TABLE Minions
DROP TABLE Towns

/*--7--*/
CREATE TABLE People(
Id BIGINT PRIMARY KEY IDENTITY(1,1),
[Name] NVARCHAR(200) NOT NULL,
Picture VARBINARY(MAX) CHECK(DATALENGTH(Picture) <= 2048 * 1024),
Height DECIMAL(5, 2),
[Weight] DECIMAL(5,2),
Gender CHAR(1) CHECK(Gender = 'm' OR Gender = 'f') NOT NULL,
Birthdate DATE NOT NULL,
Biography NVARCHAR(MAX)
)

INSERT INTO People([Name], Picture, Height, [Weight], Gender, Birthdate, Biography) VALUES
('Pesho', NULL, 185.0, 85.0, 'm', CONVERT(DATETIME, '22-05-2018', 105), 'Bkjbkbk jbk'),
('Gosho', NULL, 205.0, 80.0, 'm', CONVERT(DATETIME, '21-05-2018', 105), 'Bkjbkbk jbk'),
('Stamat', NULL, 155.0, 80.0, 'm', CONVERT(DATETIME, '21-05-2018', 105), 'Bkjbkbk jbk'),
('Nikodim', NULL, 185.0, 80.0, 'm', CONVERT(DATETIME, '21-05-2018', 105), 'Bkjbkbk jbk'),
('Unufrii', NULL, 178.0, 80.0, 'm', CONVERT(DATETIME, '01-01-1985', 105), 'Bkjbkbk jbk')

/*--8--*/
CREATE TABLE Users(
Id BIGINT PRIMARY KEY IDENTITY,
Username VARCHAR(30) UNIQUE NOT NULL,
[Password] VARCHAR(26) NOT NULL,
ProfilePicture VARBINARY(MAX) CHECK(DATALENGTH(ProfilePicture) <= 900 * 1024),
LastLoginTime DATETIME,
IsDeleted BIT
)

INSERT INTO Users(Username, [Password], ProfilePicture, LastLoginTime, IsDeleted) VALUES
('gogo007', '12345', NULL, CONVERT(DATETIME, '22-05-2018', 105), 0),
('pussio007', '123485', NULL, CONVERT(DATETIME, '06-06-2018', 105), 0),
('hammer', '12345789', NULL, CONVERT(DATETIME, '01-01-2019', 105), 0),
('roskoto', 'wefdcsda', NULL, CONVERT(DATETIME, '02-01-2019', 105), 1),
('deviant', '123457890', NULL, CONVERT(DATETIME, '03-01-2019', 105), 0)

SELECT * FROM Users

/*--9--*/
ALTER TABLE Users
DROP CONSTRAINT PK__Users__3214EC077031F8DB

ALTER TABLE Users
ADD CONSTRAINT PK_USERS PRIMARY KEY(Id, Username)

/*--10--*/
ALTER TABLE Users
ADD CONSTRAINT CHK_Password CHECK(LEN([Password]) >= 5 )

/*--11--*/
ALTER TABLE Users
ADD DEFAULT GETDATE() FOR LastLoginTime

/*--12--*/
ALTER TABLE Users
DROP CONSTRAINT PK_USERS

ALTER TABLE Users
ADD CONSTRAINT PK_USERS	PRIMARY KEY(Id)

ALTER TABLE Users
ADD CONSTRAINT CHK_UsernameLength CHECK(LEN(Username) >= 3)

/*--13--*/
CREATE DATABASE Movies

CREATE TABLE Directors(
Id INT PRIMARY KEY IDENTITY,
DirectorName NVARCHAR(50) NOT NULL,
Notes NVARCHAR(500)
)

CREATE TABLE Genres(
Id INT PRIMARY KEY IDENTITY,
GenreName NVARCHAR(50) NOT NULL,
Notes NVARCHAR(500)
)

CREATE TABLE Categories(
Id INT PRIMARY KEY IDENTITY,
CategoryName NVARCHAR(50) NOT NULL,
Notes NVARCHAR(500)
)

CREATE TABLE Movies(
Id INT PRIMARY KEY IDENTITY,
Title NVARCHAR(150) NOT NULL,
DirectorId INT FOREIGN KEY REFERENCES Directors(Id) NOT NULL,
CopyrightYear INT NOT NULL,
[Length] TIME,
GenreId INT FOREIGN KEY REFERENCES Genres(Id),
CategoryId INT FOREIGN KEY REFERENCES Categories(Id),
Rating INT,
Notes NVARCHAR(MAX)
)

INSERT INTO Directors(DirectorName) VALUES
('Stenli Kibik'),
('Paceto'),
('Gazeto'),
('Lozata'),
('Bojinkata')

INSERT INTO Genres(GenreName) VALUES
('Drama'),
('Thriller'),
('Action'),
('Comedy'),
('XXL')

INSERT INTO Categories(CategoryName) VALUES
('Big'),
('Small'),
('Average'),
('Content'),
('Crazy')

INSERT INTO Movies(Title, DirectorId, CopyrightYear, [Length], GenreId, CategoryId, Rating, Notes) VALUES
('Konq', 3, 2016, ('00:55:00'), 2, 1, 5, 'Plain and boring'),
('Kozata', 1, 1945, ('01:50:55'), 2, 1, 5, 'Enthralling'),
('Мазъта', 2, 1945, ('02:00:00'), 4, 3, 10, 'Thrilling'),
('Мъглътъ', 2, 1989, ('01:55:45'), 4, 3, 10, 'Екстра'),
('Into the Drujba', 2, 1989, ('00:55'), 4, 3, 10, 'Wow')

/*--14--*/
CREATE DATABASE CarRental

CREATE TABLE Categories(
Id INT PRIMARY KEY IDENTITY,
CategoryName NVARCHAR(50) NOT NULL,
DaylyRate INT NOT NULL,
WeeklyRate INT NOT NULL,
MonthlyRate INT NOT NULL,
WeekendRate INT NOT NULL
)

CREATE TABLE Cars(
Id INT PRIMARY KEY IDENTITY,
PlateNumber VARCHAR(20) NOT NULL UNIQUE,
Manufacturer NVARCHAR(50) NOT NULL,
Model NVARCHAR(50) NOT NULL,
CarYear INT NOT NULL,
CategoryId INT FOREIGN KEY REFERENCES Categories(Id),
Doors INT NOT NULL,
Picture VARBINARY(MAX),
Condition NVARCHAR(20),
Available BIT NOT NULL
)

CREATE TABLE Employees(
Id INT PRIMARY KEY IDENTITY,
FristName NVARCHAR(30) NOT NULL,
LastName NVARCHAR(30) NOT NULL,
Title NVARCHAR(30) NOT NULL,
Notes NVARCHAR(MAX)
)

CREATE TABLE Customers(
Id INT PRIMARY KEY IDENTITY,
DriverLicenceNumber INT UNIQUE NOT NULL,
FullName NVARCHAR(100) NOT NULL,
[Address] NVARCHAR(150) NOT NULL,
City NVARCHAR(30) NOT NULL,
ZIPCode NVARCHAR(20) NOT NULL,
Notes NVARCHAR(MAX)
)

CREATE TABLE RentalOrders(
Id INT PRIMARY KEY IDENTITY,
EmployeeId INT FOREIGN KEY REFERENCES Employees(Id) NOT NULL,
CustomerId INT FOREIGN KEY REFERENCES Customers(Id) NOT NULL,
CarId INT FOREIGN KEY REFERENCES Cars(Id) NOT NULL,
TankLevel INT NOT NULL,
KilometrageStart INT NOT NULL,
KilometrageEnd INT NOT NULL,
TotalKilometrage AS KilometrageEnd - KilometrageStart,
StartDate DATE NOT NULL,
EndDate DATE NOT NULL,
TotalDays AS DATEDIFF(DAY, StartDate, EndDate),
RateApplied INT,
TaxRate INT,
OrderStatus BIT NOT NULL,
Notes NVARCHAR(1000)
)

INSERT INTO Categories(CategoryName,DaylyRate, WeeklyRate, MonthlyRate, WeekendRate) VALUES
('Trip 1', 5, 25, 150, 6),
('Trip 2', 6, 26, 170, 7),
('Trip 3', 6, 26, 170, 7)

INSERT INTO Cars(PlateNumber, Manufacturer, Model,CarYear, CategoryId, Doors, Picture, Condition, Available) VALUES
('CB1785AK', 'Dodge', 'BYPass', 2008, 2, 5, NULL, 'Good', 1),
('CB1786AK', 'Porshe', 'Carrera', 2012, 2, 3, NULL, 'Excellent', 0),
('CB1787AK', 'Ferrery', 'F350', 2015, 2, 3, NULL, 'Excellent', 1)

INSERT INTO Employees(FristName, LastName, Title, Notes) VALUES
('Pesho', 'Peshov', 'Manager', 'Stava'),
('Gosho', 'Goshov', 'Cleaner', 'Stava'),
('Penka', 'Penkova', 'Dealer', '')

INSERT INTO Customers(DriverLicenceNumber, FullName, [Address], City, ZIPCode, Notes) VALUES
('123456', 'Stankata Petrov', 'Drujbaj 56', 'Batovica', 'A666', ''),
('123456789', 'Nako Nakov', 'Mladost 56', 'Sofja', 'A6667', 'Redoven'),
('123456000', 'Dimka Petrova', 'Drujbaj 57', 'Plovdiv', 'A6667', 'Neredovna')

INSERT INTO RentalOrders(EmployeeId, CustomerId,CarId, TankLevel, KilometrageStart, 
KilometrageEnd, StartDate, EndDate, RateApplied,TaxRate, OrderStatus, Notes) VALUES
(1, 2, 3, 25, 256, 567, '2007-08-08', '2007-08-15', 5, 20, 0, ''),
(2, 3, 1, 55, 850, 1150, '2007-08-09', '2007-08-21', 5, 20, 0, 'Active'),
(3, 1, 2, 90, 1000, 1500, '2007-08-08', '2007-08-29', 5, 20, 1, 'Great')

/*--15--*/
CREATE DATABASE Hotel

CREATE TABLE Employees(
Id INT PRIMARY KEY IDENTITY,
FirstName NVARCHAR(30) NOT NULL,
LastName NVARCHAR(30) NOT NULL,
Title NVARCHAR(30) NOT NULL,
Notes NVARCHAR(MAX)
)

CREATE TABLE Customers(
AccountNumber INT PRIMARY KEY IDENTITY,
FirstName NVARCHAR(30) NOT NULL,
LastName NVARCHAR(30) NOT NULL,
PhoneNumber NVARCHAR(30) NOT NULL,
EmergencyName NVARCHAR(50) NOT NULL,
EmergencyNumber NVARCHAR(30) NOT NULL,
Notes NVARCHAR(MAX)
)

CREATE TABLE RoomStatus(
RoomStatus NVARCHAR(50) PRIMARY KEY NOT NULL,
Notes NVARCHAR(500)
)

CREATE TABLE RoomTypes(
RoomType NVARCHAR(30) PRIMARY KEY NOT NULL,
Notes NVARCHAR(MAX)
)
CREATE TABLE BedTypes(
BedType NVARCHAR(30) PRIMARY KEY NOT NULL,
Notes NVARCHAR(MAX)
)

CREATE TABLE Rooms(
RoomNumber INT PRIMARY KEY NOT NULL,
RoomType NVARCHAR(30) FOREIGN KEY REFERENCES RoomTypes(RoomType) NOT NULL,
BedType NVARCHAR(30) FOREIGN KEY REFERENCES BedTypes(BedType) NOT NULL,
Rate INT,
RoomStatus NVARCHAR(50) FOREIGN KEY REFERENCES RoomStatus(RoomStatus) NOT NULL,
Notes NVARCHAR(MAX)
)

CREATE TABLE Payments(
Id INT PRIMARY KEY IDENTITY,
EmployeeId INT FOREIGN KEY REFERENCES Employees(Id) NOT NULL,
PaymentDate DATE NOT NULL,
AccountNumber INT FOREIGN KEY REFERENCES Customers(AccountNumber) NOT NULL,
FirstDateOccupied DATE NOT NULL,
LastDateOccupied DATE NOT NULL,
TotalDays AS DATEDIFF(DAY, LastDateOccupied, FirstDateOccupied),
AmountCharged DECIMAL(15, 2) NOT NULL,
TaxRate DECIMAL(15,2) NOT NULL,
TaxAmount AS AmountCharged * TaxRate,
PaymentTotal AS AmountCharged + AmountCharged * TaxRate,
Notes NVARCHAR(MAX)
)

CREATE TABLE Occupancies(
Id INT PRIMARY KEY IDENTITY,
EmployeeId INT FOREIGN KEY REFERENCES Employees(Id) NOT NULL,
DateOccupied DATE NOT NULL,
AccountNumber INT FOREIGN KEY REFERENCES Customers(AccountNumber) NOT NULL,
RoomNumber INT FOREIGN KEY REFERENCES Rooms(RoomNumber) NOT NULL,
RateApplied INT,
PhoneCharge DECIMAL(15,2),
Notes NVARCHAR(MAX)
)

INSERT INTO Employees(FirstName, LastName, Title, Notes) VALUES
('Pesho', 'Peshov', 'Manager', 'Stava'),
('Gosho', 'Goshov', 'Cleaner', 'Stava'),
('Penka', 'Penkova', 'Dealer', '')

INSERT INTO Customers(FirstName, LastName, PhoneNumber, EmergencyName, EmergencyNumber, Notes) VALUES
('Petko', 'Petkov', '088700', 'Petkana', '0887156', 'Stavat'),
('Petka', 'Petkova', '0887123', 'Petkan', '45645678', 'Ne Stava'),
('Joro', 'Petkov', '088733', 'Jorka', '45645678', ' ')

INSERT INTO RoomStatus(RoomStatus, Notes) VALUES
('Free', 'The room is free'),
('Occupied', 'The room is occupied'),
('Cleaned', 'The room is being cleaned')

INSERT INTO RoomTypes(RoomType) VALUES
('Single'),
('Double'),
('Appartment')

INSERT INTO BedTypes(BedType) VALUES
('Single'),
('Double'),
('Twin')

INSERT INTO Rooms(RoomNumber, RoomType, BedType, RoomStatus) VALUES
(123, 'Double', 'Double', 'Free'),
(124, 'Single', 'Twin', 'Cleaned'),
(125, 'Appartment', 'Double', 'Occupied')

INSERT INTO Payments(EmployeeId, PaymentDate, AccountNumber, FirstDateOccupied, LastDateOccupied, AmountCharged,
 TaxRate) VALUES
 (1, '2007-08-08', 1, '2007-08-08', '2007-08-10', 55.65, 0.2),
 (2, '2007-08-09', 1, '2007-08-09', '2007-08-12', 75.65, 0.2),
 (1, '2007-08-10', 1, '2007-08-10', '2007-08-15', 85.65, 0.2)

 INSERT INTO Occupancies (EmployeeId, DateOccupied, AccountNumber, RoomNumber) VALUES
 (1, '2007-08-08', 1, 123),
 (2, '2007-08-09', 2, 124),
 (3, '2007-08-10', 3, 125)


 /*--16--*/
CREATE DATABASE SoftUni

CREATE TABLE Towns(
Id INT PRIMARY KEY IDENTITY,
[Name] NVARCHAR(50) NOT NULL UNIQUE,
)

CREATE TABLE Addresses(
Id INT PRIMARY KEY IDENTITY,
AddressText NVARCHAR(70) NOT NULL UNIQUE,
TownId INT FOREIGN KEY REFERENCES Towns(Id) NOT NULL
)

CREATE TABLE Departments(
Id INT PRIMARY KEY IDENTITY,
[Name] NVARCHAR(70) NOT NULL UNIQUE
)

CREATE TABLE Employees(
Id INT PRIMARY KEY IDENTITY,
FirstName NVARCHAR(30) NOT NULL,
MiddleName NVARCHAR(30),
LastName NVARCHAR(30) NOT NULL,
JobTitle NVARCHAR(40) NOT NULL,
DepartmentId INT FOREIGN KEY REFERENCES Departments(Id) NOT NULL,
HireDate DATE NOT NULL,
Salary DECIMAL(15,2) NOT NULL,
AddressId INT FOREIGN KEY REFERENCES Addresses(Id)
)

/*--17--*/
BACKUP DATABASE SoftUni TO DISK = 'E:\temporary\softuni-backup.bak'

RESTORE DATABASE Softuni FROM DISK = 'E:\temporary\softuni-backup.bak'

USE Softuni

/*--18--*/
INSERT INTO Towns([Name]) VALUES
('Sofia'),
('Plovdiv'),
('Varna'),
('Burgas')

INSERT INTO Departments([Name]) VALUES
('Engineering'),
('Sales'),
('Marketing'),
('Software Development'),
('Quality Assurance')

INSERT INTO Employees(FirstName, MiddleName, LastName, JobTitle, DepartmentId, HireDate, Salary) VALUES
('Ivan', 'Ivanov', 'Ivanov', '.NET Developer', 4, CONVERT(DATE, '01/02/2013', 103), 3500.00),
('Petar', 'Petrov', 'Petrov', 'Senior Engineer', 1, CONVERT(DATE, '02/03/2004', 103), 4000.00),
('Maria', 'Petrova', 'Ivanova', 'Intern', 5, CONVERT(DATE, '28/08/2016', 103), 525.25),
('Georgi ', 'Teziev', 'Ivanov', 'CEO', 2, CONVERT(DATE, '09/12/2007', 103), 3000.00),
('Peter ', 'Pan', 'Pan', 'Intern', 3, CONVERT(DATE, '28/08/2016', 103), 599.88)

/*--19--*/
SELECT * FROM Towns
SELECT * FROM Departments 
SELECT * FROM Employees

/*--20--*/
SELECT * FROM Towns
ORDER BY [Name]

SELECT * FROM Departments
ORDER BY [Name]

SELECT * FROM Employees
ORDER BY Salary DESC

/*--21--*/
SELECT [Name] FROM Towns
ORDER BY [Name]

SELECT [Name] FROM Departments
ORDER BY [Name]

SELECT FirstName, LastName, JobTitle, Salary FROM Employees
ORDER BY Salary DESC


/*--22--*/
UPDATE Employees
SET Salary = Salary * 1.1
SELECT Salary FROM Employees

/*--23--*/
USE Hotel
UPDATE Payments
SET TaxRate -= TaxRate * 0.03
SELECT TaxRate FROM Payments

/*--24--*/
USE Hotel
TRUNCATE TABLE Occupancies