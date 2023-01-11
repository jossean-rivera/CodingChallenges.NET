using System;
using System.Collections.Generic;
using System.Linq;

int FindMissing(int[] arr)
{
    if (arr == null || arr.Length == 0)
    {
        return 1;
    }

    int i = 1;
    var prevs = new HashSet<int>(arr);

    while (prevs.Contains(i))
    {
        i++;
    }

    return i;
}

int[] inputs = new int[] { 3, 4, -1, 1, 2, 6 };
int result = FindMissing(inputs);

Console.WriteLine("Inputs = [{0}]", string.Join(", ", inputs));
Console.WriteLine("First Missing Number = {0}", result);

//  Create an array with numbers that include the 1 to 200 with 101 missing
inputs = Enumerable.Range(1, 100).Union(Enumerable.Range(102, 99)).OrderBy(_ => Guid.NewGuid().ToString()).ToArray();
result = FindMissing(inputs);
Console.WriteLine("Inputs = [{0}]", string.Join(", ", inputs));
Console.WriteLine("First Missing Number = {0}", result);