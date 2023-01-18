
AlphabetTrie trie = new();
trie.AddWord("dog");
trie.AddWord("deer");
trie.AddWord("deal");

Console.WriteLine("Words in the trie:");
foreach (var word in trie)
{
    Console.WriteLine("\t{0}", word);
}

Console.WriteLine();
Console.WriteLine("Words starting with 'de':");


foreach (string s in trie.GetWordsWithPrefix("de"))
{
    Console.WriteLine("\t{0}", s);
}

Console.WriteLine("Words starting with 'd':");

foreach (string s in trie.GetWordsWithPrefix("d"))
{
    Console.WriteLine("\t{0}", s);
}

Console.WriteLine("Words starting with 'a':");

foreach (string s in trie.GetWordsWithPrefix("a"))
{
    Console.WriteLine("\t{0}", s);
}

Console.WriteLine("Done.");