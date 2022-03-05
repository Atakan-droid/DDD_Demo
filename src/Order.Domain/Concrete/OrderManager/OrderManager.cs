using Order.Domain.Abstract;
using Order.Domain.AggregateModels.OrderModels;
using Order.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Domain.Concrete.OrderManager
{
    public class OrderManager:DomainService
    {
        private readonly IOrderRepository orderRepository;

        public OrderManager(IOrderRepository orderRepository)
        {
            this.orderRepository = orderRepository;
        }
        public async Task<Domain.AggregateModels.OrderModels.Order> CreateAsync(
            Guid id,
            string status,
            int buyerId,
            Address address,
            string description
            )
        {
            if(await orderRepository.GetById(id)!=null)
            {
                throw new Exception("Order is already Exist");
            }
            return new AggregateModels.OrderModels.Order(
                DateTime.Now,
                status,
                address,
                buyerId,
                description
                );
        }
    }
}
