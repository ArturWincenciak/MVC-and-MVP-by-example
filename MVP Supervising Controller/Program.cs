using System.Threading.Tasks;
using System.Windows.Forms;
using TeoVincent.MVP_Supervising_Controller.Presenters;
using TeoVincent.Utilities;

namespace TeoVincent.MVP_Supervising_Controller.Views
{
    class Program
    {
        static void Main(string[] args)
        {
            int width = 50;
            int height = 50;
            int scale = 10;

            var consoleModel = new Model(0, width, 0, height);
            var consoleView = new ConsoleView(width, height, consoleModel);
            var consoleRunner = new OverAndOverAgainActionRunner();
            var consoleModelPresenter = new ConsolPresenter(consoleModel, consoleView, consoleRunner);

            var winModel = new Model(0, width, 0, height);
            var winView = new WinFormView(width, height, scale, winModel);
            var winRunner = new OverAndOverAgainActionRunner();
            var winPresenter = new WinFormsPresenter(winModel, winView, winRunner);

            Task.Factory.StartNew(() => consoleView.ReadArrow());
            Application.Run(winView);
        }
    }
}