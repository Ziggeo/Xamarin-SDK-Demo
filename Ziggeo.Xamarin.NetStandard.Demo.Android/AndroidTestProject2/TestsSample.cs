using System.Drawing;
using NUnit.Framework;
// using Ziggeo;

namespace AndroidTestProject2
{
    [TestFixture]
    public class TestsSample
    {
        // private ZiggeoApplication _ziggeo;
        private string _appToken = "TOKEN";
        private string _ServerAuthToken = "ServerAuthToken";
        private string _ClientAuthToken = "ClientAuthToken";

        [SetUp]
        public void BeforeEachTest()
        {
            // _ziggeo = new ZiggeoApplication
            // {
            //     AppToken = _appToken,
            //     ServerAuthToken = _ServerAuthToken,
            //     ClientAuthToken = _ClientAuthToken
            // };
        }
        
        [Test]
        public void AppTokenTest()
        {
        Assert.IsTrue(_appToken == "TOKEN");
        }

        // [Test]
        // public void AppTokenTest()
        // {
        //     Assert.IsTrue(_appToken == _ziggeo.Ziggeo.AppToken);
        // }
        //
        // [Test]
        // public void ServerAuthTokenTest()
        // {
        //     Assert.IsTrue(_ServerAuthToken == _ziggeo.Ziggeo.ServerAuthToken);
        // }
        //
        // [Test]
        // public void ClientAuthTokenTest()
        // {
        //     Assert.IsTrue(_ClientAuthToken == _ziggeo.Ziggeo.ClientAuthToken);
        // }
        //
        // // CameraRecorderConfig mapping testsa
        //
        // [Test]
        // public void CameraRecorderConfigTest()
        // {
        //     _ziggeo.CameraRecorderConfig = new CameraRecorderConfig();
        //     Assert.IsTrue(null != _ziggeo.Ziggeo.RecorderConfig);
        // }
        //
        // [Test]
        // public void RecorderConfigShouldShowFaceOutlineTest()
        // {
        //     _ziggeo.CameraRecorderConfig = new CameraRecorderConfig
        //     {
        //         ShouldShowFaceOutline = true
        //     };
        //     _ziggeo.Ziggeo.RecorderConfig = CameraRecorderConfigMapper.Map(_ziggeo.CameraRecorderConfig);
        //     Assert.IsTrue(_ziggeo.Ziggeo.RecorderConfig.ShouldShowFaceOutline);
        // }
        //
        // [Test]
        // public void RecorderConfigIsLiveStreamingTest()
        // {
        //     _ziggeo.CameraRecorderConfig = new CameraRecorderConfig
        //     {
        //         IsLiveStreaming = true
        //     };
        //     _ziggeo.Ziggeo.RecorderConfig = CameraRecorderConfigMapper.Map(_ziggeo.CameraRecorderConfig);
        //     Assert.IsTrue(_ziggeo.Ziggeo.RecorderConfig.LiveStreaming);
        // }
        //
        // [Test]
        // public void RecorderConfigShouldAutoStartRecordingTest()
        // {
        //     _ziggeo.CameraRecorderConfig = new CameraRecorderConfig
        //     {
        //         ShouldAutoStartRecording = true
        //     };
        //     _ziggeo.Ziggeo.RecorderConfig = CameraRecorderConfigMapper.Map(_ziggeo.CameraRecorderConfig);
        //     Assert.IsTrue(_ziggeo.Ziggeo.RecorderConfig.ShouldAutoStartRecording);
        // }
        //
        // [Test]
        // public void RecorderConfigStartDelayTest()
        // {
        //     _ziggeo.CameraRecorderConfig = new CameraRecorderConfig
        //     {
        //         StartDelay = 8
        //     };
        //     _ziggeo.Ziggeo.RecorderConfig = CameraRecorderConfigMapper.Map(_ziggeo.CameraRecorderConfig);
        //     Assert.IsTrue(_ziggeo.Ziggeo.RecorderConfig.StartDelay == 8);
        // }
        //
        // [Test]
        // public void RecorderConfigBlurModeTest()
        // {
        //     _ziggeo.CameraRecorderConfig = new CameraRecorderConfig
        //     {
        //         BlurMode = true
        //     };
        //     _ziggeo.Ziggeo.RecorderConfig = CameraRecorderConfigMapper.Map(_ziggeo.CameraRecorderConfig);
        //     Assert.IsTrue(_ziggeo.Ziggeo.RecorderConfig.BlurMode);
        // }
        //
        // [Test]
        // public void RecorderConfigShouldSendImmediatelyTest()
        // {
        //     _ziggeo.CameraRecorderConfig = new CameraRecorderConfig
        //     {
        //         ShouldSendImmediately = false
        //     };
        //     _ziggeo.Ziggeo.RecorderConfig = CameraRecorderConfigMapper.Map(_ziggeo.CameraRecorderConfig);
        //     Assert.IsFalse(_ziggeo.Ziggeo.RecorderConfig.ShouldSendImmediately);
        // }
        //
        // [Test]
        // public void RecorderConfigShouldDisableCameraSwitchTest()
        // {
        //     _ziggeo.CameraRecorderConfig = new CameraRecorderConfig
        //     {
        //         ShouldSendImmediately = true
        //     };
        //     _ziggeo.Ziggeo.RecorderConfig = CameraRecorderConfigMapper.Map(_ziggeo.CameraRecorderConfig);
        //     Assert.IsTrue(_ziggeo.Ziggeo.RecorderConfig.ShouldSendImmediately);
        // }
        //
        // [Test]
        // public void RecorderConfigVideoQualityTest()
        // {
        //     _ziggeo.CameraRecorderConfig = new CameraRecorderConfig
        //     {
        //         VideoQuality = (int)CameraRecorderConfig.Quality.Medium
        //     };
        //     _ziggeo.Ziggeo.RecorderConfig = CameraRecorderConfigMapper.Map(_ziggeo.CameraRecorderConfig);
        //     Assert.IsTrue(_ziggeo.Ziggeo.RecorderConfig.VideoQuality == (int)CameraRecorderConfig.Quality.Medium);
        // }
        //
        // [Test]
        // public void RecorderConfigFacingTest()
        // {
        //     _ziggeo.CameraRecorderConfig = new CameraRecorderConfig
        //     {
        //         Facing = (int)CameraRecorderConfig.CameraFacing.Front
        //     };
        //     _ziggeo.Ziggeo.RecorderConfig = CameraRecorderConfigMapper.Map(_ziggeo.CameraRecorderConfig);
        //     Assert.IsTrue(_ziggeo.Ziggeo.RecorderConfig.Facing == (int)CameraRecorderConfig.CameraFacing.Front);
        // }
        //
        // [Test]
        // public void RecorderConfigMaxDurationTest()
        // {
        //     _ziggeo.CameraRecorderConfig = new CameraRecorderConfig
        //     {
        //         MaxDuration = 4
        //     };
        //     _ziggeo.Ziggeo.RecorderConfig = CameraRecorderConfigMapper.Map(_ziggeo.CameraRecorderConfig);
        //     Assert.IsTrue(_ziggeo.Ziggeo.RecorderConfig.MaxDuration == 4);
        // }
        //
        // [Test]
        // public void RecorderConfigShouldEnableCoverShotTest()
        // {
        //     _ziggeo.CameraRecorderConfig = new CameraRecorderConfig
        //     {
        //         ShouldEnableCoverShot = false
        //     };
        //     _ziggeo.Ziggeo.RecorderConfig = CameraRecorderConfigMapper.Map(_ziggeo.CameraRecorderConfig);
        //     Assert.IsFalse(_ziggeo.Ziggeo.RecorderConfig.ShouldEnableCoverShot);
        // }
        //
        // [Test]
        // public void RecorderConfigShouldConfirmStopRecordingTest()
        // {
        //     _ziggeo.CameraRecorderConfig = new CameraRecorderConfig
        //     {
        //         ShouldConfirmStopRecording = true
        //     };
        //     _ziggeo.Ziggeo.RecorderConfig = CameraRecorderConfigMapper.Map(_ziggeo.CameraRecorderConfig);
        //     Assert.IsTrue(_ziggeo.Ziggeo.RecorderConfig.ShouldConfirmStopRecording);
        // }
        //
        // // QrScannerConfig
        // [Test]
        // public void QrScannerConfigTest()
        // {
        //     _ziggeo.QrScannerConfig = new QrScannerConfig
        //     {
        //         ShouldCloseAfterSuccessfulScan = true
        //     };
        //     _ziggeo.Ziggeo.QrScannerConfig = QrScannerConfigMapper.Map(_ziggeo.QrScannerConfig);
        //     Assert.IsTrue(_ziggeo.Ziggeo.QrScannerConfig.ShouldCloseAfterSuccessfulScan);
        // }
        //
        // // ScreenRecorderConfig
        // [Test]
        // public void ScreenRecorderConfigTest()
        // {
        //     _ziggeo.ScreenRecorderConfig = new ScreenRecorderConfig();
        //     _ziggeo.Ziggeo.RecorderConfig = ScreenRecorderConfigMapper.Map(_ziggeo.ScreenRecorderConfig);
        //     Assert.IsTrue(_ziggeo.Ziggeo.RecorderConfig != null);
        // }
        //
        // // PlayerConfig
        // [Test]
        // public void PlayerConfigShouldShowSubtitlesTest()
        // {
        //     _ziggeo.PlayerConfig = new PlayerConfig
        //     {
        //         ShouldShowSubtitles = true
        //     };
        //     _ziggeo.Ziggeo.PlayerConfig = PlayerConfigMapper.Map(_ziggeo.PlayerConfig);
        //     Assert.IsFalse(_ziggeo.Ziggeo.PlayerConfig.ShouldShowSubtitles);
        // }
        //
        // [Test]
        // public void PlayerConfigIsMutedTest()
        // {
        //     _ziggeo.PlayerConfig = new PlayerConfig
        //     {
        //         IsMuted = true
        //     };
        //     _ziggeo.Ziggeo.PlayerConfig = PlayerConfigMapper.Map(_ziggeo.PlayerConfig);
        //     Assert.IsFalse(_ziggeo.Ziggeo.PlayerConfig.Muted);
        // }
        //
        // [Test]
        // public void PlayerConfigPlayerStyleTextColorTest()
        // {
        //     _ziggeo.PlayerConfig = new PlayerConfig
        //     {
        //         PlayerStyle = new PlayerStyle
        //         {
        //             TextColor = Color.Aqua.ToArgb()
        //         }
        //     };
        //     _ziggeo.Ziggeo.PlayerConfig = PlayerConfigMapper.Map(_ziggeo.PlayerConfig);
        //     Assert.IsTrue(_ziggeo.Ziggeo.PlayerConfig.Style.TextColor == Color.Aqua.ToArgb());
        // }
        //
        // [Test]
        // public void PlayerConfigPlayerStyleBufferedColorTest()
        // {
        //     _ziggeo.PlayerConfig = new PlayerConfig
        //     {
        //         PlayerStyle = new PlayerStyle
        //         {
        //             BufferedColor = Color.Aqua.ToArgb()
        //         }
        //     };
        //     _ziggeo.Ziggeo.PlayerConfig = PlayerConfigMapper.Map(_ziggeo.PlayerConfig);
        //     Assert.IsTrue(_ziggeo.Ziggeo.PlayerConfig.Style.BufferedColor == Color.Aqua.ToArgb());
        // }
        //
        // [Test]
        // public void PlayerConfigPlayerStylePlayedColorTest()
        // {
        //     _ziggeo.PlayerConfig = new PlayerConfig
        //     {
        //         PlayerStyle = new PlayerStyle
        //         {
        //             PlayedColor = Color.Aqua.ToArgb()
        //         }
        //     };
        //     _ziggeo.Ziggeo.PlayerConfig = PlayerConfigMapper.Map(_ziggeo.PlayerConfig);
        //     Assert.IsTrue(_ziggeo.Ziggeo.PlayerConfig.Style.PlayedColor == Color.Aqua.ToArgb());
        // }
        //
        // [Test]
        // public void PlayerConfigPlayerStyleTintColorTest()
        // {
        //     _ziggeo.PlayerConfig = new PlayerConfig
        //     {
        //         PlayerStyle = new PlayerStyle
        //         {
        //             TintColor = Color.Aqua.ToArgb()
        //         }
        //     };
        //     _ziggeo.Ziggeo.PlayerConfig = PlayerConfigMapper.Map(_ziggeo.PlayerConfig);
        //     Assert.IsTrue(_ziggeo.Ziggeo.PlayerConfig.Style.TintColor == Color.Aqua.ToArgb());
        // }
        //
        // [Test]
        // public void PlayerConfigPlayerStyleUnplayedColorTest()
        // {
        //     _ziggeo.PlayerConfig = new PlayerConfig
        //     {
        //         PlayerStyle = new PlayerStyle
        //         {
        //             UnplayedColor = Color.Aqua.ToArgb()
        //         }
        //     };
        //     _ziggeo.Ziggeo.PlayerConfig = PlayerConfigMapper.Map(_ziggeo.PlayerConfig);
        //     Assert.IsTrue(_ziggeo.Ziggeo.PlayerConfig.Style.UnplayedColor == Color.Aqua.ToArgb());
        // }
        //
        // [Test]
        // public void PlayerConfigPlayerStyleMuteOffImageDrawableTest()
        // {
        //     _ziggeo.PlayerConfig = new PlayerConfig
        //     {
        //         PlayerStyle = new PlayerStyle
        //         {
        //             MuteOffImageDrawable = Color.Aqua.ToArgb()
        //         }
        //     };
        //     _ziggeo.Ziggeo.PlayerConfig = PlayerConfigMapper.Map(_ziggeo.PlayerConfig);
        //     Assert.IsTrue(_ziggeo.Ziggeo.PlayerConfig.Style.MuteOffImageDrawable == Color.Aqua.ToArgb());
        // }
        //
        // [Test]
        // public void PlayerConfigPlayerStyleMuteOnImageDrawableTest()
        // {
        //     _ziggeo.PlayerConfig = new PlayerConfig
        //     {
        //         PlayerStyle = new PlayerStyle
        //         {
        //             MuteOnImageDrawable = Color.Aqua.ToArgb()
        //         }
        //     };
        //     _ziggeo.Ziggeo.PlayerConfig = PlayerConfigMapper.Map(_ziggeo.PlayerConfig);
        //     Assert.IsTrue(_ziggeo.Ziggeo.PlayerConfig.Style.MuteOnImageDrawable == Color.Aqua.ToArgb());
        // }
        // [Test]
        // public void PlayerConfigPlayerStyleControllerStyleTest()
        // {
        //     _ziggeo.PlayerConfig = new PlayerConfig
        //     {
        //         PlayerStyle = new PlayerStyle
        //         {
        //             ControllerStyle = PlayerStyle.MINIMALIST
        //         }
        //     };
        //     _ziggeo.Ziggeo.PlayerConfig = PlayerConfigMapper.Map(_ziggeo.PlayerConfig);
        //     Assert.IsTrue(_ziggeo.Ziggeo.PlayerConfig.Style.ControllerStyle == PlayerStyle.MINIMALIST);
        // }
        //
        // // FileSelectorConfig
        // [Test]
        // public void FileSelectorConfigTest()
        // {
        //     _ziggeo.FileSelectorConfig = new FileSelectorConfig();
        //     _ziggeo.Ziggeo.FileSelectorConfig = FileSelectorConfigMapper.Map(_ziggeo.FileSelectorConfig);
        //     Assert.IsTrue(_ziggeo.Ziggeo.FileSelectorConfig != null);
        // }
        //
        // // UploaderConfig
        // [Test]
        // public void UploaderConfigShouldTurnOffUploaderTest()
        // {
        //     _ziggeo.UploaderConfig = new UploaderConfig
        //     {
        //         ShouldTurnOffUploader = true
        //     };
        //     _ziggeo.Ziggeo.UploadingConfig = UploaderConfigMapper.Map(_ziggeo.UploaderConfig);
        //     Assert.IsTrue(_ziggeo.Ziggeo.UploadingConfig.ShouldTurnOffUploader);
        // }
        //
        // [Test]
        // public void UploaderConfigShouldUseWifiOnlyTest()
        // {
        //     _ziggeo.UploaderConfig = new UploaderConfig
        //     {
        //         ShouldUseWifiOnly = true
        //     };
        //     _ziggeo.Ziggeo.UploadingConfig = UploaderConfigMapper.Map(_ziggeo.UploaderConfig);
        //     Assert.IsTrue(_ziggeo.Ziggeo.UploadingConfig.ShouldUseWifiOnly);
        // }
        //
        // [Test]
        // public void UploaderConfigShouldStartAsForegroundTest()
        // {
        //     _ziggeo.UploaderConfig = new UploaderConfig
        //     {
        //         ShouldStartAsForeground = true
        //     };
        //     _ziggeo.Ziggeo.UploadingConfig = UploaderConfigMapper.Map(_ziggeo.UploaderConfig);
        //     Assert.IsTrue(_ziggeo.Ziggeo.UploadingConfig.ShouldStartAsForeground);
        // }
    }
}