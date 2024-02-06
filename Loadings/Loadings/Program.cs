using Loadings;

using AcademyContext context = new();

#region Reference
// var groupData = context.GroupData.First();

// context.Entry(groupData)
//     .Reference(gd => gd.Group)
//     .Load();
//
// context.Entry(groupData.Group)
//     .Reference(g => g.Faculty)
//     .Load();

// Console.WriteLine(groupData.Group.Name);
// Console.WriteLine(groupData.Group.Faculty.Name);
#endregion


var people = context.People.First(); // Elnur

context.Entry(people)
    .Collection(x => x.Students)
    .Load();


foreach(var student in people.Students)
{
    Console.WriteLine(student.Person.Name);
}



