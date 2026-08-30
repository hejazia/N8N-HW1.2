using System.Numerics;

namespace N8N_HW1_2;

public static class Calculator
{
    public static double Add(double firstNumber, double secondNumber)
    {
        return firstNumber + secondNumber;
    }

    public static double Subtract(double firstNumber, double secondNumber)
    {
        return firstNumber - secondNumber;
    }

    public static double Multiply(double firstNumber, double secondNumber)
    {
        return firstNumber * secondNumber;
    }

    public static double Divide(double firstNumber, double secondNumber)
    {
        if (secondNumber == 0)
        {
            throw new DivideByZeroException("امکان تقسیم بر صفر وجود ندارد.");
        }

        return firstNumber / secondNumber;
    }

    public static BigInteger Factorial(int number)
    {
        if (number < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(number), "فاکتوریل فقط برای اعداد صحیح نامنفی تعریف شده است.");
        }

        var result = BigInteger.One;

        for (var i = 2; i <= number; i++)
        {
            result *= i;
        }

        return result;
    }
}
