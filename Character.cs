﻿namespace RealSnakeGame {
    public class Character {
        public List<(int x, int y)> Position = [];
        public int Length, Speed;
        public ConsoleColor Color;

        public void Draw(){
            Console.Write(" "); //Very simple drawing method ;)
        }
    }
}
