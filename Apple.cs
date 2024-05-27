namespace RealSnakeGame {
    public class Apple : Character {
        public Apple(ConsoleColor color) {
            Color = color;
            Speed = 0;
            Length = 1;
        }

        public void Update(Snake snake, Score score, GameSet gameSet) {
            if (Position.Count == 0) {
                Random rnd = new();
                Position.Add((rnd.Next(2, 60), rnd.Next(2, 20)));
            }

            if(Position.Contains(snake.Position.Last())) {
                snake.Length++;
                score.IncreaseScore(snake);
                score.Update(gameSet);
                Position.Clear();
            }
            gameSet.DrawPositions.Add((Position.First().x, Position.First().y, this));
        }
    }
}
