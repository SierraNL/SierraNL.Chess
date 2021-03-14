using System.Linq;
using SierraNL.Chess.Core.Enums;
using SierraNL.Chess.Core.Pieces;
using Xunit;

namespace SierraNL.Chess.Core.Tests.Pieces
{
    public class BishopTests
    {
        private Bishop _sut;

        public BishopTests() {
            _sut = new Bishop(Color.White);
        }

        [Fact]
        public void BishopShouldHaveAbbrevationK()
        {
            Assert.Equal('B', _sut.Abbreviation);
        }

        [Fact]
        public void BishopShouldHaveNameBishop()
        {
            Assert.Equal("Bishop", _sut.Name);
        }

        [Fact]
        public void BishopShouldBeAllowedToMoveInDiagonalLinesInEachDirection()
        {
            var board = new Board();
            var source = new Location('d', 4);
            Assert.True(_sut.IsMovePossible(source, new Location('c', 3), board));
            Assert.True(_sut.IsMovePossible(source, new Location('c', 5), board));
            Assert.True(_sut.IsMovePossible(source, new Location('e', 3), board));
            Assert.True(_sut.IsMovePossible(source, new Location('e', 5), board));
            Assert.True(_sut.IsMovePossible(source, new Location('f', 2), board));
            Assert.True(_sut.IsMovePossible(source, new Location('f', 6), board));
            Assert.True(_sut.IsMovePossible(source, new Location('b', 2), board));
            Assert.True(_sut.IsMovePossible(source, new Location('b', 6), board));
        }

        [Fact]
        public void BishopShouldHaveCorrectPossibleMoves() {
            var board = new Board();
            var source = new Location('d', 4);
            var result = _sut.PossibleMoves(source, board);

            Assert.Contains(new Location('c', 3), result);
            Assert.Contains(new Location('e', 3), result);
            Assert.Contains(new Location('c', 5), result);
            Assert.Contains(new Location('e', 5), result);
            Assert.Contains(new Location('b', 6), result);
            Assert.Contains(new Location('f', 6), result);
            Assert.Contains(new Location('a', 7), result);
            Assert.Contains(new Location('g', 7), result);
            Assert.Equal(8, result.Count());
        }

        [Fact]
        public void BishopWithOneFreePathShouldBeAllowedToMoveInDiagonalToTheEdgeOfTheBoard()
        {
            var board = new Board();
            //create path
            board.GetField('d', 2).Piece = null;
            var source = new Location('c', 1);
            Assert.True(_sut.IsMovePossible(source, new Location('d', 2), board));
            Assert.True(_sut.IsMovePossible(source, new Location('e', 3), board));
            Assert.True(_sut.IsMovePossible(source, new Location('f', 4), board));
            Assert.True(_sut.IsMovePossible(source, new Location('g', 5), board));
            Assert.True(_sut.IsMovePossible(source, new Location('h', 6), board));
        }

        [Fact]
        public void BishopWithOneFreePathShouldHavePossibleMovesInDiagonalToTheEdgeOfTheBoard() {
            var board = new Board();
            //create path
            board.GetField('d', 2).Piece = null;
            var source = new Location('c', 1);
            var result = _sut.PossibleMoves(source, board);

            Assert.Contains(new Location('d', 2), result);
            Assert.Contains(new Location('e', 3), result);
            Assert.Contains(new Location('f', 4), result);
            Assert.Contains(new Location('g', 5), result);
            Assert.Contains(new Location('h', 6), result);
            Assert.Equal(5, result.Count());
        }
    }
}