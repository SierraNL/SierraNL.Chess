using System;
using SierraNL.Chess.Core.Enums;
using SierraNL.Chess.Core.Consts;
using System.Linq;

namespace SierraNL.Chess.Core.Pieces
{
    public class Pawn: Piece {
        public Pawn(Color color): base(color, PieceNames.Pawn) {

        }

        public override bool IsMovePossible(Location source, Location destination, Board board) {
            bool result = false;

            var destinationField = board.Fields.Single(x => x.Location == destination);
            //one step forward, if not blocked
            //can move diagonal when it's a capture, need more information to determine that
            if(Color == Color.White)
            {
                if(destination.Number == source.Number + 1 && destination.Letter == source.Letter && destinationField.Piece == null) {
                    result = true;
                }
                else if(destination.Number == source.Number + 1 && ((short)destination.Letter == (short)source.Letter + 1 || (short)destination.Letter == (short)source.Letter - 1) && destinationField.Piece != null) {
                    result = true;
                }
            }
            else {
                if(destination.Number == source.Number - 1 && destination.Letter == source.Letter && destinationField.Piece == null) {
                    result = true;
                }
                else if(destination.Number == source.Number - 1 && ((short)destination.Letter == (short)source.Letter + 1 || (short)destination.Letter == (short)source.Letter - 1) && destinationField.Piece != null) {
                    result = true;
                }
            }
            

            return result;
        }
    }
}