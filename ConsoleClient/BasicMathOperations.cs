namespace ConsoleClient;

public static class BasicMathOperations
{
    public static double AddTwoNumbers(double num1, double num2) => num1 + num2;

    public static double DivideTwoNumbers(double num1, double num2) => num2 != 0 ? num1 / num2 : throw new DivideByZeroException("Помилка: ділення на нуль");

    public static double MultiplyTwoNumbers(double num1, double num2) => num1 * num2;

    public static double PowerNumber(double num1, double num2) => Math.Pow(num1, num2);

    public static double SqrtNumber(double num1) => num1 >= 0
                                ? PowerNumber(num1, 0.5)
                                : throw new ArgumentException("Помилка: корінь з від’ємного числа");

    public static double SubstructTwoNumbers(double num1, double num2) => num1 - num2;
}
