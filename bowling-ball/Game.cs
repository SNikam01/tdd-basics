using System;

namespace BowlingBall
{
    /// <summary>
    /// Business logic for game
    /// </summary>
    public class Game:IGame
    {
        private int score = 0;
        private static readonly int[] allRolls = new int[21];
        private int currentRollis = 0;
        private int frameIndex;
        /// <summary>
        /// is for each time a ball is rolled
        /// </summary>
        /// <param name="pins"></param>
        public void Roll(int pins)
        {
            allRolls[currentRollis++] = pins;
        }

        /// <summary>
        /// is for at the end of the game to give a total score
        /// </summary>
        /// <returns></returns>
        public int GetScore()
        {
            
            for (int frame = 0; frame < 10; frame++)
            {
                if (IsStrike(frameIndex))
                {
                    score += 10 + StrikeBonus(frameIndex);
                    frameIndex++;
                }
                else if (IsSpare(frameIndex))
                {
                    score += 10 + SpareBonus(frameIndex);
                    frameIndex += 2;
                }
                else
                {
                    score += SumOfBallsInFrame(frameIndex);
                    frameIndex += 2;
                }
            }

            return score;
        }
        public bool IsStrike(int frameIndex)
        {
            return allRolls[frameIndex] == 10;
        }

        public bool IsSpare(int frameindex)
        {
            return allRolls[frameindex] +
                   allRolls[frameindex + 1] == 10;
        }
        public int SumOfBallsInFrame(int frameIndex)
        {
            return allRolls[frameIndex] + allRolls[frameIndex + 1];
        }

        public int SpareBonus(int frameIndex)
        {
            return allRolls[frameIndex + 2];
        }

        public int StrikeBonus(int frameIndex)
        {
            return allRolls[frameIndex + 1] + allRolls[frameIndex + 2];
        }


    }


}


