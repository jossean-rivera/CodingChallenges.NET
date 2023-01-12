
var list = new ListXOR<int>();
list.Add(1);
list.Add(2);
list.Add(3);
list.Add(4);

Console.WriteLine("Item at index 2 is {0}", list.Get(2));
Console.WriteLine("Done.");


class ListXOR<T>
{
    //  Hold a reference of the nodes to prevent garbage collection
    private readonly List<Node<T>> _nodes = new();
    private unsafe readonly List<ulong> _nodeIds = new();

    private Node<T> _head = null;
    private Node<T> _tail = null;

    public unsafe void Add(T value)
    {
        //  Create a new node to add
        Node<T> node = new(value);

         //  Save the address of the node for debugging purposes only
        ulong nodeId = (ulong)&node;
        _nodeIds.Add(nodeId);

       // Save the node to prevent the garbage collection of the new node
        _nodes.Add(node);


        if (_head is null)
        {
            _head = _tail = node;
        }
        else
        {
            void* nodePtr = &node;
            _tail.both = (void*)((ulong)nodePtr ^ (ulong)_tail.both);
            fixed (void* tailId = &_tail)
            {
                node.both = tailId;
            }
            _tail = node;
        }

    }

    public unsafe T Get(int index)
    {
        void* prevId = default(void*);
        void* nextId = default(void*);

        fixed (Node<T>* headPtr = &_head)
        {
            Node<T>* node = headPtr;
            for (int i = 0; i < index; i++)
            {
                nextId = (void*)((ulong)prevId ^ (ulong)node->both);

                if (nextId != default(void*))
                {
                    prevId = node;
                    node = (Node<T>*)nextId;
                }
                else
                {
                    throw new IndexOutOfRangeException();
                }

            }

            //  The node variable should be pointing to the node at the index
            return node->value;
        }



        return default(T);
    }

    private class Node<T>
    {
        public T value;
        public unsafe void* both;

        public Node(T newValue)
        {
            value = newValue;

            unsafe
            {
                both = default(void*);
            }
        }
    }
}