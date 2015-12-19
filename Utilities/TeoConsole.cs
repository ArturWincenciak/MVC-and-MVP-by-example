using System;

namespace TeoVincent.Utilities
{
    public abstract class TeoConsole
    {
        private readonly int width;
        private readonly int height;

        private int currentX;
        private int currentY;

        protected TeoConsole(int width, int height)
        {
            this.width = width;
            this.height = height;
        }

        protected void InitializeComponent()
        {
            Console.BackgroundColor = ConsoleColor.Blue;

            for (int i = 0; i < height; ++i)
            {
                for (int j = 0; j < width; ++j)
                    Console.Write(" ");

                Console.WriteLine();
            }

            Console.SetCursorPosition(0, 0);
        }

        protected void Render(int x, int y)
        {
            ClearLast(currentX, currentY);
            PrintNew(x, y);
        }

        private void ClearLast(int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(" ");
        }

        private void PrintNew(int x, int y)
        {
            if (x >= 0 && y >= 0)
            {
                Console.SetCursorPosition(x, y);
                Console.Write("#");

                currentX = x;
                currentY = y;
            }
        }
    }
}