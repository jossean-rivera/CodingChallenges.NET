
using System.Collections;
/// <summary>
/// A trie data structure for words
/// </summary>
internal class AlphabetTrie : IEnumerable<string>
{
    private const int AlphabetSize = 'Z' - 'A';
    private readonly Node[] _root = new Node[AlphabetSize];

    public void AddWord(string word)
    {
        word = word.Trim().ToUpper();
        if (string.IsNullOrWhiteSpace(word)) return;

        char c;
        Node[] index = _root;

        for (int i = 0; i < word.Length; i++)
        {
            c = word[i];
            ref Node node = ref index[c - 'A'];

            node ??= new Node(c);

            if (i == word.Length - 1)
            {
                node.IsTerminal = true;
            }

            index = node.Children;
        }
    }

    public IEnumerable<string> GetWordsWithPrefix(string prefix) 
    {
        prefix = prefix.ToUpper();
        char c;

        Node[] index = _root;

        for (int i = 0; i < prefix.Length; i++)
        {
            c = prefix[i];

            Node node = index[c - 'A'];

            if (node == null)
            {
                return Enumerable.Empty<string>();
            }

            index = node.Children;
        }

        return GetPossibleWordsFromRoot(index, prefix) ?? Enumerable.Empty<string>();
    }

    private IEnumerable<string>? GetPossibleWordsFromRoot(Node[] root, string prefix)
    {
        if (root == null)
        {
            return new[] { prefix };
        }

        HashSet<string>? result = null;

        foreach (Node node in root.Where(n => n is not null))
        {
            if (node.IsTerminal)
            {
                result ??= new();
                result.Add(prefix + node.Letter);
            }

            IEnumerable<string>? subresult = GetPossibleWordsFromRoot(node.Children, prefix + node.Letter);

            if (subresult is not null)
            {
                foreach (string s in subresult)
                {
                    result ??= new();
                    result.Add(s);
                }
            }

        }

        return result;
    }

    /// <inheritdoc />
    public IEnumerator<string> GetEnumerator() => GetWordsWithPrefix(string.Empty).GetEnumerator();

    /// <inheritdoc />
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();


    private class Node
    {
        public char Letter;
        public bool IsTerminal;
        public Node[] Children;

        public Node(char letter) 
        {
            Letter = letter;
            Children = new Node[AlphabetSize];
        }

        public override string ToString()
        {
            if (IsTerminal)
            {
                return $"{Letter} [END]";
            }

            return Letter.ToString();
        }
    }
}
