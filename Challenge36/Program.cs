using System;

Console.WriteLine("Given the root of a binary search tree, find the second largest node in the tree");

//	Create test tree
Node root = new Node(5, new Node(2, new Node(1), new Node(3)), new Node(7, new Node(6), new Node(9)));

//	Local function to find second largest value in tree
int FindSecondLargestValue(Node root)
{
	Node index = root;
	Node prevIndex = root;
	
	//	Move all the way to the right to find the largest value
	while(index.Right != null)
	{
		prevIndex = index;
		index = index.Right;
	}
	
	//	Move to the left if possible
	if (index.Left != null)
	{
		//	The second largest value is to the left of the largest value
		return index.Left.Value;
	}
	else
	{
		//	The second largest value is at the parent of the index
		return prevIndex.Value;
	}
}

//	Display tree and test results
Console.WriteLine($"Tree = {root}");
Console.WriteLine($"{nameof(FindSecondLargestValue)} Returned {FindSecondLargestValue(root)}");

root = new Node(5, new Node(2));
Console.WriteLine($"Tree = {root}");
Console.WriteLine($"{nameof(FindSecondLargestValue)} Returned {FindSecondLargestValue(root)}");

root = new Node(10, new Node(5, new Node(1)), new Node(15, new Node(10), new Node(20, null, new Node(30))));
Console.WriteLine($"Tree = {root}");
Console.WriteLine($"{nameof(FindSecondLargestValue)} Returned {FindSecondLargestValue(root)}");


//	Definition of the node class
class Node
{
	public int Value { get; set; }
	public Node Left { get; set; }
	public Node Right { get; set; }
	public Node(int value, Node left = null, Node right = null) =>
		(Value, Left, Right) = (value, left, right);
	public override string ToString() => $"[{Value}, {Left?.ToString() ?? "#"}, {Right?.ToString() ?? "#"}]";
}