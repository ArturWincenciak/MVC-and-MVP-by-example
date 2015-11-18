using Passive_MVC.Views;

namespace Passive_MVC.Controllers
{
    public interface IObservable
    {
        void Subscribe(IObserver observer);
    }
}