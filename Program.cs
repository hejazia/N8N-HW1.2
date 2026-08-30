using System.Globalization;

namespace N8N_HW1_2;

public static class Program
{
    public static void Main()
    {
        Console.WriteLine("ماشین حساب کنسولی");
        Console.WriteLine("عملیات را وارد کنید: جمع، تفریق یا خروج");

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

            if (!isAddition && !isSubtraction)
            {
                Console.WriteLine("عملیات نامعتبر است. جمع، تفریق یا خروج را وارد کنید.");
                continue;
            }

            var firstNumber = ReadNumber("عدد اول: ");
            var secondNumber = ReadNumber("عدد دوم: ");
            var result = isAddition
                ? Calculator.Add(firstNumber, secondNumber)
                : Calculator.Subtract(firstNumber, secondNumber);

            Console.WriteLine($"نتیجه: {result}");
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
}
