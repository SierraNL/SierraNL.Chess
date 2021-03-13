using System;

namespace SierraNL.Chess.Core
{
    public class Location: IEquatable<Location>
    {
        public char Letter {get; private set;}

        public short Number {get; private set;}

        public Location(char letter, short number) {
            if(number < 1 || number > 8) { throw new ArgumentException("Only 1 to 8 are valid numbers");}

            var lowerLetter = char.ToLower(letter);

            if(letter < 'a' || letter > 'h') { throw new ArgumentException("Only a to h are valid letters");}

            Letter = lowerLetter;
            Number = number;
        }

        public override string ToString()
        {
            return $"{Letter}{Number}";
        }

        public bool Equals(Location other)
        {
            return this.Number == other.Number && this.Letter.Equals(other.Letter);
        }

        public static bool operator ==(Location l1, Location l2)
        {
            bool rc;

            if (System.Object.ReferenceEquals(l1, l2))
            {
                rc = true;
            }
            else if (((object)l1 == null) || ((object)l2 == null))
            {
                rc = false;
            }
            else
            {
                rc = (l1.Equals(l2));
            }

            return rc;
        }

        public static bool operator !=(Location l1, Location l2)
        {
            return !(l1 == l2);
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Location);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Letter, Number);
        }

        public int StepsToLeftEdge() {
            return Letter-'a';
        }

        public int StepsToRightEdge() {
            return 'h'-Letter;
        }

        public int StepsToTopEdge() {
            return 8-Number;
        }

        public int StepsToBottomEdge() {
            return Number-1;
        }

        public bool AtTheEdge() {
            return Letter == 'a' || Letter == 'h' || Number == 1 || Number == 8;
        }
    }
}