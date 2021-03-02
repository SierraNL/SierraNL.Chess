using System;
using SierraNL.Chess.Core.Enums;
using SierraNL.Chess.Core.Consts;
using System.Linq;
using System.Collections.Generic;

namespace SierraNL.Chess.Core.Pieces
{
    public class King: Piece {
        public King(Color color): base(color, PieceNames.King) {

        }

        public override bool IsMovePossible(Location source, Location destination, Board board) {
            //TODO: only moves which don't result in check are allowed, how to do this without board knowledge
            bool result = true;
            var destinationField = board.GetField(destination);

            //reversed logic, no more then one step in each direction
            if((Math.Abs(source.Number - destination.Number) > 1 || Math.Abs((int)source.Letter - (int)destination.Letter) > 1) || 
                //move to a field filled by your own piece isn't allowed either
                (destinationField.HasPieceOfColor(Color))) {
                result = false;
            }

            return result;
        }

        public override IEnumerable<Location> PossibleMoves(Location source, Board board) 
        {
            var possibleFields = GetSurroundingFields(source, board);
            possibleFields = possibleFields.Where(x => x.IsEmpty() || Color == Color.Black ? x.HasPieceOfColor(Color.White) : x.HasPieceOfColor(Color.Black));
            //TODO: Check if destination will not result in check

            //TODO: Check if castling is possible

            return possibleFields.Select(x => x.Location);
        }

        private IEnumerable<Field> GetSurroundingFields(Location sourceLocation, Board board) {
            var result = new List<Field>();
            
            if(sourceLocation.StepsToLeftEdge() > 1) {
                result.Add(board.GetField(new Location((char)(sourceLocation.Letter-1), sourceLocation.Number)));
                if(sourceLocation.StepsToTopEdge() > 1) {
                    result.Add(board.GetField(new Location((char)(sourceLocation.Letter-1), (short)(sourceLocation.Number+1))));
                }
                if(sourceLocation.StepsToBottomEdge() > 1) {
                    result.Add(board.GetField(new Location((char)(sourceLocation.Letter-1), (short)(sourceLocation.Number-1))));
                }
            }
            if(sourceLocation.StepsToTopEdge() > 1) {
                result.Add(board.GetField(new Location(sourceLocation.Letter, (short)(sourceLocation.Number+1))));
            }
            if(sourceLocation.StepsToBottomEdge() > 1) {
                result.Add(board.GetField(new Location(sourceLocation.Letter, (short)(sourceLocation.Number-1))));
            }
            if(sourceLocation.StepsToRightEdge() > 1) {
                result.Add(board.GetField(new Location((char)(sourceLocation.Letter+1), sourceLocation.Number)));
                if(sourceLocation.StepsToTopEdge() > 1) {
                    result.Add(board.GetField(new Location((char)(sourceLocation.Letter+1), (short)(sourceLocation.Number+1))));
                }
                if(sourceLocation.StepsToBottomEdge() > 1) {
                    result.Add(board.GetField(new Location((char)(sourceLocation.Letter+1), (short)(sourceLocation.Number-1))));
                }
            }

            return result;
        }
    }
}