public class Tea : HotBeverageTemplate
{
    protected override void Brew()
    {
        Console.WriteLine("Завариваем чай");
    }

    protected override void AddCondiments()
    {
        Console.WriteLine("Добавляем лимон");
    }
}