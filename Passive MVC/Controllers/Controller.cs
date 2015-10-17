using Passive_MVC.Models;

namespace Passive_MVC.Controllers
{
    public class Controller : Observable, IController
    {
        private readonly IModel model;

        public Controller(IModel model)
        {
            this.model = model;
        }

        public void MoveRight()
        {
            model.IncreaseX();
            Notify();
        }

        public void MoveLeft()
        {
            model.DecreaseX();
            Notify();
        }

        public void MoveUp()
        {
            model.DecreaseY();
            Notify();
        }

        public void MoveDown()
        {
            model.IncreaseY();
            Notify();
        }

        protected override void Notify()
        {
            foreach (var view in observers)
                view.Update(model.X, model.Y);
        }
    }
}