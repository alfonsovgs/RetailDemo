using Messages;
using NServiceBus;
using NServiceBus.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientUI
{
    class PlaceOrderHandler : IHandleMessages<PlaceOrder>
    {
        private static readonly ILog _log = LogManager.GetLogger<PlaceOrderHandler>();

        public Task Handle(PlaceOrder message, IMessageHandlerContext context)
        {
            _log.Info($"Received PlaceOrder, OrderId = {message.OrderId}");
            return Task.CompletedTask;
        }
    }
}
