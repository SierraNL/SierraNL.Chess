using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SierraNL.Chess.Core.Enums;

namespace SierraNL.Chess.Core
{
    public class Game
    {
        public IEnumerable<Move> Moves { get; private set; }
        public Board Board {get; private set;}

        public Game() {
            Moves = new List<Move>();
            Board = new Board();
        }

        public bool IsFinished { 
            get {
                return Moves.Any(x => x.IsCheckMate);
            }
        }

        public void AddMove(Move move)
        {
            if(Board.TryProcessMove(move)) {
                //TODO: check for checkmate
                //move.IsCheckMate = true;
                ((List<Move>)Moves).Add(move);
            }
        }

        public Color CurrentPlayer {
            get {
                if(!Moves.Any()) {
                    return Color.White;
                }
                else {
                    return Moves.Count() % 2 == 0 ? Color.White : Color.Black;
                }
            }
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