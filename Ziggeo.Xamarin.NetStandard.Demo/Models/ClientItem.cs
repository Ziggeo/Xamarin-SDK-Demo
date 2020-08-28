namespace Ziggeo.Xamarin.NetStandard.Demo.Models
{
    public class ClientItem : BaseAboutItem
    {
        public string Name { get; set; }

        public ClientItem(string url, string name, string logo) : base(logo, url)
        {
            Name = name;
        }
    }
}