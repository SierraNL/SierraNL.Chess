using SierraNL.Chess.Core.Enums;
using SierraNL.Chess.Core.Consts;
using System.Collections.Generic;
using System.Linq;

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

        public override IEnumerable<Location> PossibleMoves(Location source, Board board) 
        {
            var possibleFields = board.GetDiagonalFields(source); 
            possibleFields = possibleFields.Where(x => board.IsFreePath(source, x.Location) && (x.IsEmpty() || x.HasPieceOfOppositeColor(Color)));

            return possibleFields.Select(x => x.Location);
        }

        
    }
}