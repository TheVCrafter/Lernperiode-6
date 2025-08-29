using System;

namespace CaffeineRacer
{
    internal class InputHandler
    {
        public bool IsKeyPressed(ConsoleKey key)
        {
            if (Console.KeyAvailable)
            {
                var pressedKey = Console.ReadKey(true).Key;
                return pressedKey == key;
            }
            return false;
        }
    }
}
