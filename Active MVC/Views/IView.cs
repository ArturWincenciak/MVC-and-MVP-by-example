using TeoVincent.ActiveMVC.Controllers;

namespace TeoVincent.ActiveMVC.Views
{
    public interface IView
    {
        void SetController(IController controller);
    }
}