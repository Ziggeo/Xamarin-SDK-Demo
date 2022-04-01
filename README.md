# Ziggeo Xamarin SDK Demo App

Thank you for visiting our demo app based on Xamarin. We invite you to download and build and give it a go.

## Ziggeo's SDKs

This demo is using Xamarin and is based on [Ziggeo's Xamarin SDK](https://github.com/Ziggeo/Xamarin-SDK).

As Xamarin has support for both iOS and Android platforms, so does our SDK. While this demos showcases some features, for all features, please check out the readme in the Xamarin SDK repo.

Ziggeo supports and provides many other mobile SDKs such as ReactNative and Flutter. There are also platform specific SDKs for iOS (Objective C and Swift SDKs) and Android (Java & Kotlin).

## How to build app

First step would be to add your app token. For this you will need Ziggeo account, which you can get on overview page if you have the account. If you do not have account, header over [here](https://ziggeo.com/signup/) to create one with 30 days free trial.

- You can grab your appToken by logging [into your](https://ziggeo.com/signin/) account and under application you will use you will see `Overview` and there you will find the app token.

You will add the app token into `FormsTestApp/FormsTestApp/App.xaml.cs` instead of `ZIGGEO_APP_TOKEN`.

Once you do, you are ready to compile and test it up

There are slightly different ways to build Xamarin apps and the [following page](https://docs.microsoft.com/en-us/xamarin/get-started/first-app/?pivots=windows) of Microsoft Documentation helps guide you through the required steps.

If you are using Microsoft Visual Studio, all you would need is to compile or use degbug option to start the emulator and see how it works.

## License

Copyright (c) 2013-2022 Ziggeo
 
Apache 2.0 License
