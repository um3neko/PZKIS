
Menu.Start();

public static class Menu
{
    static int Index = 0;
    static int SubIndex = 0;
    static bool IsDisabled = false;


    static List<Item> Items = new List<Item>();
    static Item SelectedItem { get; set; }

    static void Init()
    {
        Items.Add(new Item() {
            Name = "Файл",
            SubItems = new List<string>() { "Створити", "Видалити", "Biдкрити" } });
        Items.Add(new Item()
        {
            Name = "Редактор",
            SubItems = new List<string>() { "Копiювати", "Вставити", "Вирiзати" }
        });
        Items.Add(new Item()
        {
            Name = "Перегляд",
            SubItems = new List<string>() { "Вiдкрити", "Вiдкрити за допомогою", "Свойства" }
        });
       
        Items.Add(new Item()
        {
            Name = "Опцii",
            SubItems = new List<string>() { "Назва проекту", "Розташування", "За замовчуванням" }
        });
        Items.Add(new Item()
        {
            Name = "ПIБ ",
            SubItems = new List<string>() { "Редько", "Денис", "Павлович" }
        });

    }
    public static void Start()
    {
        DrawMenu();
    }

    static void DrawMenu()
    {
        Init();
        Console.CursorVisible = false;

        while (true)
        {
            Console.Clear();
            
            for (int i = 0; i < Items.Count; i++)
            {
                if (i == Index)
                {
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.Blue;
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.White;
                }

                Console.Write(Items[i].Name + "  ");

            }
            Console.WriteLine();

            if(SelectedItem != null)
            {
                for(int j = 0; j < SelectedItem.SubItems.Count; j++)
                {
                    if ( j == SubIndex)
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.ForegroundColor = ConsoleColor.Blue;
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    if(j >= SubIndex)
                    {
                        for (int i = 0; i < Index; i++)
                        {
                            Console.Write("\t");
                        }

                    }
                    Console.Write(SelectedItem.SubItems[j]);
                    Console.WriteLine();
                }
                
            }
            Console.ResetColor();
            

            ConsoleKeyInfo keyInfo = Console.ReadKey();

            switch (keyInfo.Key)
            {
                case ConsoleKey.LeftArrow:
                    if (Index > 0 && IsDisabled != true)
                    {
                        Index--;
                    }
                    break;
                case ConsoleKey.RightArrow:
                    if (Index < Items.Count - 1 && IsDisabled != true)
                    {
                        Index++;
                    }
                    break;
                case ConsoleKey.UpArrow:
                    if (SubIndex > 0 && IsDisabled == true)
                    {
                        SubIndex--;
                    }
                    break;
                case ConsoleKey.DownArrow:
                    if (SubIndex < Items[Index].SubItems.Count - 1 && IsDisabled == true)
                    {
                        SubIndex++;
                    }
                    break;
                case ConsoleKey.Enter:
                    SelectedItem = Items[Index];
                    IsDisabled = true;
                    break;
                case ConsoleKey.Backspace:
                    IsDisabled = false;
                    SelectedItem = null;
                    break;
            }
        }
    }
} 

public class Item
{
    public string Name { get; set; }
    public List<string> SubItems { get; set; } = new();
}
