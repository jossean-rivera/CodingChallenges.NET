

Node<int> root = Node<int>.CreateTestingTree();

Console.WriteLine("For Tree: {0}", root);
Console.WriteLine("Amount of Unival Trees = {0}", CountUnivalTrees(root));

int CountUnivalTrees<T>(Node<T> root)
{
    static int Helper(Node<T>? n, out T? commonValue, out bool foundCommonValue)
    {
        if (n == null)
        {
            commonValue = default;
            foundCommonValue = false;
            return 0;
        }


        if (n.Left == null && n.Right == null)
        {
            commonValue = n.Value;
            foundCommonValue = true;
            return 1;
        }

        int left = Helper(n.Left, out T? leftValue, out bool foundLeftValue);
        int right = Helper(n.Right, out T? rightValue, out bool foundRightValue);
        int total = left + right;

        if (foundLeftValue && foundRightValue &&
            n.Value!.Equals(leftValue) && n.Value!.Equals(rightValue))
        {
            total++;
            commonValue = leftValue;
            foundCommonValue = true;
        }
        else
        {
            commonValue = default;
            foundCommonValue = false;
        }

        return total;
    }


    return Helper(root, out T _, out bool _);
}

class Node<T>
{
    public T Value { get; set; }
    public Node<T>? Left { get; set; }
    public Node<T>? Right { get; set; }

    public Node(T value, Node<T>? left = null, Node<T>? right = null)
    {
        Value = value;
        Left = left;
        Right = right;
    }

    public override string ToString() => $"[Value: {Value}; Left: {Left?.ToString() ?? "#"}; Right: {Right?.ToString() ?? "#"}]";

    public static Node<int> CreateTestingTree()
    {
        // Create the tree
        /*
         *     0
              / \
             1   0
                / \
               1   0
              / \
             1   1
         */
        return new Node<int>(0, left: new(1), right: new(0, new(1, new(1), new(1)), new(0)));
    }
}