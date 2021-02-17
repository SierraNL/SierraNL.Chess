using System;
using System.Linq;
using SierraNL.Chess.Core.Enums;
using SierraNL.Chess.Core.Pieces;
using Xunit;

namespace SierraNL.Chess.Core.Tests.Pieces
{
    public class KingTests
    {
        private King _sut;

        public KingTests() {
            _sut = new King(Color.White);
        }

        [Fact]
        public void KingShouldHaveAbbrevationK()
        {
            Assert.Equal('K', _sut.Abbreviation);
        }

        [Fact]
        public void KingShouldHaveNameKing()
        {
            Assert.Equal("King", _sut.Name);
        }

        [Fact]
        public void KingShouldBeAllowedToMove1StepInEachDirection()
        {
            var board = new Board();
            var source = new Location('d', 4);
            Assert.True(_sut.IsMovePossible(source, new Location('c', 3), board));
            Assert.True(_sut.IsMovePossible(source, new Location('c', 4), board));
            Assert.True(_sut.IsMovePossible(source, new Location('c', 5), board));
            Assert.True(_sut.IsMovePossible(source, new Location('d', 3), board));
            Assert.True(_sut.IsMovePossible(source, new Location('d', 5), board));
            Assert.True(_sut.IsMovePossible(source, new Location('e', 3), board));
            Assert.True(_sut.IsMovePossible(source, new Location('e', 4), board));
            Assert.True(_sut.IsMovePossible(source, new Location('e', 5), board));
        }

        [Fact]
        public void KingShouldNotBeAllowedToMoveToFieldWithOwnPiece()
        {
            var board = new Board();
            var source = new Location('d', 3);
            Assert.False(_sut.IsMovePossible(source, new Location('c', 2), board));
        }

        [Fact]
        public void KingShouldBeAllowedToMoveToFieldWithOpponentsPiece()
        {
            var board = new Board();
            var source = new Location('d', 6);
            Assert.True(_sut.IsMovePossible(source, new Location('d', 7), board));
        }
    }
}