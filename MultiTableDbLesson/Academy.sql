create table People(
[Id] int primary key identity(1, 1),
[Name] nvarchar(30) NOT NULL,
[Surname] nvarchar(30) NOT NULL,
[Age] int NOT NULL check (Age >= 14 and Age < 100)
);


create table Employee(
[Id] int primary key identity(1, 1),
[Salary] smallmoney NOT NULL check ([Salary] >= 300),
[Experience] int NOT NULL check ([Experience] >= 0)
);

create table Faculty(
[Id] int primary key identity(1, 1),
[Name] nvarchar(30) NOT NULL
);

create table Students(
[Id] int primary key identity(1, 1),
[PersonId] int foreign key references People(Id)
);

create table Teachers(
[Id] int primary key identity(1, 1),
[PersonId] int foreign key references People(Id),
[EmployeeId] int foreign key references Employee(Id)
);


create table Groups(
[Id] int primary key identity(1, 1),
[Name] nvarchar(30) NOT NULL,
[Course] int NOT NULL check ([Course] >= 1 and [Course] <= 6),
[FacultyId] int foreign key references Faculty(Id)
);

create table GroupData(
[Id] int primary key identity(1, 1),
[StudentId] int foreign key references Students(Id),
[GroupId] int foreign key references Groups(Id)
);

create table StudyPlan(
[Id] int primary key identity(1, 1),
[TeacherId] int foreign key references Teachers(Id),
[GroupId] int foreign key references Groups(Id)
);



insert into People([Name], [Surname], [Age]) values(N'Elnur', N'Mamedov', 19);
insert into People([Name], [Surname], [Age]) values(N'Kenan', N'Mamedli', 15);

insert into Students(PersonId) values(1);
insert into Students(PersonId) values(2);

select * from People;

select * from Students;

alter table Students
add [GPA] int check ([GPA] >= 0 and GPA <= 12);


update Students
set GPA = 12
where Id = 1

update Students
set GPA = 7
where Id = 2


select P.[Name], P.[Surname], P.Age, Students.GPA 
from Students 
inner join People as P on Students.PersonId = P.Id
where p.Id = 2


select * 
from Students
inner join People on Students.PersonId = People.Id


insert into Students(PersonId) values(3, 8);