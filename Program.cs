using System.Runtime.Intrinsics.X86;

namespace RealSnakeGame {
    public class Program {
        static void Main() {
            Console.WriteLine("");
            Console.CursorVisible = false;
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Wall wallE = new (1,1,60,20);
            wallE.Draw();
            Snake snakey = new((wallE.Width/2), (wallE.Height/2), ConsoleColor.DarkGreen);
            Apple appie = new(ConsoleColor.Red);
            Score scorie = new();
            Console.SetCursorPosition(snakey.Position.First().x, snakey.Position.First().y);
            Task.WaitAny(snakey.Update(snakey), appie.Update(snakey, scorie));
        }
    }
}