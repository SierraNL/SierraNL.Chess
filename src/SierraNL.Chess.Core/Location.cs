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

            if(letter != 'a' &&
            letter != 'b' &&
            letter != 'c' &&
            letter != 'd' &&
            letter != 'e' &&
            letter != 'f' &&
            letter != 'g' &&
            letter != 'h') { throw new ArgumentException("Only a to h are valid letters");}

            Letter = lowerLetter;
            Number = number;
        }

        public override string ToString()
        {
            return $"{Letter}{Number}";
        }

        public bool Equals(Location other)
        {
            return this.Number == other.Number && this.Letter == other.Letter;
        }
    }
}