namespace ConsoleClient;

public static class ConsoleClient
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
                    "1" => num1 + num2,
                    "2" => num1 - num2,
                    "3" => num1 * num2,
                    "4" => num2 != 0 ? num1 / num2 : throw new DivideByZeroException("Помилка: ділення на нуль"),
                    "5" => Math.Pow(num1, num2),
                    "6" => num1 >= 0
                        ? Math.Sqrt(num1)
                        : throw new ArgumentException("Помилка: корінь з від’ємного числа"),
                    _ => throw new InvalidOperationException("Невірний вибір")
                };
                Console.WriteLine($"Результат: {result}\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Помилка: {ex.Message}\n");
            }
        }
    }
}