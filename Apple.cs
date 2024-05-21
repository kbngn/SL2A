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

        public async Task Draw(GameSet gameSet)
        {
            gameSet.DrawPosition.Add((Position.First().x, Position.First().y, this));
            Console.BackgroundColor = Color;
            Console.Write("O");
            Console.ResetColor();
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
                    // await Draw();
                }

                if (fruitPosition.Contains(snake.Position.Last()))
                {
                    snake.Length++;
                    score.IncreaseScore(10);
                    await score.Update();
                    fruitPosition.Clear();
                }
                snake.canUpdate = true;
            }
        }
    }
}
