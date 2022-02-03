using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace _01_SampleApp.Classes
{
    public class SmtpClient
    {
        private readonly SmtpSettings _settings;

        public SmtpClient(SmtpSettings settings)
        {
            _settings = settings;
        }

        internal void Send(SmtpMessage smtpMessage)
        {
            Debug.WriteLine("Message sent by SmtpClient.");
        }
    }

    public class SmtpMessage
    {
        public string Body { get; internal set; }
    }
}
