using Microsoft.EntityFrameworkCore;
using Relationship;
using Relationship.Services;


AcademyContext context = new();

#region Part1

// GetDataService dataService = new(context);

// var res = dataService.GetAllData<GroupDatum>(x => x.GroupId > 5, "Group,Student");
// var res2 = dataService.GetAllData<GroupDatum>(x => x.GroupId > 5);
// var res3 = dataService.GetAllData<GroupDatum>();
// var res4 = dataService.GetAllData<GroupDatum>(relatives:"Group,Student");
//
//
// foreach (var item in res)
// {
//     Console.WriteLine($"{item.Group.Name} - {item.Student.PersonId}");
// }

#endregion

#region Part2

// var groupData = new GroupDatum()
// {
//     GroupId = context.Groups.First(x => x.Name == "Group2").Id,
//     StudentId = context.Students.First(x => x.Person.Name == "Elnur").Id
// };
//
// context.GroupData.Add(groupData);
//
// context.SaveChanges();

#endregion

#region Part3

// context.Students
//     .Include(x => x.Person)
//     .First(x => x.Person.Name == "Elnur").Person.Name = "Elnurio";
//
// context.SaveChanges();


#endregion


