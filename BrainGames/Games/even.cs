namespace BrainGames.CLI.Engine;

public class Even:IGame
{
    public string Description => "Even or not";
    
    private int Num {get; set;} 
    private bool Answer { get; set; }
    public string GetQuestion()
    {
        Random random = new Random();
        Num = random.Next(1, 1000);
        Answer = Num % 2 == 0;
        return $"Is value even(Y/N)?{Num}";
    }

    public bool ValidateAnswer(string answer)
    {
        var result = (answer?.ToUpper() ?? "") == "Y";
        return result == Answer;
    }
}