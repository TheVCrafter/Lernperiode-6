using System;

namespace CaffeineRacer
{
    internal static class Timer
    {
        private static DateTime lastFrame = DateTime.Now;

        public static float GetDeltaTime()
        {
            DateTime now = DateTime.Now;
            float dt = (float)(now - lastFrame).TotalSeconds;
            lastFrame = now;
            return dt;
        }
    }
}
