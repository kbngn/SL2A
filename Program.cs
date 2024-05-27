namespace RealSnakeGame {
    public class Program {
        static void Main() {
            Console.CursorVisible = false;
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            GameSet gameSet = new();
            gameSet.RunGame();
        }
    }
}