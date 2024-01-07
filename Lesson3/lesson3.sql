-- use Academy_3_8;
--
-- select *
-- from Students
-- where Age > 20;

-- insert into Students(Name, Email, Age) values(N'Rufat',  N'rufat123@gmail.com', 16);

select * from Students;

update Students
set Age = 18
where Email = N'profbat018@gmail.com';


alter table Students
drop column Age;

alter table Students
alter column Email nvarchar(60);



alter table Students
add Address nvarchar(100);

select * from Students;

alter table Students
drop column Address;

select * from Students
order by Age;

select COUNT(*) as StudentCount from Students;

select MAX(Age) as MaxAge from Students;

select MIN(Age) as MinAge from Students;

select AVG(Age) as AvgAge from Students;

select SUM(Age) as SumAge from Students;



alter table Students
drop constraint CK__Students__Age__3B75D760;

alter table Students
alter column Age float
