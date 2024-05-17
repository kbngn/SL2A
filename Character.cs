namespace RealSnakeGame {
    public class Character {
        public List<(int x, int y)> Position = [];
        public int Length, Speed;
        public ConsoleColor Color;
        public List<(int fruitX, int fruitY)> fruitPosition = [];
        public List<(int scoreX, int scoreY)> scorePosition = [];
    }
}
