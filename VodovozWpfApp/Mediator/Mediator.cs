using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VodovozWpfApp
{
    public delegate void MessageReceivedEventHandler(AppPageEnum recipient, object message);
    public class Mediator
    {
        public event MessageReceivedEventHandler MessageReceived;

        public void Send(AppPageEnum recipient, object message)
        {
            MessageReceived?.Invoke(recipient, message);
        }
    }
}
