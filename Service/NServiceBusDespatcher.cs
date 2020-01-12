using NServiceBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Service
{
    public class NServiceBusDespatcher : ICommandDespatcher
    {
        IMessageSession _messageSession;

        public NServiceBusDespatcher(IMessageSession messageSession)
        {
            _messageSession = messageSession;
        }

        public void SendCommand<ICommand>(ICommand command)
        {
            _messageSession.Send(command).ConfigureAwait(false);
        }
    }
}
