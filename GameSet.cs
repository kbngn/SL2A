namespace RealSnakeGame;

public class GameSet
{
    public List<(int x, int y, object z)> DrawPosition = [];

    public async Task Draw(Snake snake, Apple apple, Score score, Wall wall)
    {
        wall.Draw();
        while (snake.Status == "Alive")
        {
            snake.Draw();
            await apple.Draw(this);
            await score.Draw(this);
        }
    }
}
