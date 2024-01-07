-- Insert data into dbo.Employee
INSERT INTO dbo.Employee (Salary, Experience) VALUES
(500, 2),
(1000, 5),
(800, 3),
(1200, 7),
(600, 1),
(900, 4),
(1100, 6),
(700, 2),
(950, 5),
(850, 3);

-- Insert data into dbo.Faculty
INSERT INTO dbo.Faculty (Name) VALUES
('Science'),
('Arts'),
('Engineering'),
('Business'),
('Medicine'),
('Social Sciences'),
('Law'),
('Computer Science'),
('Education'),
('Fine Arts');

-- Insert data into dbo.Groups
INSERT INTO dbo.Groups (Name, Course, FacultyId) VALUES
('Group1', 1, 1),
('Group2', 2, 2),
('Group3', 3, 3),
('Group4', 4, 4),
('Group5', 5, 5),
('Group6', 6, 6),
('Group7', 1, 7),
('Group8', 2, 8),
('Group9', 3, 9),
('Group10', 4, 10);

-- Insert data into dbo.People
INSERT INTO dbo.People (Name, Surname, Age) VALUES
('John', 'Doe', 25),
('Alice', 'Smith', 30),
('Bob', 'Johnson', 22),
('Emily', 'Williams', 28),
('Michael', 'Brown', 35),
('Sophia', 'Jones', 21),
('David', 'Miller', 32),
('Emma', 'Davis', 24),
('Daniel', 'Wilson', 29),
('Olivia', 'Moore', 27);

-- Insert data into dbo.Students
INSERT INTO dbo.Students (PersonId, GPA) VALUES
(1, 3),
(2, 4),
(3, 2),
(4, 3),
(5, 3),
(6, 4),
(7, 2),
(8, 3),
(9, 4),
(10, 3);

-- Insert data into dbo.GroupData
INSERT INTO dbo.GroupData (StudentId, GroupId) VALUES
(1, 1),
(2, 2),
(3, 3),
(4, 4),
(5, 5),
(6, 6),
(7, 7),
(8, 8),
(9, 9),
(10, 10);

-- Insert data into dbo.Teachers
INSERT INTO dbo.Teachers (PersonId, EmployeeId) VALUES
(1, 1),
(2, 2),
(3, 3),
(4, 4),
(5, 5),
(6, 6),
(7, 7),
(8, 8),
(9, 9),
(10, 10);

-- Insert data into dbo.StudyPlan
INSERT INTO dbo.StudyPlan (TeacherId, GroupId) VALUES
(1, 1),
(2, 2),
(3, 3),
(4, 4),
(5, 5),
(6, 6),
(7, 7),
(8, 8),
(9, 9),
(10, 10);


select * from Teachers
union all
select * from StudyPlan



