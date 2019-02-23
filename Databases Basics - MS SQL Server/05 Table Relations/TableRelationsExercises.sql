
-- 01. One-To-One Relationship --
CREATE TABLE Passports(
PassportID INT NOT NULL,
PassportNumber VARCHAR(8)

CONSTRAINT PK_Passports
PRIMARY KEY(PassportID)
)

CREATE TABLE Persons(
PersonID INT NOT NULL,
FirstName VARCHAR(30),
Salary DECIMAL(15, 2) NOT NULL,
PassportID INT UNIQUE NOT NULL,
)

ALTER TABLE Persons
ADD CONSTRAINT FK_Persons_Passports
FOREIGN KEY(PassportID) REFERENCES Passports(PassportID),
CONSTRAINT PK_Persons PRIMARY KEY(PersonId)

INSERT INTO Passports VALUES
(101, 'N34FG21B'),
(102, 'K65LO4R7'),
(103, 'ZE657QP2')

INSERT INTO Persons VALUES
(1, 'Roberto', 43300.00, 102),
(2,	'Tom', 56100.00, 103),
(3,	'Yana',	60200.00, 101)

SELECT * FROM Persons

-- 02. One-To-Many Relationship --
CREATE TABLE Manufacturers(
ManufacturerID INT NOT NULL,
[Name] VARCHAR(32) NOT NULL,
EstablishedOn DATE NOT NULL

CONSTRAINT PK_Manufacturers
PRIMARY KEY(ManufacturerID)
)

CREATE TABLE Models(
ModelID INT NOT NULL,
[Name] VARCHAR(32) NOT NULL,
ManufacturerID INT NOT NULL

CONSTRAINT PK_Models PRIMARY KEY(ModelID),
CONSTRAINT FK_Models_Manufacturers FOREIGN KEY(ManufacturerID) REFERENCES Manufacturers(ManufacturerID)
)

INSERT INTO Manufacturers VALUES
(1, 'BMW', '07/03/1916'),
(2,	'Tesla', '01/01/2003'),
(3,	'Lada',	'01/05/1966')


INSERT INTO Models VALUES
(101, 'X1',	1),
(102, 'i6',	1),
(103, 'Model S', 2),
(104, 'Model X', 2),
(105, 'Model 3', 2),
(106, 'Nova', 3)

SELECT * FROM Manufacturers

-- 03. Many-To-Many Relationship --
CREATE TABLE Students(
StudentID INT NOT NULL,
[Name] VARCHAR(32) NOT NULL

CONSTRAINT PK_Students
PRIMARY KEY(StudentID)
)

CREATE TABLE Exams(
ExamID INT NOT NULL,
[Name] VARCHAR(32) NOT NULL

CONSTRAINT PK_Exams
PRIMARY KEY(ExamID)
)

CREATE TABLE StudentsExams(
StudentID INT NOT NULL,
ExamID INT NOT NULL

CONSTRAINT FK_StudentExams_Students FOREIGN KEY(StudentID) REFERENCES Students(StudentID),
CONSTRAINT FK_StudentExams_Exams FOREIGN KEY(ExamID) REFERENCES Exams(ExamID),
CONSTRAINT PK_StudentsExams PRIMARY KEY(StudentID, ExamID)
)
INSERT INTO Students VALUES
(1, 'Mila'),                                     
(2,	'Toni'),
(3,	'Ron')

INSERT INTO Exams VALUES
(101, 'SpringMVC'),                                     
(102,	'Neo4j'),
(103,	'Oracle 11g')


INSERT INTO StudentsExams VALUES
(1,	101),
(1,	102),
(2,	101),
(3,	103),
(2,	102),
(2,	103)


-- 04. Self-Referencing --
CREATE TABLE Teachers(
TeacherID INT NOT NULL,
[Name] VARCHAR(32) NOT NULL,
ManagerID INT

CONSTRAINT PK_Teachets PRIMARY KEY(TeacherID),
CONSTRAINT FK_Teachers FOREIGN KEY(ManagerID) REFERENCES Teachers(TeacherID)
)

INSERT INTO Teachers VALUES
(101,	'John',	NULL),
(102,	'Maya',	106),
(103,	'Silvia', 106),
(104,	'Ted',	105),
(105,	'Mark',	101),
(106,	'Greta',101)

-- 05. Online Store Database --
CREATE DATABASE OnlineStore
USE OnlineStore
----------
CREATE TABLE Cities(
CityID INT NOT NULL,
[Name] VARCHAR(50)

CONSTRAINT PK_Cities PRIMARY KEY(CityID)
)

CREATE TABLE Customers(
CustomerID INT NOT NULL,
[Name] VARCHAR(50),
Birthday DATE,
CityID INT NOT NULL

CONSTRAINT PK_Customers PRIMARY KEY(CustomerID),
CONSTRAINT FK_Customers_Cities FOREIGN KEY(CityID) REFERENCES Cities(CityID)
)

CREATE TABLE Orders(
OrderID INT NOT NULL,
CustomerID INT NOT NULL

CONSTRAINT PK_Orders PRIMARY KEY(OrderID),
CONSTRAINT FK_Orders_Customers FOREIGN KEY(CustomerID) REFERENCES Customers(CustomerID)
)

CREATE TABLE ItemTypes(
ItemTypeID INT NOT NULL,
[Name] VARCHAR(50)

CONSTRAINT PK_ItemTypes PRIMARY KEY(ItemTypeID)
)

CREATE TABLE Items(
ItemID INT NOT NULL,
[Name] VARCHAR(50),
ItemTypeID INT NOT NULL

CONSTRAINT PK_Items PRIMARY KEY(ItemID),
CONSTRAINT FK_Items_ItemTypes FOREIGN KEY(ItemTypeID) REFERENCES ItemTypes(ItemTypeID)
)

CREATE TABLE OrderItems(
OrderID INT NOT NULL,
ItemID INT NOT NULL

CONSTRAINT FK_OrderItems_Orders FOREIGN KEY(OrderID) REFERENCES Orders(OrderId),
CONSTRAINT FK_OrderItems_Items FOREIGN KEY(ItemID) REFERENCES Items(ItemID),
CONSTRAINT PK_OrderItems PRIMARY KEY(OrderID, ItemID)
)

-- 06. University Database --
CREATE DATABASE University
USE University
--------------
CREATE TABLE Majors(
MajorID INT NOT NULL,
[Name] VARCHAR(50)

CONSTRAINT PK_Majors PRIMARY KEY(MajorID)
)

CREATE TABLE Students(
StudentID INT NOT NULL,
StudentNumber INT UNIQUE NOT NULL,
StudentName VARCHAR(50) NOT NULL,
MajorID INT NOT NULL

CONSTRAINT PK_Students PRIMARY KEY(StudentID),
CONSTRAINT FK_Students_Majors FOREIGN KEY(MajorID) REFERENCES Majors(MajorID)
)

ALTER TABLE Students
ADD CONSTRAINT CHK_StudentName CHECK(LEN(StudentName) > 3)

CREATE TABLE Payments(
PaymentID INT NOT NULL,
PaymentDate DATETIME NOT NULL,
PaymentAmount DECIMAL(15, 2) NOT NULL,
StudentID INT NOT NULL

CONSTRAINT PK_Payments PRIMARY KEY(PaymentID),
CONSTRAINT FK_Payments_Students FOREIGN KEY(StudentID) REFERENCES Students(StudentID)
)

CREATE TABLE Subjects(
SubjectID INT NOT NULL,
SubjectName VARCHAR(50) NOT NULL

CONSTRAINT PK_Subjects PRIMARY KEY(SubjectID),
CONSTRAINT CHK_SubjectName CHECK(LEN(SubjectName) > 2)
)

CREATE TABLE Agenda(
StudentID INT NOT NULL,
SubjectID INT NOT NULL

CONSTRAINT FK_Agenda_Students FOREIGN KEY(StudentID) REFERENCES Students(StudentID),
CONSTRAINT FK_Agenda_Subjects FOREIGN KEY(SubjectID) REFERENCES Subjects(SubjectID),
CONSTRAINT PK_Agenda PRIMARY KEY(StudentID, SubjectID)
)

-- 09. *Peaks in Rila --
USE [Geography]
------------
SELECT m.MountainRange, p.PeakName, p.Elevation
FROM Mountains AS m
JOIN Peaks AS p
ON m.Id = p.MountainId
WHERE p.MountainId = 17
ORDER BY Elevation DESC

-- 13. Count Mountain Ranges --
  SELECT	c.CountryCode, COUNT(m.MountainRange) AS MountainRanges
	FROM	Countries AS c
	JOIN	MountainsCountries AS mc ON mc.CountryCode = c.CountryCode
	JOIN	Mountains AS m ON m.Id = mc.MountainId
	WHERE	(c.CountryCode = 'BG' OR c.CountryCode = 'RU' OR c.CountryCode = 'US')
 GROUP BY	c.CountryCode

-- 14. Countries With or Without Rivers --
SELECT TOP (5) CountryName, r.RiverName
FROM Countries AS c
LEFT JOIN CountriesRivers AS cr ON cr.CountryCode = c.CountryCode
LEFT JOIN Rivers AS r ON r.Id = cr.RiverId
WHERE c.ContinentCode = 'AF'
ORDER BY c.CountryName

-- 15. *Continents and Currencies --
SELECT c.CountryCode, c.CurrencyCode
FROM   Countries AS c