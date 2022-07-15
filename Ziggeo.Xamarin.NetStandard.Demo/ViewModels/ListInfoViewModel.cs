using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;
using Ziggeo.Xamarin.NetStandard.Demo.Models;
using Ziggeo.Xamarin.NetStandard.Demo.Services;
using Ziggeo.Xamarin.NetStandard.Demo.Views;

namespace Ziggeo.Xamarin.NetStandard.Demo.ViewModels
{
    public abstract class ListInfoViewModel<T> : BaseViewModel
    {
        public ObservableCollection<T> Items { get; set; }

        public IInfoService InfoService => DependencyService.Get<IInfoService>();

        public ListInfoViewModel()
        {
            Items = new ObservableCollection<T>();
        }

    }
}