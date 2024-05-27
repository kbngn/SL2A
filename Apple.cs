namespace RealSnakeGame {
    public class Apple : Character {
        public Apple(ConsoleColor color) { //Constructor to give an apple a CUSTOM COLOUR!!!
            Color = color;
            Speed = 0;
            Length = 1;
        }

        public void Update(GameSet gameSet) {
            if(Position.Count == 0) {
                Random rnd = new();
                (int x, int y) = (rnd.Next(2, gameSet.Wall.Width), rnd.Next(2, gameSet.Wall.Height));
                if(gameSet.Snake.Position.Contains((x, y))) {
                    (x, y) = (rnd.Next(2, 60), rnd.Next(2, 20));
                }
                else {
                    Position.Add((x, y));
                }
            }

            if(Position.Contains(gameSet.Snake.Position.Last())) {
                gameSet.Snake.Length++;
                gameSet.Score.Increase(gameSet.Snake);
                gameSet.Score.Update(gameSet);
                Position.Clear();
            }
            gameSet.DrawPositions.Add((Position.First().x, Position.First().y, this));
        }
    }
}
