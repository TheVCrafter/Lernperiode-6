namespace CaffeineRacer
{
    internal class Track
    {
        public int Offset { get; private set; } = 0;

        public void Render(Renderer r)
        {
            r.DrawTrack(Offset);
            Offset++;

            if (Offset == 4)
            {
                Offset = 0;
            }
        }
    }
}