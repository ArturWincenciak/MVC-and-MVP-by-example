namespace TeoVincent.ActiveMVC.Controllers
{
    public interface IController
    {
        void MoveRight();
        void MoveLeft();
        void MoveUp();
        void MoveDown();
    }
}