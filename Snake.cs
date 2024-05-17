using System.Diagnostics;
using Microsoft.VisualBasic;

namespace RealSnakeGame {
    public class Snake : Character {
        public string Status;
        public ConsoleKey Direction;
        public string Head, Body;
        public bool canUpdate = true;
        
        public void Debug(string message) {
            Console.SetCursorPosition(0,30);
            Console.WriteLine(message);
        }

        public Snake(int x, int y, ConsoleColor color) {
            Position.Add((x, y)); //Voegt de meegegeven positie toe als startpositie
            Length = 1; //Standaard startlengte
            Speed = 10; //Standaard snelheid
            Color = color;
            Status = "Alive";
            Direction = ConsoleKey.RightArrow; //Beweegt standaard naar rechts
            Head = ":";
            Body = " ";
        }

        public void Draw() {  
            Console.BackgroundColor = ConsoleColor.Black; // Reset the color to default
            if(Position.Count() > Length){ // If the Position is longer then the max Length of the snake, remove the back
                Console.SetCursorPosition(Position.First().x, Position.First().y); // Sets the position to the back of the snake
                Console.Write(" "); // Remove the last part of the snake
                Position.Remove(Position.First());
                Console.SetCursorPosition(Position.Last().x, Position.Last().y);
            }
            Console.BackgroundColor = Color; // Sets the background color to green
            Console.ForegroundColor = ConsoleColor.White;
            foreach ((int x, int y)pos in Position)
            {
                Console.SetCursorPosition(pos.x, pos.y);
                if (pos == Position.Last())
                {
                    Console.Write(Head);
                }
                else
                {
                    Console.Write(Body);
                }
            }
        }
        
        public async Task Update() {
            while (Status == "Alive")
            {
                if (canUpdate)
                {
                    (int x, int y) frontPos = Position.Last();
                    (int x, int y) backPos = Position.First();
                    if (Console.KeyAvailable)
                    {
                        Direction = Console.ReadKey(true).Key;
                    }

                    switch (Direction)
                    {
                        case ConsoleKey.RightArrow:
                            frontPos.x++;
                            break;
                        case ConsoleKey.LeftArrow:
                            frontPos.x--;
                            break;
                        case ConsoleKey.DownArrow:
                            frontPos.y++;
                            await Task.Delay(1000 / (Speed * 2));
                            break;
                        case ConsoleKey.UpArrow:
                            frontPos.y--;
                            await Task.Delay(1000 / (Speed * 2));
                            break;
                    }

                    foreach ((int x, int y) pos in Position)
                    {
                        if (frontPos == pos)
                        {
                            Debug("Test1");
                            Console.WriteLine("Botst tegen zichzelf aan");
                            Status = "Dead";
                            break;
                        }

                        // Check of de slang tegen de muur aan botst
                        if (frontPos.x == 0 || frontPos.x == 60 || frontPos.y == 0 || frontPos.y == 20)
                        {
                            Debug("Test2");
                            Console.WriteLine("Botst tegen de muur aan");
                            Status = "Dead";
                            break;
                        }
                    }

                    Console.SetCursorPosition(frontPos.x, frontPos.y); // Sets the cursor to the new position
                    Position.Add(frontPos); // Adds the front of the snake to the list of the snake positions
                    Draw(); // Draws the front of the snake
                    await Task.Delay((1000 / Speed));
                }
            }
        }
    }
}
