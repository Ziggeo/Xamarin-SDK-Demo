using Xamarin.Forms;

namespace Ziggeo.Xamarin.NetStandard.Demo.Views.Widgets
{
    public class CameraWidget: View
    {
        #region SwitchCameraProperty

        public static readonly BindableProperty SwitchCameraProperty = BindableProperty.Create(nameof(SwitchCamera), typeof(bool), typeof(CameraWidget), default(bool));

        public bool SwitchCamera { 
            get { 
                return (bool)GetValue (SwitchCameraProperty); 
            } 
            set { 
                SetValue (SwitchCameraProperty, value); 
            } 
        }

        #endregion

        #region PlayRecordedFileProperty

        public static readonly BindableProperty PlayRecordedFileProperty = BindableProperty.Create(nameof(PlayRecordedFile), typeof(string), typeof(CameraWidget), default(string));

        public string PlayRecordedFile { 
            get { 
                return (string)GetValue (PlayRecordedFileProperty); 
            } 
            set { 
                SetValue (PlayRecordedFileProperty, value); 
            } 
        }

        #endregion
        
        #region StartRecordingProperty

        public static readonly BindableProperty StartRecordingProperty = BindableProperty.Create(nameof(StartRecording), typeof(bool), typeof(CameraWidget), default(bool));

        public bool StartRecording { 
            get { 
                return (bool)GetValue (StartRecordingProperty); 
            } 
            set { 
                SetValue (StartRecordingProperty, value); 
            } 
        }

        #endregion
        
        #region StopRecordingProperty

        public static readonly BindableProperty StopRecordingProperty = BindableProperty.Create(nameof(StopRecording), typeof(bool), typeof(CameraWidget), default(bool));

        public bool StopRecording { 
            get { 
                return (bool)GetValue (StopRecordingProperty); 
            } 
            set { 
                SetValue (StopRecordingProperty, value); 
            } 
        }

        #endregion
    }
}