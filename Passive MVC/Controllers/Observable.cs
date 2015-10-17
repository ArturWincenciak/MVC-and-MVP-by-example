using System.Collections.Generic;
using Passive_MVC.Views;

namespace Passive_MVC.Controllers
{
    public abstract class Observable
    {
        protected readonly List<IObserver> observers;

        protected Observable()
        {
            observers = new List<IObserver>();
        }

        public void Subscribe(IObserver observer)
        {
            observers.Add(observer);
        }

        protected abstract void Notify();
    }
}