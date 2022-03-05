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
        private readonly IOrderRepository orderRepository;
        public OrderStartedDomainEventHandler(IOrderRepository orderRepository,IBuyerRepository buyerRepository)
        {
            this.buyerRepository = buyerRepository;
            this.orderRepository = orderRepository;
        }
        public Task Handle(OrderStartedDomainEvent notification, CancellationToken cancellationToken)
        {
            if (notification.Order.BuyerId == 0)
            {
                var buyer = new Buyer(notification.BuyerFirstName,notification.BuyerLastName);
                buyerRepository.SaveChangesAsync();

            }
            if (notification.Order.OrderItems.Count != 0)
            {

                foreach (var item in notification.OrderItems)
                {
                    notification.Order.OrderItems.Add(item);
                }
                orderRepository.SaveChangesAsync();
            }
            return  Task.CompletedTask;
        }
    }
}
