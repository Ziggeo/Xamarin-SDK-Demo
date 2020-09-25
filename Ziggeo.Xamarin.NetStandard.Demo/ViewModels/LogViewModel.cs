using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Ziggeo.Xamarin.NetStandard.Demo.Models;

namespace Ziggeo.Xamarin.NetStandard.Demo.ViewModels
{
    public class LogViewModel : BaseViewModel
    {
        public ObservableCollection<LogItem> Items { get; set; }
        public ICommand SendReportCommand { get; }
        public Command LoadItemsCommand { get; set; }
        private bool _isEmpty;

        public bool IsEmpty
        {
            get => _isEmpty;
            set => SetProperty(ref _isEmpty, value);
        }

        public LogViewModel()
        {
            SendReportCommand = new Command(() => { });
            Items = new ObservableCollection<LogItem>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadCommand());
        }

        public override async Task ExecuteLoadCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;
            Items.Clear();
            var items = App.EventLogger.GetLogs().Reverse();
            foreach (var item in items)
            {
                Items.Add(item);
            }

            IsBusy = false;
            IsEmpty = Items.Count == 0;
        }
    }
}