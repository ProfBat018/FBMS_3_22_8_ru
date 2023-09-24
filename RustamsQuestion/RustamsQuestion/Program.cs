Menu menu = new Menu();

menu.AddMenuItem("1. Add new student", () =>
{
    Menu studentMenu = new Menu();
  
    studentMenu.AddMenuItem("1. Add", () => { Console.WriteLine("Add new student"); });
    studentMenu.AddMenuItem("2. Add", () => { Console.WriteLine("Add new teacher"); });
    studentMenu.AddMenuItem("3. Add", () => { Console.WriteLine("Add new subject"); });
    studentMenu.showMenu();
});
menu.AddMenuItem("2. Add new teacher", () => { Console.WriteLine("Add new teacher"); });
menu.AddMenuItem("3. Add new subject", () => { Console.WriteLine("Add new subject"); });
menu.showMenu();

class Menu
{
    public Dictionary<string, Action> MenuItems { get; set; }
    
    public Menu()
    {
        MenuItems = new Dictionary<string, Action>();
    }
    
    public void AddMenuItem(string name, Action action)
    {
        MenuItems.Add(name, action);
    }
    
    public void showMenu()
    {
        int choice = 0;
        do
        {
            Console.WriteLine("Please select an option:");
            foreach (var item in MenuItems)
            {
                Console.WriteLine(item.Key);
            }
            Console.WriteLine("0. Exit");
            choice = Convert.ToInt32(Console.ReadLine());
        
            if (choice > 0 && choice <= MenuItems.Count)
            {
                MenuItems.ElementAt (choice -1).Value();
            }
        } while (choice != 0);
    }
}


