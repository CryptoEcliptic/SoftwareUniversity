-- 01. Employees with Salary Above 35000 --
CREATE PROCEDURE usp_GetEmployeesSalaryAbove35000
AS
BEGIN
	SELECT FirstName AS [First Name], LastName AS [Last Name]
	  FROM Employees
	 WHERE Salary > 35000
END

EXEC usp_GetEmployeesSalaryAbove35000
GO
-- 02. Employees with Salary Above Number --
CREATE PROC usp_GetEmployeesSalaryAboveNumber (@number DECIMAL(18, 4))
AS
BEGIN
SELECT FirstName AS [First Name], LastName AS [Last Name]
FROM Employees
WHERE Salary >= @number
END

EXEC usp_GetEmployeesSalaryAboveNumber 48100
GO

-- 03. Town Names Starting With --
CREATE PROC usp_GetTownsStartingWith (@startString VARCHAR(7))
AS
BEGIN
SELECT [Name] AS Town
FROM Towns
WHERE [Name] LIKE @startString + '%'
END

EXEC usp_GetTownsStartingWith 'b'
GO

-- 04. Employees from Town --
CREATE PROCEDURE usp_GetEmployeesFromTown (@townName VARCHAR(32))
AS
BEGIN
SELECT e.FirstName AS [First Name], e.LastName AS [Last Name]
FROM Employees AS e
JOIN Addresses AS a ON a.AddressID = e.AddressID
JOIN Towns As t ON t.TownID = a.TownID
WHERE t.Name = @townName
END

EXEC usp_GetEmployeesFromTown Sofia
GO

-- 05. Salary Level Function --
CREATE FUNCTION ufn_GetSalaryLevel(@salary DECIMAL(18, 4))
RETURNS VARCHAR(7)
   AS
BEGIN
	 DECLARE @result VARCHAR(7)
	 IF(@salary < 30000)
	 BEGIN
			SET @result =  'Low'
	 END
	 ELSE IF(@salary >= 30000 AND @salary <= 50000)
	 BEGIN
			SET @result =  ('Average')
	 END
	 ELSE SET @result =  ('High')

	 RETURN @result
END

SELECT Salary, dbo.ufn_GetSalaryLevel (Salary)
FROM Employees
GO

-- 06. Employees by Salary Level --
CREATE PROC usp_EmployeesBySalaryLevel(@level VARCHAR(7))
AS
BEGIN
	SELECT FirstName AS [First Name], LastName AS [Last Name]
	  FROM Employees
	 WHERE dbo.ufn_GetSalaryLevel (Salary) = @level
END

EXEC usp_EmployeesBySalaryLevel 'Low'
GO

-- 07. Define Function --
CREATE FUNCTION ufn_IsWordComprised (@setOfLetters VARCHAR(MAX), @word VARCHAR(MAX))
RETURNS BIT
AS
BEGIN
	 DECLARE @index INT = 1
	 DECLARE @currentLetter CHAR(1)
	 DECLARE @isTrueIndex INT
	 DECLARE @result BIT

	 WHILE(@index <= LEN(@word))
	 BEGIN
		SET @currentLetter = SUBSTRING(@word, @index, 1)
		SET @isTrueIndex = CHARINDEX(@currentLetter, @setOfLetters)
		IF(@isTrueIndex = 0)
		BEGIN
			SET @result = 0
			RETURN @result
			
		  END
		  SET @index = @index + 1 
	 END
	SET @result = 1
	RETURN @result
END

SELECT dbo.ufn_IsWordComprised ('oistmiahf', 'Sofia')
GO

-- 08. Delete Employees and Departments --
BACKUP DATABASE SoftUni
TO DISk = 'E:\SOFTUNI ARCHIVE\SoftUni.bak'

CREATE PROCEDURE usp_DeleteEmployeesFromDepartment (@departmentId INT)
AS
BEGIN
	DELETE FROM EmployeesProjects
	WHERE EmployeeID IN (
		SELECT  EmployeeID
		FROM Employees
		WHERE DepartmentID = @departmentId
		)

	ALTER TABLE Departments
	ALTER COLUMN ManagerID INT

	UPDATE Employees
	SET ManagerID = NULL
	WHERE ManagerID IN (SELECT EmployeeID FROM Employees WHERE DepartmentID = @departmentId)

	UPDATE Departments
	SET ManagerID = NULL
	WHERE ManagerID IN (SELECT EmployeeID FROM Employees WHERE DepartmentID = @departmentId)

	DELETE FROM Employees WHERE DepartmentID = @departmentId
	DELETE FROM Departments WHERE DepartmentID = @departmentId

	SELECT COUNT(*) 
	FROM Employees
	WHERE DepartmentID = @departmentId
END

EXEC usp_DeleteEmployeesFromDepartment 3

RESTORE DATABASE SoftUni FROM DISK = 'E:\SOFTUNI ARCHIVE\SoftUni.bak'


-- 09. Find Full Name --
CREATE PROCEDURE usp_GetHoldersFullName
AS
BEGIN
	SELECT CONCAT(FirstName, ' ', LastName) AS [Full Name]
	  FROM AccountHolders
END

EXEC usp_GetHoldersFullName
Go

-- 10. People with Balance Higher Than --

CREATE PROCEDURE usp_GetHoldersWithBalanceHigherThan(@amountTreshold DECIMAL(15, 4))
AS
BEGIN
SELECT ah.FirstName AS [First Name], ah.LastName AS [Last Name] FROM 
AccountHolders AS ah
JOIN Accounts AS a ON a.AccountHolderId = ah.Id
GROUP BY ah.FirstName, ah.LastName
HAVING SUM(a.Balance) > @amountTreshold
ORDER BY ah.FirstName, ah.LastName
END

EXEC usp_GetHoldersWithBalanceHigherThan 30000
GO

-- 11. Future Value Function --
CREATE FUNCTION ufn_CalculateFutureValue(@sum DECIMAL(15, 2), @yearlyInterestRate FLOAT, @numberOfYears INT)
RETURNS DECIMAL(15, 4)
AS
BEGIN
	 DECLARE @totalAmount DECIMAL(15, 4)
		 SET @totalAmount = @sum * POWER((1 + @yearlyInterestRate), @numberOfYears)
	  RETURN @totalAmount
END

SELECT dbo.ufn_CalculateFutureValue (1000, 0.1, 5)
GO

-- 12. Calculating Interest --
CREATE PROCEDURE usp_CalculateFutureValueForAccount (@acID INT, @interestRate FLOAT)
AS
BEGIN
	SELECT a.Id, ac.FirstName AS [First Name], ac.LastName AS [Last Name], a.Balance AS [Current Balance],
	dbo.ufn_CalculateFutureValue(a.Balance, @interestRate, 5) AS [Balance in 5 years]
	  FROM Accounts AS a
	  JOIN AccountHolders AS ac ON ac.Id = a.Id
	  WHERE a.Id = @acID
END

EXEC dbo.usp_CalculateFutureValueForAccount 1, 0.1
GO

-- 13. *Cash in User Games Odd Rows --

CREATE FUNCTION ufn_CashInUsersGames(@gameName VARCHAR(50))
RETURNS TABLE
AS
RETURN (
		SELECT SUM(e.Cash) AS SumCash FROM (
		SELECT g.Id, ug.Cash, ROW_NUMBER() OVER(ORDER BY Cash DESC) AS RowNumber
		FROM Games AS g
		JOIN UsersGames AS ug ON ug.GameId = g.Id
		WHERE g.Name = @gameName) AS e
		WHERE e.RowNumber % 2 = 1
)
SELECT * FROM [dbo].ufn_CashInUsersGames('Love in a mist')
GO

-- 14. Create Table Logs --

CREATE TABLE Logs(
LogId INT PRIMARY KEY IDENTITY NOT NULL,
AccountId INT NOT NULL,
OldSum DECIMAL(15, 4) NOT NULL,
NewSum DECIMAL(15, 4) NOT NULL
)
GO

CREATE TRIGGER tr_AccountsUpdate
ON Accounts
AFTER UPDATE
AS
BEGIN
	   DECLARE @accountId INT = (
								SELECT Id 
								FROM inserted)
	   DECLARE @oldSum DECIMAL(15,4) = (
								SELECT Balance FROM deleted)
	   
	   DECLARE @newSum DECIMAL(15,4) = ( 
								SELECT Balance FROM inserted)
	   INSERT INTO Logs VALUES
						(@accountId
						,@oldSum
						,@newSum)
END

UPDATE Accounts 
SET BALANCE = 100 WHERE Id = 18


SELECT * 
FROM Logs
GO

-- 15. Create Table Emails --
CREATE TABLE NotificationEmails(
Id INT PRIMARY KEY IDENTITY NOT NULL,
Recepient INT NOT NULL,
[Subject] VARCHAR(128) NOT NULL,
[Body] VARCHAR(256) NOT NULL
)
GO

CREATE TRIGGER tr_LogsUpdate
ON Logs
AFTER INSERT
AS
BEGIN
		DECLARE @recepient INT = (SELECT 
									AccountId FROM inserted)

		DECLARE @subject VARCHAR(128) = ('Balance change for account: ' + CAST(@recepient AS VARCHAR))

		DECLARE @currentDate DATETIME =  GETDATE()
		DECLARE @oldBalance DECIMAL(15,4) = (SELECT OldSum FROM deleted)
		DECLARE @newBalance DECIMAL(15,4) = (SELECT NewSum FROM inserted)
		
		DECLARE @body VARCHAR(256) = CONCAT('On ', @currentDate,  
		' your balance was changed from ', @oldBalance,  ' to ', @newBalance, '.')

		INSERT INTO NotificationEmails VALUES
		(@recepient, @subject, @body)
END

SELECT * FROM NotificationEmails
GO

-- 16. Deposit Money --
CREATE PROCEDURE usp_DepositMoney (@AccountId INT, @MoneyAmount DECIMAL(15, 4))
AS
BEGIN
	BEGIN TRANSACTION
	--IF(@MoneyAmount <= 0) --THAT VALIDATION DOES NOT PASS IN JUDGE DESPITE EXERCISE DESCRIPTION
	--BEGIN
	--	ROLLBACK
	--	RAISERROR ('Amount should be positive number', 16, 1)
	--	RETURN
	--END
	
	UPDATE Accounts
	SET Balance += @MoneyAmount
	WHERE Id = @AccountId

	COMMIT						
END
GO

 -- 17. Withdraw Money Procedure --

CREATE PROCEDURE usp_WithdrawMoney  (@AccountId INT, @MoneyAmount DECIMAL(15, 4))
AS
BEGIN
	BEGIN TRANSACTION

	--IF(@MoneyAmount <= 0) --THAT VALIDATION DOES NOT PASS IN JUDGE DESPITE EXERCISE DESCRIPTION
	--BEGIN
	--	ROLLBACK
	--	RAISERROR ('Amount should be positive number', 16, 1)
	--	RETURN
	--END
	
	UPDATE Accounts
	SET Balance -= @MoneyAmount
	WHERE Id = @AccountId

	COMMIT						
END
GO

-- 18. Money Transfer --
CREATE  PROCEDURE usp_TransferMoney (@senderId INT, @receiverId INT, @amount DECIMAL(15,4))
AS
BEGIN
	
	EXEC usp_WithdrawMoney @senderId, @amount
	EXEC usp_DepositMoney @receiverId, @amount
	
END

EXEC usp_TransferMoney 5, 11, 25
GO
 -- 20. *Massive Shopping --
 
DECLARE @gameName NVARCHAR(50) = 'Safflower'
DECLARE @username NVARCHAR(50) = 'Stamat'

DECLARE @userGameId INT = (
  SELECT ug.Id
  FROM UsersGames AS ug
    JOIN Users AS u
      ON ug.UserId = u.Id
    JOIN Games AS g
      ON ug.GameId = g.Id
  WHERE u.Username = @username AND g.Name = @gameName)

DECLARE @userGameLevel INT = (SELECT [Level]
                              FROM UsersGames
                              WHERE Id = @userGameId)

DECLARE @itemsCost MONEY, @availableCash MONEY, @minLevel INT, @maxLevel INT

SET @minLevel = 11
SET @maxLevel = 12
SET @availableCash = (SELECT Cash
                      FROM UsersGames
                      WHERE Id = @userGameId)

SET @itemsCost = (SELECT SUM(Price)
                  FROM Items
                  WHERE MinLevel BETWEEN @minLevel AND @maxLevel)

IF (@availableCash >= @itemsCost AND @userGameLevel >= @maxLevel)

  BEGIN
    BEGIN TRANSACTION
    UPDATE UsersGames
    SET Cash -= @itemsCost
    WHERE Id = @userGameId
    IF (@@ROWCOUNT <> 1)
    BEGIN
        ROLLBACK
        RAISERROR ('Could not make payment', 16, 1)
    END
    ELSE
    BEGIN
        INSERT INTO UserGameItems (ItemId, UserGameId)
          (SELECT
             Id,
             @userGameId
           FROM Items
           WHERE MinLevel BETWEEN @minLevel AND @maxLevel)

        IF ((SELECT COUNT(*)
             FROM Items
             WHERE MinLevel BETWEEN @minLevel AND @maxLevel) <> @@ROWCOUNT)
        BEGIN
            ROLLBACK;
            RAISERROR ('Could not buy items', 16, 1)
        END
        ELSE COMMIT;
	 END
  END

SET @minLevel = 19
SET @maxLevel = 21
SET @availableCash = (SELECT Cash
                      FROM UsersGames
                      WHERE Id = @userGameId)
SET @itemsCost = (SELECT SUM(Price)
                  FROM Items
                  WHERE MinLevel BETWEEN @minLevel AND @maxLevel)

IF (@availableCash >= @itemsCost AND @userGameLevel >= @maxLevel)

  BEGIN
    BEGIN TRANSACTION
    UPDATE UsersGames
    SET Cash -= @itemsCost
    WHERE Id = @userGameId

    IF (@@ROWCOUNT <> 1)
      BEGIN
        ROLLBACK
        RAISERROR ('Could not make payment', 16, 1)
      END
    ELSE
      BEGIN
        INSERT INTO UserGameItems (ItemId, UserGameId)
          (SELECT
             Id,
             @userGameId
           FROM Items
           WHERE MinLevel BETWEEN @minLevel AND @maxLevel)

        IF ((SELECT COUNT(*)
             FROM Items
             WHERE MinLevel BETWEEN @minLevel AND @maxLevel) <> @@ROWCOUNT)
          BEGIN
            ROLLBACK
            RAISERROR ('Could not buy items', 16, 1)
          END
        ELSE COMMIT;
      END
  END

SELECT i.Name AS [Item Name]
FROM UserGameItems AS ugi
  JOIN Items AS i
    ON i.Id = ugi.ItemId
  JOIN UsersGames AS ug
    ON ug.Id = ugi.UserGameId
  JOIN Games AS g
    ON g.Id = ug.GameId
WHERE g.Name = @gameName
ORDER BY [Item Name]

 GO
-- 21. Employees with Three Projects --
CREATE  PROCEDURE usp_AssignProject(@emloyeeId INT, @projectID INT)
AS
BEGIN
	BEGIN TRANSACTION
			DECLARE @projectCount INT = (
								SELECT COUNT(ProjectID) 
								FROM EmployeesProjects
								WHERE EmployeeID = @emloyeeId)
		   IF(@projectCount >= 3)
		   BEGIN
				ROLLBACK
				RAISERROR ('The employee has too many projects!', 16, 1)
				RETURN
		   END

				INSERT INTO EmployeesProjects VALUES
				(@emloyeeId, @projectID)
				--SET ProjectID = @projectID
				--WHERE EmployeeID = @emloyeeId
	COMMIT
END

EXEC usp_AssignProject 263, 1
GO

-- 22. Delete Employees --
CREATE TABLE Deleted_Employees(
ID INT PRIMARY KEY IDENTITY NOT NULL,
FirstName VARCHAR(32) NOT NULL,
LastName VARCHAR(32) NOT NULL,
MiddleName VARCHAR(32),
JobTitle VARCHAR(32) NOT NULL,
DepartmentID INT,
Salary DECIMAL(15,2)
)
GO
DROP TABLE Deleted_Employees
GO
CREATE TRIGGER tr_DeleteEmployees
ON Employees
AFTER DELETE
AS
BEGIN

	INSERT INTO Deleted_Employees
	SELECT FirstName, LastName, MiddleName, JobTitle, DepartmentID, Salary
	FROM deleted
		
END

DELETE FROM EmployeesProjects WHERE EmployeeID = 10
DELETE FROM Employees WHERE EmployeeID = 10
SELECT * FROM Deleted_Employees

