namespace BullsAndCows;

public  class Game
{
    private int AttemptsMade = 0;
    private List<string> dictionary = new List<string>();
    private string word;
    private EnteredWord[] enteredWords = new EnteredWord[6];

    public void StartGame()
    {
        LoadDictionary();
        word = dictionary[Random.Shared.Next(0, dictionary.Count)];

        Console.WriteLine("_ _ _ _ _");

        do
        {
            enteredWords[AttemptsMade] = new EnteredWord();
            ReloadMatches(enteredWords[AttemptsMade].Bulls);
            ReloadMatches(enteredWords[AttemptsMade].Cows);

            var enteredWord = Console.ReadLine();
            while (dictionary.Find(x => x == enteredWord) == null)
            {
                Console.WriteLine("Такого слова нет");
                enteredWord = Console.ReadLine();
            }
            enteredWords[AttemptsMade].Word = enteredWord;
            for (int i = 0; i < enteredWord.Length; i++)
            {
                if (word[i] == enteredWord[i])
                    enteredWords[AttemptsMade].Cows[i] = true;
            }
            for (int i = 0; i < enteredWord.Length; i++)
            {
                for (int j = 0; j < enteredWord.Length; j++)
                    if (word[i] == enteredWord[j] && !enteredWords[AttemptsMade].Cows[i])
                        enteredWords[AttemptsMade].Bulls[j] = true;
            }
            Console.Clear();
            Console.WriteLine("_ _ _ _ _");
            for (int i = 0; i <= AttemptsMade; i++)
            {
                for (int j = 0; j < enteredWords[i].Word.Length; j++)
                    if (enteredWords[i].Cows[j])
                    {
                        Console.BackgroundColor = ConsoleColor.Green;
                        Console.Write(enteredWords[i].Word[j]);
                        Console.BackgroundColor = ConsoleColor.Black;
                    }
                    else if (enteredWords[i].Bulls[j])
                    {
                        Console.BackgroundColor = ConsoleColor.Yellow;
                        Console.Write(enteredWords[i].Word[j]);
                        Console.BackgroundColor = ConsoleColor.Black;
                    }
                    else
                    {
                        Console.Write(enteredWords[i].Word[j]);
                    }
                Console.WriteLine();
            }
            AttemptsMade++;
        } while (!CheckingMatches(enteredWords[AttemptsMade - 1].Cows) && AttemptsMade != 6);
    }

    private void LoadDictionary()
    {
        StreamReader f = new StreamReader("russian_nouns.txt");
        while (!f.EndOfStream)
        {
            string s = f.ReadLine();

            if (s.Length == 5) dictionary.Add(s);
        }
        f.Close();
    }
    private bool CheckingMatches(bool[] matches)
    {
        for (int i = 0; i < matches.Length; i++)
        {
            if (!matches[i])
                return false;
        }
        return true;
    }

    private void ReloadMatches(bool[] matches)
    {
        for (int i = 0; i < matches.Length; i++)
        {
            matches[i] = false;
        }
    }

}
