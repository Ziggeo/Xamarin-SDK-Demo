namespace Ziggeo.Xamarin.NetStandard.Demo.Models
{
    public class MediaItem
    {
        public virtual string Token { get; set; }
        public virtual string Key { get; set; }
        public virtual string Tags { get; set; }
        public new virtual string Date { get; set; }
        public virtual string Status { get; set; }
        public virtual string Title { get; set; }
        public virtual string Description { get; set; }

        public string Type { get; set; }

        public MediaItem(string type)
        {
            Type = type;
        }
    }

    public class VideoItem : MediaItem
    {
        public const string KeyToken = "token";
        public const string KeyState = "state_string";
        public const string KeyTitle = "title";
        public const string KeyDescription = "description";
        public const string KeyDate = "submission_date";
        public const string KeyTags = "tags";
        public const string KeyVideoKey = "key";
        public const string Type = "VideoItem";

        override
            public string Token { get; set; }

        override
            public string Key { get; set; }

        override
            public string Tags { get; set; }

        override
            public string Date { get; set; }

        override
            public string Status { get; set; }

        override
            public string Title { get; set; }

        override
            public string Description { get; set; }

        // override
        //     public string Type = "VideoItem";
        public VideoItem() : base("VideoItem")
        {
        }
    }

    public class AudioItem : MediaItem
    {
        public const string KeyToken = "token";
        public const string KeyState = "state_string";
        public const string KeyTitle = "title";
        public const string KeyDescription = "description";
        public const string KeyDate = "submission_date";
        public const string KeyTags = "tags";
        public const string KeyVideoKey = "key";
        public const string Type = "AudioItem";

        override
            public string Token { get; set; }

        override
            public string Key { get; set; }

        override
            public string Tags { get; set; }

        override
            public string Date { get; set; }

        override
            public string Status { get; set; }

        override
            public string Title { get; set; }

        override
            public string Description { get; set; }
        
        // override
            // public string Type = "AudioItem";
            public AudioItem() : base("AudioItem")
            {
            }
    }

    public class ImageItem : MediaItem
    {
        public const string KeyToken = "token";
        public const string KeyState = "state_string";
        public const string KeyTitle = "title";
        public const string KeyDescription = "description";
        public const string KeyDate = "submission_date";
        public const string KeyTags = "tags";
        public const string KeyVideoKey = "key";
        public const string Type = "ImageItem";

        override
            public string Token { get; set; }

        override
            public string Key { get; set; }

        override
            public string Tags { get; set; }

        override
            public string Date { get; set; }

        override
            public string Status { get; set; }

        override
            public string Title { get; set; }

        override
            public string Description { get; set; }
        
        // override
        //     public string Type = "ImageItem";
        public ImageItem() : base("ImageItem")
        {
        }
    }
}