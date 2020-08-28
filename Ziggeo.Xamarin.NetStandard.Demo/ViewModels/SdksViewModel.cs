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
    public class SdksViewModel : ListInfoViewModel<SdkItem>
    {
        public override async Task ExecuteLoadCommand()
        {
            try
            {
                Items.Clear();
                var items = await InfoService.GetSdks();
                foreach (var item in items)
                {
                    Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }
    }
}