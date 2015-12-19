using TeoVincent.ActiveMVC.Models;

namespace TeoVincent.ActiveMVC.Controllers
{
    public class Controller : IController
    {
        private readonly IModel model;

        public Controller(IModel model)
        {
            this.model = model;
        }

        public void MoveRight()
        {
            model.IncreaseX();
        }

        public void MoveLeft()
        {
            model.DecreaseX();
        }

        public void MoveUp()
        {
            model.DecreaseY();
        }

        public void MoveDown()
        {
            model.IncreaseY();
        }
    }
}