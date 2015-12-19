namespace TeoVincent.MVP_Supervising_Controller
{
    public delegate void ModelChangedEventHandler(IModel model);

    public interface IModel
    {
        event ModelChangedEventHandler ModelChanged;

        int X { get; }
        int Y { get; }

        void IncreaseX();
        void DecreaseX();
        void IncreaseY();
        void DecreaseY();
    }
}