using MediatR;
using Order.Application.Repository;
using Order.Domain.AggregateModels.BuyerModels;
using Order.Domain.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Order.Application.DomainEventHandlers
{
    public class OrderStartedDomainEventHandler : INotificationHandler<OrderStartedDomainEvent>
    {
        private readonly IBuyerRepository buyerRepository;
        public OrderStartedDomainEventHandler(IBuyerRepository buyerRepository)
        {
            this.buyerRepository = buyerRepository;
        }
        public Task Handle(OrderStartedDomainEvent notification, CancellationToken cancellationToken)
        {
            if (notification.Order.BuyerId == 0)
            {
                var buyer = new Buyer(notification.BuyerFirstName,notification.BuyerLastName);
                //create buyer

            }
            return Task.CompletedTask;
        }
    }
}
