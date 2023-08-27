using System.Globalization;


Person a = new()
{
    Name = "Elvin",
    Surname = "Azimov",
    BirthDate = DateTime.ParseExact("16/11/2001", "dd/MM/yyyy" ,CultureInfo.InvariantCulture)
    // BirthDate = new DateTime(2001, 11, 16),
};

Console.WriteLine(a.Age);

Console.WriteLine(a.BirthDate.Date.DayOfWeek);

class Person
{
    public string Name { get; init; }
    public string Surname { get; set; }
    public DateTime BirthDate { get; set; }

    public int Age
    {
        get 
        {
            if (DateTime.Now.Month < BirthDate.Month)
                return DateTime.Now.Year - BirthDate.Year - 1;
            else if (DateTime.Now.Month == BirthDate.Month && DateTime.Now.Day < BirthDate.Day)
                return DateTime.Now.Year - BirthDate.Year - 1;
            else
                return DateTime.Now.Year - BirthDate.Year;
        }
    }
}


