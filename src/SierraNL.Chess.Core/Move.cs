using System;

namespace SierraNL.Chess.Core
{
    public class Move
    {
        public Location SourceLocation {get; set;}
        public Location DestinationLocation {get; private set;}
        public Piece Piece { get; private set;}
        public bool IsCapture {get; set;}
        public bool IsPawnPromotion {get; set;}
        public bool IsCheck {get; set;}
        public bool IsCheckMate {get; set;}
        public bool IsCastling {get; set;}

        public Move(Location sourceLocation, Location destinationLocation, Piece piece) {
            if(sourceLocation == null) { throw new ArgumentNullException(nameof(sourceLocation)); }
            if(destinationLocation == null) { throw new ArgumentNullException(nameof(destinationLocation)); }
            if(piece == null) { throw new ArgumentNullException(nameof(piece)); }

            SourceLocation = sourceLocation;
            DestinationLocation = destinationLocation;
            Piece = piece;
        }

        public override string ToString()
        {
            var captureMark = IsCapture ? "x" : string.Empty;
            var checkMark = IsCheck ? "+" : string.Empty;
            if(IsCastling) {
                //TODO: king or queenside is different notation
                return "o-o";
            }
            else if(IsPawnPromotion) {
                return $"{DestinationLocation.Letter}{DestinationLocation.Number}=Q";
            }
            else {
                return $"{Piece.Abbreviation}{captureMark}{DestinationLocation.Letter}{DestinationLocation.Number}{checkMark}";
            }

        }

    }
}