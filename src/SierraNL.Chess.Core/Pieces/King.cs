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
            var result = new List<Location>();
            //Get all 1 step fields from source
            //Check for empty or enemy destination
            //Check if destination will not result in check

            //TODO: Check if castling is possible

            return result;
        }
    }
}