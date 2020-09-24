using System;

namespace Ziggeo.Xamarin.NetStandard.Demo.Models
{
    public class LogItem
    {
        private readonly DateTime _timestamp;
        private readonly string _reason;
        private readonly string _details;

        public LogItem(string reason, string details)
        {
            _timestamp = DateTime.Now;
            _reason = reason;
            _details = details;
        }

        public override string ToString()
        {
            return FormattedOutput;
        }

        public string FormattedOutput => $"[{_timestamp:dd.MM.yyyy HH:mm:ss}] {_reason} {_details}";
    }
}