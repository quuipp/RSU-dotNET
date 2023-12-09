﻿string inputStr;

if (args.Length == 0 || args[0] == "-c")
{
    Console.WriteLine("Enter number set: ");
    inputStr = Console.ReadLine();
    inputStr = string.Join(' ', inputStr.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries));
     
}
else if (args[0] == "-f" && args.Length == 2)
{
    using var sr = File.OpenText(args[1]);
    inputStr = sr.ReadToEnd();
}
else
{
    throw new Exception("Error: incorrect arguments");
}

var separations = new[] { ' ' };
var sequence = inputStr?.Split(separations, StringSplitOptions.RemoveEmptyEntries);

var sum = 0.0;

var composition = 1.0;
var harmonSum = 0.0;
var counter = 0;
Console.WriteLine("Sandman entered: ");
if (sequence != null)
{
    foreach (var strNumber in sequence)
    {

        var num = 0.0;
        if (double.TryParse(strNumber, out num))
        {
            Console.Write("{0} ", num);
            sum += num;
            harmonSum += 1 / num;
            composition *= num;
            ++counter;
        }
        else
        {
            Console.Write("[#Not a number = {0}] ", strNumber);
        }
    }

    Console.WriteLine($"{Environment.NewLine}Sum = {sum}");
}

Console.WriteLine("Average = {0}", sum / counter);

if (counter % 2 == 0 && composition < 0)
{
    Console.WriteLine("The geometric average = Error ({composition})^(1/{counter})");
}
else
{
    Console.WriteLine("The geometric average = {0}", Math.Pow(composition, 1.0 / counter));
}

Console.WriteLine("Average harmonic = {0}", counter / harmonSum);

Console.ReadKey();