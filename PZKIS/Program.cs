//var xN = 2.3;
//var xK = 10.2;
//var dx = 0.75;
//var a = 0.67;
//var b = 2.8;

//Task1.CalculateAndWriteY(xN, xK, dx, a, b);

var xN = 5.8;
var xK = 17;
var dx = 1.2;
var a = 1.7;
var b = 0.36;

Task1.CalculateVariant1(xN, xK, dx, a, b);

//Task2.Start();

//Task3.Start();

public static class Task1
{
    public static void CalculateVariant1(double xN, double xK,
        double dx, double a, double b)
    {
        Console.WriteLine($"X початку {xN}; X кiнця {xK}; Крок {dx}");

        for (double x = xN; x <= xK; x += dx)
        {
            var temp1 = Math.Sin(x - a);
            var temp2 = Math.Pow(Math.E, a - x) + Math.Sqrt(Math.Abs(b*x));
            var y = temp1 / temp2;
            Console.WriteLine($"y = {Math.Round(y, 2)} ");
        }
    }

    public static void CalculateAndWriteY(double xN, double xK, 
        double dx,double a, double b)
    {
        Console.WriteLine($"X початку {xN}; X кiнця {xK}; Крок {dx}");
        
        for(double x = xN; x <= xK; x+=dx) 
        {
            var temp1 = ((2.1 * b) - Math.Pow (Math.E, a * x));
            var temp2 = (0.3 * Math.Pow(Math.Log(a * x), 4));
            var y = temp1 / temp2;
            Console.WriteLine($"y = {Math.Round(y, 2)} ");
        }
    }
}

public static class Task2
{
    public static void Start()
    {
        Console.WriteLine("Сумма позики:");
        var loanAmount = double.Parse(Console.ReadLine());
        Console.WriteLine("Термiни кредиту:");
        var loanTermMonths = int.Parse(Console.ReadLine());
        Console.WriteLine("Процентна ставка: ");
        var interestRate = double.Parse(Console.ReadLine());
        Console.WriteLine("Перiод нарахування: ");
        var interestPeriodMonths = int.Parse(Console.ReadLine());
        CalculateInterest(loanAmount, loanTermMonths, interestRate, interestPeriodMonths);
    }

    private static void CalculateInterest(double loanAmount, int loanTermMonths, double interestRate, int interestPeriodMonths)
    {
        double remainingBalance = loanAmount;
        int currentMonth = 1;

        Console.WriteLine("Мiсяць\t\t Сума боргу \t\t +%");

        while (currentMonth <= loanTermMonths)
        {
            double monthlyInterest = remainingBalance * (interestRate / 100) * (interestPeriodMonths / 12.0) ;
            remainingBalance += monthlyInterest;
            var monthlyInterestPercent = remainingBalance * 100 / loanAmount;
            Console.WriteLine($"{currentMonth}\t\t{Math.Round(remainingBalance, 3)}\t\t{Math.Round(monthlyInterestPercent, 3)}");
            currentMonth += interestPeriodMonths;
        }
        var result = remainingBalance - loanAmount;
        Console.WriteLine($"Нараховано: {result}");
    }
}

public static class Task3
{
    public static void Start()
    {
        Console.WriteLine("a:");
        var a = double.Parse(Console.ReadLine());
        Console.WriteLine("b:");
        var b = double.Parse(Console.ReadLine());
        Console.WriteLine("c:");
        var c = double.Parse(Console.ReadLine());
        Console.WriteLine(c > 0 
            ? $"{a}^2 + {b}x + {c} = 0" 
            : $"{a}^2 + {b}x {c} = 0");
        CalculateQuadraticEquation(a, b, c);
    }
    private static void CalculateQuadraticEquation(double a , double b ,double c)
    {
        var D = Math.Pow(b, 2) - 4 * a * c;
        if (D > 0)
        {
            var x1 = (-b + Math.Sqrt(D)) / (2 * a);
            var x2 = (-b - Math.Sqrt(D)) / (2 * a);
            Console.WriteLine($"x1 = {x1} x2 = {x2}");
        }
        if (D == 0)
        {
            var x = -b / (2 * a);
            Console.WriteLine($"x = {x}");
        }
        if (D < 0) {
            Console.WriteLine("D < 0");
        }
            
    }
}