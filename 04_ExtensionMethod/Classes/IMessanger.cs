using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleAppLooselyCoupled.Classes
{
    public interface IMessanger
    {
        void SendMessage(string message, string user);
    }
}
