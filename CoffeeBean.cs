using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaffeineRacer
{
    internal class CoffeeBean
    {
        int X;
        int Y;
        float CaffeineValue;
        float BoostValue;

        public CoffeeBean(int x, int y)
        {
            X = x;
            Y = y;
        }
        public void Update(float dt)
        {

        }

        public void Render(Renderer r)
        {
            r.DrawCoffeeBean(X, Y);
        }
    }
}
