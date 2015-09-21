using System.Collections.Generic;
using TeoVincent.ActiveMVC.Views;

namespace TeoVincent.ActiveMVC.Models
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