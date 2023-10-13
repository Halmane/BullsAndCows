using System.Linq;

namespace BullsAndCows;

public  class Game
{
    private int _attemptsMade = 0;
    private string _word;
    private DictionaryOfRussianNouns _russianNouns = new DictionaryOfRussianNouns();
    private EnteredWord[] _enteredWords = new EnteredWord[6];

    public void StartGame()
    {
        _word = _russianNouns.GetRandomWord();

        Console.WriteLine("_ _ _ _ _");

        do
        {
            _enteredWords[_attemptsMade] = new EnteredWord();
            ResetMatches(_enteredWords[_attemptsMade].Bulls);
            ResetMatches(_enteredWords[_attemptsMade].Cows);

            var enteredWord = EnterWord();
            _enteredWords[_attemptsMade].Word = enteredWord;
            FindCows(enteredWord);
            FinBulls(enteredWord);
            OutputOfResults(_enteredWords);
            _attemptsMade++;
        } while (!CheckingMatches(_enteredWords[_attemptsMade - 1].Cows) && _attemptsMade != 6);
    }

    private void FindCows(string enteredWord)
    {
        for (int i = 0; i < enteredWord.Length; i++)
        {
            if (_word[i] == enteredWord[i])
                _enteredWords[_attemptsMade].Cows[i] = true;
        }
    }

    private void FinBulls(string enteredWord)
    {
        for (int i = 0; i < enteredWord.Length; i++)
        {
            for (int j = 0; j < enteredWord.Length; j++)
                if (_word[i] == enteredWord[j] && !_enteredWords[_attemptsMade].Cows[i])
                    _enteredWords[_attemptsMade].Bulls[j] = true;
        }
    }

    private string EnterWord()
    {
        var enteredWord = Console.ReadLine();
        while (!_russianNouns.IsContainsWord(enteredWord))
        {
            Console.WriteLine("Такого слова нет");
            enteredWord = Console.ReadLine();
        }
        return enteredWord;
    }

    private void OutputOfResults(EnteredWord[] EnteredWords)
    {
        Console.Clear();
        Console.WriteLine("_ _ _ _ _");
        for (int i = 0; i <= _attemptsMade; i++)
        {
            for (int j = 0; j < EnteredWords[i].Word.Length; j++)
                if (EnteredWords[i].Cows[j])
                {
                    using(new ChangeConsoleColor(ConsoleColor.Green))
                    {
                        Console.Write(EnteredWords[i].Word[j]);
                    }
                }
                else if (EnteredWords[i].Bulls[j])
                {
                    using (new ChangeConsoleColor(ConsoleColor.Yellow))
                    {
                        Console.Write(EnteredWords[i].Word[j]);
                    }
                }
                else
                {
                    Console.Write(EnteredWords[i].Word[j]);
                }
            Console.WriteLine();
        }
    }

    private bool CheckingMatches(bool[] matches)
    {
        return matches.All(x => x);
    }

    private void ResetMatches(bool[] matches)
    {
        for (int i = 0; i < matches.Length; i++)
        {
            matches[i] = false;
        }
    }

}
