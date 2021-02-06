using System;
using System.Linq;

int FindMissing(int[] arr)
{
    if (arr == null || arr.Length == 0)
    {
        return 1;
    }

    int lastIndex = arr.Length - 1;

    //  Sort array
    arr = arr.OrderBy(num => num).ToArray();

    int startIndex = 0;

    while (arr[startIndex] < 0)
    {
        if (startIndex == lastIndex)
        {
            return 1;
        }
        startIndex++;
    }

    //  Start index is at the first positive number
    int firstPositiveIndex = startIndex;
    int intToFind = 1;

    while (intToFind == arr[startIndex])
    {
        if (startIndex == lastIndex)
        {
            return intToFind;
        }
        startIndex++;
        intToFind++;
    }

    return intToFind;
}


int result = FindMissing(new int[] { 3, 4, -1, 1, 2, 6 });
Console.WriteLine(result);