using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SierraNL.Chess.Core
{
    public class Game
    {
        public IEnumerable<Move> Moves { get; private set; }

        public Game() {
            Moves = new List<Move>();
        }

        public bool IsFinished() {
            return Moves.Any(x => x.IsCheckMate);
        }

        public void AddMove(Move move)
        {
            ((List<Move>)Moves).Add(move);
        }

        public override string ToString()
        {
            var builder = new StringBuilder();

            builder.AppendLine("|White\t|Black\t|");
            int lines=0;
            while(lines < Moves.Count()) {
                builder.AppendLine($"|{Moves.ElementAt(lines)}\t|{Moves.ElementAtOrDefault(lines+1)}\t|");
                lines += 2;
            }

            return builder.ToString();
        }
    }
}