using System;
using BrainGames.CLI.Engine;

namespace BrainGames.CLI
{
    class Program
    {
        static void Main(string[] args)
        {
            var engine = new GameEngine();
            engine.Start();
        }
    }
}