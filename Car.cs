using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaffeineRacer
{
    internal class Car
    {
        private bool _randomTeam = true;
        protected int X;
        protected int Y;
        protected float Speed;
        public virtual void Update(float dt)
        {

        }

        public void Render(Renderer r)
        {
        }
    }
}
