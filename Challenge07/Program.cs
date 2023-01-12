// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

int NumberOfEncodings(string s) 
{
    if (s.StartsWith('0')) 
    {
        return 0;
    }
    else if (s.Length <= 1)
    {
        return 1;
    }

    int total = 0;
    if (int.Parse(s.Substring(0, 2)) <= 26) 
    {
        total += NumberOfEncodings(s.Substring(2));
    }
}