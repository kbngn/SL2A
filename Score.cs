namespace RealSnakeGame {
    public class Score {
        public int CurrentScore;
        public int HighScore;
        public List<(int x, int y)> Position = [];

        public Score() {
            CurrentScore = 0;
            HighScore = 0;
            Position.Add((0, 23));
        }

        public void Draw() {
            Console.Write("Current Score: " + CurrentScore + "\n");
            Console.Write("High Score: " + HighScore);
        }

        public void Update(GameSet gameSet) {
            gameSet.DrawPositions.Add((Position.First().x, Position.First().y, this));
            if (CurrentScore >= HighScore) {
                HighScore = CurrentScore;
            }
        }

        public void Increase(Snake snake) {
            CurrentScore += snake.Speed; //Score increases based on Snake speed
            snake.Speed++; //Snake speed increases based on score increases. This gets real hard real fast.
        }
    }
}