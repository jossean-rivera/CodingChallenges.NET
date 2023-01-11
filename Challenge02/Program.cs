
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

IEnumerable<int> ProductsWithoutDivision(IList<int> arr) 
{
    if (!arr.Any()) 
    {
        return Enumerable.Empty<int>();
    }

    if (arr.Count == 1) 
    {
        return arr.ToArray();
    }

    //  Create a list of prefix products and sufix products
    ICollection<int> prefixes = new List<int>(capacity: arr.Count);
    ICollection<int> suffixes = new List<int>(capacity: arr.Count);

    foreach (int num in arr) 
    {
        int prefix = num;

        if (prefixes.Any()) 
        {
            prefix *= prefixes.Last();
        }        

        prefixes.Add(prefix);
    }

    foreach (int num in arr.Reverse()) 
    {
        int sufix = num;

        if (suffixes.Any()) 
        {
            sufix *= suffixes.Last();
        }

        suffixes.Add(sufix);
    }

    suffixes = suffixes.Reverse().ToList();

    ICollection<int> products = new List<int>(capacity: arr.Count);

    //  Add the first item
    products.Add(suffixes.ElementAtOrDefault(1));

    //  Add the items in the middle
    for (int i = 1; i <= arr.Count - 2; i++) 
    {
        int newProduct = prefixes.ElementAt(i - 1) * suffixes.ElementAt(i + 1);
        products.Add(newProduct);
    }

    //  Add the last item
    products.Add(prefixes.ElementAt(arr.Count - 2));

    return products;
}

int[] inputs = new int[]{1, 2, 3, 4, 5};
Console.WriteLine($"Inputs = {string.Join(", ", inputs)}");
Console.WriteLine($"Output = {string.Join(", ", Products(inputs))}\n\n");

inputs = new int[]{4, 5, 2, 6, 1};
Console.WriteLine($"Inputs = {string.Join(", ", inputs)}");
Console.WriteLine($"Output = {string.Join(", ", Products(inputs))}\n\n");


Console.WriteLine("Without Using Division:\n");
inputs = new int[]{1, 2, 3, 4, 5};
Console.WriteLine($"Inputs = {string.Join(", ", inputs)}");
Console.WriteLine($"Output = {string.Join(", ", ProductsWithoutDivision(inputs))}\n\n");

inputs = new int[]{4, 5, 2, 6, 1};
Console.WriteLine($"Inputs = {string.Join(", ", inputs)}");
Console.WriteLine($"Output = {string.Join(", ", ProductsWithoutDivision(inputs))}");