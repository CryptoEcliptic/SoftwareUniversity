------ 01. DDL -----
CREATE DATABASE TripService
USE TripService

CREATE TABLE Cities(
Id INT PRIMARY KEY IDENTITY,
[Name] NVARCHAR(20) NOT NULL,
CountryCode CHAR(2) NOT NULL
) 

CREATE TABLE Hotels(
Id INT PRIMARY KEY IDENTITY,
[Name] NVARCHAR(30) NOT NULL,
CityId INT FOREIGN KEY REFERENCES Cities(Id) NOT NULL,
EmployeeCount INT NOT NULL,
BaseRate DECIMAL(15,2)
)

CREATE TABLE Rooms(
Id INT PRIMARY KEY IDENTITY,
Price DECIMAL(15,2) NOT NULL,
[Type] NVARCHAR(20) NOT NULL,
Beds INT NOT NULL,
HotelId INT FOREIGN KEY REFERENCES Hotels(Id) NOT NULL
)

CREATE TABLE Trips(
Id INT PRIMARY KEY IDENTITY,
RoomId INT FOREIGN KEY REFERENCES Rooms(Id) NOT NULL,
BookDate DATE NOT NULL,
ArrivalDate DATE NOT NULL,
ReturnDate DATE NOT NULL,
CancelDate DATE,

CONSTRAINT ck_ArrivalDate CHECK (BookDate < ArrivalDate),
CONSTRAINT ck_ReturnDate CHECK (ArrivalDate < ReturnDate)
)

CREATE TABLE Accounts(
Id INT PRIMARY KEY IDENTITY,
FirstName NVARCHAR(50) NOT NULL,
MiddleName NVARCHAR(20),
LastName NVARCHAR(50) NOT NULL,
CityId INT FOREIGN KEY REFERENCES Cities(Id) NOT NULL,
BirthDate DATE NOT NULL,
Email VARCHAR(100) UNIQUE NOT NULL
)

CREATE TABLE AccountsTrips(
AccountId INT FOREIGN KEY REFERENCES Accounts(Id) NOT NULL,
TripId INT FOREIGN KEY REFERENCES Trips(Id) NOT NULL,
Luggage INT NOT NULL CHECK (Luggage >= 0)

 CONSTRAINT PK_Orders_Items PRIMARY KEY (AccountId, TripId)
)

---- 2nd PART DML (10 pts) --
 --- 02 Insert ----
INSERT INTO Accounts VALUES
('John', 'Smith', 'Smith',	34,	'1975-07-21', 'j_smith@gmail.com'),
('Gosho', NULL, 'Petrov',	11,	'1978-05-16', 'g_petrov@gmail.com'),
('Ivan',	'Petrovich', 'Pavlov',	59,	'1849-09-26', 'i_pavlov@softuni.bg'),
('Friedrich', 'Wilhelm', 'Nietzsche', 2, '1844-10-15', 'f_nietzsche@softuni.bg')

INSERT INTO Trips VALUES
(101, '2015-04-12',	'2015-04-14',	'2015-04-20',	'2015-02-02'),
(102, '2015-07-07',	'2015-07-15',	'2015-07-22',	'2015-04-29'),
(103, '2013-07-17',	'2013-07-23',	'2013-07-24',	NULL),
(104, '2012-03-17',	'2012-03-31',	'2012-04-01',	'2012-01-10'),
(109, '2017-08-07',	'2017-08-28',	'2017-08-29',	NULL)

---- 03. Update ----
UPDATE Rooms
SET Price = Price * 1.14
WHERE HotelId IN (5, 7, 9)

------ 04. Delete -----
DELETE FROM AccountsTrips
WHERE AccountId = 47


---- 05. Bulgarian Cities ---
SELECT Id, [Name] FROM Cities
WHERE CountryCode = 'BG'
ORDER BY [Name]


------ 06. People Born After 1991 -------
	SELECT 
			[Full Name] = 
				CASE
					WHEN MiddleName IS NULL THEN CONCAT(FirstName, ' ', LastName)
					ELSE CONCAT(FirstName, ' ', MiddleName, ' ', LastName)
				END
			,DATEPART(YEAR, BirthDate) AS BirthYear
	FROM Accounts
   WHERE DATEPART(YEAR, BirthDate) > 1991
ORDER BY DATEPART(YEAR, BirthDate) DESC, FirstName


---- 07. EEE-Mails ---
	SELECT 
			FirstName
		    ,LastName
			,CONVERT(VARCHAR(10), BirthDate, 110) AS BirthDate 
			,c.[Name] AS Hometown 
			,Email
	  FROM Accounts AS a
	  JOIN Cities AS c ON c.Id = a.CityId
	  WHERE a.Email LIKE 'e%'
	  ORDER BY c.[Name] DESC


----- 08. City Statistics ---

	SELECT c.[Name] AS City, COUNT(h.Id) AS	Hotels
	  FROM Cities AS c
	  LEFT JOIN Hotels AS h ON h.CityId = c.Id
	  GROUP BY c.[Name]
	  ORDER BY COUNT(h.Id) DESC, c.[Name]


------ 09. Expensive First Class Rooms ----
	SELECT r.Id, Price, h.[Name] AS Hotel, c.[Name] AS City
	  FROM Rooms AS r
	  JOIN Hotels AS h ON h.Id = r.HotelId
	  JOIN Cities AS c ON c.Id = h.CityId
	  WHERE r.[Type] = 'First Class'
	  ORDER BY r.Price DESC, r.Id

----- 10. Longest and Shortest Trips -----
		SELECT AccountId, FullName, LongestTrip, ShortestTrip FROM (
		SELECT 
			a.Id AS AccountId
			,CONCAT(a.FirstName, ' ', a.LastName) AS FullName
			,MAX(DATEDIFF(DAY, t.ArrivalDate, t.ReturnDate)) AS LongestTrip
			,MIN(DATEDIFF(DAY, t.ArrivalDate, t.ReturnDate)) AS ShortestTrip
		FROM Accounts AS a
		JOIN AccountsTrips AS atr ON atr.AccountId = a.Id
		JOIN Trips AS t ON t.Id = atr.TripId
		WHERE (a.MiddleName IS NULL AND t.CancelDate IS NULL)
		GROUP BY a.Id, a.FirstName, a.LastName 
		) AS e
		ORDER BY LongestTrip DESC, AccountId

----- 11. Metropolis ---
	SELECT TOP 5
		c.Id
		,c.[Name] AS City
		,c.CountryCode AS Country
		,COUNT(a.Id) AS Accounts
	FROM Cities AS c
	JOIN Accounts AS a ON a.CityId = c.Id
	GROUP BY c.Id, c.[Name], c.CountryCode
	ORDER BY COUNT(a.Id) DESC

----- 12. Romantic Getaways  ----
		SELECT 
			a.Id, 
			a.Email, 
			c.[Name], 
			COUNT(t.Id)
		FROM Accounts AS a
			JOIN AccountsTrips AS ac ON ac.AccountId = a.Id
			JOIN Trips AS t ON t.Id = ac.TripId
			JOIN Rooms AS r ON r.Id = t.RoomId
			JOIN Hotels AS h ON h.Id = r.HotelId
			JOIN Cities AS c ON c.Id = a.CityId
		WHERE a.CityId = h.CityId
		GROUP BY a.Id, a.Email, c.Name
		ORDER BY COUNT(t.Id) DESC, a.Id


----- 13. Lucrative Destinations ------

	SELECT TOP 10
		 c.Id, 
		 c.[Name],
		 SUM(r.Price + h.BaseRate) AS [Total Revenue],
		 COUNT(t.Id) AS Trips
	FROM Cities AS c
	JOIN Hotels AS h ON h.CityId = c.Id
	JOIN Rooms AS r ON r.HotelId = h.Id
	JOIN Trips AS t ON t.RoomId = r.Id
	WHERE YEAR(t.BookDate) = 2016
	GROUP BY c.Id, c.[Name]
	ORDER BY [Total Revenue] DESC, Trips DESC 


----- 14. Trip Revenues ------

	SELECT 
			t.Id,
			h.[Name] AS HotelName,
			r.[Type] AS RoomType,
			CASE
				WHEN t.CancelDate IS NULL THEN SUM(h.BaseRate + r.Price)
				ELSE 0
			END AS Revenue
	FROM Trips AS t
	JOIN Rooms AS r ON r.Id = t.RoomId
	JOIN Hotels AS h ON h.Id = r.HotelId
	JOIN AccountsTrips AS ac ON ac.TripId = t.Id
	GROUP BY 
			t.Id, 
			h.Name, 
			r.Type, 
			t.CancelDate
	ORDER BY r.[Type], t.Id

	
	SELECT t.Id AS FirstId, atr.TripId AS  SecondID, atr.AccountId 
	FROM Trips AS t
	LEFT JOIN AccountsTrips AS atr ON atr.TripId = t.Id


	------ 15. Top Travelers -------
	SELECT AccountId, Email, CountryCode, Trips FROM (
		SELECT a.Id AS AccountId, a.Email AS Email, c1.CountryCode AS CountryCode, COUNT(atr.TripId) AS Trips,
			ROW_NUMBER() OVER (PARTITION BY c1.CountryCode ORDER BY COUNT(atr.TripId) DESC) AS RowNumber  
		FROM Accounts AS a
		JOIN AccountsTrips AS atr ON atr.AccountId = a.Id
		JOIN Trips AS t ON t.Id = atr.TripId
		JOIN Rooms AS r ON r.Id = t.RoomId
		JOIN Hotels AS h ON h.Id = r.HotelId
		JOIN Cities AS c1 ON c1.Id = h.CityId
		GROUP BY a.Id, a.Email, c1.CountryCode 
	) AS a
	WHERE RowNumber = 1
	ORDER BY Trips DESC, AccountId


	------ 16. Luggage Fees ------

	SELECT TripId, Luggage, '$' + CONVERT(VARCHAR, SumFee) AS Fee 
	FROM (
		SELECT TripId, SUM(Luggage) AS Luggage,
			CASE
				WHEN SUM(Luggage) > 5 THEN SUM(Luggage) * 5
				ELSE 0
			END AS SumFee
		FROM AccountsTrips
		WHERE Luggage > 0
		GROUP BY TripId )
	AS a
	ORDER BY Luggage DESC 


------ 17. GDPR Violation -------
	
	SELECT	
			t.Id AS Id,
			CONCAT(FirstName, ' ' +  MiddleName, ' ', LastName) AS [Full Name]
			,c.[Name] AS [From]
			,c1.[Name] AS [To]
			,CASE
				WHEN t.CancelDate IS NOT NULL THEN 'Canceled'
				ELSE CONVERT(VARCHAR, DATEDIFF(DAY, t.ArrivalDate, t.ReturnDate)) + ' ' + 'days'
			END AS Duration
	FROM Accounts AS a
	JOIN Cities AS c ON c.Id = a.CityId
	JOIN AccountsTrips AS ac ON ac.AccountId = a.Id
	JOIN Trips AS t ON t.Id = ac.TripId
	JOIN Rooms AS r ON r.Id = t.RoomId
	JOIN Hotels AS h ON h.Id = r.HotelId
	JOIN Cities AS c1 ON c1.Id = h.CityId
	ORDER BY [Full Name], t.Id
	GO

----- 18. Available Room  ---
	
	CREATE FUNCTION udf_GetAvailableRoom(@HotelId INT, @Date DATE, @People INT)
  RETURNS VARCHAR(MAX)
AS
  BEGIN
    DECLARE @BookedRooms TABLE(Id INT)
    INSERT INTO @BookedRooms
      SELECT DISTINCT R.Id
      FROM Rooms R
        LEFT JOIN Trips T on R.Id = T.RoomId
      WHERE R.HotelId = @HotelId AND @Date BETWEEN T.ArrivalDate AND T.ReturnDate AND T.CancelDate IS NULL

    DECLARE @Rooms TABLE(Id INT, Price DECIMAL(15, 2), Type VARCHAR(20), Beds INT, TotalPrice DECIMAL(15, 2))
    INSERT INTO @Rooms
      SELECT TOP 1
        R.Id,
        R.Price,
        R.Type,
        R.Beds,
        @People * (H.BaseRate + R.Price) AS TotalPrice
      FROM Rooms R
        LEFT JOIN Hotels AS H on R.HotelId = H.Id
      WHERE
        R.HotelId = @HotelId AND
        R.Beds >= @People AND
        R.Id NOT IN (SELECT Id
                     FROM @BookedRooms)
      ORDER BY TotalPrice DESC

    DECLARE @RoomCount INT = (SELECT COUNT(*)
                              FROM @Rooms)
    IF (@RoomCount < 1)
      BEGIN
        RETURN 'No rooms available'
      END

    DECLARE @Result VARCHAR(MAX) = (SELECT CONCAT('Room ', Id, ': ', Type, ' (', Beds, ' beds) - ', '$', TotalPrice)
                                    FROM @Rooms)

    RETURN @Result
  END

  SELECT dbo.udf_GetAvailableRoom(112, '2011-12-17', 2)
  GO

  ----- 20 Cancel Trip ----
  CREATE TRIGGER tr_TripsDelition
  ON Trips
  INSTEAD OF DELETE
  AS
  BEGIN
	
		UPDATE Trips
		SET CancelDate = GETDATE()
		WHERE Id IN (SELECT Id
                   FROM deleted
                   WHERE CancelDate IS NULL);
 END

DELETE FROM Trips
WHERE Id IN (48, 49, 50)


SELECT * FROM Trips WHERE Id = 50