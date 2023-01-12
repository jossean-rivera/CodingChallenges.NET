using System.Runtime.InteropServices;

using var list = new ListXOR<int>();

Console.WriteLine("Adding items 1, 2, 3, 4, and 5");
list.Add(1);
list.Add(2);
list.Add(3);
list.Add(4);
list.Add(5);

Console.WriteLine("Item at index 2 is {0}", list.Get(2));
Console.WriteLine("Done.");

class ListXOR<T> : IDisposable
{
    //  Save the pinned handles so that we can free them once we're done with the list
    private readonly List<GCHandle> _nodeHandles = new();

    //  .NET doesn't allow pointers of managed types of the GC.
    //  We can get the address of the nodes but we can't access the nodes from the address.
    //  So, we'll keep a dictionary of the node addresses as the keys, and the actual node as the value for the key.
    private readonly Dictionary<nint, Node> _nodeIds = new();

    private nint _headId;
    private nint _tailId;


    public unsafe void Add(T value)
    {
        //  Create a new node to add
        Node node = new(value);

        //  Save the address of the node
        GCHandle handle = GCHandle.Alloc(node, GCHandleType.Pinned);
        _nodeHandles.Add(handle);
        nint nodeId = handle.AddrOfPinnedObject();
        _nodeIds.Add(nodeId, node);


        if (_headId == default)
        {
            _headId = _tailId = nodeId;
        }
        else
        {
            //  Get the node that the tails point to
            Node tail = _nodeIds[_tailId];

            //  Update the link of the tail node
            tail.both = nodeId ^ tail.both;

            //  Update the link of the new node
            node.both = _tailId;

            //  Set the tail to the new node
            _tailId = nodeId;
        }

    }

    public unsafe T Get(int index)
    {
        nint prevId = default;
        nint nextId = default;

        //  Create an iterator variable starting with head
        nint nodeId = _headId;
        Node node = null;

        for (int i = 0; i <= index; i++)
        {
            //  Get the node that the pointer is refrencing
            node = _nodeIds[nodeId];

            //  Move to the next node
            nextId = prevId ^ node.both;

            if (nextId != default)
            {
                prevId = nodeId;
                nodeId = nextId;
            }
            else
            {
                throw new IndexOutOfRangeException();
            }

        }

        //  The node variable should be pointing to the node at the index
        return node.value;
    }

    public void Dispose()
    {
        //  Release all the GC handles to unpinned the addresses
        foreach (GCHandle handle in _nodeHandles)
        {
            handle.Free();
        }
    }

    private class Node
    {
        public T value;
        public nint both;

        public Node(T newValue)
        {
            value = newValue;
            both = default;
        }
    }
}