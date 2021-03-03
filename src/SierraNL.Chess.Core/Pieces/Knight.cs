using SierraNL.Chess.Core.Enums;
using SierraNL.Chess.Core.Consts;
using System.Collections.Generic;
using System.Linq;

namespace SierraNL.Chess.Core.Pieces
{
    public class Knight: Piece {
        public Knight(Color color): base(color, PieceNames.Knight) {

        }

        public override bool IsMovePossible(Location source, Location destination, Board board) {
            bool result = false;

            //Only one in each direction and one on the diagonal allowed
            if( destination.Number == source.Number + 1 || destination.Number == source.Number - 1 && 
                ((short)destination.Letter == (short)source.Letter + 2 || (short)destination.Letter == (short)source.Letter - 2)) {
                result = true;
            }
            else if(destination.Number == source.Number + 2 || destination.Number == source.Number - 2 && 
                    ((short)destination.Letter == (short)source.Letter + 1 || (short)destination.Letter == (short)source.Letter - 1)) {
                result = true;
            }

            return result;
        }

        public override IEnumerable<Location> PossibleMoves(Location source, Board board) 
        {
            //Get all 1 step + 1 step diagonal fields from source
            var possibleFields = GetPossibleFields(source, board);
            //Checking for a free path isn't needed for knight
            possibleFields = possibleFields.Where(x => x.IsEmpty() || x.HasPieceOfOppositeColor(Color));

            return possibleFields.Select(x => x.Location);
        }

        private IEnumerable<Field> GetPossibleFields(Location source, Board board)
        {
            var result = new List<Field>();

            if(source.StepsToLeftEdge() > 1) {
                if(source.StepsToTopEdge() > 0) {
                    result.Add(board.GetField((char)(source.Letter-2), (short)(source.Number+1)));
                }
                if(source.StepsToBottomEdge() > 0) {
                    result.Add(board.GetField((char)(source.Letter-2), (short)(source.Number-1)));
                }
            }
            if(source.StepsToRightEdge() > 1) {
                if(source.StepsToTopEdge() > 0) {
                    result.Add(board.GetField((char)(source.Letter+2), (short)(source.Number+1)));
                }
                if(source.StepsToBottomEdge() > 0) {
                    result.Add(board.GetField((char)(source.Letter+2), (short)(source.Number-1)));
                }
            }
            if(source.StepsToTopEdge() > 1) {
                if(source.StepsToLeftEdge() > 0) {
                    result.Add(board.GetField((char)(source.Letter-1), (short)(source.Number+2)));
                }
                if(source.StepsToRightEdge() > 0) {
                    result.Add(board.GetField((char)(source.Letter+1), (short)(source.Number+2)));
                }
            }
            if(source.StepsToBottomEdge() > 1) {
                if(source.StepsToLeftEdge() > 0) {
                    result.Add(board.GetField((char)(source.Letter-1), (short)(source.Number-2)));
                }
                if(source.StepsToRightEdge() > 0) {
                    result.Add(board.GetField((char)(source.Letter+1), (short)(source.Number-2)));
                }
            }

            return result;
        }
    }
}