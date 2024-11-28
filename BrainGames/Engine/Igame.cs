namespace BrainGames.CLI.Engine;

public interface IGame
{
    string Description { get; }
    string GetQuestion();
    bool ValidateAnswer(string userAnswer);
}