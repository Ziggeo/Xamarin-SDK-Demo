using System.ComponentModel;
using Android.Util;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Ziggeo.Xamarin.Android.CustomViews;
using Ziggeo.Xamarin.NetStandard.Demo.Droid;
using Ziggeo.Xamarin.NetStandard.Demo.Views.Widgets;

[assembly: ExportRenderer(typeof(CameraWidget), typeof(CameraWidgetRenderer))]

namespace Ziggeo.Xamarin.NetStandard.Demo.Droid
{
    public class
        CameraWidgetRenderer : global::Xamarin.Forms.Platform.Android.AppCompat.ViewRenderer<CameraWidget, ZCameraView>
    {
        private bool _isDisposed;
        private ZCameraView _zCamera;

        public CameraWidgetRenderer()
        {
            AutoPackage = false;
            _zCamera = new ZCameraView(Context);
            _zCamera.SetZiggeo(App.ZiggeoApplication);
            _zCamera.LoadConfig();
            _zCamera.Start();
        }

        protected override void Dispose(bool disposing)
        {
            if (_isDisposed)
            {
                return;
            }

            _isDisposed = true;
            _zCamera.Stop();
            base.Dispose(disposing);
        }

        protected override void OnElementChanged(ElementChangedEventArgs<CameraWidget> e)
        {
            base.OnElementChanged(e);
            if (e.OldElement == null)
            {
                SetNativeControl(_zCamera);
            }
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            if (e.PropertyName == CameraWidget.StartRecordingProperty.PropertyName)
            {
                _zCamera.StartRecording();
            }
            else if (e.PropertyName == CameraWidget.StopRecordingProperty.PropertyName)
            {
                _zCamera.StopRecording();
            }
            else if (e.PropertyName == CameraWidget.PlayRecordedFileProperty.PropertyName)
            {
                App.ZiggeoApplication.StartPlayerWithPath(new[]
                    {
                        _zCamera.GetRecordedFile()
                    });
            }
            else if (e.PropertyName == CameraWidget.SwitchCameraProperty.PropertyName)
            {
                _zCamera.SwitchCamera();
            }
        }

    }
}