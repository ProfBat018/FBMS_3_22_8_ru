using System;

#region Output

//Console.WriteLine("Hello");
//Console.WriteLine("World");

//Console.Write("Hello");
//Console.Write("World");


#endregion

#region ref&out

//int sumNumbers(out int num1, out int num2)
//{
//    num1 = 5; num2 = 2;

//    return num1 + num2;
//}

//int sumNumbers2(ref int num1, ref int num2)
//{
//    return num1 + num2;
//}

//int firstNum;
//int secondNum;

//sumNumbers(out firstNum, out secondNum);

//Console.WriteLine(firstNum);
//Console.WriteLine(secondNum);


//sumNumbers2(ref firstNum, ref secondNum);


#endregion

#region Input 

/*
Console.Write("Enter first number: ");
int num1 = Int32.Parse(Console.ReadLine());

Console.Write("Enter second number: ");
int num2 = Int32.Parse(Console.ReadLine());

int res = num1 + num2;

Console.WriteLine(res);
*/

//int num1, num2;

//Console.Write("Enter first number: ");
//bool num1Result = Int32.TryParse(Console.ReadLine(), out num1);

//Console.Write("Enter second number: ");
//bool num2Result = Int32.TryParse(Console.ReadLine(), out num2);

//if (num1Result && num2Result)
//{
//    Console.WriteLine(num1 + num2);
//}

#endregion

#region Arrays

//int[] arr = new int[4] { 1, 2, 3, 4 };

#endregion

#region MultiArrays

//int[][] arr1 = new int[2][] { new int[2] {1, 2}, new int[3] { 3, 4, 5 } }; // jagged array

//int[,] arr2 = new int[,] { { 1, 2}, { 3, 4 } }; // multi array

#endregion

internal class Program
{
    public static Inventory inventory = new();

    static void Main(string[] args)
    {
        BasicStatus();
        inventory.ShowInventory();
    }

    static void BasicStatus()
    {

        Item weap1 = new Item("Old Sword", "ATK", 2, "Common");
        Item armo1 = new Item("Iron Armor", "DEF", 5, "Uncommon");

        inventory.GetItem(weap1);
        inventory.GetItem(armo1);
    }


}

public class Item
{
    public string Name { get; set; }
    public string Type { get; set; }
    public int Effect { get; set; }
    public string Info { get; set; }

    public Item(string name, string type, int effect, string info)
    {
        Name = name;
        Type = type;
        Effect = effect;
        Info = info;
    }
}

public class Inventory
{
    public List<Item> items;

    public Inventory()
    {
        items = new List<Item>();
    }

    public void GetItem(Item item)
    {
        items.Add(item);
    }

    public void ShowInventory()
    {
        Console.Clear();

        Console.WriteLine("[ITEM LIST]");

        foreach (var Item in items)
        {
            Console.WriteLine($"- {Item.Name} | {Item.Type} +{Item.Effect} | {Item.Info}");
        }
    }
}