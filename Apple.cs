using System;
using System.Collections.Generic;

namespace RealSnakeGame {
    public class Apple : Character {
        public Apple(ConsoleColor color)
        {
            Color = color;
            Speed = 0;
            Length = 1;
        }

        public async Task Draw()
        {
            (int fruitX, int fruitY) returnPosition = Console.GetCursorPosition();
            await Task.Run(()=>Console.SetCursorPosition(fruitPosition.First().fruitX, fruitPosition.First().fruitY));
            Console.BackgroundColor = Color;
            Console.Write("O");
            Console.ResetColor();
            Console.SetCursorPosition(returnPosition.fruitX, returnPosition.fruitY);
            await Task.Delay(10);
        }

        public async Task Update(Snake snake, Score score)
        {
            while (snake.Status == "Alive")
            {
                snake.canUpdate = false;
                if (fruitPosition.Count == 0)
                {
                    Random rnd = new Random();
                    fruitPosition.Add((rnd.Next(1, 60), rnd.Next(1, 20)));
                    await Draw();
                }

                if (fruitPosition.Contains(snake.Position.Last()))
                {
                    snake.Length++;
                    score.IncreaseScore(10);
                    fruitPosition.Clear();
                }
                snake.canUpdate = true;
            }
        }
    }
}
