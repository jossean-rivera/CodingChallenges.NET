using System;

Console.WriteLine("Given an array of integers, return a new array such that each element at index i of the new array is the product of all the numbers in the original array except the one at i.");
Console.WriteLine("For example, if our input was [1, 2, 3, 4, 5], the expected output would be [120, 60, 40, 30, 24]. If our input was [3, 2, 1], the expected output would be [2, 3, 6].\n\n");

//  Local function to get the products of the input array
int[] Products(int[] arr)
{
    //  Calculate the total product of all the elements in the array
    int totalProduct = 0;

    for(int i = 0; i < arr.Length; i++)
    {
        if (i == 0)
        {
            totalProduct = arr[i];
        }
        else
        {
            totalProduct *= arr[i];
        }
    }

    //  Assign each item in the array the division of the total product and item
    for (int i = 0; i <arr.Length; i++)
    {
        arr[i] = totalProduct / arr[i];
    }

    //  Return processed array
    return arr;
}

int[] inputs = new int[]{1, 2, 3, 4, 5};
Console.WriteLine($"Inputs = {string.Join(", ", inputs)}");
Console.WriteLine($"Output = {string.Join(", ", Products(inputs))}\n\n");

inputs = new int[]{4, 5, 2, 6, 1};
Console.WriteLine($"Inputs = {string.Join(", ", inputs)}");
Console.WriteLine($"Output = {string.Join(", ", Products(inputs))}");