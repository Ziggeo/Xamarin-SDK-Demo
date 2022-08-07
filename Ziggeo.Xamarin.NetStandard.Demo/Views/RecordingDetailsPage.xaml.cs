using System.Collections.Generic;
using System.Linq;
using Acr.UserDialogs;
using Xamarin.Essentials;
using Xamarin.Forms;
using Ziggeo.Xamarin.NetStandard.Demo.Models;
using Ziggeo.Xamarin.NetStandard.Demo.Utils;
using Ziggeo.Xamarin.NetStandard.Demo.ViewModels;

namespace Ziggeo.Xamarin.NetStandard.Demo.Views
{
    public partial class RecordingDetailsPage : ContentPage
    {
        private readonly RecordingDetailsViewModel _viewModel;
        private ToolbarItem _editToolbarItem;
        private ToolbarItem _deleteToolbarItem;
        private ToolbarItem _saveToolbarItem;
        private ToolbarItem _cancelToolbarItem;

        // Note - The Xamarin.Forms Previewer requires a default, parameterless constructor to render a page.
        public RecordingDetailsPage()
        {
            InitializeComponent();
            var item = new VideoItem
            {
                Token = "Item 1",
            };

            _viewModel = new RecordingDetailsViewModel { Item = item };
            BindingContext = _viewModel;
        }

        public RecordingDetailsPage(RecordingDetailsViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = this._viewModel = viewModel;
            _viewModel.Page = this;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.LoadCommand.Execute(null);
            UpdateToolbar();
        }

        public void UpdateToolbar()
        {
            CreateToolbarItems();
            ToolbarItems.Clear();
            if (_viewModel.IsEditMode)
            {
                ToolbarItems.Add(_saveToolbarItem);
                ToolbarItems.Add(_cancelToolbarItem);
            }
            else
            {
                ToolbarItems.Add(_editToolbarItem);
                ToolbarItems.Add(_deleteToolbarItem);
            }
        }


        private void CreateToolbarItems()
        {
            if (_editToolbarItem == null)
            {
                var resources = Application.Current.Resources;
                var font = (string)((OnPlatform<string>)resources["MaterialFontFamily"])
                    .Platforms.FirstOrDefault(p => p.Platform[0] == Device.RuntimePlatform)?.Value;
                const int iconSize = 48;

                _editToolbarItem = new ToolbarItem { Command = _viewModel.EditCommand };
                var editImageSource = new FontImageSource
                {
                    Size = iconSize, FontFamily = font, Glyph = resources["IconEdit"] as string
                };
                _editToolbarItem.IconImageSource = editImageSource;

                _deleteToolbarItem = new ToolbarItem { Command = _viewModel.DeleteCommand };
                var deleteImageSource = new FontImageSource
                {
                    Size = iconSize, FontFamily = font, Glyph = resources["IconDelete"] as string
                };
                _deleteToolbarItem.IconImageSource = deleteImageSource;

                _saveToolbarItem = new ToolbarItem { Command = _viewModel.SaveCommand };
                var saveImageSource = new FontImageSource
                {
                    Size = iconSize, FontFamily = font, Glyph = resources["IconSave"] as string
                };
                _saveToolbarItem.IconImageSource = saveImageSource;

                _cancelToolbarItem = new ToolbarItem { Command = _viewModel.CancelCommand };
                var cancelImageSource = new FontImageSource
                {
                    Size = iconSize, FontFamily = font, Glyph = resources["IconClose"] as string
                };
                _cancelToolbarItem.IconImageSource = cancelImageSource;
            }
        }

        public void ShowLoading()
        {
            UserDialogs.Instance.Loading().Show();
        }

        public void HideLoading()
        {
            UserDialogs.Instance.Loading().Hide();
        }

        public async void OnVideoSelected(VideoItem item)
        {
            if (GetCustomPlayerMode())
            {
                await Navigation.PushAsync(new CustomPlayerPage(
                    new List<string> { item.Token }, null));
            }
            else
            {
                App.ZiggeoApplication.StartPlayer(item.Token);
            }
        }

        private bool GetCustomPlayerMode()
        {
            return Preferences.Get(Constants.CustomPlayerMode, false);
        }
    }
}