using System;
using System.Linq;
using SierraNL.Chess.Core;
using SierraNL.Chess.Core.Consts;
using Xunit;

namespace SierraNL.Chess.Core.Tests
{
    public class BoardTests
    {
        private Board _sut;

        public BoardTests() {
            _sut = new Board();
        }

        [Fact]
        public void TheBoardShouldHave64Fields()
        {
            Assert.Equal(64, _sut.Fields.Count());
        }

        [Fact]
        public void ANewBoardShouldHave32FieldsWithPieces()
        {
            Assert.Equal(32, _sut.Fields.Count(x => x.Piece != null));
        }

        [Fact]
        public void ANewBoardShouldHave32FieldsWithoutPieces()
        {
            Assert.Equal(32, _sut.Fields.Count(x => x.Piece == null));
        }

        [Fact]
        public void ANewBoardShouldHave16FieldsWithWhitePieces()
        {
            Assert.Equal(16, _sut.Fields.Count(x => x.Piece != null && x.Piece.Color == Enums.Color.White));
        }

        [Fact]
        public void ANewBoardShouldHave16FieldsWithBlackPieces()
        {
            Assert.Equal(16, _sut.Fields.Count(x => x.Piece != null && x.Piece.Color == Enums.Color.Black));
        }

        [Fact]
        public void ANewBoardShouldHave8FieldsWithBlackPawns()
        {
            Assert.Equal(8, _sut.Fields.Count(x => x.Piece != null && x.Piece.Color == Enums.Color.Black && x.Piece.Name == PieceNames.Pawn));
        }

        [Fact]
        public void ANewBoardShouldHave8FieldsWithWhitePawns()
        {
            Assert.Equal(8, _sut.Fields.Count(x => x.Piece != null && x.Piece.Color == Enums.Color.White && x.Piece.Name == PieceNames.Pawn));
        }

        [Fact]
        public void ANewBoardShouldAcceptMovingPawnFromE2ToE4()
        {
            var sut = new Board();
            var move = new Move(new Location('e', 2), new Location('e', 4));
            sut.ProcessMove(move);

            //Pawn is now at e4
            Assert.Single(sut.Fields.Where(x => x.Piece != null && x.Piece.Color == Enums.Color.White && x.Piece.Name == PieceNames.Pawn && x.Location.Letter == 'e' && x.Location.Number == 4));
            //e2 is empty
            Assert.Single(sut.Fields.Where(x => x.Piece == null && x.Location.Letter == 'e' && x.Location.Number == 2));
        }
    }
}
