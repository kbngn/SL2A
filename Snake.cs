namespace RealSnakeGame {
    public class Snake : Character {
        public bool Alive, Move;
        public ConsoleKey Direction;
        public int MovementMultiplier;
        public (int x, int y) Heading;

        public Snake(int x, int y, ConsoleColor color) {
            Position.Add((x, y)); //Voegt de meegegeven positie toe als startpositie
            Length = 1; //Standaard startlengte
            Speed = 8; //Standaard snelheid
            Color = color;
            Alive = true;
            Direction = ConsoleKey.RightArrow; //Beweegt standaard naar rechts
            MovementMultiplier = 1000 / Speed;
        }

        public void CheckCollision(Wall wall) {
            if(Heading.x == wall.Width || Heading.x == 0 || Heading.y == wall.Height || Heading.y == 0 || Position.Contains(Heading)) {
                Alive = false;
                Move = false;
            }
        }

        public void Update(Wall wall, GameSet gameSet) {
            if(Alive && Move) {
                Heading = Position.Last();
                MovementMultiplier = 1000/Speed;

                if(Console.KeyAvailable) {
                    ConsoleKey key = Console.ReadKey(true).Key;
                    switch(key) { //Switch statement prevents movement in the opposite direction to prevent suicide
                        case ConsoleKey.LeftArrow:
                            if(Direction != ConsoleKey.RightArrow) { Direction = key; };
                            break;
                        case ConsoleKey.RightArrow:
                            if(Direction != ConsoleKey.LeftArrow) { Direction = key; };
                            break;
                        case ConsoleKey.UpArrow:
                            if(Direction != ConsoleKey.DownArrow) { Direction = key; };
                            break;
                        case ConsoleKey.DownArrow:
                            if(Direction != ConsoleKey.UpArrow) { Direction = key; };
                            break;
                    }
                }

                switch(Direction) {
                    case ConsoleKey.RightArrow:
                        Heading.x++;
                        break;
                    case ConsoleKey.LeftArrow:
                        Heading.x--;
                        break;
                    case ConsoleKey.DownArrow:
                        Heading.y++;
                        MovementMultiplier *= 2;
                        break;
                    case ConsoleKey.UpArrow:
                        Heading.y--;
                        MovementMultiplier *= 2;
                        break;
                }

                CheckCollision(wall); //Check for collision
                Position.Add(Heading); // Adds the front of the snake to the list of the snake positions
                if(Position.Count > Length + 1) {
                    Console.SetCursorPosition(Position.First().x, Position.First().y);
                    Console.Write(" ");
                    Position.Remove(Position.First()); //Remove oldest element (Tail end) from position list
                }
                foreach(var (x, y) in Position) {
                    gameSet.DrawPositions.Add((x, y, this));
                }
            }
        }
    }
}
