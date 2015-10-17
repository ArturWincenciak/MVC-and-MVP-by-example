using Passive_MVC.Controllers;

namespace Passive_MVC.Views
{
    public interface IView
    {
        void SetController(IController controller);
    }
}