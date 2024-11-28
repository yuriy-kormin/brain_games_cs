namespace BrainGames.CLI.Engine;

public interface IGame
{
    string Description { get; }
    string GetQuestion();
    bool ValidateAnswer(string userAnswer);
}

public class GameEngine
{
    private readonly List<IGame> _games;

    public GameEngine()
    {
        _games = new List<IGame>
        {
            new Calc(),
            // new WordGame()
        };
    }

    public void Start()
    {
        Console.WriteLine("Welcome to Brain Games!");

        // Display available games
        Console.WriteLine("Available games:");
        for (int i = 0; i < _games.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_games[i].Description}");
        }

        Console.Write("Select a game by entering its number: ");
        if (int.TryParse(Console.ReadLine(), out int gameChoice) && gameChoice > 0 && gameChoice <= _games.Count)
        {
            PlayGame(_games[gameChoice - 1]);
        }
        else
        {
            Console.WriteLine("Invalid choice. Exiting.");
        }
    }

    private void PlayGame(IGame game)
    {
        Console.WriteLine($"You selected: {game.Description}");
        Console.WriteLine(game.GetQuestion());

        Console.Write("Your answer: ");
        string userAnswer = Console.ReadLine();

        if (game.ValidateAnswer(userAnswer))
        {
            Console.WriteLine("Correct! Well done.");
        }
        else
        {
            Console.WriteLine("Incorrect. Better luck next time.");
        }
    }
}