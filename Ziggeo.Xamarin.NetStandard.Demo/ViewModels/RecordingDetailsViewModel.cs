using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;
using Ziggeo.Xamarin.NetStandard.Demo.Models;
using Ziggeo.Xamarin.NetStandard.Demo.Utils;
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
        private Aspect _aspectProp;

        public Aspect AspectProp
        {
            get => _aspectProp;
            set => SetProperty(ref _aspectProp, value);
        }

        public ImageSource ImageSource
        {
            get => _imageSource;
            set => SetProperty(ref _imageSource, value);
        }

        private bool IsLoading
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

        private bool IsError
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
            ImageClickedCommand = new Command(async () =>
                {
                    switch (Item)
                    {
                        case VideoItem item:
                            Page.OnVideoSelected(item);
                            break;
                        case AudioItem _:
                            App.ZiggeoApplication.StartAudioWithToken(new[] { Item.Token });
                            break;
                        case ImageItem _:
                            App.ZiggeoApplication.OpenImage(Item.Token);
                            break;
                    }
                }
            );

            // xaml required default constructor
            Item = new MediaItem("");
        }

        public override async Task ExecuteLoadCommand()
        {
            var resources = Application.Current.Resources;
            const int iconSize = 200;
            var font = (string)((OnPlatform<string>)resources["MaterialFontFamily"])
                .Platforms.FirstOrDefault(p => p.Platform[0] == Device.RuntimePlatform)?.Value;
            try
            {
                switch (Item)
                {
                    case VideoItem _:
                        AspectProp = Aspect.AspectFill;
                        var url = await App.ZiggeoApplication.Videos.GetImageUrl(Item.Token);
                        ImageSource = ImageSource.FromUri(new Uri(url));
                        break;
                    case AudioItem _:
                        AspectProp = Aspect.AspectFit;
                        ImageSource = new FontImageSource
                        {
                            Color = Color.Gray,
                            Size = iconSize,
                            FontFamily = font,
                            Glyph = resources["IconMic"] as string
                        };
                        break;
                    case ImageItem _:
                        AspectProp = Aspect.AspectFill;
                        var imageUrl = await App.ZiggeoApplication.Images.GetImageUrl(Item.Token);
                        ImageSource = ImageSource.FromUri(new Uri(imageUrl));
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