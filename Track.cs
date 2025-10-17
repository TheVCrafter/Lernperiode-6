using CaffeineRacer;

internal class Track
{
    private string MapCurbColor(int logicalRow, int offset, Renderer r)
    {
        int rowsPerStripe = 4;

        // Subtract offset so the stripes move downward
        int stripeIndex = ((logicalRow - offset) + rowsPerStripe * 2) / rowsPerStripe;

        return stripeIndex % 2 == 0 ? r.Colors["CURB_WHITE"] : r.Colors["CURB_RED"];
    }

    private string MapTrackColor(Renderer r)
    {
        return r.Colors["ASPHALT_DARK"];
    }

    public void Render(Renderer r, int offset)
    {
        int logicalRows = r.Height * 2;
        int width = r.Width;

        for (int row = 0; row < logicalRows; row++)
        {
            for (int b = 0; b < 3; b++)
            {
                string curbColor = MapCurbColor(row, offset, r);
                r.SetPixel(10 + b, row, curbColor);
                r.SetPixel(width - 11 - b, row, curbColor);
            }

            string trackColor = MapTrackColor(r);
            for (int x = 13; x < width - 13; x++)
            {
                r.SetPixel(x, row, trackColor);
            }
        }
    }
}
