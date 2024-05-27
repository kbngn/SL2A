namespace RealSnakeGame {
    public class Program {
        static void Main() {
            Console.CursorVisible = false;
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Wall wallE = new (60,20);
            wallE.Draw();
            Snake snakey = new((wallE.Width/2), (wallE.Height/2), ConsoleColor.DarkGreen);
            Apple appie = new(ConsoleColor.Red);
            Score scorie = new();
            GameSet gameSet = new(snakey, appie, scorie, wallE);
            gameSet.RunGame();
        }
    }
}