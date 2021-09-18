using Microsoft.Maui.Controls;
using System.Threading.Tasks;
using Back2LearnMauiApp.ViewModels;

namespace Back2LearnMauiApp.Views
{
    public partial class GameView : ContentPage
    {
        GameViewModel vm;

        public GameView()
        {
            InitializeComponent();

            vm = new GameViewModel();
            BindingContext = vm;
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            await Task.Run(() => vm.LoadDataCommand.Execute(null));
        }
    }
}