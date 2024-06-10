namespace RealSnakeGame {
    public class Program {
        static void Main() {
            Console.CursorVisible = false;
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Menu menu = new Menu();
            menu.ShowMenu();
            GameSet gameSet = new();
            gameSet.RunGame();
        }
    }
}