using System;

namespace CaffeineRacer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();
            game.Initialize();
            game.Render();
            /*game.Run();*/             
        }
    }
}
