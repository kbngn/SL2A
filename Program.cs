namespace RealSnakeGame {
    public class Program {
        static void Main() {
            Console.CursorVisible = false;
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Score score = new Score();
            Menu menu = new Menu(score);
            menu.ShowMenu();
            GameSet gameSet = new(score);
            gameSet.RunGame();
        }
    }
}