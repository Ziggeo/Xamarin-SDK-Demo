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
        private bool _isDeleted;
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
            set => SetProperty(ref _isLoading, value);
        }

        public bool IsDeleted
        {
            get => _isDeleted;
            set => SetProperty(ref _isDeleted, value);
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
            get => Item.Key ?? Item.Token;
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

        public VideoItem Item;

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
                App.ZiggeoApplication.StartPlayer(Item.Token)
            );
            
            // xaml required default constructor
            Item = new VideoItem();
        }

        public override async Task ExecuteLoadCommand()
        {
            try
            {
                var stream = await App.ZiggeoApplication.Videos.DownloadImage(Item.Token);
                ImageSource = ImageSource.FromStream(() => stream);
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
                await App.ZiggeoApplication.Videos.Destroy(Item.Token);
                IsDeleted = true;
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

                await App.ZiggeoApplication.Videos.Update(Item.Token, data);
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