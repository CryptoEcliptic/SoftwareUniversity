---  01. Employee Address
SELECT TOP (5) e.EmployeeID, e.JobTitle, a.AddressID, A.AddressText 
FROM Employees AS e
	JOIN Addresses AS a
	ON a.AddressID = e.AddressID
	ORDER BY a.AddressID

	-----  02. Addresses with Towns
	SELECT TOP(50)	e.FirstName, E.LastName, t.[Name] AS Town, a.AddressText
	FROM	Employees AS e
	JOIN	Addresses AS a ON a.AddressID = e.AddressID
	JOIN	Towns AS t ON t.TownID = a.TownID
	ORDER BY FirstName, LastName


	---- 03. Sales Employees
SELECT EmployeeID, FirstName, LastName, d.[Name] AS DepartmentName
 FROM   Employees AS e
 JOIN Departments AS d ON d.DepartmentID = e.DepartmentID
 WHERE d.[Name] IN ('Sales')
 ORDER BY EmployeeID


 ----- 04. Employee Departments
  SELECT TOP(5) EmployeeID, FirstName, Salary, d.[Name] AS DepartmentName
 FROM	Employees AS e
 JOIN	Departments AS d ON d.DepartmentID = e.DepartmentID
 WHERE	e.Salary > 15000
 ORDER BY d.DepartmentID

 ----- 05. Employees Without Projects 
  WITH Employees_CTE (EmployeeID,FirstName)
 AS
 (
 SELECT TOP(3) e.EmployeeID, e.FirstName
 FROM Employees AS e
 LEFT JOIN EmployeesProjects AS ep ON ep.EmployeeID = e.EmployeeID
 WHERE ep.EmployeeID IS NULL
 ORDER BY e.EmployeeID
 )
 SELECT * FROM Employees_CTE


 ---- 06. Employees Hired After 
   SELECT e.FirstName, e.LastName, e.HireDate, d.[Name] AS DeptName
	FROM Employees e
	JOIN Departments AS d ON d.DepartmentID = e.DepartmentID
   WHERE (e.HireDate > '1999.01.01' AND d.[Name] IN ('Sales', 'Finance'))
ORDER BY e.HireDate



-- 07. Employees With Project --
	SELECT TOP(5) e.EmployeeID, e.FirstName, p.[Name] AS 'ProjectName'
	  FROM Employees AS e
	  JOIN EmployeesProjects AS ep ON ep.EmployeeID = e.EmployeeID
	  JOIN Projects AS p ON p.ProjectID = ep.ProjectID
	 WHERE (p.StartDate > '2002.08.13' AND p.EndDate IS NULL)
  ORDER BY e.EmployeeID


  ---- 08. Employee 24 
  	SELECT e.EmployeeID, e.FirstName, p.[Name] AS ProjectName
	  FROM Employees AS e
	  LEFT JOIN EmployeesProjects AS ep ON ep.EmployeeID = e.EmployeeID
	  LEFT JOIN Projects AS p ON p.ProjectID = ep.ProjectID AND p.StartDate < '2005.01.01'
	 WHERE (e.EmployeeID = 24)


	----09. Employee Manager 
	SELECT e.EmployeeID, e.FirstName, e.ManagerID, manager.FirstName AS ManagerName
	  FROM Employees AS e
	  JOIN Employees AS manager ON manager.EmployeeID = e.ManagerID
	 WHERE (manager.EmployeeID = 7 OR manager.EmployeeID = 3)
  ORDER BY e.EmployeeID


  ---- 10. Employees Summary 
   SELECT TOP(50) e.EmployeeID, e.FirstName + ' ' + e.LastName AS EmployeeName, 
 m.FirstName + ' ' + m.LastName AS ManagerName, d.[Name] AS DepartmentName
   FROM Employees AS e
   JOIN Employees AS m ON m.EmployeeID = e.ManagerID
   JOIN Departments AS d ON d.DepartmentID = e.DepartmentID
   ORDER BY e.EmployeeID


   ----- 11. Min Average Salary 
   	SELECT MIN(e.AverSalary) AS MinAverageSalary FROM(
	SELECT AVG(Salary) AS AverSalary
	  FROM Employees GROUP BY DepartmentID) 
		AS e

	--- 12. Highest Peaks in Bulgaria
	  SELECT c.CountryCode, m.MountainRange, p.PeakName, p.Elevation
		FROM Countries AS c
		JOIN MountainsCountries AS mc ON mc.CountryCode = c.CountryCode
		JOIN Mountains AS m ON m.Id = mc.MountainId
		JOIN Peaks AS p ON p.MountainId = m.Id
		WHERE (c.CountryCode = 'BG' AND p.Elevation > 2835)
		ORDER BY p.Elevation DESC

	---- 13. Count Mountain Ranges 
	SELECT c.CountryCode, COUNT(m.MountainRange) AS MountainRanges
FROM Countries AS c
JOIN MountainsCountries AS mc ON mc.CountryCode = c.CountryCode
JOIN Mountains AS m ON m.Id = mc.MountainId
WHERE (c.CountryCode = 'BG' OR c.CountryCode = 'RU' OR c.CountryCode = 'US')
GROUP BY c.CountryCode


---- 14. Countries With or Without Rivers 
SELECT TOP (5) CountryName, r.RiverName
FROM Countries AS c
LEFT JOIN CountriesRivers AS cr ON cr.CountryCode = c.CountryCode
LEFT JOIN Rivers AS r ON r.Id = cr.RiverId
WHERE c.ContinentCode = 'AF'
ORDER BY c.CountryName


---- 15. Continents and Currencies (not included in final score)
	WITH CTE_ContinentsAndCurrencies(ContinentCode, CurrencyCode, CurrencyUsage) AS (
  SELECT ContinentCode, CurrencyCode, COUNT(CurrencyCode) AS CurrencyUsage
	FROM Countries
GROUP BY ContinentCode, CurrencyCode
  HAVING COUNT(CurrencyCode) > 1
  )

 SELECT e.ContinentCode, cci.CurrencyCode, e.MaxCurrency AS CurrencyUsage FROM (
  SELECT ContinentCode, MAX(CurrencyUsage) AS MaxCurrency 
   FROM  CTE_ContinentsAndCurrencies
   GROUP BY ContinentCode) AS e
   JOIN CTE_ContinentsAndCurrencies AS cci ON cci.ContinentCode = e.ContinentCode 
   AND cci.CurrencyUsage = e.MaxCurrency


   ---- 16. Countries Without any Mountains 
   	SELECT COUNT(*) AS CountryCode
	FROM Countries AS c
	LEFT JOIN MountainsCountries AS mc ON mc.CountryCode = c.CountryCode
	WHERE mc.CountryCode IS NULL

---- 17. Highest Peak and Longest River by Country 
WITH HighestPeaksAndRivers_CTE (CountryName, HighestPeakElevation, LongestRiverLength)
AS
(
SELECT c.CountryName, MAX(p.Elevation) AS HighestPeakElevation, MAX(r.Length) AS LongestRiverLength
FROM Countries AS c
LEFT JOIN MountainsCountries AS mc ON mc.CountryCode = c.CountryCode
LEFT JOIN Mountains AS m ON m.Id = mc.MountainId
LEFT JOIN Peaks AS p ON p.MountainId = m.Id
LEFT JOIN CountriesRivers AS cr ON cr.CountryCode = c.CountryCode
LEFT JOIN Rivers AS r ON r.Id = cr.RiverId
GROUP BY c.CountryName
)
SELECT TOP (5) * 
FROM HighestPeaksAndRivers_CTE
ORDER BY HighestPeakElevation DESC, LongestRiverLength DESC


---- 18. Highest Peak Name and Elevation by Country (not included in final score)
WITH CTE_CountriesHighestElevation AS
(
	SELECT c.CountryName,
		CASE 
			WHEN MAX(p.Elevation) IS NULL THEN 0
			ELSE MAX(p.Elevation)
		END 
		AS [Highest Peak Elevation] FROM Countries AS c
	LEFT JOIN MountainsCountries AS mc
	ON mc.CountryCode = c.CountryCode
	LEFT JOIN Peaks As p
	ON p.MountainId = mc.MountainId
	GROUP BY c.CountryName
),

CTE_MountainHighestElevation AS
(
	SELECT m.Id, MAX(p.Elevation) AS mhe FROM Mountains AS m
	JOIN Peaks AS p
	ON p.MountainId = m.Id
	GROUP BY m.Id
)

SELECT TOP 5
	he.CountryName AS Country,
	CASE
		WHEN p.PeakName IS NULL THEN '(no highest peak)'
		ELSE p.PeakName
	END AS [Highest Peak Name],

	he.[Highest Peak Elevation],
	CASE
		WHEN m.MountainRange IS NULL THEN '(no mountain)'
		ELSE m.MountainRange
	END AS Mountain

FROM CTE_CountriesHighestElevation As he
JOIN Countries AS c
ON c.CountryName = he.CountryName
LEFT JOIN MountainsCountries AS mc
ON mc.CountryCode = c.CountryCode
LEFT JOIN CTE_MountainHighestElevation AS mh
ON mh.Id = mc.MountainId AND mh.mhe = [Highest Peak Elevation]
LEFT JOIN Peaks AS p
ON p.Elevation = mh.mhe
LEFT JOIN Mountains AS m
ON mc.MountainId = m.Id
WHERE he.[Highest Peak Elevation] = p.Elevation OR he.[Highest Peak Elevation] = 0
ORDER BY he.CountryName

