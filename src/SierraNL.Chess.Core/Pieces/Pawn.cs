using System;
using SierraNL.Chess.Core.Enums;
using SierraNL.Chess.Core.Consts;
using System.Linq;
using System.Collections.Generic;

namespace SierraNL.Chess.Core.Pieces
{
    public class Pawn: Piece {
        public Pawn(Color color): base(color, PieceNames.Pawn) {

        }

        public override bool IsMovePossible(Location source, Location destination, Board board) {
            bool result = false;

            var destinationField = board.GetField(destination);
            //one step forward (color dependant), if not blocked
            //can move diagonal when it's a capture
            if(Color == Color.White)
            {
                if(destination.Number == source.Number + 1 && destination.Letter == source.Letter && destinationField.IsEmpty()) {
                    result = true;
                }
                else if(destination.Number == source.Number + 1 && ((short)destination.Letter == (short)source.Letter + 1 || (short)destination.Letter == (short)source.Letter - 1) && 
                        destinationField.HasPieceOfColor(Color.Black)) {
                    result = true;
                }
            }
            else {
                if(destination.Number == source.Number - 1 && destination.Letter == source.Letter && destinationField.IsEmpty()) {
                    result = true;
                }
                else if(destination.Number == source.Number - 1 && ((short)destination.Letter == (short)source.Letter + 1 || (short)destination.Letter == (short)source.Letter - 1) && 
                        destinationField.HasPieceOfColor(Color.White)) {
                    result = true;
                }
            }
            

            return result;
        }

        public override IEnumerable<Location> PossibleMoves(Location source, Board board) 
        {
            var result = new List<Location>();

            Field nextField = board.GetField(new Location(source.Letter, Color == Color.White ? (short)(source.Number + 1) : (short)(source.Number - 1)));
            if(nextField.IsEmpty()) {
                result.Add(nextField.Location);
            }
            if(source.StepsToLeftEdge() > 0) {
                Field leftField = board.GetField(new Location((char)(source.Letter-1), Color == Color.White ? (short)(source.Number + 1) : (short)(source.Number - 1)));
                if(leftField.HasPieceOfColor(Color == Color.White ? Color.Black : Color.White)) {
                    result.Add(leftField.Location);
                }
            }
            if(source.StepsToRightEdge() > 0) {
                Field rightField = board.GetField(new Location((char)(source.Letter+1), Color == Color.White ? (short)(source.Number + 1) : (short)(source.Number - 1)));
                if(rightField.HasPieceOfColor(Color == Color.White ? Color.Black : Color.White)) {
                    result.Add(rightField.Location);
                }
            }

            return result;
        }
    }
}