using System;
using TeoVincent.Utilities;

namespace TeoVincent.MVP_Supervising_Controller.Views
{
    public class ConsoleView : TeoConsole, IView<ConsoleKey>
    {
        public ConsoleView(int width, int height, IModel model)
            : base(width, height)
        {
            InitializeComponent();
            Bind(model);
        }

        public event EventHandler<ConsoleKey> OnPressArrow;

        public void ReadArrow()
        {
            while (true)
            {
                var key = Console.ReadKey();
                OnPressArrow?.Invoke(this, key.Key);
            }
        }

        private void Bind(IModel model)
            => model.ModelChanged += (m) => Render(model.X, model.Y);
    }
}