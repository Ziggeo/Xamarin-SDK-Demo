using Xamarin.Forms;
using Ziggeo.Xamarin.NetStandard.Demo.ViewModels;

namespace Ziggeo.Xamarin.NetStandard.Demo.Views
{
    public partial class LogPage : ContentPage
    {
        private readonly LogViewModel _viewModel;

        public LogPage()
        {
            InitializeComponent();
            BindingContext = _viewModel = new LogViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.LoadItemsCommand.Execute(null);
        }
    }
}