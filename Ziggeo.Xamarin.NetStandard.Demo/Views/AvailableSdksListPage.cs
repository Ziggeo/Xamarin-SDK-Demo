using Xamarin.Essentials;
using Xamarin.Forms;
using Ziggeo.Xamarin.NetStandard.Demo.Models;
using Ziggeo.Xamarin.NetStandard.Demo.ViewModels;

namespace Ziggeo.Xamarin.NetStandard.Demo.Views
{
    public class AvailableSdksListPage : ListInfoPage
    {
        public AvailableSdksListPage() : base(new SdksViewModel())
        {
        }
    }
}