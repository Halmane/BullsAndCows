namespace BullsAndCows;

public class DictionaryOfRussianNouns
{
    private HashSet<string> _wordsList = new HashSet<string>();

    public DictionaryOfRussianNouns()
    {
        using var f = new StreamReader("Resources\\russian_nouns.txt");
        while (!f.EndOfStream)
        {
            string s = f.ReadLine();

            if (s.Length == 5) _wordsList.Add(s);
        }
    }

    public string GetRandomWord()
    {
        return _wordsList.ElementAt(Random.Shared.Next(0, _wordsList.Count));
    }

    public bool WordFound(string s)
    {
        return _wordsList.Contains(s);
    }
}
