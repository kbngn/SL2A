namespace RealSnakeGame;

public class Menu
{
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
                    // You'll need to implement this method
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
        // Implement your high scores viewing logic here
    }
}