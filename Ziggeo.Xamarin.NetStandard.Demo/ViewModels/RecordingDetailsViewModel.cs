using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Ziggeo.Xamarin.NetStandard.Demo.Models;
using Ziggeo.Xamarin.NetStandard.Demo.Views;

namespace Ziggeo.Xamarin.NetStandard.Demo.ViewModels
{
    public class RecordingDetailsViewModel : BaseViewModel
    {
        public RecordingDetailsPage Page { get; set; }
        private bool _isLoading;
        private bool _isEditMode;
        private bool _isError;
        private ImageSource _imageSource;

        public ImageSource ImageSource
        {
            get => _imageSource;
            set => SetProperty(ref _imageSource, value);
        }

        public bool IsLoading
        {
            get => _isLoading;
            set
            {
                SetProperty(ref _isLoading, value);
                if (_isLoading)
                {
                    Page.ShowLoading();
                }
                else
                {
                    Page.HideLoading();
                }
            }
        }

        public bool IsEditMode
        {
            get => _isEditMode;
            set
            {
                SetProperty(ref _isEditMode, value);
                Page.UpdateToolbar();
            }
        }

        public bool IsError
        {
            get => _isError;
            set => SetProperty(ref _isError, value);
        }

        public string Title
        {
            get => Item.Title;
            set => Item.Title = value;
        }

        public string TokenOrKey
        {
            get => string.IsNullOrEmpty(Item.Key) ? Item.Token : Item.Key;
            set
            {
                if (Item.Key != null)
                {
                    Item.Key = value;
                }
                else
                {
                    Item.Token = value;
                }
            }
        }

        public string Description
        {
            get => Item.Description;
            set => Item.Description = value;
        }

        public MediaItem Item;

        public ICommand EditCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand CancelCommand { get; set; }
        public ICommand SaveCommand { get; set; }
        public ICommand ImageClickedCommand { get; set; }

        public RecordingDetailsViewModel()
        {
            EditCommand = new Command(() => IsEditMode = true);
            CancelCommand = new Command(() => IsEditMode = false);
            DeleteCommand = new Command(RunDelete);
            SaveCommand = new Command(RunSave);
            ImageClickedCommand = new Command(() =>
                {
                    switch (Item)
                    {
                        case VideoItem _:
                            App.ZiggeoApplication.StartPlayer(Item.Token);
                            break;
                        case AudioItem _:
                            App.ZiggeoApplication.StartPlayer(Item.Token);
                            break;
                        case ImageItem _:
                            App.ZiggeoApplication.StartPlayer(Item.Token);
                            break;
                    }
                }
            );

            // xaml required default constructor
            Item = new VideoItem();
        }

        public override async Task ExecuteLoadCommand()
        {
            try
            {
                switch (Item)
                {
                    case VideoItem _:
                        var url = await App.ZiggeoApplication.Videos.GetImageUrl(Item.Token);
                        ImageSource = ImageSource.FromUri(new Uri(url));
                        break;
                    case AudioItem _:
                    case ImageItem _:
                        await App.ZiggeoApplication.Videos.Destroy(Item.Token);
                        break;
                }
            }
            catch (Exception ex)
            {
                IsError = true;
            }
        }

        private async void RunDelete()
        {
            IsLoading = true;
            try
            {
                switch (Item)
                {
                    case VideoItem _:
                        await App.ZiggeoApplication.Videos.Destroy(Item.Token);
                        break;
                    case AudioItem _:
                        await App.ZiggeoApplication.Audios.Destroy(Item.Token);
                        break;
                    case ImageItem _:
                        await App.ZiggeoApplication.Images.Destroy(Item.Token);
                        break;
                }

                await Page.Navigation.PopAsync();
            }
            catch (Exception exception)
            {
                _isError = true;
            }
            finally
            {
                IsLoading = false;
            }
        }

        private async void RunSave()
        {
            IsLoading = true;
            try
            {
                Dictionary<string, string> data = new Dictionary<string, string>();
                data[VideoItem.KeyTitle] = Item.Title;
                data[VideoItem.KeyDescription] = Item.Description;
                if (Item.Key != null)
                {
                    data[VideoItem.KeyVideoKey] = Item.Key;
                }

                switch (Item)
                {
                    case VideoItem _:
                        await App.ZiggeoApplication.Videos.Update(Item.Token, data);
                        break;
                    case AudioItem _:
                        await App.ZiggeoApplication.Audios.Update(Item.Token, data);
                        break;
                    case ImageItem _:
                        await App.ZiggeoApplication.Images.Update(Item.Token, data);
                        break;
                }

                IsEditMode = false;
            }
            catch (Exception exception)
            {
                _isError = true;
            }
            finally
            {
                IsLoading = false;
            }
        }
    }
}