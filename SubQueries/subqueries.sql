use Academy;

insert into People(Name, Surname, Age) values('John', 'Ivanov', 20);

select distinct p.Name, (select count(*) from People where p.Name = Name) as 'Count'
from People as p

select *
from Students
where Students.PersonId in (select Id from People where Name = 'John')

-- table subquery
select People.Name from (select * from People) as People


insert into Students(PersonId, CourseId) values((select Id from People
                                                           where GPA = 3), 1);

