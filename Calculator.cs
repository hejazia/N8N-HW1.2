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
}
