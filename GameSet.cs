namespace RealSnakeGame {
    public class GameSet {
        public List<(int x, int y, object o)> DrawPositions = [];
        public bool Paused = false;
        public Snake Snake;
        public Apple Apple;
        public Score Score;
        public Wall Wall;

        public GameSet(Snake snake, Apple apple, Score score, Wall wall) {
            Snake = snake;
            Apple = apple;
            Score = score;
            Wall = wall;
        }

        public void Setup() {
            if(Snake.Position.Count > 1 || Apple.Position.Count != 0 || Score.CurrentScore != 0) {
                //Reset Game
                Snake.Position.Clear(); //Clear lists of all positions
                Apple.Position.Clear(); //Same with apples
                Score.CurrentScore = 0; //Resets only the current score
                Snake.Position.Add((Wall.Width/2, Wall.Height/2)); //Sets snake position to middle (default start)
                Snake.Speed = 8; //Default snake speed
            }
            Console.Clear(); //Clears console
            Wall.Draw();
            Snake.Alive = true;
            RunGame();
        }

        public void RunGame() {
            while(Paused == false) {
                Task.WaitAny(
                    Draw(Snake, Apple, Score),
                    Update(Snake, Apple, Score, Wall),
                    Task.Delay(Snake.MovementMultiplier)
                );
                //PauseGame();
                if(!Snake.Alive) {
                    GameOver();
                }
            }
        }

        public void PauseGame() {
            if(Console.KeyAvailable) {
                ConsoleKey Key = Console.ReadKey(true).Key;
                if(Key == ConsoleKey.P || Key == ConsoleKey.Spacebar) {
                    if(Paused == false) {
                        Paused = true;
                    }
                    else {
                        Paused = false;
                    }
                }
            }
        }

        public void GameOver() {
            string gameOverText = "YOU DIED";
            string continueText = "CONTINUE? Y/N";
            Console.SetCursorPosition((Wall.Width / 2 - (gameOverText.Length / 2)), Wall.Height / 2 - 1);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(gameOverText);
            Console.SetCursorPosition((Wall.Width / 2 - (continueText.Length / 2)), Wall.Height / 2); // New line so walls dont break on writing line
            Console.Write(continueText);
            if(Console.KeyAvailable) {
                ConsoleKey Key = Console.ReadKey(true).Key;
                Reset(Key);
            }
        }

        public void Reset(ConsoleKey Key) {
            if(Key == ConsoleKey.Y) {
                Setup();
            }
            else if(Key == ConsoleKey.N){
                Environment.Exit(0);
            }
        }

        public async Task Draw(Snake snake, Apple apple, Score score) {
            foreach(var (x, y, o) in DrawPositions) {
                Console.SetCursorPosition(x, y);
                if(o == snake && snake.Alive) {
                    Console.BackgroundColor = snake.Color;
                    snake.Draw();
                }
                if(o == apple) {
                    snake.Move = false;
                    Console.BackgroundColor = apple.Color;
                    apple.Draw();
                }
                if(o == score) {
                    snake.Move = false;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = score.Color;
                    score.DrawScore();
                }
            }
            DrawPositions.Clear();
            Console.BackgroundColor = default;
            Console.ForegroundColor = default;
            snake.Move = true;
            await Task.Delay(snake.MovementMultiplier / 2);
        }

        public async Task Update(Snake snake, Apple apple, Score score, Wall wall) {
            snake.Update(wall, this);
            apple.Update(snake, score, this);
            score.Update(this);
            await Task.Delay(snake.MovementMultiplier / 2);
        }
    }
}
