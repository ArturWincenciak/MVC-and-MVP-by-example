using System;
using TeoVincent.ActiveMVC.Controllers;

namespace TeoVincent.ActiveMVC.Views
{
    public class ConsoleView : IObserver, IView
    {
        private IController controller;

        private readonly int width;
        private readonly int height;

        private int currentX;
        private int currentY;

        public ConsoleView(int width, int height)
        {
            this.width = width;
            this.height = height;
            RenderBackground();
        }

        public void SetController(IController controller)
        {
            this.controller = controller;
        }

        public void Update(int x, int y)
        {
            Render(x, y);
        }

        public void Navigate()
        {
            while (true)
            {
                var key = Console.ReadKey();

                switch (key.Key)
                {
                    case ConsoleKey.UpArrow:
                        controller.MoveUp();
                        break;
                    case ConsoleKey.DownArrow:
                        controller.MoveDown();
                        break;
                    case ConsoleKey.RightArrow:
                        controller.MoveRight();
                        break;
                    case ConsoleKey.LeftArrow:
                        controller.MoveLeft();
                        break;
                    case ConsoleKey.Escape:
                        return;
                }
            }
        }

        private void Render(int x, int y)
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

        private void RenderBackground()
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
    }
}