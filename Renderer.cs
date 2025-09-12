using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CaffeineRacer
{
    internal class Renderer
    {
        private string[,] _screen;
        public int Width;
        public int Height;
        public Renderer()
        {
            Width = Console.WindowWidth;
            Height = Console.WindowHeight;
            Console.BufferHeight = Height;
            Console.BufferWidth = Width;

            _screen = new string[Width, Height];

            for (int i = 0; i < Width; i++)
            {
                for (int j = 0; j < Height; j++)
                {
                    _screen[i, j] = "\u001b[48;2;0;100;0m\u001b[38;2;0;100;0m";
                }
            }
        }
        public void Clear()
        {

        }

        public void DrawTrack(int offset)
        {
            string ColorWhite = "\u001b[48;2;255;255;255m\u001b[38;2;255;255;255m";
            string ColorRed = "\u001b[48;2;255;0;0m\u001b[38;2;255;0;0m";
            string trackColor = "\u001b[48;2;70;70;70m\u001b[38;2;70;70;70m";

            for (int i = 0; i < Height; i++)
            {
                string curbColor = ((i / 2) % 2 == 0) ? ColorWhite : ColorRed;
                int yPos = (i + offset) % Height;
                for (int b = 0; b < 3; b++)
                {
                    _screen[10 + b, yPos] = curbColor;
                    _screen[Width - 11 - b, yPos] = curbColor;
                }

                for (int j = 13; j < Width - 13; j++)
                {
                    _screen[j, yPos] = trackColor;
                }
            }
        }


        public void DrawCar(int x, int y, bool player)
        {

        }

        public void DrawCoffeeBean(int x, int y)
        {
            // Mittelbraun (rgba(99,51,15,255))
            string foreBrownMedium = "\u001b[38;2;99;51;15m";
            string backBrownMedium = "\u001b[48;2;99;51;15m";

            // Hellbraun (rgba(141,68,17,255))
            string foreBrownLight = "\u001b[38;2;141;68;17m";
            string backBrownLight = "\u001b[48;2;141;68;17m";  

            // Dunkelbraun (rgba(64,30,5,255))
            string foreBrownDark = "\u001b[38;2;64;30;5m";
            string backBrownDark = "\u001b[48;2;64;30;5m";

            //Bean
            _screen[x, y] += foreBrownMedium;
            _screen[x + 1, y] += foreBrownMedium;
            if (y>0)
            {
                _screen[x-1, y - 1] = backBrownLight + foreBrownLight;
                _screen[x, y-1] = backBrownMedium + foreBrownLight;
                _screen[x + 1, y - 1] = backBrownDark + foreBrownDark;
                _screen[x + 2, y-1] = backBrownMedium + foreBrownMedium;
            }
            if (y > 1)
            {
                _screen[x - 1, y - 2] += backBrownLight;
                _screen[x, y - 2] = backBrownDark + foreBrownLight;
                _screen[x + 1, y - 2] = backBrownMedium + foreBrownLight;
                _screen[x + 2, y - 2] += backBrownMedium;
            }
        }


        public void Present()
        {
            for (int i = 0;i < Width;i++)
            {
                for (int j = 0;j < Height;j++)
                {
                    Console.SetCursorPosition(i,j);
                    Console.Write(_screen[i,j] + "▀");
                }
            }
        }
    }
}
