using System.Numerics;

try
{
    Complex[] kordanoTest = Kordan(1.0, 1.0, 1.0, 1.0, 0.00001);
    Complex[] vietaTest = Vieta(1.0, 1.0, 1.0, 1.0, 0.00001);

    for (int i = 0; i < 3; i++)
    {
        Console.WriteLine(kordanoTest[i]);
        Console.WriteLine(vietaTest[i]);
    }
}
catch (ArgumentException ex)
{
    // TODO: add exception instance handling
    Console.WriteLine($"Processing failed: {ex.Message}");
    Environment.Exit(1);

}

Complex[] Kordan(double a, double b, double c, double d, double epsilon)
{
    if (epsilon <= 0)
    {
        throw new ArgumentException("Invalid epsilon value", nameof(epsilon));
    }

    if (Math.Abs(a) < -epsilon)
    {
        throw new ArgumentException("Not cubic Equation: param a = 0", nameof(a));
    }

    Complex[] roots = new Complex[3];

    double p = (3 * a * c - b * b) / (3 * a * a);
    double q = (2 * Math.Pow(b, 3) - 9 * a * b * c + 27 * a * a * d) / (27 * Math.Pow(a, 3));

    double Q = Math.Pow((p / 3), 3) + Math.Pow((q / 2), 2);

    Complex y1;
    Complex y2;
    Complex y3;

    double param = b / (3 * a);

    if (Q > epsilon)
    {
        double sumtmp = Math.Cbrt(-q / 2 + Math.Sqrt(Q)) + Math.Cbrt(-q / 2 - Math.Sqrt(Q));
        double diftmp = Math.Cbrt(-q / 2 + Math.Sqrt(Q)) - Math.Cbrt(-q / 2 - Math.Sqrt(Q));
        y1 = sumtmp - param;
        y2 = new Complex(-1.0 / 2 * sumtmp - param, Math.Sqrt(3) / 2 * diftmp);
        y3 = new Complex(-1.0 / 2 * sumtmp - param, -Math.Sqrt(3) / 2 * diftmp);
        roots[0] = y1;
        roots[1] = y2;
        roots[2] = y3;
    }
    else if (Q < epsilon)
    {

        double phi = 0;

        if (q < epsilon)
        {
            phi = Math.Atan(Math.Sqrt(-Q) / (-q / 2));
        }
        else if (q > epsilon)
        {
            phi = Math.Atan(Math.Sqrt(-Q) / (-q / 2)) + Math.PI;
        }
        else if (q.CompareTo(0) == 0)
        {
            phi = Math.PI / 2;
        }

        y1 = 2 * Math.Sqrt(-p / 3) * Math.Cos(phi / 3);
        y2 = 2 * Math.Sqrt(-p / 3) * Math.Cos(phi / 3 + 2 * Math.PI / 3);
        y3 = 2 * Math.Sqrt(-p / 3) * Math.Cos(phi / 3 + 4 * Math.PI / 3);

        roots[0] = y1 - param;
        roots[1] = y2 - param;
        roots[2] = y3 - param;
    }
    else if (Q.CompareTo(0) == 0)
    {
        roots[0] = 2 * Math.Cbrt(-q / 2) - param;
        roots[1] = -Math.Cbrt(-q / 2) - param;
        roots[2] = -Math.Cbrt(-q / 2) - param;
    }

    return roots;
}

Complex[] Vieta(double a, double b, double c, double d, double epsilon)
{

    // TODO: use epsilon parameter

    b /= a;
    c /= a;
    d /= a;

    Complex[] roots = new Complex[3];

    double Q = (b * b - 3 * c) / 9;
    double R = (2 * Math.Pow(b, 3) - 9 * b * c + 27 * d) / 54;

    double S = Math.Pow(Q, 3) - Math.Pow(R, 2);

    double phi;

    if (S > epsilon)
    {
        phi = Math.Acos(R / Math.Pow(Q, 3 / 2)) / 3;
        roots[0] = -2 * Math.Sqrt(Q) * Math.Cos(phi) - b / 3;
        roots[1] = -2 * Math.Sqrt(Q) * Math.Cos(phi + 2 * (Math.PI / 3)) - b / 3;
        roots[2] = -2 * Math.Sqrt(Q) * Math.Cos(phi - 2 * (Math.PI / 3)) - b / 3;
    }
    else if (S < epsilon)
    {
        double tmpx = Math.Abs(R) / Math.Pow(Math.Abs(Q), 3.0 / 2);
        double T;

        if (Q > epsilon)
        {
            phi = Math.Log(tmpx + Math.Sqrt(tmpx * tmpx - 1)) / 3;
            T = Math.Sign(R) * Math.Sqrt(Q) * Math.Cosh(phi);

            roots[0] = -2 * T - b / 3;
            roots[1] = new Complex(T - b / 3, Math.Sqrt(3) * Math.Sqrt(Q) * Math.Sinh(phi));
            roots[2] = new Complex(T - b / 3, -Math.Sqrt(3) * Math.Sqrt(Q) * Math.Sinh(phi));
        }
        else if (Q < epsilon)
        {
            phi = Math.Log(tmpx + Math.Sqrt(tmpx * tmpx + 1)) / 3;
            T = Math.Sign(R) * Math.Sqrt(Q) * Math.Sinh(phi);

            roots[0] = -2 * T - b / 3;
            roots[1] = new Complex(T - b / 3, Math.Sqrt(3) * Math.Sqrt(Math.Abs(Q)) * Math.Cosh(phi));
            roots[2] = new Complex(T - b / 3, -Math.Sqrt(3) * Math.Sqrt(Math.Abs(Q)) * Math.Cosh(phi));
        }
        else if (Q.CompareTo(0) == 0)
        {
            T = -Math.Pow(d - b * b * b / 27, 1.0 / 3) - b / 3;
            roots[0] = T;
            roots[1] = new Complex(-(b + T) / 2, 1.0 / 2 * Math.Sqrt(Math.Abs((b - 3 * T) * (b + T) - 4 * c)));
            roots[2] = new Complex(-(b + T) / 2, -1.0 / 2 * Math.Sqrt(Math.Abs((b - 3 * T) * (b + T) - 4 * c)));
        }
    }
    else if (S.CompareTo(0) == 0)
    {
        double T = Math.Sign(R) * Math.Sqrt(Q);

        roots[0] = -2 * T - b / 3;
        roots[1] = T - b / 3;
        roots[2] = T - b / 3;
    }

    return roots;
}