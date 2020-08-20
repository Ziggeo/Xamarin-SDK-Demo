using System;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;
using Ziggeo.Xamarin.NetStandard.Demo.Utils;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Xamarin.Forms;

namespace Ziggeo.Xamarin.NetStandard.Demo.ViewModels
{
    public class HomeViewModel : INotifyPropertyChanged
    {
        private string _appToken;
        private bool _isManualQrMode;
        private string _switchModeBtnText;
        private string _authActionBtnText;
        public event PropertyChangedEventHandler PropertyChanged;

        public HomeViewModel()
        {
            AuthCommand = new Command(() => { }, CanExecute);
            SwitchQrMode = new Command(() => { IsManualQrMode = !IsManualQrMode; });
            _switchModeBtnText = AppResources.enter_qr_manually_text;
            _authActionBtnText = AppResources.btn_scan_qr_text;
        }


        public string AppToken
        {
            get => _appToken;
            set
            {
                SetProperty(ref _appToken, value);
                ((Command) AuthCommand).ChangeCanExecute();
            }
        }

        public ICommand AuthCommand { get; }

        public ICommand SwitchQrMode { get; }

        private bool CanExecute()
        {
            return !IsManualQrMode || !string.IsNullOrWhiteSpace(AppToken);
        }

        public string SwitchModeBtnText
        {
            get => _switchModeBtnText;
            set
            {
                _switchModeBtnText = value;
                OnPropertyChanged(nameof(SwitchModeBtnText));
            }
        }

        public string AuthActionBtnText
        {
            get => _authActionBtnText;
            set
            {
                _authActionBtnText = value;
                OnPropertyChanged(nameof(AuthActionBtnText));
            }
        }


        public bool IsManualQrMode
        {
            get => _isManualQrMode;
            set
            {
                _isManualQrMode = value;
                OnPropertyChanged(nameof(IsManualQrMode));
                if (_isManualQrMode)
                {
                    AuthActionBtnText = AppResources.btn_use_entered_text;
                    SwitchModeBtnText = AppResources.use_scanner_text;
                }
                else
                {
                    AuthActionBtnText = AppResources.btn_scan_qr_text;
                    SwitchModeBtnText = AppResources.enter_qr_manually_text;
                }
            }
        }

        bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = null)
        {
            if (Object.Equals(storage, value))
                return false;

            storage = value;
            OnPropertyChanged(propertyName);
            return true;
        }

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}