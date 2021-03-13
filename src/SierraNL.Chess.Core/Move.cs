using System;

namespace SierraNL.Chess.Core
{
    public class Move
    {
        public Location SourceLocation {get; set;}
        public Location DestinationLocation {get; private set;}
        public bool IsCapture {get; set;}
        public bool IsPawnPromotion {get; set;}
        public bool IsCheck {get; set;}
        public bool IsCheckMate {get; set;}
        public bool IsCastling {get; set;}

        public Move(Location sourceLocation, Location destinationLocation) {
            SourceLocation = sourceLocation;
            DestinationLocation = destinationLocation;
        }

        public override string ToString()
        {
            if(IsCapture) {
                return $"{DestinationLocation.Letter}x{DestinationLocation.Number}";
            }
            else {
                return DestinationLocation.ToString();
            }
        }

    }
}