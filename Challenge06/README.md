# Challenge 06

An XOR linked list is a more memory efficient doubly linked list. Instead of each node holding next and prev fields, it holds a field named both, which is an XOR of the next node and the previous node. Implement an XOR linked list; it has an add(element) which adds the element to the end, and a get(index) which returns the node at index.

**Note:** Having a fully functional XOR list in .NET is not possible. The garbage collector will release from memory the nodes we don't have references to. We can "pin" the nodes and avoid the GC to collect them, but we still can't access the nodes from a pointer because .NET does not allow pointers of managed types. See [Pointer Types](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/unsafe-code#pointer-types).