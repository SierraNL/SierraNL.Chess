using System;
using SierraNL.Chess.Core.Enums;
using SierraNL.Chess.Core.Consts;

namespace SierraNL.Chess.Core.Pieces
{
    public class Rook: Piece {
        public Rook(Color color): base(color, PieceNames.Rook) {

        }

        public override bool IsMovePossible(Location source, Location destination, Board board) {
            bool result = true;

            if(board.IsFreePath(source, destination)) {
                //Only straight lines allowed
                result = Path.IsStraight(source, destination);
            }
            else {
                result = false;
            }
            
            return result;
        }
    }
}