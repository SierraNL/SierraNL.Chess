using System;
using SierraNL.Chess.Core.Enums;

namespace SierraNL.Chess.Core
{
    public class Field
    {
        public Color Color {get; private set;}
        public Location Location {get; private set;}
        public Piece Piece {get; set;}

        public Field(Location location) {
            Location = location;

            Color = DetermineColor();
        }

        public Field(Location location, Piece piece) : this(location) {
            Piece = piece;
        }

        public override string ToString()
        {
            return $"{Piece?.Abbreviation}{Location}";
        }

        public bool IsEmpty() {
            return Piece == null;
        }

        public bool IsNotEmpty() { 
            return Piece != null;
        }

        public bool HasPieceOfColor(Color color) {
            return (Piece != null && Piece.Color == color);
        }

        public bool HasPieceOfOppositeColor(Color color) {
            return (Piece != null && Piece.Color != color);
        }

        private Color DetermineColor() {
            var odd = Location.Number % 2 == 1;
            Color result = Color.White;

            if(Location.Letter == 'a' && odd) {
                result = Color.Black;
            }
            if(Location.Letter == 'b' && !odd) {
                result = Color.Black;
            }
            if(Location.Letter == 'c' && odd) {
                result = Color.Black;
            }
            if(Location.Letter == 'd' && !odd) {
                result = Color.Black;
            }
            if(Location.Letter == 'e' && odd) {
                result = Color.Black;
            }
            if(Location.Letter == 'f' && !odd) {
                result = Color.Black;
            }
            if(Location.Letter == 'g' && odd) {
                result = Color.Black;
            }
            if(Location.Letter == 'h' && !odd) {
                result = Color.Black;
            }

            return result;
        }
    }
}