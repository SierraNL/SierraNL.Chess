using System;
using System.Linq;
using SierraNL.Chess.Core.Enums;
using SierraNL.Chess.Core.Pieces;
using Xunit;

namespace SierraNL.Chess.Core.Tests.Pieces
{
    public class KnightTests
    {
        private Knight _sut;

        public KnightTests() {
            _sut = new Knight(Color.White);
        }

        [Fact]
        public void KnightShouldHaveAbbrevationK()
        {
            Assert.Equal('N', _sut.Abbreviation);
        }

        [Fact]
        public void KnightShouldHaveNameKnight()
        {
            Assert.Equal("Knight", _sut.Name);
        }

        [Fact]
        public void KnightShouldBeAllowedToMove1StepAnd1DiagonalInEachDirection()
        {
            var board = new Board();
            var source = new Location('d', 3);
            Assert.True(_sut.IsMovePossible(source, new Location('c', 1), board));
            Assert.True(_sut.IsMovePossible(source, new Location('c', 5), board));
            Assert.True(_sut.IsMovePossible(source, new Location('b', 2), board));
            Assert.True(_sut.IsMovePossible(source, new Location('b', 4), board));
            Assert.True(_sut.IsMovePossible(source, new Location('e', 1), board));
            Assert.True(_sut.IsMovePossible(source, new Location('e', 5), board));
            Assert.True(_sut.IsMovePossible(source, new Location('f', 2), board));
            Assert.True(_sut.IsMovePossible(source, new Location('f', 4), board));
        }
    }
}