using System;
using System.Collections.Generic;
using System.Threading;

namespace CaffeineRacer
{
    internal class Game
    {
        private PlayerCar playerCar;
        private List<OpponentCar> opponents;
        private List<CoffeeBean> coffeeBeans;
        private Track track;
        private Renderer renderer;
        private InputHandler inputHandler;

        private Random random = new Random();

        private volatile int trackOffset = 0;
        private bool running = false;

        private int coffeeSpawnTimer = 0;
        private const int CoffeeSpawnInterval = 2000;

        public void Initialize()
        {
            renderer = new Renderer();
            track = new Track();
            playerCar = new PlayerCar();
            opponents = new List<OpponentCar>();
            coffeeBeans = new List<CoffeeBean>();
            inputHandler = new InputHandler();

            running = true;
            Thread trackThread = new Thread(TrackLoop);
            trackThread.IsBackground = true;
            trackThread.Start();

            // Start main game loop
            Run();
        }

        private void TrackLoop()
        {
            const int trackSleepMs = 100;
            while (running)
            {
                trackOffset++;
                if (trackOffset >= 8)
                {
                    trackOffset = 0;
                }
                Thread.Sleep(trackSleepMs);
            }
        }

        public void Run()
        {
            DateTime lastUpdate = DateTime.Now;

            while (running)
            {
                DateTime now = DateTime.Now;
                float dt = (float)(now - lastUpdate).TotalSeconds;
                lastUpdate = now;

                HandleInput();
                Update(dt);
                Render();

                Thread.Sleep(1);
            }
        }

        private void HandleInput()
        {
            while (Console.KeyAvailable)
            {
                var key = Console.ReadKey(true).Key;

                switch (key)
                {
                    case ConsoleKey.A:
                        playerCar.MoveLeft();
                        break;
                    case ConsoleKey.D:
                        playerCar.MoveRight(renderer.Width);
                        break;
                    case ConsoleKey.Escape:
                        running = false;
                        break;
                }
            }
        }

        private void Update(float dt)
        {
            // Move opponents and coffee beans
            foreach (var coffee in coffeeBeans)
            {
                coffee.Update(dt);
            }

            foreach (var opponent in opponents)
            {
                opponent.Update(dt);
            }

            // Spawn coffee beans periodically
            coffeeSpawnTimer += (int)(dt * 1000);
            if (coffeeSpawnTimer >= CoffeeSpawnInterval)
            {
                SpawnCoffeeBean();
                coffeeSpawnTimer = 0;
            }

            // Check collisions
            CheckCollisions();
        }

        private void Render()
        {
            renderer.Clear();
            track.Render(renderer, trackOffset);
            playerCar.Render(renderer);

            /*foreach (var opponent in opponents)
            {
                opponent.Render(renderer);
            }

            foreach (var coffee in coffeeBeans)
            {
                coffee.Render(renderer);
            }*/

            renderer.Present();
        }

        private void CheckCollisions()
        {
            // Implement collision checks between player, opponents, and coffee beans
        }

        private void SpawnCoffeeBean()
        {
            int x = random.Next(10, renderer.Width - 10);
            int y = 5;
            coffeeBeans.Add(new CoffeeBean(x, y));
        }
    }
}
