using System;
using System.Collections.Generic;

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

        Random random = new Random();

        public void Run()
        {
            //Game Loop
        }

        public void Initialize()
        {
            renderer = new Renderer();
            coffeeBeans = new List<CoffeeBean>();
        }

        public void HandleInput()
        {
            //Handle Inputs
        }

        public void Update(float dt)
        {
            //Delta Time
        }

        public void Render()
        {
            SpawnCoffeeBean();
            foreach (CoffeeBean coffeeBean in coffeeBeans)
            {
                coffeeBean.Render(renderer);
            }
            renderer.Present();
        }

        private void CheckCollisions()
        {
            //Check for Collisions
        }

        private void SpawnCoffeeBean()
        {
            int x = random.Next(50, renderer.Width-50);
            int y = 0;
            coffeeBeans.Add(new CoffeeBean(x, y));
        }
    }
}
