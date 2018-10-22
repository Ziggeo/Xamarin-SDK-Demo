# Ziggeo Xamarin SDK 1.2.3

Ziggeo API (https://ziggeo.com) allows you to integrate video recording and playback with only
several lines of code in your app.

## Upgrading from v.1.2.2 to v.1.2.3
The update bring  `RecordingStopped` event. It will be invoked at the moment of the recording was stopped

## Upgrading from v.1.2.1 to v.1.2.2
The update changes the behaviour of the `RecordingStarted` event. It will be invoked on actual recording start instead of the recorder UI appearance

## Upgrading from v.1.1.0 to v.1.2.1
The update bring crossplatform available events for recorder and video service.

## Upgrading from v.1.0.0 to v.1.1.0
The update bring crossplatform avaiable client/server auth tokens. Use ZiggeoApplication.ClientAuthToken and ZiggeoApplication.ServerAuthToken properties to set the auth tokens on iOS and Android platforms

## Integration

You need to add these code to your `Application` class:
```csharp
public const string AppToken = "your_token_here";
public static Ziggeo.ZiggeoApplication ZiggeoApplication = new Ziggeo.ZiggeoApplication(AppToken);
```

You can check other global options, [see here](https://ziggeo.com/docs).

To fire up a recorder, add:
```csharp
Ziggeo.IZiggeoRecorder recorder = App.ZiggeoApplication.Recorder;
try
{
	string token = await recorder.Record();
}
catch(Exception ex)
{
	await DisplayAlert("Error", ex.Message, "Okay");
}
``` 

To start a player for an existing video, add:
```csharp
Ziggeo.IZiggeoPlayer player = App.ZiggeoApplication.Player;
await player.Play(viewModel.Item.token);
``` 

For the full documentation, please visit [ziggeo.com](https://ziggeo.com/docs).


## Auth Tokens

To enable client/server auth tokens use:

```csharp
ZiggeoApplication.ServerAuthToken = "SERVER_AUTH_TOKEN"
ZiggeoApplication.ClientAuthToken = "CLIENT_AUTH_TOKEN"
```

## Events
### Video service events

```csharp
ZiggeoApplication.Videos.UploadStarted += (string filePath) =>
{
//upload started
Console.WriteLine("upload started from {0}", filePath);
};

ZiggeoApplication.Videos.UploadProgressChanged += (string token, string filename, long bytesSent, long totalBytes) => 
{
//update progress    
Console.WriteLine("upload progress changed for {2}: {0}/{1}", bytesSent, totalBytes, token);
};

ZiggeoApplication.Videos.UploadComplete += (string token, string filename) =>
{
//done
Console.WriteLine("{0} upload done with token {1}", filename, token);
};

ZiggeoApplication.Videos.UploadFailed += (string filename, Exception error) =>
{
//handle error
Console.WriteLine("{0} upload failed with error {1}", filename, error.ToString());
};
```

### Recorder events
```csharp
ZiggeoApplication.Recorder.RecordingStarted += () =>
{
//recording started
Console.WriteLine("recording started");
};

ZiggeoApplication.Recorder.RecordingStopped += () =>
{
//recording was stopped
Console.WriteLine("recording stopped");
};

ZiggeoApplication.Recorder.RecordingCanceled += () =>
{
//recorder was closed by the user
Console.WriteLine("recorded was closed manually, recording was canceled");
};

ZiggeoApplication.Recorder.RecordingFinishedUploadDone += (string token) =>
{
//done
Console.WriteLine("recording and file upload were finished with token {0}", token);
};

ZiggeoApplication.Recorder.RecordingError += (Exception ex) =>
{
//handle error
Console.WriteLine("recorder error: {0}", ex.ToString());
};
```

## API Methods
To access API methods, use:
```csharp
App.ZiggeoApplication.Videos
```
or
```csharp
App.ZiggeoApplication.Streams
```

### Videos  

The videos resource allows you to access all single videos. Each video may contain more than one stream. 
 

#### Index 
 
Query an array of videos (will return at most 50 videos by default). Newest videos come first. 

```csharp 
App.ZiggeoApplication.Videos.Index(Dictionary<string, string> arguments) 
``` 
 
Arguments 
- limit: *Limit the number of returned videos. Can be set up to 100.* 
- skip: *Skip the first [n] entries.* 
- reverse: *Reverse the order in which videos are returned.* 
- states: *Filter videos by state* 
- tags: *Filter the search result to certain tags, encoded as a comma-separated string* 


#### Get 
 
Get a single video by token or key. 

```csharp 
App.ZiggeoApplication.Videos.Get(string token_or_key) 
``` 
 

#### Download Video 
 
Download the video data file 

```csharp 
App.ZiggeoApplication.Videos.DownloadVideo(string token_or_key) 
``` 
 


#### Download Image 
 
Download the image data file 

```csharp 
App.ZiggeoApplication.Videos.DownloadImage(string token_or_key) 
``` 
 
#### Apply Effect 
 
Apply an effect profile to a video. 

```csharp 
App.ZiggeoApplication.Videos.ApplyEffect(string token_or_key, Dictionary<string, string> arguments) 
``` 
 
Arguments 
- effectprofiletoken: *Effect Profile token (from the Effect Profiles configured for the app)* 


#### Update 
 
Update single video by token or key. 

```csharp 
App.ZiggeoApplication.Videos.Update(string token_or_key, Dictionary<string, string> arguments) 
``` 
 
Arguments 
- min_duration: *Minimal duration of video* 
- max_duration: *Maximal duration of video* 
- tags: *Video Tags* 
- key: *Unique (optional) name of video* 
- volatile: *Automatically removed this video if it remains empty* 
- expiration_days: *After how many days will this video be deleted* 


#### Destroy 
 
Destroy a single video by token or key. 

```csharp 
App.ZiggeoApplication.Videos.Destroy(string token_or_key) 
``` 

#### Create 
 
Create a new video. 

```csharp 
App.ZiggeoApplication.Videos.Create(string filePath, Dictionary<string, string> arguments) 
``` 
 
Arguments 
- file: *Video file to be uploaded* 
- min_duration: *Minimal duration of video* 
- max_duration: *Maximal duration of video* 
- tags: *Video Tags* 
- key: *Unique (optional) name of video* 
- volatile: *Automatically removed this video if it remains empty* 

### Streams  

The streams resource allows you to directly access all streams associated with a single video. 
 

#### Create 
 
Create a new stream 

```csharp 
App.ZiggeoApplication.Streams.Create(string video_token_or_key, Dictionary<string, string> arguments, string file) 
``` 
 
Arguments 
- file: *Video file to be uploaded* 


#### Attach Image 
 
Attaches an image to a new stream 

```csharp 
App.ZiggeoApplication.Streams.AttachImage(string video_token_or_key, string token_or_key, Dictionary<string, string> arguments, string file) 
``` 
 
Arguments 
- file: *Image file to be attached* 


#### Attach Video 
 
Attaches a video to a new stream 

```csharp 
App.ZiggeoApplication.Streams.AttachVideo(string video_token_or_key, string token_or_key, Dictionary<string, string> arguments, string file) 
``` 
 
Arguments 
- file: *Video file to be attached* 


#### Bind 
 
Closes and submits the stream 

```csharp 
App.ZiggeoApplication.Streams.Bind(string video_token_or_key, string token_or_key, Dictionary<string, string> arguments) 
``` 
 

## License

Copyright (c) 2013-2018 Ziggeo
 
Apache 2.0 License
