using System;
using SierraNL.Chess.Core.Enums;
using SierraNL.Chess.Core.Consts;

namespace SierraNL.Chess.Core.Pieces
{
    public class Queen: Piece {
        public Queen(Color color): base(color, PieceNames.Queen) {

        }

        public override bool IsMovePossible(Location source, Location destination) {
            //TODO: only moves that don't cross other pieces are possible, how to do this without board knowledge
            bool result = true;

            //Only straight lines and diagonal allowed

            return result;
        }
    }
}