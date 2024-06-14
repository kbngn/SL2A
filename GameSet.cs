namespace RealSnakeGame {
    public class GameSet {
        public List<(int x, int y, object o)> DrawPositions = [];
        public bool Paused = false;
        public Snake Snake;
        public Apple Apple;
        public Score Score;
        public Wall Wall;

        public GameSet(Score score) {
            this.Score = score;
            Wall = new(60, 20);
            Snake = new(Wall.Width/2, Wall.Height/2, ConsoleColor.DarkGreen);
            Apple = new(ConsoleColor.Red);
            Wall.Draw();
        }

        public void Setup() {
            if(Snake.Position.Count > 1 || Apple.Position.Count > 0 || Score.CurrentScore > 0) {
                //Reset Game
                Snake.Position.Clear(); //Clear lists of all positions
                Apple.Position.Clear(); //Same with apples
                DrawPositions.Clear(); //Clears all the drawing positions~~
                Score.CurrentScore = 0; //Resets only the current score
                Snake.Position.Add((Wall.Width/2, Wall.Height/2)); //Sets snake position to middle (default start)
                Snake.Direction = ConsoleKey.RightArrow; //Default snake direction
                Snake.Speed = 8; //Default snake speed
                Snake.Length = 1; //Default snake length
            }
            Console.Clear(); //Clears console
            Wall.Draw();
            Snake.Alive = true;
            RunGame();
        }

        public void RunGame() {
            while(Paused == false) {
                Task.WaitAny(
                    DrawAll(),
                    UpdateAll(),
                    Task.Delay(Snake.MovementMultiplier)
                );
                // PauseGame();
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

        public void GameOver()
        {
            string gameOverText = "YOU DIED";
            string continueText = "CONTINUE? Y/N";
            Console.SetCursorPosition((Wall.Width / 2 - (gameOverText.Length / 2)), Wall.Height / 2 - 1);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(gameOverText);
            Console.SetCursorPosition((Wall.Width / 2 - (continueText.Length / 2)), Wall.Height / 2); // New line so walls dont break on writing line
            Console.Write(continueText);
            if (Score.NewHighScoreAchieved)
            {
                Console.Write("\nCongratulations! You've achieved a new high score. Please enter your name: \n");
                string playerName = Console.ReadLine();
                Score.PlayerNames.Add(playerName);
                Score.SaveHighScore();
                Score.NewHighScoreAchieved = false;
            }
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
                Console.Write("\nThank you for playing!");
                Environment.Exit(0);
            }
        }

        public async Task DrawAll() {
            foreach(var (x, y, o) in DrawPositions) {
                Console.SetCursorPosition(x, y);
                if(o == Snake && Snake.Alive) {
                    Console.BackgroundColor = Snake.Color;
                    Snake.Draw();
                }
                if(o == Apple) {
                    Console.BackgroundColor = Apple.Color;
                    Apple.Draw();
                }
                if(o == Score) {
                    Snake.Move = false;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.Black;
                    Score.Draw();
                }
            }
            DrawPositions.Clear();
            Console.BackgroundColor = default;
            Console.ForegroundColor = default;
            Snake.Move = true;
            await Task.Delay(Snake.MovementMultiplier / 2);
        }

        public async Task UpdateAll() {
            Snake.Update(Wall, this);
            Apple.Update(this);
            Score.Update(this);
            await Task.Delay(Snake.MovementMultiplier / 2);
        }
    }
}
