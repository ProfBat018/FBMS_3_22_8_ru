using System.Text;
using System.Text.Json.Serialization;


// Атрибут Serializable говорит о том, что объекты этого класса могут быть сериализованы
// Нужен только для BinaryFormatter

//[Serializable]

class Classroom
{
    private readonly string _id = Guid.NewGuid().ToString();
    public string Id { get => _id; }

    public UInt16 MaxStudentsCount { get; private set; }
    
    public List<Student> Students { get; set; }
    
    public void IncreaseMaxStudentsCount(UInt16 value)
    {
        MaxStudentsCount += value;
    }
    
    public void AddStudent(Student student)
    {
        if (MaxStudentsCount > Students.Count)
        {
            Students.Add(student);
            return;
        }
        throw new OverflowException("Classroom is full");
    }
    
    public void AddStudents(IEnumerable<Student> students)
    {
        if (MaxStudentsCount >= Students.Count + students.Count())
        {
            Students.AddRange(students);
            return;
        }
        throw new OverflowException("Classroom is full");
    }

    public Classroom(UInt16 maxStudentsCount)
    {
        Students = new List<Student>();
        MaxStudentsCount = maxStudentsCount;
    }

    public override string ToString()
    {
        StringBuilder sb = new();
        sb.AppendLine($"Classroom Id: {_id}");
        sb.AppendLine($"Max students count: {MaxStudentsCount}");
        sb.AppendLine("Students:");
        
        foreach (var student in Students)
        {
            sb.AppendLine(student.ToString());
        }
        return sb.ToString();
    }
}