USE Softuni
-- 01. Find Names of All Employees by First Name --

SELECT FirstName, LastName FROM Employees
WHERE FirstName LIKE 'SA%'

-- 02. Find Names of All Employees by Last Name --
SELECT FirstName, LastName FROM Employees
WHERE LastName LIKE '%ei%'

-- 03. Find First Names of All Employess  --
SELECT FirstName FROM Employees
WHERE ((DepartmentID = 10 OR DepartmentID = 3) 
AND DATEPART(YEAR, HireDate) BETWEEN 1995 AND 2005)

-- 04. Find All Employees Except Engineers --
SELECT FirstName, LastName FROM Employees
WHERE JobTitle NOT LIKE '%engineer%'

-- 05. Find Towns with Name Length --
SELECT [Name] FROM Towns
WHERE LEN([Name]) BETWEEN 5 AND 6
ORDER BY [Name]

-- 06. Find Towns Starting With --
SELECT * FROM Towns
WHERE (SUBSTRING([Name], 1, 1) = 'M' OR SUBSTRING([Name], 1, 1) = 'K' OR SUBSTRING([Name], 1, 1) = 'B' OR
SUBSTRING([Name], 1, 1) = 'E' )
ORDER BY [Name]

-- 07. Find Towns Not Starting With --
SELECT * FROM Towns
WHERE ([Name]NOT LIKE 'R%' AND [Name]NOT LIKE 'B%' AND [Name]NOT LIKE 'D%')
ORDER BY [Name]

--08. Create View Employees Hired After --
GO
CREATE VIEW V_EmployeesHiredAfter2000 AS
SELECT FirstName, LastName FROM Employees
WHERE DATEPART(YEAR, HireDate) > 2000

GO
SELECT * FROM V_EmployeesHiredAfter2000 

-- 09. Length of Last Name --
SELECT FirstName, LastName FROM Employees
WHERE LEN(LastName) = 5


USE [Geography]
-- 10. Countries Holding 'A' --
SELECT CountryName, ISOCode FROM Countries
WHERE CountryName LIKE '%a%a%a%'
ORDER BY IsoCode

-- 10.1. Rank Employees by Salary
SELECT a.EmployeeID, a.FirstName, a.LastName, a.Salary, a.SalaryRank AS [Rank] FROM (
SELECT EmployeeID, FirstName, LastName, Salary, 
DENSE_RANK() OVER (PARTITION BY Salary ORDER BY EmployeeID) AS SalaryRank
FROM Employees) AS a
WHERE (Salary >= 10000 AND Salary <= 50000)
ORDER BY Salary DESC


-- 11. Mix of Peak and River Names --
SELECT PeakName, RiverName, LOWER(CONCAT(LEFT(PeakName, LEN(PeakName) - 1), RiverName))
AS[Mix]
FROM Peaks, Rivers
WHERE RIGHT(PeakName, 1) = LEFT(RiverName, 1)
ORDER BY Mix

--11.1 Find All Employees with Rank 2
SELECT a.EmployeeID, a.FirstName, a.LastName, a.Salary, a.SalaryRank AS [Rank] 
FROM (
	SELECT EmployeeID, FirstName, LastName, Salary, 
	DENSE_RANK() OVER (PARTITION BY Salary ORDER BY EmployeeID) AS SalaryRank
	FROM Employees
	 ) AS a
WHERE (SalaryRank = 2 AND Salary >= 10000 AND Salary <= 50000)
ORDER BY Salary DESC


USE Diablo
-- 12. Games From 2011 and 2012 Year --
SELECT TOP(50) [Name], FORMAT([Start], 'yyyy-MM-dd') AS [Start]
FROM Games
WHERE (DATEPART(YEAR, [Start]) = 2011 OR DATEPART(YEAR, [Start]) = 2012)
ORDER BY [Start], [Name]

-- 13. User Email Providers --
SELECT Username, SUBSTRING(Email, CHARINDEX('@', Email) + 1, LEN(Email) - CHARINDEX('@', Email))  
AS [Email Provider]
FROM Users
ORDER BY [Email Provider], Username

-- 14. Get Users with IPAddress Like Pattern --
SELECT UserName, IpAddress 
FROM Users
WHERE IpAddress LIKE '___.1%.%.___'
ORDER BY Username

-- 15. Show All Games with Duration --
SELECT [Name] AS [Game],
	CASE
		WHEN DATEPART(HOUR, [Start]) < 12 THEN 'Morning'
		WHEN DATEPART(HOUR, [Start]) >= 12 AND DATEPART(HOUR, [Start]) < 18 THEN 'Afternoon'
		WHEN DATEPART(HOUR, [Start]) >= 18 AND DATEPART(HOUR, [Start]) < 24 THEN 'Evening'
	END AS [Part of the Day],

	CASE
		WHEN Duration <= 3 THEN 'Extra Short'
		WHEN Duration >= 4 AND Duration <= 6 THEN 'Short'
		WHEN Duration > 6 THEN 'Long'
		ELSE 'Extra Long'
	END  AS [Duration]
FROM Games
ORDER BY [Name], Duration, [Part of the day]


USE Orders
 -- 16. Orders Table --
 SELECT ProductName, OrderDate, 
 DATEADD(DAY, 3, OrderDate) AS [Pay Due],
 DATEADD(MONTH, 1, OrderDate) AS [Deliver Due]
 FROM Orders

 -- 17. People Table --
 CREATE TABLE People(
 Id INT NOT NULL,
 [Name] NVARCHAR(40) NOT NULL,
 Birthdate DATE NOT NULL

 CONSTRAINT PK_People
 PRIMARY KEY (Id) 
 )

 INSERT INTO People (Id, [Name], Birthdate) VALUES
	(1, 'Victor', '2000-12-07 00:00:00.000'),
	(2,	'Steven', '1992-09-10 00:00:00.000'),
	(3,	'Stephen',	'1910-09-19 00:00:00.000'),
	(4,	'John',	'2010-01-06 00:00:00.000')

SELECT [Name], 
DATEDIFF(YEAR, Birthdate, GETDATE()) AS [Age in Years],
DATEDIFF(MONTH, Birthdate, GETDATE()) AS [Age in Months],
DATEDIFF(DAY, Birthdate, GETDATE()) AS [Age in Days],
DATEDIFF(MINUTE, Birthdate, GETDATE()) AS [Age in Minutes]
FROM People
