namespace Passive_MVC.Models
{
    public interface IModel
    {
        int X { get; }
        int Y { get; }

        void IncreaseX();
        void DecreaseX();
        void IncreaseY();
        void DecreaseY();
    }
}