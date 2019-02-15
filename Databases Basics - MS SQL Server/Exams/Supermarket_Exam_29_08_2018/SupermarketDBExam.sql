

--- SECTION 01. DDL ---
CREATE TABLE Employees(
Id INT PRIMARY KEY IDENTITY,
FirstName NVARCHAR(50) NOT NULL,
LastName NVARCHAR(50) NOT NULL,
Phone CHAR(12) NOT NULL,
Salary DECIMAL(15, 2) NOT NULL
)

CREATE TABLE Shifts
(
	Id INT IDENTITY NOT NULL,
	EmployeeId INT FOREIGN KEY REFERENCES Employees(Id) NOT NULL,
	CheckIn DATETIME NOT NULL,
	CheckOut DATETIME NOT NULL
	
	CONSTRAINT PK_Shifts PRIMARY KEY (Id, EmployeeId)
)

CREATE TABLE Categories(
Id INT PRIMARY KEY IDENTITY,
[Name] NVARCHAR(30) NOT NULL
)

CREATE TABLE Items(
Id INT PRIMARY KEY IDENTITY,
[Name] NVARCHAR(30) NOT NULL,
Price DECIMAL(15, 2) NOT NULL,
CategoryId INT FOREIGN KEY REFERENCES Categories(Id) NOT NULL
)

CREATE TABLE Orders(
Id INT PRIMARY KEY IDENTITY,
[DateTime] DATETIME NOT NULL,
EmployeeId INT FOREIGN KEY REFERENCES Employees(Id) NOT NULL
)

CREATE TABLE OrderItems(
OrderId INT FOREIGN KEY REFERENCES Orders(Id),
ItemId INT FOREIGN KEY REFERENCES Items(Id),
Quantity INT NOT NULL CHECK (Quantity >= 1) 

CONSTRAINT PK_OrderItems PRIMARY KEY (OrderId, ItemId)

)

ALTER TABLE Shifts 
ADD CONSTRAINT CHK_CheckDates CHECK(CheckIn < CheckOut)

--- Section 2. DML (10 pts) --
INSERT INTO Employees (FirstName, LastName, Phone, Salary) VALUES
('Stoyan', 'Petrov', '888-785-8573', 500.25),
('Stamat', 'Nikolov', '789-613-1122', 999995.25),
('Evgeni', 'Petkov', '645-369-9517', 1234.51),
('Krasimir', 'Vidolov', '321-471-9982',	50.25)

INSERT INTO Items (Name, Price, CategoryId) VALUES
('Tesla battery', 154.25, 8),
('Chess', 30.25, 8),
('Juice', 5.32,	1),
('Glasses',	10,	8),
('Bottle of water',	1, 1)

-----03 Update --
UPDATE Items
SET Price = Price * 1.27
WHERE CategoryId IN (1, 2, 3)

---- 04 Delete -----
DELETE FROM OrderItems
WHERE OrderId = 48

--- Section 3. Querying (40 pts) ---
SELECT Id, FirstName 
FROM Employees
WHERE Salary > 6500
ORDER BY FirstName, Id


----- 06. Cool Phone Numbers -----
SELECT CONCAT(FirstName, ' ', LastName) AS FullName, Phone AS [Phone Number]
FROM Employees
WHERE Phone LIKE '3%'
ORDER BY FirstName, Phone

----- 07. Employee Statistics ------
SELECT FirstName, LastName, [Count] FROM (
SELECT FirstName, LastName, COUNT(o.EmployeeId) AS [Count]
FROM Employees AS e
JOIN Orders AS o ON o.EmployeeId = e.Id
GROUP BY FirstName, LastName) AS a
ORDER BY [Count] DESC, FirstName

------ 08 Hard Workers Club ---------
SELECT FirstName, LastName, [Work hours] FROM (
SELECT e.Id, FirstName, LastName, [Work hours] = AVG(DATEDIFF(HOUR, s.CheckIn, s.CheckOut))
FROM Employees AS e
JOIN Shifts AS s ON s.EmployeeId = e.Id
GROUP BY FirstName, LastName, e.Id
) AS a
WHERE [Work hours] > 7
ORDER BY [Work hours] DESC, Id

---- 09. The Most Expensive Order ----

SELECT TOP 1  o.Id, TotalPrice = SUM(oi.Quantity * i.Price)
FROM Orders AS o
JOIN OrderItems AS oi ON oi.OrderId = o.Id
JOIN Items AS i ON i.Id = oi.ItemId
GROUP BY o.Id
ORDER BY SUM(oi.Quantity * i.Price) DESC

---- 10. Rich Item, Poor Item ---
	SELECT TOP 10 a.OrderId, a.ExpensivePrice, CheapPrice FROM (
	SELECT  OrderId, MAX(Price) AS ExpensivePrice,  MIN(Price) AS CheapPrice
	  FROM  OrderItems AS oi
      JOIN  Items AS i ON i.Id = oi.ItemId
  GROUP BY  OrderId) AS a
  ORDER BY	ExpensivePrice DESC, a.OrderId ASC


  ---- 11. Cashiers ---
	SELECT e.Id, FirstName, LastName
	 FROM Employees AS e
	 JOIN Orders AS o ON o.EmployeeId = e.Id
	 GROUP BY e.Id, FirstName, LastName
	 ORDER BY e.Id

  ----- 12. Lazy Employees ---
  SELECT Id, [Full Name] FROM (
  SELECT e.Id, CONCAT(e.FirstName, ' ', e.LastName) AS [Full Name]
  FROM Employees AS e
  JOIN Shifts AS s ON s.EmployeeId = e.Id
  WHERE DATEDIFF(HOUR, s.CheckIn, s.CheckOut) < 4 ) AS e
  GROUP BY Id, [Full Name]
  ORDER BY e.Id

  ------ 13. Sellers ------

  SELECT TOP 10   
		   CONCAT(FirstName, ' ', LastName) AS [Full Name],
		   SUM(i.Price * oi.Quantity) AS [Total Price],
		   SUM(oi.Quantity) AS Items
  FROM Employees AS e
  JOIN Orders AS o ON o.EmployeeId = e.Id
  JOIN OrderItems AS oi ON oi.OrderId = o.Id
  JOIN Items AS i ON i.Id = oi.ItemId
  WHERE o.DateTime < '2018-06-15'
  GROUP BY e.FirstName, e.LastName
  ORDER BY SUM(i.Price * oi.Quantity) DESC, SUM(oi.Quantity)

  ------ 14. Tough Days ------
  SELECT CONCAT(FirstName, ' ', LastName) AS [Full Name], 
				[Day of week] = DATENAME(WEEKDAY,  s.CheckIn)
  FROM Employees AS e
  LEFT JOIN Orders AS o ON o.EmployeeId = e.Id
  JOIN Shifts AS s ON s.EmployeeId = e.Id
  WHERE (o.Id IS NULL AND DATEDIFF(HOUR, s.CheckIn, s.CheckOut ) > 12)
  ORDER BY e.Id

  ------ 15. Top Order per Employee -----

  SELECT 
	CONCAT(FirstName, ' ', LastName) AS [Full Name],
	DATEDIFF(HOUR, s.CheckIn, s.CheckOut) AS WorkHours,
	a.TotalPrice 
	FROM (
		SELECT o.EmployeeId, SUM(oi.Quantity * i.Price) AS TotalPrice, o.DateTime,
		DENSE_RANK() OVER (PARTITION BY o.EmployeeId ORDER BY SUM(oi.Quantity * i.Price) DESC) AS Rank 
		FROM Orders AS o
		JOIN OrderItems AS oi ON oi.OrderId = o.Id
		JOIN Items AS i ON i.Id = oi.ItemId
		GROUP BY o.EmployeeId, o.Id, o.DateTime
	) AS a
	JOIN Employees AS e ON e.Id = a.EmployeeId
	JOIN Shifts AS s ON s.EmployeeId = e.Id
	WHERE (a.Rank = 1 AND a.DateTime BETWEEN s.CheckIn AND s.CheckOut)
	ORDER BY [Full Name], WorkHours DESC, TotalPrice DESC

	----- 16. Average Profit per Day ------
	SELECT a.[Day], FORMAT([Total profit], 'N2') AS [Total profit] FROM (
	SELECT 
		 DATEDIFF(DAY, '2018-05-31', [DateTime]) AS [Day]
		 ,AVG(i.Price * oi.Quantity) AS [Total profit]
	FROM Orders AS o
	JOIN OrderItems AS oi ON oi.OrderId = o.Id
	JOIN Items AS i ON i.Id = oi.ItemId
	GROUP BY DATEDIFF(DAY, '2018-05-31', [DateTime])
	) AS a
	ORDER BY a.[Day]

	--- 17. Top Products ---
	SELECT Item, c.[Name] AS Category, SUM([Count]) AS [Count], SUM(Price) AS TotalPrice FROM (
	SELECT
		i.CategoryId,
		i.[Name] AS Item
		,SUM(Quantity) AS [Count]
		,SUM(i.Price * oi.Quantity) AS Price
	FROM OrderItems AS oi
	RIGHT JOIN Items AS i ON i.Id = oi.ItemId
	GROUP BY i.[Name], oi.OrderId, i.CategoryId
	 ) AS a
	 JOIN Categories AS c ON c.Id = a.CategoryId
	 GROUP BY Item, c.[Name]
	 ORDER BY TotalPrice DESC, SUM([Count]) DESC

	 --Second decision without sub queries
	SELECT
		 i.[Name] AS Item
		,c.Name AS Categoty
		,SUM(Quantity) AS [Count]
		,SUM(i.Price * oi.Quantity) AS TotalPrice
	FROM OrderItems AS oi
	RIGHT JOIN Items AS i ON i.Id = oi.ItemId
	JOIN Categories AS c ON c.Id = i.CategoryId
	GROUP BY i.[Name], c.[Name]
	ORDER BY SUM(i.Price * oi.Quantity)DESC, SUM(Quantity) DESC

	GO
	----- 18. Promotion Days -----
	CREATE FUNCTION udf_GetPromotedProducts
	(@CurrentDate DATETIME , @StartDate DATETIME, @EndDate DATETIME, @Discount DECIMAL(15,2), @FirstItemId INT, @SecondItemId INT, @ThirdItemId INT)
	RETURNS VARCHAR(256)
	AS
	BEGIN
			IF (NOT EXISTS (SELECT Id FROM Items WHERE id = @FirstItemId) 
				OR NOT EXISTS (SELECT Id FROM Items WHERE id = @SecondItemId)
				OR NOT EXISTS (SELECT Id FROM Items WHERE id = @ThirdItemId))
			BEGIN
							RETURN('One of the items does not exists!')
			END

			ELSE IF(@CurrentDate < @StartDate OR @CurrentDate > @EndDate)
			BEGIN
				RETURN ('The current date is not within the promotion dates!')
			END

			ELSE
			DECLARE @FirstItemPrice DECIMAL(15,2) = (SELECT Price FROM Items WHERE Id = @FirstItemId),
					@SecondItemPrice DECIMAL(15,2)= (SELECT Price FROM Items WHERE Id = @SecondItemId),
					@ThirdItemPrice DECIMAL(15,2) = (SELECT Price FROM Items WHERE Id = @ThirdItemId)
				 
			SET @FirstItemPrice = @FirstItemPrice - ((@Discount / 100) * @FirstItemPrice) 
			SET @SecondItemPrice = @SecondItemPrice -  ((@Discount / 100) * @SecondItemPrice)
			SET @ThirdItemPrice = @ThirdItemPrice -  ((@Discount / 100) * @ThirdItemPrice)
			DECLARE @FirstItemName VARCHAR(64) = (SELECT Name FROM Items WHERE Id = @FirstItemId),
					@SecondItemName VARCHAR(64) = (SELECT Name FROM Items WHERE Id = @SecondItemId),
					@ThirdItemName VARCHAR(64) = (SELECT Name FROM Items WHERE Id = @ThirdItemId)
			-- Water price: 0.74 <-> Juice price: 1.31 <-> Ayran price: 4.35		

			RETURN CONCAT(@FirstItemName, ' price: ', @FirstItemPrice, ' <-> ', @SecondItemName, ' price: ', @SecondItemPrice, ' <-> ', @ThirdItemName, ' price: ', @ThirdItemPrice)

	END
	GO
	SELECT dbo.udf_GetPromotedProducts('2018-08-02', '2018-08-01', '2018-08-03',13, 3,4,5)


	GO
	------- 19. Cancel Order --------
	CREATE PROC usp_CancelOrder(@OrderId INT, @CancelDate DATETIME)
	AS
	BEGIN
		BEGIN TRANSACTION
				IF (NOT EXISTS (SELECT Id FROM Orders WHERE Id = @OrderId))
				BEGIN
							ROLLBACK
							RAISERROR('The order does not exist!', 16,1)
							RETURN
				END

				ELSE IF(DATEDIFF(DAY, (SELECT [DateTime] FROM Orders WHERE Id = @OrderId), @CancelDate) > 3)
				BEGIN
							ROLLBACK
							RAISERROR('You cannot cancel the order!', 16,1)
							RETURN
				END
				ELSE

				BEGIN
					DELETE FROM OrderItems WHERE OrderId = @OrderId
					DELETE FROM Orders WHERE Id = @OrderId
				END

		COMMIT
	END
	
	EXEC usp_CancelOrder 1, '2018-06-02'
	SELECT COUNT(*) FROM Orders
	SELECT COUNT(*) FROM OrderItems

	----- 20. Deleted Orders ---
	CREATE TABLE DeletedOrders(
	Id INT PRIMARY KEY IDENTITY,
	OrderId INT NOT NULL,
	ItemId INT NOT NULL,
	ItemQuantity INT
	)
	GO

	CREATE TRIGGER tr_DeletedOrders
	ON OrderItems
	AFTER DELETE AS
	BEGIN
		 INSERT INTO DeletedOrders (OrderId, ItemId, ItemQuantity)
		 SELECT d.OrderId, d.ItemId, d.Quantity
	     FROM deleted AS d
	
	END
	
	DELETE FROM OrderItems
	WHERE OrderId = 8
	
	DELETE FROM Orders
	WHERE Id = 8
	SELECT * FROM DeletedOrders
	SELECT * FROM OrderItems WHERE OrderId = 8