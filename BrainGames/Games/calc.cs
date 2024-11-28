namespace BrainGames.CLI.Engine;

public class Calc:IGame
{
    public string Description => "calc";

    private int Num1 { get; set; }
    private int Num2 { get; set; }

    public string GetQuestion()
    {
        Random random = new Random();
        Num1 = random.Next(1, 10);
        Num2 = random.Next(1, 10);
        
        return $"What is a summ of {Num1} + {Num2}?";
    }

    public bool ValidateAnswer(string answer)
    {
        int.TryParse(answer, out int result);
        return result == (Num1+Num2);
    }
}