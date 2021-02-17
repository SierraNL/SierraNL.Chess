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
    }
}