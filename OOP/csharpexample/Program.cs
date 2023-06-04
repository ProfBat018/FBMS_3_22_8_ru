Car myCar = new()
{
    Make = "Mercedes",
    Model = "C200"
};

Console.WriteLine(myCar);

class Car 
{
    public string Make;
    public string Model;

    public override string ToString()
    {
        return $"{Make} {Model}";
    }
}