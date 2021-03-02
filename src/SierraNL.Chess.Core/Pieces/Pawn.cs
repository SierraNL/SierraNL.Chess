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
            //Get all 1 step forward fields from source
            //Check for empty destination
            //Or get both 1 step diagonal forward fields is a capture is possible

            return result;
        }
    }
}