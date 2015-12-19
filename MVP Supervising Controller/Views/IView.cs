using System;

namespace TeoVincent.MVP_Supervising_Controller.Views
{
    public interface IView<T>
    {
        event EventHandler<T> OnPressArrow;
    }
}