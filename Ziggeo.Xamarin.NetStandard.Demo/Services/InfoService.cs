using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ziggeo.Xamarin.NetStandard.Demo.Models;

namespace Ziggeo.Xamarin.NetStandard.Demo.Services
{
    public class InfoService : IInfoService
    {
        private List<ClientItem> _clientItems;
        private List<SdkItem> _sdkItems;

        public InfoService()
        {
            _initClients();
            _initSdks();
        }

        public async Task<IEnumerable<ClientItem>> GetTopClients()
        {
            return await Task.Run(() => _clientItems);
        }

        public async Task<IEnumerable<SdkItem>> GetSdks()
        {
            return await Task.Run(() => _sdkItems);
        }

        private void _initClients()
        {
            _clientItems = new List<ClientItem>
            {
                new ClientItem(
                    "logo_sap",
                    "SAP",
                    "https://sap.com"
                ),
                new ClientItem(
                    "logo_gofundme",
                    "GoFundMe",
                    "https://www.gofundme.com"
                ),
                new ClientItem(
                    "logo_swisspost",
                    "SwissPost",
                    "https://www.post.ch/en"
                ),
                new ClientItem(
                    "logo_virgin",
                    "Virgin",
                    "https://www.virginatlantic.com"
                ),
                new ClientItem(
                    "logo_itslearning",
                    "ItsLearning",
                    "https://itslearning.com"
                ),
                new ClientItem(
                    "logo_callidus",
                    "Callidus Cloud",
                    "https://www.calliduscloud.com"
                ),
                new ClientItem(
                    "logo_hireiq",
                    "Hire IQ",
                    "http://www.hireiqinc.com"
                ),
                new ClientItem(
                    "logo_fiverr",
                    "Fiverr",
                    "https://www.fiverr.com"
                ),
                new ClientItem(
                    "logo_circleup",
                    "CircleUp",
                    "https://circleup.com"
                ),
                new ClientItem(
                    "logo_youcruit",
                    "Youcruit",
                    "https://us.youcruit.com"
                ),
                new ClientItem(
                    "logo_netflix",
                    "Netflix",
                    "https://www.netflix.com"
                ),
                new ClientItem(
                    "logo_spotify",
                    "Spotify",
                    "https://spotify.com"
                ),
                new ClientItem(
                    "logo_nyustern",
                    "NYU Stern",
                    "http://www.stern.nyu.edu"
                ),
                new ClientItem(
                    "logo_dubizzle",
                    "Dubizzle",
                    "https://dubizzle.com"
                ),
                new ClientItem(
                    "logo_usv",
                    "Union Square Ventures",
                    "https://usv.com"
                ),
                new ClientItem(
                    "logo_mavenclinic",
                    "Maven Clinic",
                    "https://www.mavenclinic.com"
                )
            };
        }

        private void _initSdks()
        {
            _sdkItems = new List<SdkItem>
            {
                new SdkItem(
                    "logo_objc",
                    "https://github.com/Ziggeo/iOS-Client-SDK"
                ),
                new SdkItem(
                    "logo_swift",
                    "https://github.com/Ziggeo/Swift-Client-SDK"
                ),
                new SdkItem(
                    "logo_android",
                    "https://github.com/Ziggeo/Android-Client-SDK"
                ),
                new SdkItem(
                    "logo_xamarin",
                    "https://github.com/Ziggeo/Xamarin-SDK-Demo"
                ),
                new SdkItem(
                    "logo_react",
                    "https://github.com/Ziggeo/ReactNativeDemo"
                ),
                new SdkItem(
                    "logo_flutter",
                    "https://github.com/Ziggeo/Flutter-SDK"
                ),
                new SdkItem(
                    "logo_php",
                    "https://github.com/Ziggeo/ZiggeoPhpSdk"
                ),
                new SdkItem(
                    "logo_python",
                    "https://github.com/Ziggeo/ZiggeoPythonSdk"
                ),
                new SdkItem(
                    "logo_nodejs",
                    "https://github.com/Ziggeo/ZiggeoNodeSdk"
                ),
                new SdkItem(
                    "logo_ruby",
                    "https://github.com/Ziggeo/ZiggeoRubySdk"
                ),
                new SdkItem(
                    "logo_java",
                    "https://github.com/Ziggeo/ZiggeoJavaSdk"
                ),
                new SdkItem(
                    "logo_csharp",
                    "https://github.com/Ziggeo/ZiggeoCSharpSDK"
                )
            };
        }
    }
}