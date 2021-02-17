using System;

namespace SierraNL.Chess.Core
{
    public static class Path
    {
        public static bool IsStraight(Location source, Location destination) {
            //only changes on either number or letter
            return source.Number == destination.Number || source.Letter == destination.Letter;
        }

        public static bool IsDiagonal(Location source, Location destination) {
            //similar changes to both number and letter
            return  Math.Abs(source.Number - destination.Number) == Math.Abs(source.Letter - destination.Letter);
        }
    }
}