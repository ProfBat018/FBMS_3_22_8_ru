using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DbFirst;

public class AcademyContext : DbContext
{
    public AcademyContext(DbContextOptions<AcademyContext> options)
        : base(options)
    {
    }

    public  DbSet<Employee> Employees { get; set; }

    public  DbSet<Faculty> Faculties { get; set; }

    public  DbSet<Group> Groups { get; set; }

    public  DbSet<GroupDatum> GroupData { get; set; }
    public  DbSet<Person> People { get; set; }

    public  DbSet<Student> Students { get; set; }

    public  DbSet<StudyPlan> StudyPlans { get; set; }

    public  DbSet<Teacher> Teachers { get; set; }
}
