using System;
using System.Linq;
using Acr.UserDialogs;
using Xamarin.Forms;
using Ziggeo.Xamarin.NetStandard.Demo.Models;
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

            _viewModel = new RecordingDetailsViewModel {Item = item};
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
                var font = (string) ((OnPlatform<string>) resources["MaterialFontFamily"])
                    .Platforms.FirstOrDefault(p => p.Platform[0] == Device.RuntimePlatform)?.Value;
                var iconSize = 48;

                _editToolbarItem = new ToolbarItem();
                _editToolbarItem.Command = _viewModel.EditCommand;
                FontImageSource editImageSource = new FontImageSource();
                editImageSource.Size = iconSize;
                editImageSource.FontFamily = font;
                editImageSource.Glyph = resources["IconEdit"] as string;
                _editToolbarItem.IconImageSource = editImageSource;

                _deleteToolbarItem = new ToolbarItem();
                _deleteToolbarItem.Command = _viewModel.DeleteCommand;
                FontImageSource deleteImageSource = new FontImageSource();
                deleteImageSource.Size = iconSize;
                deleteImageSource.FontFamily = font;
                deleteImageSource.Glyph = resources["IconDelete"] as string;
                _deleteToolbarItem.IconImageSource = deleteImageSource;

                _saveToolbarItem = new ToolbarItem();
                _saveToolbarItem.Command = _viewModel.SaveCommand;
                FontImageSource saveImageSource = new FontImageSource();
                saveImageSource.Size = iconSize;
                saveImageSource.FontFamily = font;
                saveImageSource.Glyph = resources["IconSave"] as string;
                _saveToolbarItem.IconImageSource = saveImageSource;

                _cancelToolbarItem = new ToolbarItem();
                _cancelToolbarItem.Command = _viewModel.CancelCommand;
                FontImageSource cancelImageSource = new FontImageSource();
                cancelImageSource.Size = iconSize;
                cancelImageSource.FontFamily = font;
                cancelImageSource.Glyph = resources["IconClose"] as string;
                _cancelToolbarItem.IconImageSource = cancelImageSource;
            }
        }

        private void ShowLoading()
        {
            UserDialogs.Instance.Loading().Show();
        }

        private void HideLoading()
        {
            UserDialogs.Instance.Loading().Hide();
        }
    }
}