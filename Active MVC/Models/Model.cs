using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TeoVincent.ActiveMVC.Views;
using TeoVincent.Utilities;

namespace TeoVincent.ActiveMVC.Models
{
    public class Model : IModel, IObservable
    {
        private readonly int minX;
        private readonly int maxX;

        private readonly int minY;
        private readonly int maxY;

        private int x;
        private int y;

        private readonly List<IObserver> observers;
        private readonly IActionRunner actionRunner;

        public Model(int minX, int maxX, int minY, int maxY, IActionRunner actionRunner)
        {
            this.minX = minX;
            this.maxX = maxX;
            this.minY = minY;
            this.maxY = maxY;
            this.actionRunner = actionRunner;

            observers = new List<IObserver>();
        }

        public void Subscribe(IObserver observer)
        {
            observers.Add(observer);
        }

        public void IncreaseX()
            => DoIt(IncX);

        public void DecreaseX()
            => DoIt(DecX);

        public void IncreaseY()
            => DoIt(IncY);

        public void DecreaseY()
            => DoIt(DecY);

        private void IncX()
        {
            if (x == maxX - 1)
                x = 0;
            else
                x++;
        }

        private void DecX()
        {
            if (x == minX)
                x = maxX - 1;
            else
                x--;
        }

        private void IncY()
        {
            if (y == maxY - 1)
                y = 0;
            else
                y++;
        }

        private void DecY()
        {
            if (y == minY)
                y = maxY - 1;
            else
                y--;
        }

        private void Notify()
        {
            foreach (var observer in observers)
                observer.Update(x, y);
        }

        private void DoIt(Action action)
        {
            actionRunner.DoIt(() => {
                action();
                Notify();
            });
        }
    }
}