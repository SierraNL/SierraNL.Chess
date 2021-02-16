using System;
using SierraNL.Chess.Core.Enums;
using SierraNL.Chess.Core.Consts;

namespace SierraNL.Chess.Core.Pieces
{
    public class Bishop: Piece {
        public Bishop(Color color): base(color, PieceNames.Bishop) {

        }

        public override bool IsMovePossible(Location source, Location destination) {
            //TODO: only moves that don't cross other pieces are possible, how to do this without board knowledge
            bool result = true;

            //Only diagonal allowed

            return result;
        }
    }
}