using System.Collections.Generic;
using Ziggeo.Xamarin.NetStandard.Demo.Models;

namespace Ziggeo.Xamarin.NetStandard.Demo.Utils
{
    public class EventLogger
    {
        private readonly IList<LogItem> _events;

        public EventLogger()
        {
            _events = new List<LogItem>();
        }

        public void Add(string reason, string details = null)
        {
            _events.Add(new LogItem(reason, details));
        }

        public IList<LogItem> GetLogs()
        {
            return _events;
        }
    }
}