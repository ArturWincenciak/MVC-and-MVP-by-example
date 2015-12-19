using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Passive_MVC.Models;
using Passive_MVC.Views;
using TeoVincent.Utilities;

namespace Passive_MVC.Controllers
{
    public class Controller : IController, IObservable
    {
        private readonly IModel model;
        private readonly IActionRunner actionRunner;
        private readonly List<IObserver> observers;

        public Controller(IModel model, IActionRunner actionRunner)
        {
            this.model = model;
            this.actionRunner = actionRunner;
            observers = new List<IObserver>();
        }

        public void Subscribe(IObserver observer)
            => observers.Add(observer);

        private void Notify()
        {
            foreach (var view in observers)
                view.Update(model.X, model.Y);
        }

        public void MoveRight()
            => DoIt(model.IncreaseX);

        public void MoveLeft()
            => DoIt(model.DecreaseX);

        public void MoveUp()
            => DoIt(model.DecreaseY);

        public void MoveDown()
            => DoIt(model.IncreaseY);

        private void DoIt(Action action)
            => actionRunner.DoIt(() => {
                action();
                Notify();
            });
    }
}