using AutoMapper;
using Order.Application.Abstract;
using Order.Domain.Concrete.OrderManager;
using Order.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Application.Services
{
    public class OrderAppService:ApplicationService
    {
        private readonly OrderManager orderManager;
        private readonly IOrderRepository orderRepository;
        private readonly IMapper mapper;

        public OrderAppService(OrderManager orderManager,IOrderRepository orderRepository,IMapper mapper)
        {
            this.orderManager = orderManager;
            this.orderRepository = orderRepository;
            this.mapper = mapper;
        }
        public async Task<OrderDto> CreateAsync(OrderCreatingDto creatingDto)
        {
            var order = orderManager.CreateAsync(/*somethings*/);
            if (creatingDto.description == null)
            {
                /*Dto business rules*/
            }
            
            await orderRepository.SaveChangesAsync();
            return mapper.Map<Order.Domain.AggregateModels.OrderModels.Order,OrderDto>(order);
        }
    }
}
