public abstract class HotBeverageTemplate
{
    public void PrepareBeverage()
    {
        BoilWater();
        Brew();
        PourInCup();
        AddCondiments();
        Console.WriteLine("Напиток готов!");
    }

    protected abstract void Brew();
    protected abstract void AddCondiments();

    private void BoilWater()
    {
        Console.WriteLine("Кипятим воду");
    }

    private void PourInCup()
    {
        Console.WriteLine("Наливаем в чашку");
    }
}