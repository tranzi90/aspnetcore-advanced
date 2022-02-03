using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleAppLooselyCoupled.Classes
{
    public class Messanger : IMessanger
    {
        private readonly SmtpClient _client;
        private readonly MessageFactory _factory;

        public Messanger(SmtpClient client, MessageFactory factory)
        {
            _client = client;
            _factory = factory;
        }

        public void SendMessage(string message, string user)
        {
            SmtpMessage smtpMessage = _factory.Create(message);
            _client.Send(smtpMessage);
        }
    }
}
