
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

    total += NumberOfEncodings(s.Substring(1));
    return total;
}

void RunTest(string input)
{
    Console.WriteLine("Input = {0}", input);
    Console.WriteLine("NumberOfEncodings = {0}", NumberOfEncodings(input));
}

RunTest("111");