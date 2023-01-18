
using System.Collections;
using System.Xml.Linq;

/// <summary>
/// A trie data structure for words
/// </summary>
internal class AlphabetTrie : IEnumerable<string>
{
    private readonly Dictionary<char, Node> _root2 = new();

    public void AddWord(string word)
    {
        if (string.IsNullOrWhiteSpace(word)) return;

        char c;
        Dictionary<char, Node> index = _root2;

        for (int i = 0; i < word.Length; i++)
        {
            c = word[i];
            Node? node;
            if (!index.ContainsKey(c))
            {
                node = new(c);
                index[c] = node;
            }
            else
            {
                node = index[c];
            }

            if (i == word.Length - 1)
            {
                node.IsTerminal = true;
            }

            index = node.Children;
        }
    }

    public IEnumerable<string> GetWordsWithPrefix(string prefix)
    {
        prefix = prefix.ToLower();
        char c;

        Dictionary<char, Node> index = _root2;

        for (int i = 0; i < prefix.Length; i++)
        {
            c = prefix[i];

            if (!index.ContainsKey(c))
            {
                return Enumerable.Empty<string>();
            }

            Node node = index[c];

            index = node.Children;
        }

        return GetPossibleWordsFromRoot(index, prefix) ?? Enumerable.Empty<string>();
    }

    private IEnumerable<string>? GetPossibleWordsFromRoot(Dictionary<char, Node> root, string prefix)
    {
        if (root == null)
        {
            return new[] { prefix };
        }

        HashSet<string>? result = null;

        foreach (KeyValuePair<char, Node> item in root)
        {
            Node node = item.Value;

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
        public Dictionary<char, Node> Children;

        public Node(char letter) 
        {
            Letter = letter;
            Children = new();
        }

        public override string ToString() => IsTerminal ? $"{Letter} [END]" : Letter.ToString();
    }
}
