using System;
using SierraNL.Chess.Core.Enums;
using SierraNL.Chess.Core.Consts;

namespace SierraNL.Chess.Core
{
    public abstract class Piece {

        public Color Color {get; private set;}

        public char? Abbreviation {get; private set;}

        public string Name {get; private set;}

        public Piece (Color color, string name) {
            Color = color;
            Name = name;
            Abbreviation = DetermineAbbriviation();
        }

        public abstract bool IsMovePossible(Location source, Location destination);

        private char? DetermineAbbriviation()
        {
            char? result;

            switch(Name) {
                case PieceNames.King:
                    result = 'K';
                    break;
                case PieceNames.Queen:
                    result = 'Q';
                    break;
                case PieceNames.Knight:
                    result = 'N';
                    break;
                case PieceNames.Bishop:
                    result = 'B';
                    break;
                case PieceNames.Rook:
                    result = 'R';
                    break;
                default: 
                    result = null;
                break;
            }

    	    return result;
        }
    }
}