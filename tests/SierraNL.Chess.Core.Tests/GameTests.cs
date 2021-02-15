using System;
using System.Linq;
using SierraNL.Chess.Core;
using SierraNL.Chess.Core.Consts;
using Xunit;

namespace SierraNL.Chess.Core.Tests
{
    public class GameTests
    {
        private Game _sut;

        public GameTests() {
            _sut = new Game();
        }

        [Fact]
        public void TheGameStartWithZeroMoves()
        {
            Assert.Equal(0, _sut.Moves.Count());
        }
    }
}