using System;
using Xunit;

namespace BowlingBall.Tests
{
    /// <summary>
    /// Test Cases for Game
    /// </summary>
    public class GameFixture
    {
        private readonly Game g;

        public GameFixture()
        {
            g = new Game();
        }
        private void RollMany(int rolls, int pins)
        {
            for (int i = 0; i < rolls; i++)
            {
                g.Roll(pins);
            }
        }
        [Fact]
        //All Zeroes Works
        public void TestAllZeros()
        {
            for (int i = 0; i < 20; i++)
                g.Roll(0);
            Assert.Equal(0, g.GetScore());
        }
        [Fact]
        //All One Works
        public void TestAllOnes()
        {
            for (int i = 0; i < 20; i++)
                g.Roll(1);
            Assert.Equal(20, g.GetScore());
        }

        [Fact]
        public void TestOneSpare()
        {
            RollSpare();
            g.Roll(3);
            RollMany(17, 0);
            Assert.Equal(16, g.GetScore());
        }

        [Fact]
        public void TestOneStrike()
        {
            RollStrike();
            g.Roll(3);
            g.Roll(4);
            RollMany(16, 0);
            Assert.Equal(24, g.GetScore());
        }

        [Fact]
        public void TestAllStrike()
        {
            RollMany(12, 10);
            Assert.Equal(300, g.GetScore());
        }
        [Theory]
        [InlineData(new int[] { 7, 2, 4, 2, 4, 6, 3, 1, 5, 4, 2, 7, 4, 3, 4, 5, 6, 4, 3, 7, 5 }, 94)]
        [InlineData(new int[] { 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 10 }, 155)]
        [InlineData(new int[] { 5, 5, 10, 10, 6, 3, 6, 4, 7, 3, 2, 6, 4, 3, 2, 7, 5, 4 }, 136)]
        public void GetScore_RandomPinsWorks(int[] inputPins, int expected)
        {
            Game game = new Game();
            for (int i = 0; i < inputPins.Length; i++)
            {
                game.Roll(inputPins[i]);
            }

            Assert.Equal(expected, game.GetScore());
        }
        private void RollStrike()
        {
            g.Roll(10);
        }
        private void RollSpare()
        {
            g.Roll(5);
            g.Roll(5);
        }
    }
}
