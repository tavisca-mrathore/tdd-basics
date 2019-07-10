using System;
using Xunit;

namespace BowlingBall.Tests
{
    public class GameFixture
    {
        [Fact]
        public void testGutterGame()
        {
            var game = new Game();
            RollPins(game, 20, 0);
            Assert.Equal(0, game.GetScore());
        }

        [Fact]
        public void testHittingOnePinPerRoll()
        {
            var game = new Game();
            RollPins(game, 20, 1);
            Assert.Equal(20, game.GetScore());
        }

        [Fact]
        public void testOneSpare()
        {
            var game = new Game();
            rollSpare(game);
            game.Roll(3);
            RollPins(game, 17, 0);
            Assert.Equal(16, game.GetScore());
        }

        [Fact]
        public void testOneStrike()
        {
            var game = new Game();
            rollStrike(game);
            game.Roll(3);
            game.Roll(4);
            RollPins(game, 16, 0);
            Assert.Equal(24, game.GetScore());
        }

        [Fact]
        public void testPerfectGame()
        {
            var game = new Game();
            RollPins(game, 12, 10);
            Assert.Equal(300, game.GetScore());
        }

        // ---------------------------------------------------------------------
        private void rollSpare(Game game)
        {
            game.Roll(5);
            game.Roll(5);
        }

        private void RollPins(Game game, int numberOfRolls, int pinsHitPerRoll)
        {
            for (int i = 0; i < numberOfRolls; i++)
                game.Roll(pinsHitPerRoll);
        }

        private void rollStrike(Game game)
        {
            game.Roll(10);
        }

    }
}
