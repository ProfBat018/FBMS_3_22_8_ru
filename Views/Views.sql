use Academy;

create view FirstView
as
    select P.Name, S.GPA  from Students as S
    inner join dbo.People P on P.Id = S.PersonId
    where P.Age > 17


select * from FirstView

update Students
set GPA = 4
where Id =
      (select PersonId
            from Students as S
            inner join dbo.People P on P.Id = S.PersonId
            where P.Name = 'John')

select * from Students
inner join dbo.People P on P.Id = Students.PersonId
where P.Name = 'John'


select * from FirstView;


create table #TempStudents
(
    Id int primary key identity(1,1),
    Name nvarchar(50),
    GPA decimal(3,2)
)


go;

declare @i int = (select count(*) from Students)
declare @j int = (select top 1 PersonId from Students)


while @i <> @j
begin
    insert into #TempStudents(Name, GPA)
    values ((select P.Name
                 from Students as S
                 inner join dbo.People P on P.Id = S.PersonId
                 where P.Id = @j),
            (select S.GPA
                 from Students as S
                 inner join dbo.People P on P.Id = S.PersonId
                 where P.Id = @j));
    set @j = @j + 1;

end


select * from #TempStudents;


