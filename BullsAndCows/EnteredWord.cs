namespace BullsAndCows;

public class EnteredWord
{
    public string Word {  get; set; }
    public bool[] Bulls { get; set; }
    public bool[] Cows {  get; set; }

    public EnteredWord() 
    {
        Word = string.Empty;
        Bulls = new bool[5];
        Cows = new bool[5];
    }
}
