using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Passive_MVC.Models;
using Passive_MVC.Views;

namespace Passive_MVC.Controllers
{
    public class Controller : IController, IObservable
    {
        private readonly IModel model;
        private readonly Task overAndOverAgain;
        private Action action;
        private readonly List<IObserver> observers;
        private const int INTERVAL = 50;

        public Controller(IModel model)
        {
            this.model = model;

            observers = new List<IObserver>();

            action = () => { };
            overAndOverAgain = Task.Factory.StartNew(OverAndOverAgain);
        }

        public void Subscribe(IObserver observer)
        {
            observers.Add(observer);
        }

        private void Notify()
        {
            foreach (var view in observers)
                view.Update(model.X, model.Y);
        }

        public void MoveRight()
        {
            lock (action)
                action = model.IncreaseX;
        }

        public void MoveLeft()
        {
            lock (action)
                action = model.DecreaseX;
        }

        public void MoveUp()
        {
            lock (action)
                action = model.DecreaseY;
        }

        public void MoveDown()
        {
            lock (action)
                action = model.IncreaseY;
        }

        private void OverAndOverAgain()
        {
            while (true)
            {
                lock (action)
                {
                    action();
                    Notify();
                    overAndOverAgain.Wait(INTERVAL);
                }
            }
        }
    }
}