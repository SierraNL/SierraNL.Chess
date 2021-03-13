using System;
using System.Collections.Generic;
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
            Assert.True(sut.TryProcessMove(move));

            //Pawn is now at e4
            Assert.Single(sut.Fields.Where(x => x.Piece != null && x.Piece.Color == Enums.Color.White && x.Piece.Name == PieceNames.Pawn && x.Location.Letter == 'e' && x.Location.Number == 4));
            //e2 is empty
            Assert.Single(sut.Fields.Where(x => x.Piece == null && x.Location.Letter == 'e' && x.Location.Number == 2));
        }

        [Fact]
        public void CheckPathShouldReturnTrueIfNothingIsInItsPath() {
            var sut = new Board();

            Assert.True(sut.IsFreePath(new Location('a',3), new Location('a', 6)));
        }

        [Fact]
        public void CheckPathShouldReturnFalseIfSomethingIsInItsPath() {
            var sut = new Board();

            //On a new board, there is a pawn at a2
            Assert.False(sut.IsFreePath(new Location('a',1), new Location('a', 4)));
        }

        [Fact]
        public void CheckPathShouldReturnTrueIfSomethingIsInTheDestination() {
            var sut = new Board();

            //On a new board, there is a pawn at a2, but since that's the destination, the path is ok
            Assert.True(sut.IsFreePath(new Location('a',4), new Location('a', 2)));
        }

        [Fact]
        public void CheckPathShouldReturnTrueIfSomethingIsInTheSource() {
            var sut = new Board();

            Assert.True(sut.IsFreePath(new Location('a',2), new Location('a', 3)));
        }

        [Fact]
        public void GetDiagonalFieldsShouldReturnAllFieldsDiagonalFromCorner() {
            var sut = new Board();

            var result = sut.GetDiagonalFields(new Location('a', 1));
            Assert.Contains(new Location('b', 2), result.Select(x => x.Location));
            Assert.Contains(new Location('c', 3), result.Select(x => x.Location));
            Assert.Contains(new Location('d', 4), result.Select(x => x.Location));
            Assert.Contains(new Location('e', 5), result.Select(x => x.Location));
            Assert.Contains(new Location('f', 6), result.Select(x => x.Location));
            Assert.Contains(new Location('g', 7), result.Select(x => x.Location));
            Assert.Contains(new Location('h', 8), result.Select(x => x.Location));
            Assert.Equal(7, result.Count());
        }

        [Fact]
        public void GetDiagonalFieldsShouldReturnAllFieldsDiagonalFromSide() {
            var sut = new Board();

            var result = sut.GetDiagonalFields(new Location('a', 4));
            Assert.Contains(new Location('b', 3), result.Select(x => x.Location));
            Assert.Contains(new Location('b', 5), result.Select(x => x.Location));
            Assert.Contains(new Location('c', 2), result.Select(x => x.Location));
            Assert.Contains(new Location('c', 6), result.Select(x => x.Location));
            Assert.Contains(new Location('d', 1), result.Select(x => x.Location));
            Assert.Contains(new Location('d', 7), result.Select(x => x.Location));
            Assert.Contains(new Location('e', 8), result.Select(x => x.Location));
            Assert.Equal(7, result.Count());
        }

        [Fact]
        public void GetDiagonalFieldsShouldReturnAllFieldsDiagonalFromCenter() {
            var sut = new Board();

            var result = sut.GetDiagonalFields(new Location('d', 4));
            Assert.Contains(new Location('c', 3), result.Select(x => x.Location));
            Assert.Contains(new Location('c', 5), result.Select(x => x.Location));
            Assert.Contains(new Location('b', 2), result.Select(x => x.Location));
            Assert.Contains(new Location('b', 6), result.Select(x => x.Location));
            Assert.Contains(new Location('a', 1), result.Select(x => x.Location));
            Assert.Contains(new Location('a', 7), result.Select(x => x.Location));
            Assert.Contains(new Location('e', 3), result.Select(x => x.Location));
            Assert.Contains(new Location('e', 5), result.Select(x => x.Location));
            Assert.Contains(new Location('f', 2), result.Select(x => x.Location));
            Assert.Contains(new Location('f', 6), result.Select(x => x.Location));
            Assert.Contains(new Location('g', 1), result.Select(x => x.Location));
            Assert.Contains(new Location('g', 7), result.Select(x => x.Location));
            Assert.Contains(new Location('h', 8), result.Select(x => x.Location));
            Assert.Equal(13, result.Count());
        }
    }
}
