using System;
using SierraNL.Chess.Core.Enums;
using SierraNL.Chess.Core.Consts;
using System.Linq;

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
    }
}