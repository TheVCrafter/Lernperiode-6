using CaffeineRacer;

internal class CoffeeBean
{
    private int x, y;

    public CoffeeBean(int startX, int startY)
    {
        x = startX;
        y = startY;
    }

    public void Update(float dt)
    {
        y++; // simple downward movement
    }

    private string MapBeanColor(string symbol, Renderer r)
    {
        return symbol switch
        {
            "L" => r.Colors["COFFEE_LIGHT"],
            "M" => r.Colors["COFFEE_MEDIUM"],
            "D" => r.Colors["COFFEE_DARK"],
            _ => r.Colors["GRASS_DARK"]
        };
    }

    public void Render(Renderer r)
    {
        if (x < 0 || x + 3 >= r.Width || y < 0 || y >= r.Height) return;

        string[,] beanDesign = new string[,]
        {
            { "L", "M", "D", "M" }, // top layer
            { "M", "D", "M", "L" }  // bottom layer
        };

        int rows = beanDesign.GetLength(0);
        int cols = beanDesign.GetLength(1);

        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < cols; col++)
            {
                int drawX = x + col;
                int drawY = y + row;

                if (drawX < 0 || drawX >= r.Width || drawY < 0 || drawY >= r.Height) continue;

                string color = MapBeanColor(beanDesign[row, col], r);
                r.SetPixel(drawX, drawY, color);
            }
        }
    }
}
