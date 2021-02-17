using System;
using SierraNL.Chess.Core.Enums;
using SierraNL.Chess.Core.Consts;

namespace SierraNL.Chess.Core.Pieces
{
    public class Bishop: Piece {
        public Bishop(Color color): base(color, PieceNames.Bishop) {

        }

        public override bool IsMovePossible(Location source, Location destination, Board board) {
            bool result = true;

            if(board.IsFreePath(source, destination)) {
                result = Path.IsDiagonal(source, destination);
            }
            else {
                result = false;
            }

            return result;
        }
    }
}