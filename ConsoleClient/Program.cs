namespace ConsoleClient;
public static class Program
{
    private static void Main()
    {
        while (true)
        {
            Console.WriteLine("=== Головне меню ===");
            Console.WriteLine("1. Додавання (+)");
            Console.WriteLine("2. Віднімання (-)");
            Console.WriteLine("3. Множення (*)");
            Console.WriteLine("4. Ділення (/)");
            Console.WriteLine("5. Піднесення до степеня (^)");
            Console.WriteLine("6. Обчислення квадратного кореня (√)");
            Console.WriteLine("7. Вихід із програми");
            Console.Write("Оберіть опцію: ");

            var input = Console.ReadLine();

            if (input == "7") break;
            try
            {
                double num1, num2 = 0;
                if (input != "6")
                {
                    Console.Write("Введіть перше число: ");
                    num1 = double.Parse(Console.ReadLine() ?? string.Empty);
                    Console.Write("Введіть друге число: ");
                    num2 = double.Parse(Console.ReadLine() ?? string.Empty);
                }
                else
                {
                    Console.Write("Введіть число: ");
                    num1 = double.Parse(Console.ReadLine() ?? string.Empty);
                }

                var result = input switch
                {
                    "1" => BasicMathOperations.AddTwoNumbers(num1, num2),
                    "2" => BasicMathOperations.SubstructTwoNumbers(num1, num2),
                    "3" => BasicMathOperations.MultiplyTwoNumbers(num1, num2),
                    "4" => BasicMathOperations.DivideTwoNumbers(num1, num2),
                    "5" => BasicMathOperations.PowerNumber(num1, num2),
                    "6" => BasicMathOperations.SqrtNumber(num1),
                    _ => throw new InvalidOperationException("Невірний вибір")
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
}