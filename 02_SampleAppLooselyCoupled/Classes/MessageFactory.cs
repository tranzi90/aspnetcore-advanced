using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _02_SampleAppLooselyCoupled.Classes
{
    public class MessageFactory
    {
        internal SmtpMessage Create(string message)
        {
            return new SmtpMessage() { Body = message };
        }
    }
}
