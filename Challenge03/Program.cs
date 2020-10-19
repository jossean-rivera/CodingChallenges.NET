using System;
using System.Collections;

Console.WriteLine("Given the root to a binary tree, implement Serialize(root), which serializes the tree into a string, and Deserialize(s), which deserializes the string back into the tree.");

//  Create test tree
//              5
//          /       \
//         2         8
//        / \       / \
//       1   3     6   9
Node root = new Node(5, left: new Node(2, new Node(1), new Node(3)), right: new Node (8, new Node(6), new Node(9)));

//  Local method to serialize a tree
//  Use the ToString() action to serialize the tree
string Serialize(Node root) => root?.ToString();

//  Local action to deserialize the tree
Node Deserialize(string tree)
{
    //  Null or empty string will return a null 
    if (string.IsNullOrEmpty(tree))
    {
        return null;
    }

    Node Helper(IEnumerator enumerator)
    {
        if (enumerator.MoveNext())
        {
            //  Get the current value of the enumerator
            string current = enumerator.Current as string;

            if (current == "#")
            {
                return null;
            }

            //  Get the value
            int value = int.Parse(enumerator.Current as string);

            //  Create new node with the value and process the left and right side
            return new Node(value, Helper(enumerator), Helper(enumerator));
        }

        return null;
    }

    //  Split tree with space
    string[] nodes = tree.Split(' ');

    //  Get the enumerator of the node strings
    IEnumerator enumerator = nodes.GetEnumerator();

    return Helper(enumerator);
}

//  Run actions
string t = Serialize(root);
Console.WriteLine($"Serialize = {t}");
Node r = Deserialize(t);
Console.WriteLine($"Deserialize (and Serialized again) = {r}");

//  Class definition of a Node
class Node
{
    public int Value { get; set; }

    public Node Left { get; set; }

    public Node Right { get; set; }

    public Node(int value, Node left = null, Node right = null) =>
        (Value, Left, Right) = (value, left, right);

    // We use the ToString() action that every object has to serialize the node
    // When we run this action, left and right will run its own ToString action
    // recursively 
    public override string ToString() => $"{Value} {Left?.ToString() ?? "#"} {Right?.ToString() ?? "#"}";
}

