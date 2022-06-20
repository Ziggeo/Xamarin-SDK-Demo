using System;
using System.Reflection;
using Android.App;
using Android.Runtime;
using Xamarin.Android.NUnitLite;

namespace Ziggeo.Xamarin.NetStandard.Demo.Droid
{
    [Instrumentation(Name = "ziggeo.xamarin.netStandard.demo.droid.TestInstrumentation")]
    public class TestInstrumentation : TestSuiteInstrumentation
    {
        public TestInstrumentation(IntPtr handle, JniHandleOwnership transfer) : base(handle, transfer)
        {
        }

        protected override void AddTests()
        {
            AddTest(Assembly.GetExecutingAssembly());
        }
    }
}