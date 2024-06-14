namespace RealSnakeGame;

public class Menu : Score
{
    private Score score;

    public Menu(Score score)
    {
        this.score = score;
    }
    public void ShowMenu()
    {
        while (true)
        {
            Console.WriteLine("Welcome to the Snake game!");
            Console.WriteLine("1. Start game");
            Console.WriteLine("2. View high scores");
            Console.WriteLine("3. View game rules");
            Console.WriteLine("4. Exit");
            Console.Write("Enter your choice: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    // Clear the console
                    Console.Clear();

                    // Start the game
                    GameSet gameSet = new GameSet(score);
                    gameSet.RunGame();
                    break;
                case "2":
                    // View high scores
                    ViewHighScores();
                    break;
                case "3":
                    // View game rules
                    ViewGameRules();
                    break;
                case "4":
                    // Exit the application
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }

    private void ViewHighScores()
    {
        Console.Clear();
        score.DrawHighScoreWithDate();
        Console.WriteLine("\nPress any key to return to the menu...");
        Console.ReadKey();
        Console.Clear();
    }
    private void ViewGameRules()
    {
        Console.Clear();
        Console.WriteLine("Game Rules:");
        Console.WriteLine("1. The snake moves in the direction of the arrow keys.");
        Console.WriteLine("2. The snake grows by one segment each time it eats an apple.");
        Console.WriteLine("3. The game ends when the snake hits the wall or its own body.");
        Console.WriteLine("\nPress any key to return to the menu...");
        Console.ReadKey();
        Console.Clear();
    }
}