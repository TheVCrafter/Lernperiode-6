using System;
using System.Collections.Generic;
using System.Text;

namespace CaffeineRacer
{
    internal class Renderer
    {
        private string[,] _screen;
        public Dictionary<string, string> Colors;
        //public Dictionary<string, string> _bgColors;
        //public Dictionary<string, string> _fgColors;

        public int Width;
        public int Height;
        private readonly Random _random = new Random();

        public List<string[,]> CarDesigns { get; set; }

        public Renderer()
        {
            Width = Console.WindowWidth;
            Height = Console.WindowHeight;
            Console.BufferHeight = Height + 1;
            Console.BufferWidth = Width;

            _screen = new string[Width, Height * 2];

            InitializeColors();
            Clear();
        }

        private void InitializeColors()
        {
            Colors = new Dictionary<string, string>()
{
    // Environment
    { "GRASS_DARK", "2;0;100;0m" },
    { "GRASS_MEDIUM", "2;0;150;0m" },
    { "GRASS_LIGHT", "2;0;200;0m" },
    { "ASPHALT_DARK", "2;50;50;50m" },
    { "ASPHALT_MEDIUM", "2;100;100;100m" },
    { "ASPHALT_LIGHT", "2;150;150;150m" },

    // Track Curbs
    { "CURB_RED", "2;255;0;0m" },
    { "CURB_YELLOW", "2;255;215;0m" },
    { "CURB_WHITE", "2;255;255;255m" },

    // Coffee Beans
    { "COFFEE_LIGHT", "2;141;68;17m" },
    { "COFFEE_MEDIUM", "2;99;51;15m" },
    { "COFFEE_DARK", "2;64;30;5m" },

    // General colors
    { "BLACK", "2;0;0;0m" },
    { "WHITE", "2;255;255;255m" },

    // Ferrari
    { "FERRARI_DARK_RED", "2;130;23;41m" },
    { "FERRARI_RED", "2;232;0;45m" },
    { "FERRARI_LIGHT_RED", "2;255;76;106m" },
    { "FERRARI_YELLOW", "2;255;221;0m" },
    { "FERRARI_WHITE", "2;255;255;255m" },

    // Mercedes
    { "MERCEDES_DARK_GRAY", "2;60;60;60m" },
    { "MERCEDES_GRAY", "2;128;128;128m" },
    { "MERCEDES_LIGHT_GRAY", "2;192;192;192m" },
    { "MERCEDES_TURQUOISE", "2;0;215;182m" },

    // Red Bull Racing
    { "RED_BULL_RED", "2;218;41;28m" },
    { "RED_BULL_DARK_BLUE", "2;0;0;139m" },
    { "RED_BULL_BLUE", "2;71;129;215m" },
    { "RED_BULL_LIGHT_BLUE", "2;173;216;230m" },
    { "RED_BULL_YELLOW", "2;255;215;0m" },

    // McLaren
    { "MCLAREN_ORANGE", "2;255;128;0m" },
    { "MCLAREN_WHITE", "2;255;255;255m" },

    // Alpine
    { "ALPINE_BLUE", "2;0;161;232m" },
    { "ALPINE_RED", "2;255;0;0m" },
    { "ALPINE_WHITE", "2;255;255;255m" },

    // Aston Martin
    { "ASTON_MARTIN_GREEN", "2;34;153;113m" },
    { "ASTON_MARTIN_WHITE", "2;255;255;255m" },

    // Williams
    { "WILLIAMS_BLUE", "2;24;104;219m" },
    { "WILLIAMS_WHITE", "2;255;255;255m" },

    // Alfa Romeo
    { "ALFA_ROMEO_RED", "2;186;0;0m" },
    { "ALFA_ROMEO_WHITE", "2;255;255;255m" },

    // Haas
    { "HAAS_RED", "2;186;0;0m" },
    { "HAAS_WHITE", "2;255;255;255m" },

    // AlphaTauri
    { "ALPHATAURI_BLUE", "2;0;0;255m" },
    { "ALPHATAURI_WHITE", "2;255;255;255m" }
};
        }

        public void SetPixel(int x, int y, string color)
        {
            if (x >= 0 && x < Width && y >= 0 && y < _screen.GetLength(1))
            {
                _screen[x, y] = color;
            }
        }

        public void Clear()
        {
            for (int x = 0; x < Width; x++)
                for (int y = 0; y < Height * 2; y++)
                {
                    _screen[x, y] = Colors["GRASS_DARK"];
                }

        }

        public void Present()
        {
            Console.SetCursorPosition(0, 0);
            var sb = new StringBuilder(Width * Height * 4);

            for (int y = 0; y < Height * 2; y += 2)
            {
                for (int x = 0; x < Width; x++)
                {
                    string top = $"\u001b[38;{_screen[x, y]}";
                    string bottom = $"\u001b[48;{_screen[x, y + 1]}";
                    sb.Append(top).Append(bottom).Append('▀');
                }
                sb.Append("\u001b[0m");
                if (y < Height * 2 - 2) sb.Append('\n');
            }
            Console.Write(sb.ToString());
            Console.SetCursorPosition(0, 0);
        }

    }
}
