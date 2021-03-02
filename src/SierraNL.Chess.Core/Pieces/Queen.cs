using System;
using SierraNL.Chess.Core.Enums;
using SierraNL.Chess.Core.Consts;
using System.Collections.Generic;

namespace SierraNL.Chess.Core.Pieces
{
    public class Queen: Piece {
        public Queen(Color color): base(color, PieceNames.Queen) {

        }

        public override bool IsMovePossible(Location source, Location destination, Board board) {
            bool result = true;

            if(board.IsFreePath(source, destination)) {
                //Only straight lines and diagonal allowed
                result = Path.IsStraight(source, destination) || Path.IsDiagonal(source, destination);
            }
            else {
                result = false;
            }
            
            return result;
        }

        public override IEnumerable<Location> PossibleMoves(Location source, Board board) 
        {
            var result = new List<Location>();
            //Get all fields in a straight line or diagonal line from source
            //Check for free path
            //Check for empty or enemy destination

            return result;
        }
    }
}