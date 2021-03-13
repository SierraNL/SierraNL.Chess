using System.Linq;
using SierraNL.Chess.Core.Enums;
using SierraNL.Chess.Core.Pieces;
using Xunit;

namespace SierraNL.Chess.Core.Tests.Pieces
{
    public class QueenTests
    {
        private Queen _sut;

        public QueenTests() {
            _sut = new Queen(Color.White);
        }

        [Fact]
        public void QueenShouldHaveAbbrevationK()
        {
            Assert.Equal('Q', _sut.Abbreviation);
        }

        [Fact]
        public void QueenShouldHaveNameQueen()
        {
            Assert.Equal("Queen", _sut.Name);
        }

        [Fact]
        public void QueenShouldBeAllowedToMoveInEachDirection()
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
            Assert.True(_sut.IsMovePossible(source, new Location('a', 4), board));
            Assert.True(_sut.IsMovePossible(source, new Location('h', 4), board));
            Assert.True(_sut.IsMovePossible(source, new Location('d', 3), board));
            Assert.True(_sut.IsMovePossible(source, new Location('d', 6), board));
        }

        [Fact]
        public void QueenShouldHaveCorrectPossibleMoves() {
            var board = new Board();
            var source = new Location('d', 4);
            var result = _sut.PossibleMoves(source, board);

            //Diagonal
            Assert.Contains(new Location('c', 3), result);
            Assert.Contains(new Location('e', 3), result);
            Assert.Contains(new Location('c', 5), result);
            Assert.Contains(new Location('e', 5), result);
            Assert.Contains(new Location('b', 6), result);
            Assert.Contains(new Location('f', 6), result);
            Assert.Contains(new Location('a', 7), result);
            Assert.Contains(new Location('g', 7), result);

            //Straight
            Assert.Contains(new Location('d', 3), result);
            Assert.Contains(new Location('d', 5), result);
            Assert.Contains(new Location('d', 6), result);
            Assert.Contains(new Location('d', 7), result);
            Assert.Contains(new Location('a', 4), result);
            Assert.Contains(new Location('b', 4), result);
            Assert.Contains(new Location('c', 4), result);
            Assert.Contains(new Location('e', 4), result);
            Assert.Contains(new Location('f', 4), result);
            Assert.Contains(new Location('g', 4), result);
            Assert.Contains(new Location('h', 4), result);
            Assert.Equal(19, result.Count());
        }
    }
}