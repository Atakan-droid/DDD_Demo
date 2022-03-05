using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Domain.Events
{
    public class OrderCreatedEmailEvent:IDomainEvent
    {
        public int BuyerId { get; set; }

        public OrderCreatedEmailEvent(int buyerId)
        {
            BuyerId = buyerId;
        }
    }
}
