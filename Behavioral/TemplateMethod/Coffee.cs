public class Coffee : HotBeverageTemplate
{
    protected override void Brew()
    {
        Console.WriteLine("Варим кофе");
    }

    protected override void AddCondiments()
    {
        Console.WriteLine("Добавляем сахар и молоко");
    }
}