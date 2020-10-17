using System;

/*
 * Given a singly linked list and an integer k, remove the kth last element from the list. k is 
 * guaranteed to be smaller than the length of the list.
 * The list is very long, so making more than one pass is prohibitively expensive.
 * Do this in constant space and in one pass.
 */

void RemoveKthLastNode(Node header, int k)
{
    //  Create node variables for one that will go until the end of the list
    //  Index will be at the node we need to remove and prevIndex will be the
    //  node before the index so that we can change its Next property
    Node end, index, prevIndex;
    end = index = prevIndex = header;

    //  Move the end index K times forward
    for (int i = 0; i < k; i++) end = end.Next;

    //  Move the end index until the it reaches the end of the list
    while (end != null)
    {
        prevIndex = index;
        index = index.Next;
        end = end.Next;
    }

    //  Remove the element at index
    prevIndex.Next = index.Next;
}

void DisplayList(Node header)
{
    while(header != null)
    {
        Console.Write($"[{header.Value}]->");
        header = header.Next;
    }
    Console.WriteLine("|");
}

//  Test
Node list = new Node(1, new Node(2, new Node(3, new Node(4, new Node(5)))));
const int K = 2;

Console.WriteLine($"List before removing the {K}th last element.");
DisplayList(list);
RemoveKthLastNode(list, K);

Console.WriteLine($"List after removing the {K}th last element.");
DisplayList(list);

//  Class definition of a Node
class Node 
{
    public int Value { get; set; }
    public Node Next { get; set; }

    public Node (int value, Node next = null) => (Value, Next) = (value, next);
}