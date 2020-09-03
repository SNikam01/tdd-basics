using System;
using System.Collections.Generic;
using System.Text;

namespace BowlingBall
{
    interface IGame
    {
        void Roll(int pins);
        int GetScore();
        bool IsStrike(int frameIndex);
        bool IsSpare(int frameindex);
        int SumOfBallsInFrame(int frameIndex);
        int SpareBonus(int frameIndex);
        int StrikeBonus(int frameIndex);
    }
}
