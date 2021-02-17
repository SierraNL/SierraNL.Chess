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
    }
}