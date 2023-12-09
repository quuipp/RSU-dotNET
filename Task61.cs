using System;
using System.Collections.Generic;
using System.Linq;
class MethodDichotomy
{
    delegate double Func(double one);
    static void Main()
    {
        try
        {
            double root = Dichotomy(-2, 2, x => x-1, 0.00001);
            Console.WriteLine(root);
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Processing failed: {ex.Message}");
            Environment.Exit(1);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <param name="equation"></param>
    /// <param name="epsilon"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentException"></exception>
    static double Dichotomy(double left, double right, Func equation, double epsilon)
    {
        if (epsilon <= 0)
        {
            throw new ArgumentException("Invalid epsilon value", nameof(epsilon));
        }
        if (equation(left) * equation(right) < -epsilon)
        {
            double middle = (left + right) / 2;

            while (Math.Abs(equation(middle)) > epsilon)
            {
                if (equation(left) * equation(middle) < -epsilon)
                    right = middle;
                else
                    left = middle;
                middle = (left + right) / 2;
            }

            return middle;
        }
        else
        { 
            throw new ArgumentException("The interval boundaries are entered incorrectly");
        }

    }
}

