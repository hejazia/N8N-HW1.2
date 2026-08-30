using System.Globalization;

namespace N8N_HW1_2;

public static class Program
{
    public static void Main()
    {
        Console.WriteLine("ماشین حساب کنسولی");
        Console.WriteLine("عملیات را وارد کنید: جمع، تفریق، ضرب، تقسیم، فاکتوریل یا خروج");

        while (true)
        {
            Console.Write("عملیات: ");
            var operation = Console.ReadLine()?.Trim().ToLowerInvariant();

            if (operation is "خروج" or "exit" or "quit")
            {
                Console.WriteLine("خدانگهدار!");
                return;
            }

            var isAddition = operation is "جمع" or "جمع کن" or "add" or "+";
            var isSubtraction = operation is "تفریق" or "تفریق کن" or "subtract" or "sub" or "-";
            var isMultiplication = operation is "ضرب" or "ضرب کن" or "multiply" or "mult" or "*";
            var isDivision = operation is "تقسیم" or "تقسیم کن" or "divide" or "div" or "/";
            var isFactorial = operation is "فاکتوریل" or "factorial" or "fact" or "!";

            if (isFactorial)
            {
                var number = ReadInteger("عدد: ");

                try
                {
                    Console.WriteLine($"نتیجه: {Calculator.Factorial(number)}");
                }
                catch (ArgumentOutOfRangeException exception)
                {
                    Console.WriteLine(exception.Message);
                }

                continue;
            }

            if (!isAddition && !isSubtraction && !isMultiplication && !isDivision)
            {
                Console.WriteLine("عملیات نامعتبر است. جمع، تفریق، ضرب، تقسیم، فاکتوریل یا خروج را وارد کنید.");
                continue;
            }

            var firstNumber = ReadNumber("عدد اول: ");
            var secondNumber = ReadNumber("عدد دوم: ");

            try
            {
                var result = isAddition
                    ? Calculator.Add(firstNumber, secondNumber)
                    : isSubtraction
                        ? Calculator.Subtract(firstNumber, secondNumber)
                        : isMultiplication
                            ? Calculator.Multiply(firstNumber, secondNumber)
                            : Calculator.Divide(firstNumber, secondNumber);

                Console.WriteLine($"نتیجه: {result}");
            }
            catch (DivideByZeroException exception)
            {
                Console.WriteLine(exception.Message);
            }
        }
    }

    private static double ReadNumber(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            var input = Console.ReadLine();

            if (double.TryParse(input, NumberStyles.Float, CultureInfo.CurrentCulture, out var number) ||
                double.TryParse(input, NumberStyles.Float, CultureInfo.InvariantCulture, out number))
            {
                return number;
            }

            Console.WriteLine("لطفاً یک عدد معتبر وارد کنید.");
        }
    }

    private static int ReadInteger(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            var input = Console.ReadLine();

            if (int.TryParse(input, NumberStyles.Integer, CultureInfo.CurrentCulture, out var number) ||
                int.TryParse(input, NumberStyles.Integer, CultureInfo.InvariantCulture, out number))
            {
                return number;
            }

            Console.WriteLine("لطفاً یک عدد صحیح معتبر وارد کنید.");
        }
    }
}
