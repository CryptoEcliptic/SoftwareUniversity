
CREATE TABLE Students(
Id INT PRIMARY KEY IDENTITY,
FirstName NVARCHAR(30) NOT NULL,
MiddleName NVARCHAR(25),
LastName NVARCHAR(30) NOT NULL,
Age INT CHECK (Age BETWEEN 5 AND 100),
[Address] NVARCHAR(50),
Phone NCHAR(10)
)

CREATE TABLE Subjects(
Id INT PRIMARY KEY IDENTITY,
[Name] NVARCHAR(20) NOT NULL,
Lessons INT NOT NULL CHECK(Lessons > 0) 
)

CREATE TABLE StudentsSubjects(
Id INT PRIMARY KEY IDENTITY,
StudentId INT FOREIGN KEY REFERENCES Students(Id) NOT NULL,
SubjectId INT FOREIGN KEY REFERENCES Subjects(Id) NOT NULL,
Grade DECIMAL(15,2) NOT NULL, CHECK(Grade BETWEEN 2 AND 6)
)

CREATE TABLE Exams(
Id INT PRIMARY KEY IDENTITY,
[Date] DATETIME,
SubjectId INT FOREIGN KEY REFERENCES Subjects(Id) NOT NULL,
)

CREATE TABLE StudentsExams(
StudentId INT FOREIGN KEY REFERENCES Students(Id) NOT NULL,
ExamId INT FOREIGN KEY REFERENCES Exams(Id) NOT NULL,
Grade DECIMAL(15,2) NOT NULL, CHECK(Grade BETWEEN 2 AND 6),

PRIMARY KEY(StudentId, ExamId)
)

CREATE TABLE Teachers(
Id INT PRIMARY KEY IDENTITY,
FirstName NVARCHAR(20) NOT NULL,
LastName NVARCHAR(20) NOT NULL,
[Address] NVARCHAR(20) NOT NULL,
Phone NCHAR(10),
SubjectId INT FOREIGN KEY REFERENCES Subjects(Id) NOT NULL
)

CREATE TABLE StudentsTeachers(
StudentId INT FOREIGN KEY REFERENCES Students(Id) NOT NULL,
TeacherId INT FOREIGN KEY REFERENCES Teachers(Id) NOT NULL,
PRIMARY KEY(StudentId, TeacherId)
)



----- 02 INSERT ----
INSERT INTO Teachers VALUES
('Ruthanne',	'Bamb',	'84948 Mesta Junction',	'3105500146',	6),
('Gerrard',	'Lowin',	'370 Talisman Plaza',	'3324874824',	2),
('Merrile',	'Lambdin',	'81 Dahle Plaza',	'4373065154',	5),
('Bert',	'Ivie',	'2 Gateway Circle',	'4409584510',	4)

INSERT INTO Subjects VALUES
('Geometry',	12),
('Health',	10),
('Drama',	7),
('Sports',	9)


----- 03 UPDATE ------

UPDATE StudentsSubjects
   SET Grade = 6.00
 WHERE Grade >= 5.50 AND SubjectId IN(1, 2)


---- 04 Delete ----
 DELETE 
   FROM StudentsTeachers
  WHERE TeacherId IN (SELECT Id FROM Teachers WHERE Phone LIKE '%72%')

 DELETE 
   FROM Teachers
  WHERE Phone LIKE '%72%'


------ 05 Teen Students ---
	SELECT FirstName, LastName, Age
	  FROM Students
     WHERE Age >= 12
  ORDER BY FirstName, LastName

-----  06 Cool Addresses ----
	SELECT
		CASE
			 WHEN MiddleName IS NULL THEN FirstName + '  ' + LastName
			 WHEN MiddleName IS NOT NULL THEN FirstName + ' ' + MiddleName + ' ' + LastName
		 END AS [Full Name]
		,[Address]
	 FROM Students
    WHERE [Address] LIKE '%road%'
 ORDER BY FirstName, LastName, [Address]

---- 07 42 Phones -----
	SELECT 
		  FirstName, 
		  [Address], 
		  Phone
	 FROM Students
    WHERE MiddleName IS NOT NULL AND Phone LIKE '42%'
 ORDER BY FirstName


----- 08 Students Teachers ------
	SELECT
		 FirstName,
		 LastName, 
		 COUNT(st.TeacherId) AS TeachersCount
	 FROM Students AS s
	          JOIN StudentsTeachers AS st ON st.StudentId = s.Id
 GROUP BY FirstName, LastName

----- 09 Subjects with Students ----- ----TODO CHESK

		SELECT
			FirstName + ' ' +  LastName AS [Full Name], 
			CONCAT(s.Name,  '-' , s.Lessons) AS Subjects,
			COUNT(st.StudentId) AS Students
		FROM Teachers AS t
		JOIN Subjects AS s ON s.Id = t.SubjectId
		JOIN StudentsTeachers AS st ON st.TeacherId = t.Id
		GROUP BY t.FirstName, t.LastName, s.Name, s.Lessons
		ORDER BY COUNT(st.StudentId) DESC, [Full Name] ASC, Subjects ASC


----- 101Students to Go -----

	SELECT 
		  FirstName + ' ' + LastName AS FullName
      FROM Students AS s
			LEFT JOIN StudentsExams AS se ON se.StudentId = s.Id
	 WHERE se.StudentId IS NULL
  ORDER BY FullName


--- 11. Busiest Teachers -----
SELECT TOP 10 
			FirstName, 
			LastName, 
			COUNT(st.StudentId) AS StudentsCount
      FROM Teachers AS t
				JOIN StudentsTeachers AS st ON st.TeacherId = t.Id
  GROUP BY FirstName, LastName
  ORDER BY StudentsCount DESC, FirstName, LastName


----- 12 Top Students ----
SELECT TOP 10
			FirstName,
			LastName,
			FORMAT(AVG(st.Grade), 'N2') AS Grade
	  FROM Students AS s
					JOIN StudentsExams AS st ON st.StudentId = s.Id
  GROUP BY FirstName, LastName
  ORDER BY AVG(st.Grade) DESC, FirstName, LastName


---- 13. Second Highest Grade -----
 SELECT DISTINCT FirstName, LastName, Grade FROM (
		SELECT 
				FirstName, 
				LastName,
				SS.Grade,
				ROW_NUMBER() OVER (PARTITION BY ss.StudentId ORDER BY ss.Grade DESC) AS Ranks  
		  FROM Students AS s
					JOIN StudentsSubjects AS ss ON ss.StudentId = s.Id
		  ) AS h
   WHERE Ranks = 2
ORDER BY FirstName, LastName

---- 14 Not So In The Studying -----

	SELECT
			CASE
				WHEN MiddleName IS NULL THEN FirstName + ' ' + LastName
				ELSE FirstName + ' ' + MiddleName + ' ' + LastName 
			 END AS FullName
	  FROM Students AS s
					LEFT JOIN StudentsSubjects AS ss ON ss.StudentId = s.Id
	 WHERE ss.StudentId IS NULL
  ORDER BY FullName

---- 15 Top Student per Teacher ----

SELECT
		[Teacher FULL Name], [Subject Name], [Student FULL Name], CAST(Grade AS NUMERIC(10, 2)) AS Grade
		FROM(
    SELECT
    CONCAT(t.FirstName, ' ', t.LastName) AS [Teacher FULL Name],
    sb.[Name] AS [Subject Name],
    CONCAT(s.FirstName, ' ', s.LastName) AS [Student FULL Name],
    AVG(ss.Grade) AS Grade,
    ROW_NUMBER() OVER (PARTITION BY t.FirstName, t.LastName ORDER BY AVG(ss.Grade) DESC) AS [Rank]
    FROM Students AS s
				JOIN StudentsSubjects AS ss ON ss.StudentId = s.Id
				JOIN StudentsTeachers AS st ON st.StudentId = s.Id
				JOIN Teachers AS t ON t.Id = st.TeacherId
				JOIN Subjects AS sb ON sb.Id = t.SubjectId
    WHERE t.SubjectId = ss.SubjectId
    GROUP BY s.Id, s.FirstName, s.LastName, t.FirstName, t.LastName, sb.[Name]
    ) AS t
    WHERE [Rank] = 1
ORDER BY [Subject Name], [Teacher FULL Name], Grade DESC



--SELECT [Teacher Full Name], [Subject Name], [Student Full Name], FORMAT(Grade, 'N2') AS Grade FROM (
--	SELECT 
--			t.FirstName + ' ' + t.LastName AS [Teacher Full Name],
--			s.Name AS [Subject Name],
--			stu.FirstName + ' ' + stu.LastName AS [Student Full Name],
--			AVG(ss.Grade) AS Grade,
--			DENSE_RANK() OVER (PARTITION BY stu.Id ORDER BY AVG(ss.Grade) DESC) AS Ranks  
--	FROM Teachers AS t
--	JOIN Subjects AS s ON s.Id = t.SubjectId
--	JOIN StudentsSubjects AS ss ON ss.SubjectId = s.Id
--	JOIN Students AS stu ON stu.Id = ss.StudentId
--	JOIN StudentsTeachers AS st ON st.TeacherId = t.Id
--	GROUP BY t.Id, t.FirstName, t.LastName, s.Name, stu.FirstName, stu.LastName, stu.Id
--	) AS h
--	WHERE Ranks = 1
--ORDER BY [Subject Name] , [Teacher Full Name], Grade DESC



	----- 16. Average Grade per Subject ----
	SELECT 
			s.Name,
			AVG(ss.Grade) AS AverageGrade
	FROM Subjects AS s
	JOIN StudentsSubjects AS ss ON ss.SubjectId = s.Id
	GROUP BY s.Name, s.Id
	ORDER BY s.Id

	----- 17 ----
		
	SELECT [Quarter], SubjectName, SUM(StudentsCount) AS StudentsCount FROM(
		SELECT
			CASE
				WHEN DATEPART(QUARTER, Date) = 1 THEN 'Q1'
				WHEN DATEPART(QUARTER, Date) = 2 THEN 'Q2'
				WHEN DATEPART(QUARTER, Date) = 3 THEN 'Q3'
				WHEN DATEPART(QUARTER, Date) = 4 THEN 'Q4'
				ELSE 'TBA'
		END AS [Quarter],
		s.[Name] AS SubjectName,
		COUNT(se.StudentId) AS StudentsCount
		FROM Exams AS e
			JOIN Subjects AS s ON s.Id = e.SubjectId
			JOIN StudentsExams AS se ON se.ExamId = e.Id
			WHERE Grade >= 4.00
			GROUP BY Date, s.Name
			) AS h
			GROUP BY [Quarter], SubjectName
		ORDER BY [Quarter] ASC, SubjectName ASC


		GO
------ 18. Exam Grades-----------
 CREATE FUNCTION udf_ExamGradesToUpdate(@studentId INT, @grade DECIMAL(15, 2))
 RETURNS VARCHAR(256)
 AS
 BEGIN
		
		DECLARE @result VARCHAR(256),
				@countOfGrades INT,
				@studentName VARCHAR(30)

		IF(@studentId NOT IN (SELECT Id FROM Students))
		BEGIN
			RETURN 'The student with provided id does not exist in the school!'
		END

		ELSE IF(@grade > 6.00)
		BEGIN
			RETURN 'Grade cannot be above 6.00!'
		END

			SET @countOfGrades = (SELECT COUNT(Grade) 
										FROM StudentsExams
										WHERE StudentId = @studentId AND Grade BETWEEN @grade AND @grade + 0.50)

			SET @studentName = (Select TOP 1 FirstName from Students WHERE Id = @studentId)

			SET @result = CONCAT('You have to update ' , @countOfGrades ,' grades for the student ',  @studentName)
			
	
		RETURN @result
 END
 Go

 SELECT dbo.udf_ExamGradesToUpdate(12, 6.20)

 SELECT dbo.udf_ExamGradesToUpdate(121, 5.50)

 SELECT dbo.udf_ExamGradesToUpdate(12, 5.50)


 GO
 ----- 19- -----
 CREATE PROC usp_ExcludeFromSchool(@StudentId INT)
 AS
 BEGIN
		BEGIN TRANSACTION
			IF(@StudentId NOT IN (SELECT Id FROM Students))
		BEGIN
			ROLLBACK
			RAISERROR ('This school has no student with the provided id!', 16, 1)
			RETURN
		END

		DELETE FROM StudentsTeachers
		WHERE StudentId = @StudentId

		DELETE FROM StudentsSubjects
		WHERE StudentId = @StudentId

		DELETE FROM StudentsExams
		WHERE StudentId = @StudentId

		DELETE FROM Students
		WHERE Id = @StudentId

		COMMIT
 END

 EXEC usp_ExcludeFromSchool 1
SELECT COUNT(*) FROM Students



------ 20 Deleted Students ----
CREATE TABLE ExcludedStudents(
Id INT PRIMARY KEY IDENTITY,
StudentId INT,
StudentName NVARCHAR(128)
)

CREATE TRIGGER tr_DeletedStudents
ON Students
AFTER DELETE
AS
BEGIN
	
	INSERT INTO ExcludedStudents (StudentId, StudentName)
		 SELECT d.Id, d.FirstName + ' ' + d.LastName
	FROM deleted AS d

END

DELETE FROM StudentsExams
WHERE StudentId = 1

DELETE FROM StudentsTeachers
WHERE StudentId = 1

DELETE FROM StudentsSubjects
WHERE StudentId = 1

DELETE FROM Students
WHERE Id = 1


SELECT * FROM ExcludedStudents



