using System.Text;

var taskOne = new Task1();
var str = Console.ReadLine();
if (str != null)
{
    Console.WriteLine(taskOne.Encryption(str));
    Console.WriteLine("cipher");
    Console.WriteLine("Key: \t Value:");
    taskOne.ShowСipher();
}

//var task2 = new Task2();
//for (int i = 0; i < 2; i++)
//{
//    task2.Start(); 
//}


public class Task2
{
    public string BeginName { get; set; }
    public string EndName { get; set; }
    public bool IsEncoding { get; set; } // false - decoding
    private IEncoder _encoder;

    public void Start()
    {
        Init();
        try
        {
            if (IsEncoding) // шифрую
            {
                var code = File.ReadAllText(BeginName + ".txt");
                Console.WriteLine($"Ок! Строку зчитано з файлу {BeginName}.txt");


                File.WriteAllText(EndName + ".txt", _encoder.Encode(code));
                Console.WriteLine($"Ок! Строку зашифровано у файл {EndName}.txt");
            }
            else // дешифрую
            {
                var code = File.ReadAllText(BeginName + ".txt");
                Console.WriteLine($"Ок! Строку зчитано з файлу {BeginName}.txt");
                File.WriteAllText(EndName + ".txt", _encoder.Decode(code));
                Console.WriteLine($"Ок! Строку разшифровано у файл {EndName}.txt");
            }
        }

        catch (Exception ex)
        {
            Console.WriteLine("wrong operration");
        }
    }
    private void Init()
    {
        Console.WriteLine("Iм'я вхiдного файлу:");
        BeginName = Console.ReadLine();
        Console.WriteLine("Iм'я вихідного файлу:");
        EndName = Console.ReadLine();
        Console.WriteLine("Метод кодування (1-Base64, 2 - Rot13");
        while (true)
        {
            var input = Console.ReadLine();
            if (int.Parse(input) == 1 )
            {
                _encoder = new EncoderBase64();
                break;
            }
            if (int.Parse(input) == 2)
            {
                _encoder = new EncoderROT13();
                break;
            }
            else
            {
                Console.WriteLine("1 або 2");
            }
        }
        Console.WriteLine("Режим роботи (1-Кодування, 2 - декодування");
        while (true)
        {
            var input = Console.ReadLine();
            if (int.Parse(input) == 1)
            {
                IsEncoding = true;
                break;
            }
            if (int.Parse(input) == 2)
            {
                IsEncoding = false;
                break;
            }
            else
            {
                Console.WriteLine("1 або 2");
            }
        }
    }
}

public interface IEncoder
{
    public string Encode(string str);

    public string Decode(string str);
}

public class EncoderBase64 : IEncoder
{
    public string Encode(string str)
    {
        byte[] bytes = Encoding.UTF8.GetBytes(str);
        return Convert.ToBase64String(bytes);
    }

    public string Decode(string str)
    {
        byte[] bytes = Convert.FromBase64String(str);
        return Encoding.UTF8.GetString(bytes);
    }
}

public class EncoderROT13 : IEncoder
{
    public string Encode(string str)
    {
        StringBuilder result = new StringBuilder();

        foreach (char c in str)
        {
            if (char.IsLetter(c))
            {
                char baseChar = char.IsUpper(c) ? 'A' : 'a';
                result.Append((char)(((c - baseChar + 13) % 26) + baseChar));
            }
            else
            {
                result.Append(c);
            }
        }

        return result.ToString();
    }

    public string Decode(string str)
    {
        return Encode(str);
    }
}

public class Task1
{
    private Dictionary<char, string> Keys { get; set; } = new();
    private string alphabetHigh = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
    private void Init()
    {
        Random rand = new Random();
        var space = rand.Next(-10, 0);
        Keys.Add(' ',space.ToString());
        for (int i = 0; i<26; i++)
        {
            var charA = (char)('a' + i);
            
            var randomInt = rand.Next(0, 10);
            var stringB = randomInt >= 4 
                ? new string(Enumerable.Repeat(alphabetHigh, 2).Select(s => s[rand.Next(s.Length)]).ToArray())
                : rand.Next(500, 5000).ToString();
            Keys.Add(charA, stringB);
        }
        for (int i = 0; i < 26; i++)
        {
            var charA = (char)('A' + i);
            var randomInt = rand.Next(0, 10);
            var stringB = randomInt >= 4
                ? new string(Enumerable.Repeat(alphabetHigh, 2).Select(s => s[rand.Next(s.Length)]).ToArray())
                : rand.Next(500, 5000).ToString();
            Keys.Add(charA, stringB);
        }
    }
    public Task1()
    {
        Init();
    }
    public string Encryption(string str)
    {
        var charArray = str.ToCharArray();
        var encruptionCharArray = new List<string>();
        for(int i = 0; i < charArray.Length; i++)
        {
            if (Keys.TryGetValue(charArray[i], out string value)) 
            {
                encruptionCharArray.Add(value);
            }

        }
        var newStr = new StringBuilder();
        foreach(var subStr in encruptionCharArray)
        {
            newStr.Append(subStr);
        }
        return newStr.ToString();
    }
    public void ShowСipher()
    {
        foreach (var item in Keys)
        {
            Console.Write(item.Key);
            Console.Write(":\t");
            Console.Write(item.Value);
            Console.WriteLine();
        }
    }
}


