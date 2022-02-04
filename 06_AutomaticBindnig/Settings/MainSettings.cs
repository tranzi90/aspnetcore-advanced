using System.Collections.Generic;

namespace _06_AutomaticBindnig.Settings
{
    public class MainSettings
    {
        public string Key1 { get; set; }
        public string Key2 { get; set; }
        public IEnumerable<SmtpServerSettings> SmtpServers { get; set; }
        public IDictionary<string, ProfileData> Profiles { get; set; }
    }
}
