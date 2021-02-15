using System;

namespace SierraNL.Chess.Core
{
    public class Move
    {
        public Location SourceLocation {get; set;}
        public Location DestinationLocation {get; private set;}
        public bool IsCapture {get; private set;}
        public bool IsPawnPromotion {get; private set;}
        public bool IsCheck {get; private set;}
        public bool IsCheckMate {get; private set;}
        public bool IsCastling {get; private set;}

        public Move(Location sourceLocation, Location destinationLocation, bool isCapture = false, bool isPawnPromotion = false, bool isCheck = false, bool isCheckMate = false, bool isCastling = false) {
            SourceLocation = sourceLocation;
            DestinationLocation = destinationLocation;
            IsCapture = isCapture;
            IsPawnPromotion = isPawnPromotion;
            IsCheck = isCheck;
            IsCheckMate = isCheckMate;
            IsCastling = isCastling;
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