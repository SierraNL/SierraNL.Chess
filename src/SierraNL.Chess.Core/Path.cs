using System;

namespace SierraNL.Chess.Core
{
    public static class Path
    {
        public static bool IsStraight(Location source, Location destination) {
            //only changes on either number or letter
            return IsVertical(source, destination) || IsHorizontal(source, destination);
        }

        public static bool IsVertical(Location source, Location destination) {
            //only changes on number
            return source.Letter == destination.Letter;
        }

        public static bool IsHorizontal(Location source, Location destination) {
            //only changes on letter
            return source.Number == destination.Number;
        }

        public static bool IsDiagonal(Location source, Location destination) {
            //similar changes to both number and letter
            return  Math.Abs(source.Number - destination.Number) == Math.Abs(source.Letter - destination.Letter);
        }
    }
}