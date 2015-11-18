using TeoVincent.ActiveMVC.Views;

namespace TeoVincent.ActiveMVC.Models
{
    public interface IObservable
    {
        void Subscribe(IObserver observer);
    }
}