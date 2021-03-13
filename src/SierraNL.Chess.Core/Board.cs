using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SierraNL.Chess.Core.Enums;
using SierraNL.Chess.Core.Pieces;

namespace SierraNL.Chess.Core
{
    public class Board
    {
        public IEnumerable<Field> Fields { get; private set; }

        public Board() {
            Fields = FillBoard();
        }

        public bool TryProcessMove(Move move) {
            if(move.SourceLocation != null && move.DestinationLocation != null) 
            {
                var piece = GetField(move.SourceLocation).Piece;

                if(piece == null) {
                    throw new InvalidOperationException("You can't make a move from a location not containing a piece");
                }

                if(!piece.IsMovePossible(move.SourceLocation, move.DestinationLocation, this)) {
                    return false;
                }

                if(Fields.Single(x => x.Location == move.DestinationLocation).HasPieceOfOppositeColor(piece.Color)) {
                    move.IsCapture = true;
                }

                Fields.Single(x => x.Location == move.DestinationLocation).Piece = piece;
                Fields.Single(x => x.Location == move.SourceLocation).Piece = null;
            }
            else {
                //TODO: castling?
            }

            return true;
        }

        public Field GetField(char letter, short number) {
            return GetField(new Location(letter, number));
        }

        public Field GetField(Location location) {
            return Fields.SingleOrDefault(x => x.Location == location);
        }

        public IEnumerable<Field> GetDiagonalFields(Location source) {
            var result = new List<Field>();

            var location = source;
            while(location.StepsToBottomEdge() > 0 && location.StepsToLeftEdge() > 0) {
                location = new Location((char)(location.Letter - 1), (short)(location.Number - 1));
                result.Add(GetField(location));
            }
            
            location = source;
            while(location.StepsToTopEdge() > 0 && location.StepsToLeftEdge() > 0) {
                location = new Location((char)(location.Letter - 1), (short)(location.Number + 1));
                result.Add(GetField(location));
            }

            location = source;
            while(location.StepsToBottomEdge() > 0 && location.StepsToRightEdge() > 0) {
                location = new Location((char)(location.Letter + 1), (short)(location.Number - 1));
                result.Add(GetField(location));
            }
            
            location = source;
            while(location.StepsToTopEdge() > 0 && location.StepsToRightEdge() > 0) {
                location = new Location((char)(location.Letter + 1), (short)(location.Number + 1));
                result.Add(GetField(location));
            }

            return result;
        }

        public IEnumerable<Field> GetStraightLineFields(Location source) {
            var result = new List<Field>();

            for(int i = 'a'; i<source.Letter; i++) {
                result.Add(GetField(new Location((char)i, source.Number)));
            }
            for(int i = 'h'; i>source.Letter; i--) {
                result.Add(GetField(new Location((char)i, source.Number)));
            }
            for(short i = 1; i<source.Number; i++) {
                result.Add(GetField(new Location(source.Letter, i)));
            }
            for(short i = 8; i>source.Number; i--) {
                result.Add(GetField(new Location(source.Letter, i)));
            }

            return result;
        }

        //The path is everything in between the source and destination, so excluding the source and destination fields
        public bool IsFreePath(Location source, Location destination) {
            IEnumerable<Field> result = new List<Field>();

            //Create list of field's that is the path, and check each field for a piece
            if(Path.IsVertical(source, destination)) {
                result = GetVerticalFields(source.Number, destination.Number, source.Letter);
            }
            else if(Path.IsHorizontal(source, destination)) {
                result = GetHorizontalFields(source.Letter, destination.Letter, source.Number);
            }
            else if(Path.IsDiagonal(source, destination)) {
                if(source.Number > destination.Number && source.Letter > destination.Letter) {
                    result = GetDiagonalFields(destination.Number, destination.Letter, source.Number, source.Letter);
                }
                else if(source.Number > destination.Number && source.Letter < destination.Letter) {
                    result = GetDiagonalFields(destination.Number, source.Letter, source.Number, destination.Letter);
                }
                else if(source.Number < destination.Number && source.Letter > destination.Letter) {
                    result = GetDiagonalFields(source.Number, destination.Letter, destination.Number, source.Letter);
                }
                else if(source.Number < destination.Number && source.Letter < destination.Letter) {
                    result = GetDiagonalFields(source.Number, source.Letter, destination.Number, destination.Letter);
                }
            }

            return result.All(y => y.IsEmpty());
        }

        private IEnumerable<Field> GetDiagonalFields(short startNumber, char startLetter, short endNumber, char endLetter)
        {
            var letterCounter = startLetter;
            for(int numberCounter = startNumber+1; numberCounter < endNumber; numberCounter++) {
                letterCounter++;
                yield return GetField(new Location((char)letterCounter, (short)numberCounter));
            }
        }

        private IEnumerable<Field> GetVerticalFields(short startNumber, short endNumber, char letter) {
            if(startNumber > endNumber) {
                return Fields.Where(x => x.Location.Letter == letter && x.Location.Number > endNumber && x.Location.Number < startNumber);
            }
            else {
                return Fields.Where(x => x.Location.Letter == letter && x.Location.Number > startNumber && x.Location.Number < endNumber);
            }
        }

        private IEnumerable<Field> GetHorizontalFields(char startLetter, char endLetter, short number) {
            if(startLetter > endLetter) {
                return Fields.Where(x => x.Location.Number == number && x.Location.Letter > endLetter && x.Location.Letter < startLetter);
            }
            else {
               return Fields.Where(x => x.Location.Number == number && x.Location.Letter > startLetter && x.Location.Letter < endLetter);
            }
        }

        public override string ToString()
        {
            var builder = new StringBuilder();
            
            foreach(var field in Fields) {
                builder.AppendLine(field.ToString());
            }

            return builder.ToString();
        }

        private IEnumerable<Field> FillBoard() {
            var result = new List<Field>();

            CreateFields(result);
            
            AddPieces(result);

            return result;
        }

        private void AddPieces(IEnumerable<Field> fields)
        {
            var firstRow = fields.Where(x => x.Location.Number == 1);
            var secondRow = fields.Where(x => x.Location.Number == 2);
            AddPieces(Color.White, firstRow, secondRow);

            var seventhRow = fields.Where(x => x.Location.Number == 7);
            var eightRow = fields.Where(x => x.Location.Number == 8);
            AddPieces(Color.Black, eightRow, seventhRow);
        }

        private void AddPieces(Color color, IEnumerable<Field> mainRow, IEnumerable<Field> pawnRow)
        {
            foreach(var field in pawnRow) {
                field.Piece = new Pawn(color);
            }

            mainRow.Single(x => x.Location.Letter == 'a').Piece = new Rook(color);
            mainRow.Single(x => x.Location.Letter == 'b').Piece = new Knight(color);
            mainRow.Single(x => x.Location.Letter == 'c').Piece = new Bishop(color);
            mainRow.Single(x => x.Location.Letter == 'd').Piece = new Queen(color);
            mainRow.Single(x => x.Location.Letter == 'e').Piece = new King(color);
            mainRow.Single(x => x.Location.Letter == 'f').Piece = new Bishop(color);
            mainRow.Single(x => x.Location.Letter == 'g').Piece = new Knight(color);
            mainRow.Single(x => x.Location.Letter == 'h').Piece = new Rook(color);
        }

        private void CreateFields(List<Field> fields)
        {
            for(short i = 1; i < 9; i++) {
                fields.Add(new Field(new Location('a', i)));
                fields.Add(new Field(new Location('b', i)));
                fields.Add(new Field(new Location('c', i)));
                fields.Add(new Field(new Location('d', i)));
                fields.Add(new Field(new Location('e', i)));
                fields.Add(new Field(new Location('f', i)));
                fields.Add(new Field(new Location('g', i)));
                fields.Add(new Field(new Location('h', i)));
            }
        }
    }
}
