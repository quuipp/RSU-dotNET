using System;
using System.Numerics;
using System.Collections.Generic;
using System.Collections;
using System.Diagnostics;

namespace Task2
{
    class Program
    {

        static void Main(string[] args)
        {
            Exponential();
            Pi();
            Ln();
            Sqrt();
            Gamma();
        }
        public static void Exponential()
        {
            Console.WriteLine("Enter the epsilon value:");
            string str = Console.ReadLine();
            string[] s_split = str.Split();
            double epsilon = double.Parse(s_split[0]);
            exp1(epsilon);
            exp2(epsilon);
            exp3(epsilon);
        }
        public static void exp1(double epsilon)
        {
            double n = 2;
            double previous = Math.Pow((1.0 + 1.0 / n), n);
            while (true)
            {
                n++;
                double current = Math.Pow((1.0 + 1.0 / n), n);
                if (Math.Abs(current - previous) > epsilon)
                {
                    previous = current;
                }
                else
                {
                    Console.WriteLine("Exponent as the sum of the series " + previous + " with the value of epsilon " + epsilon);
                    break;
                }
            }
        }
        public static void exp2(double epsilon)
        {
            long n = 0;
            double previous = 1.0 / (double)factorial(n);
            n++;
            previous += 1.0 / (double)factorial(n);
            while (true)
            {
                n++;
                double current = previous + 1.0 / (double)factorial(n);
                if (Math.Abs(current - previous) > epsilon)
                {
                    previous = current;
                }
                else
                {
                    Console.WriteLine("Exponent how to solve the equation lnх = 1 " + previous + " with the value of epsilon " + epsilon);
                    break;
                }
            }

        }
        public static void exp3(double epsilon)
        {
            double step = epsilon / 10;
            double previous = step;
            while (true)
            {
                double current = previous + step;
                if (Math.Abs(1.0 - Math.Log(current)) > epsilon)
                {
                    previous = current;
                }
                else
                {
                    Console.WriteLine("Exponent as the value of the limit" + previous + " with the value of epsilon " + epsilon);
                    break;
                }
            }
        }
        public static void Pi()
        {
            //double epsilon = 0.00001;
            Console.WriteLine("Enter the epsilon value:");
            string str = Console.ReadLine();
            string[] s_split = str.Split();
            double epsilon = double.Parse(s_split[0]);
            pi1(epsilon);
            pi2(epsilon);
            pi3(epsilon);
        }
        public static void pi1(double epsilon)
        {
            epsilon = epsilon < 0.001 ? 0.00999 : epsilon;
            long n = 1;
            double previous = Math.Pow(2, 4 * n) * Math.Pow(factorial(n), 4) / n / Math.Pow(factorial(2 * n), 2);
            while (true)
            {
                n++;
                double current = Math.Pow(2, 4 * n) * Math.Pow(factorial(n), 4) / n / Math.Pow(factorial(2 * n), 2);
                if (Math.Abs(current - previous) > epsilon)
                {
                    previous = current;
                }
                else
                {
                    Console.WriteLine("PI as the sum of the series " + previous + " with the value of epsilon " + epsilon);
                    break;
                }
            }
        }
        public static void pi2(double epsilon)
        {
            long n = 1;
            double previous = Math.Pow(-1, n + 1) / (2 * n - 1);
            double accum = previous;
            while (true)
            {
                n++;
                double current = Math.Pow(-1, n + 1) / (2 * n - 1);
                if (Math.Abs(current - previous) > epsilon)
                {
                    accum += current;
                    previous = current;
                }
                else
                {
                    accum *= 4;
                    Console.WriteLine("PI how to solve the equation cosх = -1 " + accum + " with the value of epsilon " + epsilon);
                    break;
                }
            }
        }
        public static void pi3(double epsilon)
        {
            for (double i = 0; i <= 2 * Math.PI; i += epsilon / 10.0)
            {
                double value = Math.Cos(i);
                if (Math.Abs(value + 1) < epsilon)
                {
                    Console.WriteLine("PI as the value of the limit " + i + " with the value of epsilon " + epsilon);
                    break;
                }
            }

        }
        public static void Ln()
        {
            Console.WriteLine("Enter the epsilon value:");
            string str = Console.ReadLine();
            string[] s_split = str.Split();
            double epsilon = double.Parse(s_split[0]);
            ln1(epsilon);
            ln2(epsilon);
            ln3(epsilon);
        }
        public static void ln1(double epsilon)
        {
            double n = 1;
            double previous = n * (Math.Pow(2, (1.0 / n)) - 1);
            while (true)
            {
                n++;
                double current = n * (Math.Pow(2, (1.0 / n)) - 1);
                if (Math.Abs(current - previous) > epsilon)
                {
                    previous = current;
                }
                else
                {
                    Console.WriteLine("The natural logarithm of 2 as the sum of a series " + previous + " with the value of epsilon " + epsilon);
                    break;
                }
            }
        }
        public static void ln2(double epsilon)
        {
            double n = 1;
            double previous = Math.Pow(-1, n - 1) / n;
            while (true)
            {
                n++;
                double current = previous + Math.Pow(-1, n - 1) / n;
                if (Math.Abs(current - previous) > epsilon)
                {
                    previous = current;
                }
                else
                {
                    Console.WriteLine("Natural logarithm 2 as a solution to the equation е^х = 2 " + previous + " with the value of epsilon " + epsilon);
                    break;
                }
            }
        }
        public static void ln3(double epsilon)
        {
            double step = epsilon / 10.0;
            double x = step;
            while (true)
            {
                if (Math.Abs(Math.Exp(x) - 2.0) > epsilon)
                {
                    x += step;
                }
                else
                {
                    Console.WriteLine("Natural logarithm 2 as the value of the limit " + x + " with the value of epsilon " + epsilon);
                    break;
                }
            }
        }
        public static void Sqrt()
        {
            //double epsilon = 0.001;
            Console.WriteLine("Enter the epsilon value:");
            string str = Console.ReadLine();
            string[] s_split = str.Split();
            double epsilon = double.Parse(s_split[0]);
            sqrt1(epsilon);
            sqrt2(epsilon);
            sqrt3(epsilon);
        }
        public static void sqrt1(double epsilon)
        {
            double n = 2;
            double x = 1;
            for (; ; )
            {
                double nx = (x + n / x) / 2;
                if (Math.Abs(x - nx) < epsilon)
                {
                    break;
                }
                x = nx;
            }
            Console.WriteLine("The root of 2 as the sum of the series " + x + " with the value of epsilon " + epsilon);
        }
        public static void sqrt2(double epsilon)
        {
            int k = 2;

            double previous = Math.Pow(2, Math.Pow(2, -k));

            while (true)
            {
                k++;
                double current = previous * Math.Pow(2, Math.Pow(2, -k));
                if (Math.Abs(previous - current) > epsilon)
                {
                    previous = current;
                }
                else
                {
                    Console.WriteLine("The root of 2 as a solution to the equation х^2 = 2 " + previous + " with the value of epsilon " + epsilon);
                    break;
                }
            }
        }
        public static void sqrt3(double epsilon)
        {
            double step = epsilon / 10.0;
            double x = step;
            while (true)
            {
                if (Math.Abs(Math.Pow(x, 2) - 2.0) > epsilon)
                {
                    x += step;
                }
                else
                {
                    Console.WriteLine("The root of the two as the value of the limit " + x + " with the value of epsilon " + epsilon);
                    break;
                }

            }
        }
        public static void Gamma()
        {
            //double epsilon = 0.00001;
            Console.WriteLine("Enter the epsilon value:");
            string str = Console.ReadLine();
            string[] s_split = str.Split();
            double epsilon = double.Parse(s_split[0]);
            gam1(epsilon);
            gam2(epsilon);
            gam3(epsilon);
        }
        public static void gam1(double epsilon)
        {
            int n = (int)(1.0 / epsilon) * 100;
            double accum = 1.0;
            double previous = 1.0;
            for (int i = 2; i < n; i++)
            {
                double current = accum + (1.0 / i) - Math.Log(n);
                if (Math.Abs(current - previous) > epsilon)
                {
                    accum += 1.0 / i;
                    previous = current;
                }
                else
                {
                    accum = accum - Math.Log(i);
                    Console.WriteLine("The value of the Euler-Mascheroni constant as the sum of a series " + accum + " with the value of epsilon " + epsilon);
                    break;
                }
            }
        }
        public static void gam2(double epsilon)
        {
            long k = 1;
            double n = 1.0 / epsilon;
            double previous = (-Math.Pow(Math.PI, 2)) / 6;
            while (k < n)
            {
                k++;
                previous += (1.0 / Math.Pow(((int)Math.Sqrt(k)), 2) - 1.0 / k);
            }
            Console.WriteLine(" The value of the Euler - Mascheroni constant as a solution to the equation е^-х = lim t->∞ (ln𝑡 p<=t, p∈P ∏ (p−1 / p )) " + previous + " with the value of epsilon " + epsilon);
        }
        public static void gam3(double epsilon)
        {
            int k = 2;
            double previous = (((double)(k - 1)) / k);
            while (true)
            {
                k++;
                double current = 1;
                if (NumberIsPrime(k))
                {
                    current = (((double)(k - 1)) / k);
                }
                else
                {
                    continue;
                }
                if (Math.Abs(current * previous - previous) > epsilon)
                {
                    previous *= current;
                }
                else
                {
                    previous *= Math.Log(k);
                    Console.WriteLine("The exponent value in the degree of minus gamma " + previous);
                    break;
                }
            }
        }
        public static bool NumberIsPrime(int number)
        {
            if (number <= 1)
            {
                return false;
            }
            if (number == 2)
            {
                return true;
            }
            if (number % 2 == 0)
            {
                return false;
            }
            for (int i = 3; i <= Math.Sqrt(number); i += 2)
            {
                if (number % i == 0)
                {
                    return false;
                }
            }
            return true;

        }
        static long factorial(long number)
        {
            if (number == 0)
            {
                return 1;
            }
            long result = 1;
            for (long i = 1; i <= number; i++)
            {
                result *= i;
            }
            return result;
        }
        static long CalculateCombination(int n, int k)
        {
            if (k < 0 || k > n)
            {
                throw new ArgumentException("0<k<n !");
            }
            long numenator = factorial(n);
            long denominator = factorial(k) * factorial(n - k);
            return numenator / denominator;
        }

    }
}
