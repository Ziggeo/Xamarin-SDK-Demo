namespace Ziggeo.Xamarin.NetStandard.Demo.Models
{
    public abstract class BaseAboutItem
    {
        public string Url { get; set; }
        public string Logo { get; set; }

        protected BaseAboutItem(string logo, string url)
        {
            Logo = logo;
            Url = url;
        }
    }
}