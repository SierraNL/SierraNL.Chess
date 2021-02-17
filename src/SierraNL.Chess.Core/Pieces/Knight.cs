using System;
using SierraNL.Chess.Core.Enums;
using SierraNL.Chess.Core.Consts;

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
    }
}