using System;
using SierraNL.Chess.Core;

namespace SierraNL.Chess.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var game = new Game();
            System.Console.WriteLine("First move:");
            var move = new Move(new Location('e', 2), new Location('e', 4));
            System.Console.WriteLine(move);
            game.AddMove(move);
            System.Console.WriteLine("Current game:");
            System.Console.Write(game.ToString());
        }
    }
}
