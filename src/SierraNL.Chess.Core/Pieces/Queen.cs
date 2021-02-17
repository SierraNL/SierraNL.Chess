using System;
using SierraNL.Chess.Core.Enums;
using SierraNL.Chess.Core.Consts;

namespace SierraNL.Chess.Core.Pieces
{
    public class Queen: Piece {
        public Queen(Color color): base(color, PieceNames.Queen) {

        }

        public override bool IsMovePossible(Location source, Location destination, Board board) {
            bool result = true;

            if(board.IsFreePath(source, destination)) {
                //Only straight lines and diagonal allowed
                result = Path.IsStraight(source, destination) || Path.IsDiagonal(source, destination);
            }
            else {
                result = false;
            }
            
            return result;
        }
    }
}