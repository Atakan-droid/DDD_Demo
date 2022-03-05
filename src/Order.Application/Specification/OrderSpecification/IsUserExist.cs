using Order.Domain.Repository;
using Order.Domain.SeedWork;
using Order.Domain.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Application.Specification.OrderSpecification
{
    public class IsUserExist<T> : GenericSpecification<T> where T : IAggregateRoot
    {
        private readonly IOrderRepository orderRepository;
        private readonly IBuyerRepository buyerRepository;
        private T entity;

        public IsUserExist(IOrderRepository orderRepository,IBuyerRepository buyerRepository)
        {
            this.orderRepository = orderRepository;
            this.buyerRepository = buyerRepository;
        }
        public override bool IsSatisfiedBy(T o)
        {
             entity = o;
            return true;
        }
    }
}
