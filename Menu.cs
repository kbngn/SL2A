namespace RealSnakeGame;

public class Menu : Score
{
    private Score score = new Score();
    public void ShowMenu()
    {
        while (true)
        {
            Console.WriteLine("Welcome to the Snake game!");
            Console.WriteLine("1. Start game");
            Console.WriteLine("2. View high scores");
            Console.WriteLine("3. Exit");
            Console.Write("Enter your choice: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    // Clear the console
                    Console.Clear();

                    // Start the game
                    GameSet gameSet = new GameSet();
                    gameSet.RunGame();
                    break;
                case "2":
                    // View high scores
                    ViewHighScores();
                    break;
                case "3":
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
}