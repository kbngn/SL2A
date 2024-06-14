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
        public DateTime HighScoreTime; // Added this 22line
        public List<(int x, int y)> Position = new List<(int x, int y)>();
        public List<string> PlayerNames = new List<string>();
        public bool NewHighScoreAchieved;

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
                HighScoreTime = DateTime.Now;
                NewHighScoreAchieved = true;
            }
        }

        public void Increase(Snake snake)
        {
            CurrentScore += snake.Speed; // Score increases based on Snake speed
            snake.Speed++; // Snake speed increases based on score increases. This gets real hard real fast.
        }

        private Tuple<int, DateTime, string> LoadHighScore()
        {
            if (File.Exists(HighScoreFilePath))
            {
                try
                {
                    string[] scoreData = File.ReadAllLines(HighScoreFilePath);
                    int score = int.Parse(scoreData[0]);
                    DateTime time = DateTime.Parse(scoreData[1]);
                    string name = scoreData[2];
                    PlayerNames.Add(name); // Add the player name to the PlayerNames list
                    return Tuple.Create(score, time, name);
                }
                catch
                {
                    // Handle any errors that might occur during reading/parsing
                    return Tuple.Create(0, DateTime.MinValue, string.Empty);
                }
            }
            return Tuple.Create(0, DateTime.MinValue, string.Empty);
        }
        public void SaveHighScore()
        {
            try
            {
                foreach (var playerName in PlayerNames)
                {
                    string[] scoreData = { HighScore.ToString(), HighScoreTime.ToString(), playerName };
                    File.WriteAllLines(HighScoreFilePath, scoreData);
                }
            }
            catch
            {
                // Handle any errors that might occur during writing
                Console.WriteLine("Failed to save high score.");
            }
        }
        public void DrawHighScoreWithDate()
        {
            if (PlayerNames.Any()) // Check if the list is not empty
            {
                Console.SetCursorPosition(Position.First().x, Position.First().y);
                DateTime highScoreTimeWithoutSeconds = HighScoreTime.AddSeconds(-HighScoreTime.Second);
                Console.Write("High Score: " + HighScore + " achieved by " + PlayerNames.Last() + " at " + highScoreTimeWithoutSeconds);
            }
            else
            {
                Console.WriteLine("No highscores available yet.");
            }
        }
    }
}