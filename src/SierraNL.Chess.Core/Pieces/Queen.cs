using System;
using SierraNL.Chess.Core.Enums;
using SierraNL.Chess.Core.Consts;
using System.Collections.Generic;
using System.Linq;

namespace SierraNL.Chess.Core.Pieces
{
    public class Queen : Piece
    {
        public Queen(Color color) : base(color, PieceNames.Queen)
        {

        }

        public override bool IsMovePossible(Location source, Location destination, Board board)
        {
            bool result = true;

            if (board.IsFreePath(source, destination))
            {
                //Only straight lines and diagonal allowed
                result = Path.IsStraight(source, destination) || Path.IsDiagonal(source, destination);
            }
            else
            {
                result = false;
            }

            return result;
        }

        public override IEnumerable<Location> PossibleMoves(Location source, Board board)
        {
            var possibleFields = new List<Field>();
            possibleFields.AddRange(board.GetStraightLineFields(source));
            possibleFields.AddRange(board.GetDiagonalFields(source));

            return possibleFields.Where(x => board.IsFreePath(source, x.Location) && (x.IsEmpty() || x.HasPieceOfOppositeColor(Color))).Select(x => x.Location);
        }
    }
}