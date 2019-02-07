CREATE DATABASE Bank

CREATE TABLE Clients(
Id INT PRIMARY KEY IDENTITY,
FirstName NVARCHAR(50) NOT NULL,
LastName NVARCHAR(50) NOT NULL
)

CREATE TABLE AccountTypes(
Id INT PRIMARY KEY IDENTITY,
[Name] NVARCHAR(50) NOT NULL
)

CREATE TABLE Accounts(
Id INT PRIMARY KEY IDENTITY,
AccountTypeId INT FOREIGN KEY REFERENCES AccountTypes(Id),
Balance DECIMAL(15, 2) NOT NULL DEFAULT(0),
ClientId INT FOREIGN KEY REFERENCES Clients(Id)
)

INSERT INTO Clients(FirstName, LastName) VALUES
('Petko', 'Petkov'),
('Mara', 'Popara'),
('Boro', 'Boro'),
('Merry', 'Christmass')

INSERT INTO AccountTypes(Name) VALUES
('Checkings'),
('Savings')

INSERT INTO Accounts(AccountTypeId, Balance, ClientId) VALUES
(1, 500.55, 4),
(2, 1000.00, 2),
(2, 1000.00, 1)


GO
CREATE FUNCTION f_CalculateTotalBalance(@ClientId INT)
RETURNS DECIMAL(15,2)
BEGIN
DECLARE @result AS DECIMAL(15,2) = (SELECT SUM(Balance) FROM Accounts WHERE ClientId = @ClientId)
RETURN @result
END

GO
SELECT dbo.f_CalculateTotalBalance(2)
 
GO
CREATE PROC p_AddAccount @ClientId INT, @AccountTypeId INT AS
INSERT INTO Accounts (ClientId, AccountTypeId) 
VALUES (@ClientId, @AccountTypeId)

GO
p_AddAccount 4, 1


GO
SELECT * FROM Accounts


GO
CREATE PROC p_Deposit @AccountID INT, @Amount DECIMAL(15,2)
AS UPDATE Accounts
SET Balance += @Amount
WHERE Id = @AccountID

GO
p_Deposit 3, 10000

GO
CREATE PROC p_Withdrawl @AccountId INT, @Amount DECIMAL(15,2) AS
BEGIN
DECLARE @OldBalance DECIMAL(15,2)
SELECT OldBalance = Balance FROM Accounts WHERE Id = @AccountId
IF(@OldBalance - @Amount >=0)
BEGIN
UPDATE Accounts
SET Balance -= @Amount WHERE Id = @AccountId
END
ELSE
	BEGIN
		RAISERROR('Insufficient funds', 10, 1)
	END
END

GO
CREATE TABLE Transactions(
Id INT PRIMARY KEY IDENTITY,
AccountId INT FOREIGN KEY REFERENCES Accounts(Id),
OldBalance DECIMAL(15,2) NOT NULL,
NewBalance DECIMAL(15, 2) NOT NULL,
Amount AS NewBalance - OldBalance,
[DateTime] DATETIME2
)
GO
CREATE TRIGGER tr_Transaction ON Accounts
AFTER UPDATE
AS
INSERT INTO Transactions(AccountId, OldBalance, NewBalance, [DateTime])
SELECT inserted.Id, deleted.Balance, inserted.Balance, GETDATE() FROM inserted
	JOIN deleted ON inserted.Id = deleted.Id

GO
p_Deposit 1, 25.00
GO

p_Deposit 1, 40.00
GO

p_Withdrawl 2, 200.00
GO

p_Deposit 4, 180.00
GO

SELECT * FROM Transactions