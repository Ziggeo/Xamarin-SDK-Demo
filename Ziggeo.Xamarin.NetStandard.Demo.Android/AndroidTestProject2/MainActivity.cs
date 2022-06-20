using System;
using System.Reflection;
using Android.App;
using Android.Runtime;
using Xamarin.Android.NUnitLite;

namespace AndroidTestProject2
{
    // [Activity(Label = "AndroidTestProject2", MainLauncher = true)]
    // public class MainActivity : TestSuiteActivity
    // {
    //     protected override void OnCreate(Bundle bundle)
    //     {
    //         // tests can be inside the main assembly
    //         AddTest(Assembly.GetExecutingAssembly());
    //         // or in any reference assemblies
    //         // AddTest (typeof (Your.Library.TestClass).Assembly);
    //
    //         // Once you called base.OnCreate(), you cannot add more assemblies.
    //         base.OnCreate(bundle);
    //     }
    // }


    [Instrumentation(Name = "app.tests.TestInstrumentation")]
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