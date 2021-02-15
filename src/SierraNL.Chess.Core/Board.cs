using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SierraNL.Chess.Core.Consts;
using SierraNL.Chess.Core.Enums;

namespace SierraNL.Chess.Core
{
    public class Board
    {
        public IEnumerable<Field> Fields { get; private set; }

        public Board() {
            Fields = FillBoard();
        }

        public void ProcessMove(Move move) {
            //TODO: check if a move is possible

            if(move.SourceLocation != null && move.DestinationLocation != null) 
            {
                var piece = Fields.Single(x => x.Location == move.SourceLocation).Piece;
                
                if(piece == null) {
                    throw new InvalidOperationException("You can't make a move from a location not containing a piece");
                }

                Fields.Single(x => x.Location == move.DestinationLocation).Piece = piece;
                Fields.Single(x => x.Location == move.SourceLocation).Piece = null;
            }
            else {
                //TODO: castling?
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
                field.Piece = new Piece(color, PieceNames.Pawn);
            }

            mainRow.Single(x => x.Location.Letter == 'a').Piece = new Piece(color, PieceNames.Rook);
            mainRow.Single(x => x.Location.Letter == 'b').Piece = new Piece(color, PieceNames.Knight);
            mainRow.Single(x => x.Location.Letter == 'c').Piece = new Piece(color, PieceNames.Bishop);
            mainRow.Single(x => x.Location.Letter == 'd').Piece = new Piece(color, PieceNames.Queen);
            mainRow.Single(x => x.Location.Letter == 'e').Piece = new Piece(color, PieceNames.King);
            mainRow.Single(x => x.Location.Letter == 'f').Piece = new Piece(color, PieceNames.Bishop);
            mainRow.Single(x => x.Location.Letter == 'g').Piece = new Piece(color, PieceNames.Knight);
            mainRow.Single(x => x.Location.Letter == 'h').Piece = new Piece(color, PieceNames.Rook);
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
