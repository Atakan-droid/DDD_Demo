using MediatR;
using Order.Domain.AggregateModels.OrderModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Domain.Events
{
    public class OrderStartedDomainEvent : INotification
    {
        public string BuyerFirstName { get; private set; }
        public string BuyerLastName { get; private set; }
        public AggregateModels.OrderModels.Order Order { get; private set; }
        public ICollection<AggregateModels.OrderModels.OrderItem> OrderItems{ get; private set; }

        public OrderStartedDomainEvent(string buyerFirstName, string buyerLastName, AggregateModels.OrderModels.Order order, ICollection<OrderItem> orderItems)
        {
            BuyerFirstName = buyerFirstName ?? throw new ArgumentNullException(nameof(buyerFirstName));
            BuyerLastName = buyerLastName ?? throw new ArgumentNullException(nameof(buyerLastName));
            Order = order ?? throw new ArgumentNullException(nameof(order));
            OrderItems = orderItems ?? throw new ArgumentNullException(nameof(orderItems));
        }
    }
}
