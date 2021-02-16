using System;
using SierraNL.Chess.Core.Enums;
using SierraNL.Chess.Core.Consts;

namespace SierraNL.Chess.Core.Pieces
{
    public class Pawn: Piece {
        public Pawn(Color color): base(color, PieceNames.Pawn) {

        }

        public override bool IsMovePossible(Location source, Location destination) {
            bool result = true;

            //TODO: color dependent which way you're moving
            //TODO: can move diagonal when it's a capture, need more information to determine that

            return result;
        }
    }
}