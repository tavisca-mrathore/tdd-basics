using System;
using System.Collections.Generic;

namespace BowlingBall
{
    public class Game
    {
        private int Score;
        private List<int> totalRolls = new List<int>(21);
        private int currentRoll = 0;
        public Game()
        {
            Score = 0;
            for (int i = 0; i < 22; i++)
            {
                totalRolls.Add(0);
            }
        }
        public void Roll(int pins)
        {
            totalRolls[currentRoll] = pins;
            currentRoll++;
        }

        public int GetScore()
        {
            Score = 0;
            int frameIndex = 0;
            for (int frame = 0; frame < 10; frame++)
            {
                if (IsStrike(frameIndex))
                {
                    //strike
                    Score += 10 + StrikeBonus(frameIndex);
                    frameIndex++;
                }
                else if (IsSpare(frameIndex))
                {
                    //spare
                    Score += 10 + SpareBonus(frameIndex);
                    frameIndex += 2;
                }
                else
                {
                    Score += NormalBonus(frameIndex);
                    frameIndex = frameIndex + 2;
                }
            }
            return Score;
        }

        private int NormalBonus(int frameIndex)
        {
            return totalRolls[frameIndex] + totalRolls[frameIndex + 1];
        }

        private int SpareBonus(int frameIndex)
        {
            return totalRolls[frameIndex + 2];
        }

        private int StrikeBonus(int frameIndex)
        {
            return totalRolls[frameIndex + 1] + totalRolls[frameIndex + 2];
        }

        private bool IsStrike(int frameIndex)
        {
            return totalRolls[frameIndex] == 10;
        }

        private bool IsSpare(int frameIndex)
        {
            return totalRolls[frameIndex] + totalRolls[frameIndex + 1] == 10;
        }
    }
}
