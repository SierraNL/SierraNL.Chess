using System.Linq;
using SierraNL.Chess.Core.Enums;
using SierraNL.Chess.Core.Pieces;
using Xunit;

namespace SierraNL.Chess.Core.Tests.Pieces
{
    public class RookTests
    {
        private Rook _sut;

        public RookTests() {
            _sut = new Rook(Color.White);
        }

        [Fact]
        public void RookShouldHaveAbbrevationK()
        {
            Assert.Equal('R', _sut.Abbreviation);
        }

        [Fact]
        public void RookShouldHaveNameRook()
        {
            Assert.Equal("Rook", _sut.Name);
        }

        [Fact]
        public void RookShouldBeAllowedToMoveInStraightLinesInEachDirection()
        {
            var board = new Board();
            var source = new Location('d', 4);
            Assert.True(_sut.IsMovePossible(source, new Location('a', 4), board));
            Assert.True(_sut.IsMovePossible(source, new Location('h', 4), board));
            Assert.True(_sut.IsMovePossible(source, new Location('d', 3), board));
            Assert.True(_sut.IsMovePossible(source, new Location('d', 6), board));
        }

        [Fact]
        public void RookShouldHaveCorrectPossibleMoves() {
            var board = new Board();
            var source = new Location('d', 4);
            var result = _sut.PossibleMoves(source, board);

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
            Assert.Equal(11, result.Count());
        }
    }
}