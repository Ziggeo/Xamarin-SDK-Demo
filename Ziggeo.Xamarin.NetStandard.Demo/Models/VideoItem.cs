using System;

namespace Ziggeo.Xamarin.NetStandard.Demo.Models
{
    public class VideoItem
    {
        public const string KeyToken = "token";
        public const string KeyState = "state_string";
        public const string KeyTitle = "title";
        public const string KeyDescription = "description";
        public const string KeyDate = "submission_date";
        public const string KeyTags = "tags";
        public const string KeyVideoKey = "key";
        public string Token { get; set; }
        public string Key { get; set; }
        public string Tags { get; set; }
        public string Date { get; set; }
        public string Status { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }
    }
}