Car c1 = new()
{
    Make = "BMW",
    Model = "M3",
    Color = "Red",
    Engine = new()
    {
        HP = 500,
        Volume = 3
    }
};

Car c2 = (Car)c1.Clone();

c2.Engine.HP = 2000;

Console.WriteLine(c1);
Console.WriteLine(c2);




class Car : ICloneable
{
    public string Make { get; set; }
    public string Model { get; set; }
    public string Color { get; set; }
    public Engine Engine { get; set; }

    public object Clone()
    {
        return new Car
        {
            Make = this.Make,
            Model = this.Model,
            Color = this.Color,
            Engine = new Engine
            {
                HP = this.Engine.HP,
                Volume = this.Engine.Volume
            }
        };
    }

    public override string ToString()
    {
        return $"Make: {Make}, Model: {Model}, Color: {Color}, Engine: {Engine.HP}HP {Engine.Volume}L";
    }
}


class Engine
{
    public int HP { get; set; }
    public int Volume { get; set; }
}