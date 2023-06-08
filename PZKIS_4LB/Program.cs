using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

ListContext db = new ListContext();

var task1 = new ToDo
{
    Id = Guid.NewGuid(),
    Name = "Task 1",
    Description = "Description for task 1",
    IsDone = true,
};
var task2 = new ToDo
{
    Id = Guid.NewGuid(),
    Name = "Task 2",
    Description = "Description for task 2",
    IsDone = false,
};
var task3 = new ToDo
{
    Id = Guid.NewGuid(),
    Name = "Task 3",
    Description = "Description for task 3",
    IsDone = true,
};

var user1 = new User
{
    Id = Guid.NewGuid(),
    Name = "Denys",
    LastName = "Redko",
};

var toDoList1 = new ToDoList
{
    Id = Guid.NewGuid(),
    Name = "New LIST",
    ToDos = new List<ToDo> { task1, task2, task3 },
    User = user1,
};

//db.ToDoLists.Add(toDoList1);
//db.SaveChanges();


var x = db.ToDoLists.ToList();

var displayer = new Displayer(db);


while (true)
{
    Console.Clear();
    Console.WriteLine("1. Iснуючi задачi");
    Console.WriteLine("2. Список користувачiв");
    Console.WriteLine("3. Спикок спискiв задач.");
    Console.WriteLine("4. Вивести користувачiв за iм-ям");

    string choice = Console.ReadLine();

    switch (choice)
    {
        case "1":

            displayer.DisplayAllTodos();
            Console.ReadKey();
            Console.Clear();
            break;

        case "2":
            displayer.DisplayUsers();
            Console.ReadKey();
            Console.Clear();
            break;

        case "3":
            displayer.DisplayAllTodosList();
            Console.ReadKey();
            Console.Clear();
            break;
        case "4":
            Console.WriteLine("Введiть iмя");

            var str = Console.ReadLine();
            displayer.DisplayUserByName(str);
            Console.ReadKey();
            Console.Clear();
            break;


        default:
            Console.ReadKey();
            break;
    }
}

class Displayer
{
    private readonly ListContext db;
    public Displayer(ListContext db)
    {

        this.db = db;

    }
    public void DisplayUsers()
    {
        var users = db.Users.ToList();
        Console.WriteLine("Users");
        Console.Write($"User Id \t\t\t\t Name \t Last name ");
        Console.WriteLine();

        foreach (User u in users)
        {
            Console.Write($"{u.Id}\t {u.Name}\t {u.LastName}");
            Console.WriteLine();
        }
    }

    public void DisplayAllTodos()
    {
        var todos = db.ToDos.ToList();
        Console.WriteLine("ToDos");
        Console.WriteLine($"Todo Id \t\t\t\t Name \t Description \t Is Done? ");

        foreach (ToDo u in todos)
        {
            Console.WriteLine($"{u.Id}\t {u.Name}\t {u.Description} \t {u.IsDone}");
        }
    }

    public void DisplayAllTodosList()
    {
        var todoLists = db.ToDoLists.ToList();
        Console.WriteLine("ToDo Lists ");
        Console.WriteLine($"TodoList Id \t\t\t\t To Do Name ");
        Console.WriteLine();

        foreach (var e in todoLists)
        {
            Console.WriteLine($"{e.Id} \t {e.Name} ");
            if (e.User != null)
            {
                Console.WriteLine($"User name \t User Last name");
                Console.WriteLine($"{e.User.Name} \t {e.User.LastName}");
                Console.WriteLine();
            }
            if (e.ToDos.Count > 0)
            {
                Console.WriteLine("-----------------------------to do-----------------------------");
                Console.WriteLine($"todo id \t\t\t\t name \t description \t\t is done? ");
                foreach (ToDo elem in e.ToDos)
                {
                    Console.WriteLine($"{elem.Id}\t {elem.Name}\t {elem.Description}\t {elem.IsDone}");
                    Console.WriteLine();
                }
            }

        }

        
        foreach (ToDoList u in todoLists)
        {
            
        }
        
 
    }
    public void DisplayUserByName(string str)
    {
        var users = db.Users.Where(x => x.Name == str).ToList();
        Console.Write($"User Id \t\t\t\t Name \t Last name ");
        Console.WriteLine();

        foreach (User u in users)
        {
            Console.Write($"{u.Id}\t {u.Name}\t {u.LastName}");
            Console.WriteLine();
        }

    }
}

class ToDo 
{
    public Guid Id { get; set; } = new Guid();
    public string Name { get; set; }
    public string Description { get; set; }
    public bool IsDone { get; set; }


    public Guid ToDoListId { get; set; }
    public ToDoList? ToDoList { get; set; }
} 

class ToDoList
{
    public Guid Id { get; set; } = new Guid();
    public string Name { get; set; }

    public List<ToDo>? ToDos { get; set; } = new();

    public User? User { get; set; }

}

class User
{
    public Guid Id { get; set; } = new Guid();

    public Guid ToDoListId { get; set; }
    public ToDoList? ToDoList { get; set; }

    public string Name { get; set; }
    public string LastName { get; set; }
}

class ListContext : DbContext
{
    public ListContext() => Database.EnsureCreated();

    public virtual DbSet<ToDo> ToDos { get; set;}
    public virtual DbSet<User> Users { get; set; }
    public virtual DbSet<ToDoList> ToDoLists { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=111DataBase.db");
    }
}


