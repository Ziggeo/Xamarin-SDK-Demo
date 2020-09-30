using System.Collections.Generic;

namespace Ziggeo.Xamarin.NetStandard.Demo.Utils
{
    public class EventLogger
    {
        private readonly IList<LogModel> _events;

        public EventLogger()
        {
            _events = new List<LogModel>();
        }

        public void Add(string reason, string details = null)
        {
            _events.Add(new LogModel(reason, details));
        }

        public IList<LogModel> GetLogs()
        {
            return _events;
        }
    }
}