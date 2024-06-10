using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace RealSnakeGame
{
    public class Score
    {
        public int CurrentScore;
        public int HighScore;
        public DateTime HighScoreTime; // Added this line
        public List<(int x, int y)> Position = new List<(int x, int y)>();

        private const string HighScoreFilePath = "highscore.txt";

        public Score()
        {
            CurrentScore = 0;
            var highScoreData = LoadHighScore();
            HighScore = highScoreData.Item1;
            HighScoreTime = highScoreData.Item2;
            Position.Add((0, 23));
        }

        public void Draw()
        {
            Console.SetCursorPosition(Position.First().x, Position.First().y);
            Console.Write("Current Score: " + CurrentScore + "\n");
            Console.SetCursorPosition(Position.First().x, Position.First().y + 1);
            Console.Write("High Score: " + HighScore);
        }

        public void Update(GameSet gameSet)
        {
            gameSet.DrawPositions.Add((Position.First().x, Position.First().y, this));
            if (CurrentScore > HighScore)
            {
                HighScore = CurrentScore;
                HighScoreTime = DateTime.Now; // Added this line
                SaveHighScore();
            }
        }

        public void Increase(Snake snake)
        {
            CurrentScore += snake.Speed; // Score increases based on Snake speed
            snake.Speed++; // Snake speed increases based on score increases. This gets real hard real fast.
        }

        private Tuple<int, DateTime> LoadHighScore() // Modified this method
        {
            if (File.Exists(HighScoreFilePath))
            {
                try
                {
                    string[] scoreData = File.ReadAllLines(HighScoreFilePath);
                    int score = int.Parse(scoreData[0]);
                    DateTime time = DateTime.Parse(scoreData[1]);
                    return Tuple.Create(score, time);
                }
                catch
                {
                    // Handle any errors that might occur during reading/parsing
                    return Tuple.Create(0, DateTime.MinValue);
                }
            }
            return Tuple.Create(0, DateTime.MinValue);
        }

        private void SaveHighScore() // Modified this method
        {
            try
            {
                string[] scoreData = { HighScore.ToString(), HighScoreTime.ToString() };
                File.WriteAllLines(HighScoreFilePath, scoreData);
            }
            catch
            {
                // Handle any errors that might occur during writing
                Console.WriteLine("Failed to save high score.");
            }
        }
        public void DrawHighScoreWithDate()
        {
            Console.SetCursorPosition(Position.First().x, Position.First().y);
            DateTime highScoreTimeWithoutSeconds = HighScoreTime.AddSeconds(-HighScoreTime.Second);
            Console.Write("High Score: " + HighScore + " achieved at " + highScoreTimeWithoutSeconds);
        }
    }
}