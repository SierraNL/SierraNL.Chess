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
    }
}