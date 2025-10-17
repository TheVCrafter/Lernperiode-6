using CaffeineRacer;

internal class PlayerCar : Car
{
    private string[,] design = new string[,]
    {
        { " ", "R", "R", "Y", "Y", "R", "R", " " },
        { "R", "DB", "DB", "Y", "Y", "DB", "DB", "R" },
        { "DB", " ", " ", "DB", "DB", " ", " ", "DB" },
        { " ", " ", " ", "DB", "DB", " ", " ", " " },
        { "B", "B", " ", "DB", "DB", " ", "B", "B" },
        { "B", "B", "B", "DB", "DB", "B", "B", "B" },
        { "B", "B", " ", "DB", "DB", " ", "B", "B" },
        { " ", " ", "DB", "DB", "DB", "DB", " ", " " },
        { " ", "DB", "DB", "B", "B", "DB", "DB", " " },
        { " ", "DB", "DB", "B", "B", "DB", "DB", " " },
        { " ", "DB", "DB", "Y", "Y", "DB", "DB", " " },
        { " ", "DB", "DB", "R", "R", "DB", "DB", " " },
        { " ", "DB", "DB", "R", "R", "DB", "DB", " " },
        { " ", " ", "DB", "DB", "DB", "DB", " ", " " },
        { "B", "B", " ", "DB", "DB", " ", "B", "B" },
        { "B", "B", "B", "DB", "DB", "B", "B", "B" },
        { "B", "B", " ", "DB", "DB", " ", "B", "B" },
        { " ", " ", "DB", "W", "W", "DB", " ", " " },
    };

    public int X { get; set; } = 40;
    public int Y { get; set; } = 20;

    public void MoveLeft() => X--;
    public void MoveRight(int maxWidth) => X = Math.Min(maxWidth - design.GetLength(1), X + 1);

    private string MapSymbolToColor(string symbol, Renderer r)
    {
        return symbol switch
        {
            "R" => r.Colors["RED_BULL_RED"],
            "Y" => r.Colors["RED_BULL_YELLOW"],
            "DB" => r.Colors["RED_BULL_DARK_BLUE"],
            "B" => r.Colors["BLACK"],
            "W" => r.Colors["WHITE"],
            " " => null, // transparent
            _ => null
        };
    }

    public void Render(Renderer r)
    {
        int rows = design.GetLength(0);
        int cols = design.GetLength(1);

        for (int row = 0; row < rows; row++)
        {
            int drawY = Y + row;

            for (int col = 0; col < cols; col++)
            {
                int drawX = X + col;
                if (drawX < 0 || drawX >= r.Width || drawY < 0 || drawY >= r.Height)
                    continue;

                string color = MapSymbolToColor(design[row, col], r);
                if (color != null)
                    r.SetPixel(drawX, drawY, color);
            }
        }
    }

}