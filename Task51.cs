using System.Text;

Console.WriteLine(" if file, enter 1, if  console, enter 2");
int input_flag = Convert.ToInt16(Console.ReadLine());
Console.WriteLine("Enter the desired flag ");
string flag = Console.ReadLine();
if (input_flag == 1)
{
    Console.WriteLine("enter the path to the file: ");
    string file = Console.ReadLine();
    if (File.Exists(file))
    {
        //
        string input = File.ReadAllText(file);
        if (String.Compare(flag, "a") == 0)
        {
            flag_a(input);
        }
        if (String.Compare(flag, "b") == 0)
        {
            Console.WriteLine(flag_b(input));
        }
        if (String.Compare(flag, "c") == 0)
        {
            Console.WriteLine(flag_c(input));
        }
        if (String.Compare(flag, "d") == 0)
        {
            Console.WriteLine(flag_d(input));
        }
        if (String.Compare(flag, "e") == 0)
        {
            Console.WriteLine((flag_e(input)));
        }
    }
    else
        Console.WriteLine("file does not exist");
}
else if (input_flag == 2)
{
    string input = Console.ReadLine();
        if (String.Compare(flag, "a") == 0)
        {
            flag_a(input);
        }
        if (String.Compare(flag, "b") == 0)
        {
            Console.WriteLine(flag_b(input));
        }
        if (String.Compare(flag, "c") == 0)
        {
            Console.WriteLine(flag_c(input));
        }
        if (String.Compare(flag, "d") == 0)
        {
            Console.WriteLine(flag_d(input));
        }
        if (String.Compare(flag, "e") == 0)
        {
            Console.WriteLine((flag_e(input)));
        }
}
else Console.WriteLine("incorrect input");

void flag_a(string input)
{
    StringBuilder result = new StringBuilder();
    string[] words = input.Split(' ');
    Array.Sort(words, StringComparer.InvariantCultureIgnoreCase);
    for (int i = 0; i < words.Length; i++)
    {
        Console.WriteLine(words[i]);
        result.Append(words[i][words[i].Length - 1]);
    }
    Console.WriteLine($"resulting word: {result.ToString()} ");
}
// !
string flag_b(string input)
{
    string[] words = input.Split(' ');
    StringBuilder sb = new StringBuilder();

    for (int i = 0; i < words.Length; i++)
    {
        StringBuilder wordBuilder = new StringBuilder(words[i]);
        wordBuilder[0] = char.ToUpper(wordBuilder[0]);
        wordBuilder[wordBuilder.Length - 1] = char.ToLower(wordBuilder[wordBuilder.Length - 1]);
        words[i] = wordBuilder.ToString();
    }

    return string.Join(" ", words);
}
int flag_c(string input)
{
    int count = 0;
    Console.WriteLine("enter the word you want to count: ");
    string searchWord = Console.ReadLine();
    string[] words = input.Split(new [] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
    foreach (string word in words)
    {
        if (String.Compare(word, searchWord) == 0) count++;
    }
    return count;
}
string flag_d(string input)
{
    Console.WriteLine("enter a replacement word: ");
    string replacement = Console.ReadLine();
    string[] words = input.Split(' ');
    words[words.Length - 2] = replacement;
    return string.Join(" ", words);
}
string flag_e(string input)
{
    Console.WriteLine("enter k: ");
    int k = Convert.ToInt16(Console.ReadLine());
    string[] words = input.Split(' ');
    int count = 0;
    foreach (string word in words)
    {
        if (char.IsUpper(word[0]))
            count++;
        if (count == k)
            return word;

    }
    Console.WriteLine("not found");
    return null;
}