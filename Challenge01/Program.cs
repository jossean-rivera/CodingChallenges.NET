using System;
using System.Linq;
using System.Diagnostics;

Console.WriteLine("Given a list of numbers and a number k, return whether any two numbers from the list add up to k.");
Console.WriteLine("For example, given [10, 15, 3, 7] and k of 17, return true since 10 + 7 is 17.\n\n");

//  Local function to determine if two elements 
//  in array have a sum equal to a target
bool TwoSum(int[] arr, int target)
{
    //  Initialize indexes to find the target
    int i = 0, j = arr.Length - 1;

    //  Sort array (Time complexity: O(n log n))
    arr = arr.OrderBy(num => num).ToArray();

    //  Iterate while the indexes are within the range of the array
    while(i < arr.Length && j >= 0)
    {
        //  Get the sum of items at i and j
        int sum = arr[i] + arr[j];

        if (sum > target)
        {
            //  Decrement j
            j--;

            if (i == j)
            {
                //  Indexes cannot be the same
                j--;
            }
        }
        else if (sum < target)
        {
            //  Increment i
            i++;

            if (i == j)
            {
                //  Indexes cannot be the same
                i++;
            }
        }
        else 
        {
            //  The sum is equal to the target
            return true;
        }
    }

    //  We never found a sum equal to the target
    return false;
}

#region Tests

//  Local function to time performance of a delegate
(T Result, TimeSpan Performace) Time<T>(Func<T> func)
{
    Stopwatch stopwatch = Stopwatch.StartNew();
    T result = func();
    stopwatch.Stop();
    return (result, stopwatch.Elapsed);
}

int[] inputs;
int target;
bool result;
TimeSpan performance;

//  Test 1
inputs = new int[] { 10, 15, 3, 7 };
target = 17;
Console.WriteLine("Test 1");
Console.WriteLine("Inputs: Array = [10, 15, 3, 7], Target = 17");
Console.WriteLine("Expected output: True (10 + 7 == 17)");

(result, performance) = Time(() => TwoSum(inputs, target));
Console.WriteLine($"Output: {result}");
Console.WriteLine($"Time Performance: {performance.TotalMilliseconds:f2}ms");
Console.WriteLine("\n");

//  Test 2
inputs = new int[] { 4, 3, 9, 1 };
target = 8;
Console.WriteLine("Test 2");
Console.WriteLine("Inputs: Array = [4, 3, 9, 1], Target = 8");
Console.WriteLine("Expected output: False");

(result, performance) = Time(() => TwoSum(inputs, target));
Console.WriteLine($"Output: {result}");
Console.WriteLine($"Time Performance: {performance.TotalMilliseconds:f2}ms");
Console.WriteLine("\n");

//  Test 3
inputs = new int[] { 13, 1, 3, 11, 7, 8, 2, 5 };
target = 8;
Console.WriteLine("Test 3");
Console.WriteLine("Inputs: Array = [13, 1, 3, 11, 7, 8, 2, 5], Target = 15");
Console.WriteLine("Expected output: True");

(result, performance) = Time(() => TwoSum(inputs, target));
Console.WriteLine($"Output: {result}");
Console.WriteLine($"Time Performance: {performance.TotalMilliseconds:f2}ms");
Console.WriteLine("\n");

Console.WriteLine("Generating random items for testing");
for (int i = 0; i < 7; i++)
{
    int n = (int)Math.Pow(10f, i + 1);
    Random rnd = new Random();
    target = rnd.Next() % 100;
    inputs = new int[n];

    for(int j = 0; j < n; j++)
    {
        inputs[j] = rnd.Next() % 100;
    }

    Console.WriteLine($"Test {i + 4}");
    Console.WriteLine($"Array Size = {n}");

    (result, performance) = Time(() => TwoSum(inputs, target));
    Console.WriteLine($"Output: {result}");
    Console.WriteLine($"Time Performance: {performance.TotalMilliseconds:f2}ms");
    //Console.WriteLine($"Array = [{string.Join(", ", inputs)}]");
    Console.WriteLine("\n");
}
#endregion