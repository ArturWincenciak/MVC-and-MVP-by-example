using System;
using System.Windows.Forms;
using TeoVincent.MVP_Supervising_Controller.Views;
using TeoVincent.Utilities;

namespace TeoVincent.MVP_Supervising_Controller.Presenters
{
    public class WinFormsPresenter
    {
        private readonly IModel model;
        private readonly IView<Keys> view;
        private readonly IActionRunner actionRunner;

        public WinFormsPresenter(IModel model, IView<Keys> view, IActionRunner actionRunner)
        {
            this.model = model;
            this.view = view;
            this.view.OnPressArrow += ViewOnPressArrow;
            this.actionRunner = actionRunner;
        }

        private void ViewOnPressArrow(object sender, Keys keys)
        {
            switch (keys)
            {
                case Keys.Up:
                    DoIt(model.DecreaseY);
                    break;
                case Keys.Down:
                    DoIt(model.IncreaseY);
                    break;
                case Keys.Right:
                    DoIt(model.IncreaseX);
                    break;
                case Keys.Left:
                    DoIt(model.DecreaseX);
                    break;
                case Keys.Escape:
                    return;
            }
        }
        private void DoIt(Action action) => actionRunner.DoIt(action);
    }
}