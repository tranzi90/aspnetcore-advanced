using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _03_SampleAppLooselyCoupled.Classes
{
    public interface IMessanger
    {
        void SendMessage(string message, string user);
    }
}
