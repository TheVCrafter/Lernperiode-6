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

        public void Run()
        {
            //Game Loop
        }

        public void Initialize()
        {
            //Init Logic
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
            //Draw Game
        }

        private void CheckCollisions()
        {
            //Check for Collisions
        }

        private void SpawnCoffeeBean()
        {
            //Spawn a Coffee Bean
        }
    }
}
