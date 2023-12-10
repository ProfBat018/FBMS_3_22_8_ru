using System;

Console.WriteLine("Приготовление чая:");
HotBeverageTemplate tea = new Tea();
tea.PrepareBeverage();

Console.WriteLine("\nПриготовление кофе:");
HotBeverageTemplate coffee = new Coffee();
coffee.PrepareBeverage();
