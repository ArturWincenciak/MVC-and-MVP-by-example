using System;
using TeoVincent.ActiveMVC.Controllers;
using TeoVincent.Utilities;

namespace TeoVincent.ActiveMVC.Views
{
    public class ConsoleView : TeoConsole, IObserver, IView
    {
        private IController controller;

        public ConsoleView(int width, int height)
            : base(width, height)
        {
            InitializeComponent();
        }

        public void SetController(IController cntrl)
            => controller = cntrl;

        public void Update(int x, int y)
            => Render(x, y);

        public void ReadArrow()
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
    }
}