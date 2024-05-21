using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealSnakeGame
{
    public class Score : Character
    {
        private readonly object _lock = new object();
        public int CurrentScore;
        public int HighScore;

        public Score()
        {
            CurrentScore = 0;
            HighScore = 0;
            scorePosition.Add((0, 25));
        }

        public async Task Draw(GameSet gameSet)
        {
            (int scoreX, int scoreY) returnPosition = Console.GetCursorPosition();
            await Task.Run(() =>
            {
                lock (_lock)
                {
                    gameSet.DrawPosition.Add((Position.First().x, Position.First().y, this));
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.Write("Score: " + CurrentScore);
                    Console.SetCursorPosition(returnPosition.scoreX, returnPosition.scoreY);
                }
            });
            await Task.Delay(100); // Hier gaat het fout, wanneer de delay op 10000 staat runt de code wel
        }

        public async Task Update()
        {
            lock (_lock)
            {
                if (CurrentScore >= HighScore)
                {
                    HighScore = CurrentScore;
                }
            }

            // await Draw();
        }

        public void IncreaseScore(int points)
        {
            lock (_lock)
            {
                CurrentScore += points;
            }
        }
    }
}