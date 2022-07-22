using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Ziggeo.Xamarin.NetStandard.Demo.Models;
using Ziggeo.Xamarin.NetStandard.Demo.Utils;
using Ziggeo.Xamarin.NetStandard.Demo.ViewModels;

namespace Ziggeo.Xamarin.NetStandard.Demo.Views
{
    public partial class MainPage : MasterDetailPage
    {
        private List<MasterPageItem> MenuList { get; set; }

        public MainPage()
        {
            InitializeComponent();
            MenuList = new List<MasterPageItem>();
            var recPage = new MasterPageItem
                {Title = AppResources.item_recordings, TargetType = typeof(RecordingsListPage)};
            var setPage = new MasterPageItem {Title = AppResources.item_settings, TargetType = typeof(SettingsPage)};
            var sdkPage = new MasterPageItem
                {Title = AppResources.item_sdks, TargetType = typeof(AvailableSdksListPage)};
            var clPage = new MasterPageItem
                {Title = AppResources.item_clients, TargetType = typeof(TopClientsListPage)};
            var contPage = new MasterPageItem {Title = AppResources.item_contact, TargetType = typeof(ContactUsPage)};
            var abPage = new MasterPageItem {Title = AppResources.item_about, TargetType = typeof(AboutPage)};
            var logPage = new MasterPageItem {Title = AppResources.item_log, TargetType = typeof(LogPage)};
            var customPlayerPage = new MasterPageItem {Title = AppResources.item_log, TargetType = typeof(CustomPlayerPage)};
            var customCameraPage = new MasterPageItem {Title = AppResources.item_log, TargetType = typeof(CustomCameraPage)};

            MenuList.Add(recPage);
            MenuList.Add(setPage);
            MenuList.Add(sdkPage);
            MenuList.Add(clPage);
            MenuList.Add(contPage);
            MenuList.Add(abPage);
            MenuList.Add(logPage);
            MenuList.Add(customPlayerPage);
            MenuList.Add(customCameraPage);

            NavigationList.ItemsSource = MenuList;

            Detail = new NavigationPage((Page) Activator.CreateInstance(typeof(RecordingsListPage)));

            MessagingCenter.Subscribe<MainViewModel>(
                this,
                Constants.NavAuth,
                async sender =>
                {
                    MessageCenterUnsubscribe();
                    Navigation.InsertPageBefore(new AuthPage(), this);
                    await Navigation.PopAsync();
                });
        }

        private void OnMenuItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = (MasterPageItem) e.SelectedItem;
            Type page = item.TargetType;

            Detail = new NavigationPage((Page) Activator.CreateInstance(page));
            IsPresented = false;
        }

        public void MessageCenterUnsubscribe()
        {
            MessagingCenter.Unsubscribe<MainViewModel>(this, Constants.NavAuth);
        }
    }
}