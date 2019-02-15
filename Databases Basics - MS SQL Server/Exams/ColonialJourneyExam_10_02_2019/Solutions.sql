

----- 01 DDL ------
CREATE TABLE Planets(
Id INT PRIMARY KEY IDENTITY,
[Name] VARCHAR(30) NOT NULL,
)

CREATE TABLE Spaceports(
Id INT PRIMARY KEY IDENTITY,
[Name] VARCHAR(50) NOT NULL,
PlanetId INT FOREIGN KEY REFERENCES Planets(Id) NOT NULL
)

CREATE TABLE Spaceships(
Id INT PRIMARY KEY IDENTITY,
[Name] VARCHAR(50) NOT NULL,
Manufacturer VARCHAR(30) NOT NULL,
LightSpeedRate INT DEFAULT (0)
)

CREATE TABLE Colonists(
Id INT PRIMARY KEY IDENTITY,
FirstName VARCHAR(20) NOT NULL,
LastName VARCHAR(20) NOT NULL,
Ucn VARCHAR(10) UNIQUE NOT NULL,
BirthDate DATE NOT NULL
)

CREATE TABLE Journeys(
Id INT PRIMARY KEY IDENTITY,
JourneyStart DATETIME  NOT NULL,
JourneyEnd DATETIME NOT NULL,
Purpose VARCHAR(11) CHECK (Purpose IN( 'Medical', 'Technical', 'Educational', 'Military')),
DestinationSpaceportId INT FOREIGN KEY REFERENCES Spaceports(Id) NOT NULL,
SpaceshipId INT FOREIGN KEY REFERENCES Spaceships(Id) NOT NULL
)

CREATE TABLE TravelCards(
Id INT PRIMARY KEY IDENTITY,
CardNumber CHAR(10) UNIQUE NOT NULL,
JobDuringJourney VARCHAR(8) CHECK (JobDuringJourney IN( 'Pilot', 'Engineer', 'Trooper', 'Cleaner', 'Cook')),
ColonistId INT FOREIGN KEY REFERENCES Colonists(Id) NOT NULL,
JourneyId INT FOREIGN KEY REFERENCES Journeys(Id) NOT NULL
)


------- 02 Insert -------
INSERT INTO Planets VALUES
('Mars'),
('Earth'),
('Jupiter'),
('Saturn')

INSERT INTO Spaceships VALUES
('Golf', 'VW', 3),
('WakaWaka', 'Wakanda', 4),
('Falcon9',	'SpaceX', 1),
('Bed',	'Vidolov', 6)


------- 03 Update -------
UPDATE Spaceships
SET LightSpeedRate += 1
WHERE Id BETWEEN 8 AND 12

------ 04 Delete -----
DELETE FROM TravelCards
WHERE JourneyId BETWEEN 1 AND 3

DELETE FROM Journeys
WHERE Id  BETWEEN 1 AND 3

SELECT * FROM Journeys
SELECT * FROM TravelCards


-----  05. Select All Travel Cards-----
 SELECT CardNumber, JobDuringJourney
 FROM TravelCards
 ORDER BY CardNumber


 ----- 06. Select All Colonists ----
 SELECT Id, CONCAT(FirstName, ' ', LastName), Ucn
 FROM Colonists
 ORDER BY FirstName, LastName, Id


 ------  07. Select All Military Journeys ----
 SELECT Id, CONVERT(VARCHAR, JourneyStart, 103) AS JourneySart, CONVERT(VARCHAR, JourneyEnd, 103) AS JourneyEnd
 FROM Journeys
 WHERE Purpose = 'Military'
 ORDER BY JourneyStart


 ----- 08. Select All Pilots ------
 SELECT c.Id AS id, FirstName + ' ' + LastName AS full_name
 FROM Colonists AS c
 JOIN TravelCards AS tr ON tr.ColonistId = c.Id
 WHERE tr.JobDuringJourney = 'Pilot'
 ORDER BY c.Id

 ----- 09. Count Colonists ----
 SELECT COUNT(*) AS [count]
 FROM Journeys AS j
 JOIN TravelCards AS t ON t.JourneyId = j.Id
 WHERE j.Purpose = 'Technical'


 ----- 10. Select The Fastest Spaceship ----
	SELECT TOP 1 ss.Name AS SpaceshipName, sp.Name AS SpaceportName
	FROM Spaceships AS ss
	JOIN Journeys AS j ON j.SpaceshipId = ss.Id
	JOIN Spaceports AS sp ON sp.Id = j.DestinationSpaceportId
	ORDER BY ss.LightSpeedRate DESC

-----  11. Select Spaceships With Pilots -----

SELECT DISTINCT ss.Name, ss.Manufacturer
FROM Spaceships AS ss
JOIN Journeys AS j ON j.SpaceshipId = ss.Id
JOIN TravelCards AS t ON t.JourneyId = j.Id
JOIN Colonists AS c ON c.Id = t.ColonistId
WHERE DATEDIFF(YEAR, c.BirthDate, '01-01-2019') < 30 AND t.JobDuringJourney = 'Pilot'
ORDER BY ss.Name

------ 12. Select All Educational Mission ----
SELECT p.Name AS PlanetName, s.Name AS SpaceportName
FROM Planets AS p
JOIN Spaceports AS s ON s.PlanetId = p.Id
JOIN Journeys As j ON j.DestinationSpaceportId = s.Id
WHERE j.Purpose = 'Educational'
ORDER BY s.Name DESC


----- 13. Planets And Journeys ------
	
SELECT * FROM (
	SELECT p.Name AS PlanetName, COUNT(j.Id) AS JourneysCount
	FROM Planets AS p
	JOIN Spaceports AS sp ON sp.PlanetId = p.Id
	JOIN Journeys AS j ON j.DestinationSpaceportId = sp.Id
	GROUP BY p.Name ) AS a
ORDER BY JourneysCount DESC, PlanetName


------ 14. Extract The Longestt Journey-----
	SELECT h.Id As Id, PlanetName, SpaceportName, JourneyPurpose FROM (
		SELECT j.Id, p.Name AS PlanetName, sp.Name AS SpaceportName, j.Purpose AS JourneyPurpose,
				ROW_NUMBER() OVER(ORDER BY DATEDIFF(MINUTE, j.JourneyStart, j.JourneyEnd) ASC) AS RowNumber
		FROM Journeys AS j
		JOIN Spaceports AS sp ON sp.Id = j.DestinationSpaceportId
		JOIN Planets AS p ON p.Id = sp.PlanetId)
		AS h
	WHERE RowNumber = 1



-----  15. Select The Less Popular Job ------
	
	SELECT TOP 1 JourneyId, JobName FROM (
	SELECT
			j.Id AS JourneyId,
			tc.JobDuringJourney AS JobName,
			COUNT(tc.JobDuringJourney) AS JobCount
	FROM TravelCards AS tc
	JOIN Journeys AS j ON j.Id = tc.JourneyId
	WHERE j.Id = (SELECT TOP 1 Id FROM Journeys ORDER BY DATEDIFF(DAY, JourneyStart, JourneyEnd) DESC)
	GROUP BY j.Id, tc.JobDuringJourney
	) AS h
	ORDER BY JobCount

	------ 15 Alternative
	
		SELECT TOP 1 j.Id, tc.JobDuringJourney AS JobName
		FROM Journeys AS j
		JOIN TravelCards AS tc ON tc.JourneyId = j.Id
		GROUP BY j.Id, tc.JobDuringJourney, j.JourneyStart, j.JourneyEnd
		ORDER BY DATEDIFF(DAY, j.JourneyStart, j.JourneyEnd) DESC, COUNT(tc.JobDuringJourney) ASC
	------

 ---- 16. Select Special Colonists -----
SELECT * FROM (
	SELECT 
		JobDuringJourney, 
		FirstName + ' ' + LastName as FullName,
		DENSE_RANK() OVER (PARTITION BY JobDuringJourney ORDER BY BirthDate) as JobRank
	FROM TravelCards AS tc
	JOIN Colonists AS c ON c.Id = tc.ColonistId ) AS a
WHERE JobRank = 2

----- 17. Planets and Spaceports ------
	SELECT p.Name AS [Name], COUNT(sp.Id) AS [Count]
	FROM Planets AS p
	LEFT JOIN Spaceports AS sp ON sp.PlanetId = p.Id
	GROUP BY p.Name
	ORDER BY COUNT(sp.Id) DESC, p.Name
GO

------ 18. Get Colonists Count  -----
CREATE FUNCTION udf_GetColonistsCount(@PlanetName VARCHAR (30))
RETURNS INT
AS
BEGIN
	DECLARE @PlanetPeopleCount INT
	SET @PlanetPeopleCount = (SELECT COUNT(*)
								FROM Planets AS p
								JOIN Spaceports AS sp ON sp.PlanetId = p.Id
								JOIN Journeys AS j ON j.DestinationSpaceportId = sp.Id
								JOIN TravelCards AS t ON t.JourneyId = j.Id
								WHERE p.Name = @PlanetName)
	

	RETURN @PlanetPeopleCount
END

GO
SELECT dbo.udf_GetColonistsCount('Otroyphus')
GO
----- 19. Change Journey Purpose -----
CREATE PROCEDURE usp_ChangeJourneyPurpose(@JourneyId INT, @NewPurpose VARCHAR(11))
AS
BEGIN	
		BEGIN TRANSACTION

			IF(@JourneyId NOT IN (SELECT Id FROM Journeys))
			BEGIN
				ROLLBACK
				RAISERROR('The journey does not exist!', 16,1)
				RETURN
			END

			ELSE IF(@NewPurpose IN (SELECT Purpose FROM Journeys WHERE Id = @JourneyId))
			BEGIN
				ROLLBACK
				RAISERROR('You cannot change the purpose!', 16,1)
				RETURN
			END

			UPDATE Journeys
			SET Purpose = @NewPurpose
			WHERE Id = @JourneyId

			COMMIT
END

----  20. Deleted Journeys ----
CREATE TABLE DeletedJourneys(
tableId INT PRIMARY KEY IDENTITY,
Id INT NOT NULL,
JourneyStart DATETIME NOT NULL,
JourneyEnd DATETIME NOT NULL,
Purpose VARCHAR(11),
DestinationSpaceportId INT NOT NULL,
SpaceshipId INT NOT NULL
)
GO
DROP TABLE DeletedJourneys
GO
CREATE TRIGGER tr_DeletedJourneysLog 
ON Journeys
FOR DELETE
AS
BEGIN
	
	INSERT INTO DeletedJourneys
	SELECT Id, JourneyStart, JourneyEnd, Purpose, DestinationSpaceportId, SpaceshipId
	FROM deleted

END

DELETE FROM TravelCards
WHERE JourneyId =  2

DELETE FROM Journeys
WHERE Id =  2

SELECT * FROM DeletedJourneys



--DECLARE @JourneyStart DATETIME = (SELECT JourneyStart FROM deleted)

	--DECLARE @JourneyEnd DATETIME = (SELECT JourneyEnd FROM deleted)

	--DECLARE @Purpose VARCHAR(11) = (SELECT Purpose FROM deleted)

	--DECLARE @DestinationSpaceportId INT = (SELECT DestinationSpaceportId FROM deleted)

	--DECLARE @SpaceshipId INT = (SELECT SpaceshipId FROM deleted)
