
-- 1. Number of Users for Email Provider --
WITH CTE_Domains ([Email Provider])
AS
(
	SELECT SUBSTRING(u.Email, u.[DomainIndex] + 1, LEN(Email)) AS [Email Provider]
	FROM (
	SELECT CHARINDEX('@', Email) AS [DomainIndex], Email
	FROM Users) 
	AS u
)

SELECT [Email Provider], COUNT(*) AS [Number Of Users]
FROM CTE_Domains
GROUP BY [Email Provider]
ORDER BY [Number Of Users] DESC, [Email Provider]


-- 02. All Users in Games --

SELECT g.[Name] AS Game, gt.[Name] AS [Game Type], u.Username, ug.[Level], ug.Cash, ch.[Name] AS [Character]
FROM UsersGames AS ug
JOIN Games AS g ON g.Id = ug.GameId
JOIN GameTypes AS gt ON gt.Id = g.GameTypeId
JOIN Users AS u ON u.Id = ug.UserId
JOIN Characters AS ch ON ch.Id = ug.CharacterId
ORDER BY ug.[Level] DESC, u.Username, g.[Name]
GO

-- 03. Users in Games with Their Items --
WITH CTE_GamesAndItems([Username], Game, [Items Count], [Items Price])
AS
(
	SELECT u.Username AS [Username], g.[Name] AS Game, COUNT(i.Name) AS [Items Count], SUM(i.Price) AS [Items Price]
	FROM UsersGames AS ug
	JOIN Users AS u ON u.Id = ug.UserId
	JOIN Games AS g ON g.Id = ug.GameId
	JOIN UserGameItems AS ugi ON ugi.UserGameId = ug.Id
	JOIN Items AS i ON i.Id = ugi.ItemId
	GROUP BY u.Username, g.[Name]
)

	SELECT * 
	FROM 
		CTE_GamesAndItems
	WHERE 
		[Items Count] >= 10
	ORDER BY 
		[Items Count] DESC, 
		[Items Price] DESC

-- 05. All Items with Greater than Average Statistics --

SELECT * FROM (
SELECT i.[Name] AS [Name], i.Price AS [Price], i.MinLevel AS [MinLevel], 
		st.Strength As [Strength], st.Defence As [Defence], 
		st.Speed AS [Speed], st.Luck AS [Luck], st.Mind AS [Mind]
  FROM Items AS i
  JOIN [Statistics] AS st ON st.Id = i.StatisticId
  )
  AS e
  WHERE 
	(Mind > (SELECT AVG(Mind) FROM [Statistics])
	AND Luck > (SELECT AVG(Luck) FROM [Statistics])
	AND Speed > (SELECT AVG(Speed) FROM [Statistics]))
  ORDER BY [Name]

  -- 06. Display All Items about Forbidden Game Type --

  SELECT a.[Name] AS Item, a.Price, a.MinLevel, gt.[Name] AS [Forbidden Game Type]
  FROM Items AS a
  LEFT JOIN GameTypeForbiddenItems AS gtfi ON gtfi.ItemId = a.Id
  LEFT JOIN GameTypes AS gt ON gt.Id = gtfi.GameTypeId
  ORDER BY gt.[Name] DESC, a.[Name] 
  GO
  -- 07. Buy Items for User in Game --

-- CREATE PROCEDURE udp_BuyItems
-- AS
-- BEGIN
--		DECLARE @UserId INT = (SELECT Id 
--						   FROM Users
--						   WHERE Username = 'Alex')
						
--		DECLARE @GameID INT = (SELECT Id 
--								FROM Games
--								WHERE Name = 'Edinburgh')
							
--		DECLARE @UserGamesId INT = (SELECT Id 
--								  FROM UsersGames
--								  WHERE (UserId = @UserId AND GameId = @GameID))

--		DECLARE @TtotalPrice DECIMAL(15,2) = (SELECT SUM(Price) 
--												FROM Items 
--												WHERE 
--														(  [Name] = 'Blackguard' 
--														OR [Name] = 'Bottomless Potion of Amplification'
--														OR [Name] = 'Eye of Etlich (Diablo III)'
--														OR [Name] = 'Gem of Efficacious Toxin'
--														OR [Name] = 'Golden Gorget of Leoric'
--														OR [Name] = 'Hellfire Amulet'))

--		INSERT INTO UserGameItems VALUES
--		((SELECT Id FROM Items WHERE [Name] = 'Blackguard'), @UserGamesId),
--		((SELECT Id FROM Items WHERE [Name] = 'Bottomless Potion of Amplification'), @UserGamesId),
--		((SELECT Id FROM Items WHERE [Name] = 'Eye of Etlich (Diablo III)'), @UserGamesId),
--		((SELECT Id FROM Items WHERE [Name] = 'Gem of Efficacious Toxin'), @UserGamesId),
--		((SELECT Id FROM Items WHERE [Name] = 'Golden Gorget of Leoric'), @UserGamesId),
--		((SELECT Id FROM Items WHERE [Name] = 'Hellfire Amulet'), @UserGamesId)
		
		
									
--		UPDATE UsersGames
--		SET Cash -= @TtotalPrice
--		WHERE Id = @UserGamesId
--END
--	EXEC udp_BuyItems
	
--  SELECT u.Username, g.[Name], REPLACE(ug.Cash, ug.Cash, '****.**') AS Cash, i.[Name] AS [Item Name]
--  FROM UsersGames AS ug
--  JOIN Users AS u ON u.Id = ug.UserId
--  JOIN Games AS g ON g.Id = ug.GameId
--  JOIN UserGameItems AS ugi ON ugi.UserGameId = ug.Id
--  JOIN Items AS i ON i.Id = ugi.ItemId
--  ORDER BY i.[Name]

-- 08. Peaks and Mountains --

	SELECT PeakName, MountainRange AS [Mountain], Elevation
	FROM Mountains AS m
	JOIN Peaks AS p ON p.MountainId = m.Id
	ORDER BY Elevation DESC, PeakName

-- 09. Peaks with Mountain, Country and Continent --

	SELECT PeakName, MountainRange AS [Mountain], CountryName, ContinentName
	FROM Mountains AS m
	JOIN Peaks AS p ON p.MountainId = m.Id
	JOIN MountainsCountries AS mc ON mc.MountainId = m.Id
	JOIN Countries AS c ON c.CountryCode = mc.CountryCode
	JOIN Continents AS cont ON cont.ContinentCode = c.ContinentCode
	ORDER BY PeakName, CountryName

-- 10. Rivers by Country --
SELECT CountryName, ContinentName, COUNT(r.Id) AS RiersCount, [TotalLength] = 
  
      CASE   
         WHEN SUM([Length]) IS NULL THEN 0  
         
         ELSE SUM([Length]) 
      END  
FROM Countries AS c
LEFT JOIN Continents AS cont ON cont.ContinentCode = c.ContinentCode
LEFT JOIN CountriesRivers AS cr ON cr.CountryCode = c.CountryCode
LEFT JOIN Rivers AS r ON r.Id = cr.RiverId
GROUP BY CountryName, ContinentName
ORDER BY COUNT(r.Id) DESC, SUM([Length]) DESC, c.CountryName

-- 11. Count of Countries by Currency --
SELECT cur.CurrencyCode AS [CurrencyCode], cur.[Description] AS [Currency], COUNT(c.CountryCode) AS [NumberOfCountries]
FROM Currencies AS cur
LEFT JOIN Countries AS c ON c.CurrencyCode = cur.CurrencyCode
GROUP BY cur.CurrencyCode, cur.[Description]
ORDER BY COUNT(c.CountryCode) DESC, cur.[Description]

SELECT * FROM Currencies

-- 12. Population and Area by Continent --

ALTER TABLE Countries
ALTER COLUMN [Population] BIGINT NOT NULL

SELECT ContinentName, SUM(c.AreaInSqKm) AS [CountriesArea], SUM(c.Population) AS CountriesPopulation
FROM Continents AS con
JOIN Countries AS c ON c.ContinentCode = con.ContinentCode
GROUP BY ContinentName
ORDER BY SUM(c.Population) DESC
GO

-- 13. Monasteries by Country --

CREATE TABLE Monasteries(
Id INT IDENTITY NOT NULL,
[Name] NVARCHAR(64) NOT NULL,
CountryCode CHAR(2) NOT NULL

CONSTRAINT PK_Monasteries
PRIMARY KEY(Id)

CONSTRAINT FK_Monasteries_Countries
FOREIGN KEY(CountryCode) REFERENCES Countries(CountryCode)
)


INSERT INTO Monasteries ([Name], CountryCode) VALUES
('Rila Monastery “St. Ivan of Rila”', 'BG'), 
('Bachkovo Monastery “Virgin Mary”', 'BG'),
('Troyan Monastery “Holy Mother''s Assumption”', 'BG'),
('Kopan Monastery', 'NP'),
('Thrangu Tashi Yangtse Monastery', 'NP'),
('Shechen Tennyi Dargyeling Monastery', 'NP'),
('Benchen Monastery', 'NP'),
('Southern Shaolin Monastery', 'CN'),
('Dabei Monastery', 'CN'),
('Wa Sau Toi', 'CN'),
('Lhunshigyia Monastery', 'CN'),
('Rakya Monastery', 'CN'),
('Monasteries of Meteora', 'GR'),
('The Holy Monastery of Stavronikita', 'GR'),
('Taung Kalat Monastery', 'MM'),
('Pa-Auk Forest Monastery', 'MM'),
('Taktsang Palphug Monastery', 'BT'),
('Sümela Monastery', 'TR')

--ALTER TABLE Countries  --**NOT TO BE UPLOADED IN JUDGE**
--ADD IsDeleted BIT

--UPDATE Countries        --**NOT TO BE UPLOADED IN JUDGE**
--SET IsDeleted = 0
--GO

	UPDATE Countries
	SET IsDeleted = 1
	WHERE CountryCode IN (SELECT CountryCode
						   FROM CountriesRivers
						   GROUP BY CountryCode
						   HAVING COUNT(RiverId) > 3 )
	

SELECT m.[Name] AS Monastery, c.CountryName AS Country
FROM Monasteries AS m
JOIN Countries AS c ON c.CountryCode = m.CountryCode
WHERE c.IsDeleted = 0
ORDER BY m.[Name]

-- 14. Monasteries by Continents and Countries --
UPDATE Countries 
SET CountryName = 'Burma'
WHERE CountryName = 'Myanmar'

INSERT INTO Monasteries(Name, CountryCode) VALUES
('Hanga Abbey', (SELECT CountryCode FROM Countries WHERE CountryName = 'Tanzania'))
INSERT INTO Monasteries(Name, CountryCode) VALUES
('Myin-Tin-Daik', (SELECT CountryCode FROM Countries WHERE CountryName = 'Maynmar'))

SELECT ContinentName, CountryName, COUNT(m.Name) AS [MonasteriesCount]
FROM Countries AS c
LEFT JOIN Continents AS cont ON cont.ContinentCode = c.ContinentCode
LEFT JOIN Monasteries AS m ON m.CountryCode = c.CountryCode
WHERE c.IsDeleted = 0
GROUP BY ContinentName, CountryName
ORDER BY COUNT(m.Name) DESC, c.CountryName
