namespace RealSnakeGame {
    public class Wall {
        public int Height, Width;
        public int Col, Row;

        public Wall(int width, int height) {
            Height = height + 2;
            Width = width + 2;
        }   

        public void Draw() {
            for(int h = 0; h <= Height; h++) {
                for(int w = 0; w <= Width; w++) {
                    if((w == 0 || w == Width) && !(h == 0 || h == Height)) {
                        Console.Write("\u2551");
                    }
                    if(!(w == 0 || w == Width) && (h == 0 || h == Height)) {
                        Console.Write("\u2550");
                    }
                    if(!(w == 0 || w == Width) && !(h == 0 || h == Height)) {
                        Console.Write(" ");
                    }
                    if(w == 0 && h == 0) {
                        Console.Write("\u2554");
                    }
                    if(w == Width && h == 0) {
                        Console.Write("\u2557");
                    }
                    if(w == 0 && h == Height) {
                        Console.Write("\u255A");
                    }
                    if(w == Width && h == Height) {
                        Console.Write("\u255D");
                    }
                }
                Console.Write("\n");
            }
        }
    }
}
