namespace RealSnakeGame {
    public class Score : Character {
        public int CurrentScore;
        public int HighScore;

        public Score() {
            CurrentScore = 0;
            HighScore = 0;
            Color = ConsoleColor.Black;
            Position.Add((0, 25));
        }

        public void DrawScore() {
            Console.Write("Current Score: " + CurrentScore + "\n");
            Console.Write("High Score: " + HighScore);
        }

        public void Update(GameSet gameSet) {
            gameSet.DrawPositions.Add((Position.First().x, Position.First().y, this));
            if (CurrentScore >= HighScore) {
                HighScore = CurrentScore;
            }
        }

        public void IncreaseScore(Snake snake) {
            CurrentScore += snake.Speed; //Score increases based on Snake speed
            snake.Speed++; //Snake speed increases based on score increases. This gets real hard real fast.
        }
    }
}