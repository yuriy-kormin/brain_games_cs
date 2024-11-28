namespace BrainGames.CLI.Engine;

public class GameEngine
{
    private readonly List<IGame> _games;

    public GameEngine()
    {
        _games = new List<IGame>
        {
            new Calc(),
            new Even(),
        };
    }

    private bool GameLoop()
    {
        Console.Clear();
        Console.WriteLine("Available games:");
        for (int i = 0; i < _games.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_games[i].Description}");
        }

        Console.Write(" Select a game by entering its number (or 'q' to quit): ");
        string input = Console.ReadLine();
        if (int.TryParse(input, out int gameChoice) && gameChoice > 0 && gameChoice <= _games.Count)
        {
            PlayGame(_games[gameChoice - 1]);
        }
        else if (input.ToLower() == "q") return true;
        else Console.WriteLine("Invalid choice."); 

        Console.WriteLine("Want to play again? (Y/N)");
        return Console.ReadLine().ToUpper() == "N";
    }
    
    public void Start()
    {
        Console.WriteLine("Welcome to Brain Games!");

        while (true)
        {
            var WannaExit = GameLoop();
            if (WannaExit) break;
        }
    }

    private void ColorPrint(string result, ConsoleColor color)
    {
        Console.ForegroundColor = color;
        Console.WriteLine(result);
        Console.ResetColor();
    }
    private void Validator(IGame game)
    {
        Console.Write("Your answer: ");
        string userAnswer = Console.ReadLine();

        if (game.ValidateAnswer(userAnswer)) ColorPrint("Correct! Well done.", ConsoleColor.Green); 
        else ColorPrint("Incorrect. Better luck next time.", ConsoleColor.Red); 
    }

    private void QuestionPrint(IGame game)
    {
        var question = game.GetQuestion();
        var text = question.Split(new char[]{'?'},2);
        ColorPrint(text[0], ConsoleColor.Cyan);
        ColorPrint(text[1], ConsoleColor.DarkBlue);
    }

    private void PlayGame(IGame game)
    {
        Console.WriteLine($"  You selected: {game.Description}\n");
        QuestionPrint(game);
        Validator(game);
    }
}