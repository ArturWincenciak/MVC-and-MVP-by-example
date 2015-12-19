using System;
using TeoVincent.MVP_Supervising_Controller.Views;
using TeoVincent.Utilities;

namespace TeoVincent.MVP_Supervising_Controller.Presenters
{
    public class ConsolPresenter
    {
        private readonly IModel model;
        private readonly IActionRunner actionRunner;

        public ConsolPresenter(IModel model, IView<ConsoleKey> view, IActionRunner actionRunner)
        {
            this.model = model;
            view.OnPressArrow += ViewOnPressArrow;
            this.actionRunner = actionRunner;
        }

        private void ViewOnPressArrow(object sender, ConsoleKey consoleKey)
        {

            switch (consoleKey)
            {
                case ConsoleKey.UpArrow:
                    DoIt(model.DecreaseY);
                    break;
                case ConsoleKey.DownArrow:
                    DoIt(model.IncreaseY);
                    break;
                case ConsoleKey.RightArrow:
                    DoIt(model.IncreaseX);
                    break;
                case ConsoleKey.LeftArrow:
                    DoIt(model.DecreaseX);
                    break;
                case ConsoleKey.Escape:
                    return;
            }
        }

        private void DoIt(Action action)
            => actionRunner.DoIt(action);
    }
}