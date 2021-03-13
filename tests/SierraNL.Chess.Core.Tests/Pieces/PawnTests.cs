using System;
using System.Linq;
using SierraNL.Chess.Core.Enums;
using SierraNL.Chess.Core.Pieces;
using Xunit;

namespace SierraNL.Chess.Core.Tests.Pieces
{
    public class PawnTests
    {
        private Pawn _sut;

        public PawnTests() {
            _sut = new Pawn(Color.White);
        }

        [Fact]
        public void PawnShouldHaveAbbrevationK()
        {
            Assert.Null(_sut.Abbreviation);
        }

        [Fact]
        public void PawnShouldHaveNamePawn()
        {
            Assert.Equal("Pawn", _sut.Name);
        }

        [Fact]
        public void PawnShouldBeAllowedToMove1StepForwardForWhite()
        {
            var board = new Board();
            var source = new Location('d', 3);
            Assert.True(_sut.IsMovePossible(source, new Location('d', 4), board));
        }

        [Fact]
        public void PawnShouldBeAllowedToMove2StepsForwardForWhiteIfOnNumber2()
        {
            var board = new Board();
            var source = new Location('d', 2);
            Assert.True(_sut.IsMovePossible(source, new Location('d', 4), board));
        }

        [Fact]
        public void PawnShouldBeAllowedToMove1StepForwardForBlack()
        {
            var sut = new Pawn(Color.Black);
            var board = new Board();
            var source = new Location('d', 4);
            Assert.True(sut.IsMovePossible(source, new Location('d', 3), board));
        }
        [Fact]
        public void PawnShouldBeAllowedToMove2StepsForwardForBlackIfOnNumber7()
        {
            var sut = new Pawn(Color.Black);
            var board = new Board();
            var source = new Location('d', 7);
            Assert.True(sut.IsMovePossible(source, new Location('d', 5), board));
        }

        [Fact]
        public void PawnShouldBeAllowedToMove1StepDiagonalIfCapturingForWhite()
        {
            var board = new Board();
            var source = new Location('d', 6);
            Assert.True(_sut.IsMovePossible(source, new Location('c', 7), board));
            Assert.True(_sut.IsMovePossible(source, new Location('e', 7), board));
        }

        [Fact]
        public void PawnShouldBeAllowedToMove1StepDiagonalIfCapturingForBlack()
        {
            var sut = new Pawn(Color.Black);
            var board = new Board();
            var source = new Location('d', 3);
            Assert.True(sut.IsMovePossible(source, new Location('c', 2), board));
            Assert.True(sut.IsMovePossible(source, new Location('e', 2), board));
        }
    }
}