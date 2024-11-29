namespace BrainGames.CLI.Engine;

public class Calc:IGame
{
    public string Description => "Calc expression";

    private int Num1 { get; set; }
    private int Num2 { get; set; }
    private char Op { get; set; }
    
    private double Answer { get; set; }

    public string GetQuestion()
    {
        var Operations = new Dictionary<char,Func<int,int,int>>()
        {
            { '+', (a,b) => a+b },
            { '-', (a,b) => a-b },
            { '*', (a,b) => a*b },
            // { '/', (a,b) => a/b }, # Todo add validator, exclude 0 devide
        };
        
        Random random = new Random();
        Num1 = random.Next(1, 10);
        Num2 = random.Next(1, 10);
        Op = Operations.Keys.ElementAt(random.Next(Operations.Count));
        Answer = Operations[Op](Num1, Num2);
        
        return $"What is result of expression?{Num1} {Op} {Num2} ";
    }

    public bool ValidateAnswer(string answer)
    {
        double.TryParse(answer, out double result);
        return result == Answer;
    }
}