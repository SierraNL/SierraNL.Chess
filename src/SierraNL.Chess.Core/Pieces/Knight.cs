using System;
using SierraNL.Chess.Core.Enums;
using SierraNL.Chess.Core.Consts;

namespace SierraNL.Chess.Core.Pieces
{
    public class Knight: Piece {
        public Knight(Color color): base(color, PieceNames.Knight) {

        }

        public override bool IsMovePossible(Location source, Location destination) {
            bool result = true;

            //Only one in each direction and one on the diagonal allowed

            return result;
        }
    }
}