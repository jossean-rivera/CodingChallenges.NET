using static System.Math;


Run(new int[] { 2, 4, 6, 2, 5 });
Run(new int[] { 5, 1, 1, 5 });

static void Run(int[] nums)
{
    Console.WriteLine("For numbers [{0}]", string.Join(", ", nums));
    Console.WriteLine("LargestSumOfNonAdjancent = {0}", LargestSumOfNonAdjancent(nums));
}

static int LargestSumOfNonAdjancent(int[] arr)
{
    /*
    Non - linear approach
    if (arr == null || arr.Length == 0) return 0;

    if (arr.Length == 1) return arr[0];

    if (arr.Length == 2) return Max(arr[0], arr[1]);

    return Max(
        LargestSumOfNonAdjancent(arr.Skip(1).ToArray()),
        LargestSumOfNonAdjancent(arr.Take(1).ToArray()) + LargestSumOfNonAdjancent(arr.Skip(2).ToArray())
        );
    */

    if (arr == null || arr.Length == 0) return 0;
    if (arr.Length == 1) return arr[0];
    if (arr.Length == 2) return Max(arr[0], arr[1]);

    int[] cache = new int[arr.Length];
    cache[0] = Max(0, arr[0]);
    cache[1] = Max(cache[0], arr[1]);

    for (int i = 2; i < arr.Length; i++)
    {
        cache[i] = Max(arr[i] + cache[i - 2], cache[i - 1]);
    }

    return cache.Last();
}