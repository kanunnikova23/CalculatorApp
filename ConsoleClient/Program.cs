namespace ConsoleClient;
public static class Program
{
    private static void Main()
    {
        while (true)
        {
            Console.Write(GetConsoleMenu());

            bool isOperationValid = Enum.TryParse(Console.ReadLine(), out ConsoleOperations operation) // "1" (string) == 1 -> AddTwoNumbers (Enum.ConsoleOperations) == 1
                        && Enum.IsDefined(operation);

            if (!isOperationValid)
            {
                Console.WriteLine("Невірна операція");
                Console.WriteLine("Натисніть будь-яку клавішу щоби продовжить");
                _ = Console.ReadKey();
                Console.Clear();
                continue;
            }

            if (operation == ConsoleOperations.Abort)
            {
                Console.WriteLine("bye!");
                _ = Console.ReadKey();
                break;
            }

            try
            {
                double num1, num2 = 0;
                if (operation == ConsoleOperations.SqrtNumber)
                {
                    Console.Write("Введіть число: ");
                    num1 = double.Parse(Console.ReadLine() ?? string.Empty);
                }
                else
                {
                    Console.Write("Введіть перше число: ");
                    num1 = double.Parse(Console.ReadLine() ?? string.Empty);
                    Console.Write("Введіть друге число: ");
                    num2 = double.Parse(Console.ReadLine() ?? string.Empty);
                }

                var result = operation switch
                {
                    ConsoleOperations.AddTwoNumbers => BasicMathOperations.AddTwoNumbers(num1, num2),
                    ConsoleOperations.SubstractTwoNumbers => BasicMathOperations.SubstructTwoNumbers(num1, num2),
                    ConsoleOperations.MultiplyTwoNumbers => BasicMathOperations.MultiplyTwoNumbers(num1, num2),
                    ConsoleOperations.DivideTwoNumbers => BasicMathOperations.DivideTwoNumbers(num1, num2),
                    ConsoleOperations.PowerNumber => BasicMathOperations.PowerNumber(num1, num2),
                    ConsoleOperations.SqrtNumber => BasicMathOperations.SqrtNumber(num1),
                    _ => throw new InvalidOperationException("Невідома операція")
                };

                Console.WriteLine($"Результат: {result}\n");
                Console.WriteLine("Натисніть будь-яку клавішу щоби продовжить");
                _ = Console.ReadKey();
                Console.Clear();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Помилка: {ex.Message}\n");
            }
        }
    }

    private static string GetConsoleMenu()
    {
        var menu = "=== Головне меню ===\n";
        menu = GetOptionsList(menu);
        menu += "Оберіть опцію: ";

        return menu;
    }

    private static string GetOptionsList(string options)
    {
        foreach (var operation in Enum.GetValues<ConsoleOperations>())
        {
            string formattedName = string.Concat(operation.ToString().Select(c => char.IsUpper(c) ? " " + c : c.ToString())).Trim();
            options += $"{(int)operation}. {formattedName}\n";
        }

        return options;
    }
}