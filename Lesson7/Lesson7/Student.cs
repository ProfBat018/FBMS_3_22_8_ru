// [Serializable]
class Student
{
    private readonly string _id;
    public string Id { get => _id; }

    public string Name { get; set; }
    public string Surname { get; set; }
    public Student(string name, string surname)
    {
        _id = Guid.NewGuid().ToString();
        Name = name;
        Surname = surname;
    }

    public override string ToString()
    {
        return $"Id: {_id}\n" +
               $"Name: {Name}\n" +
               $"Surname: {Surname}\n";
    }
}