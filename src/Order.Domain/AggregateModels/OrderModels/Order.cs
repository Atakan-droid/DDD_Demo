using Order.Domain.Events;
using Order.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Domain.AggregateModels.OrderModels
{
    public class Order:BaseEntity,IAggregateRoot
    {
        public DateTime OrderDate { get;private set; }
        public string Description { get;private set; }
        public Address Address { get;private set; }
        public int BuyerId { get;private set; }
        public string OrderStatus { get;private set; }
        public ICollection<OrderItem> OrderItems { get;private set; }

        public Order(DateTime orderDate, string description, Address address, int buyerId, string orderStatus, ICollection<OrderItem> orderItems)
        {
            if (orderDate < DateTime.Now) throw new Exception("OrderDate must be greater than now");
            if (address.City == "") throw new Exception("City cannot be empty");

            OrderDate = orderDate;
            Description = description ?? throw new ArgumentNullException(nameof(description));
            Address = address ?? throw new ArgumentNullException(nameof(address));
            BuyerId = buyerId;
            OrderStatus = orderStatus ?? throw new ArgumentNullException(nameof(orderStatus));
            OrderItems = orderItems ?? throw new ArgumentNullException(nameof(orderItems));

            AddDomainEvents(new OrderStartedDomainEvent("","",this));
        }

        public void AddOrderItem(int quantity,decimal price,int productId)
        {
            OrderItem item = new(quantity, price, productId);

            OrderItems.Add(item);
        }
    }
}
