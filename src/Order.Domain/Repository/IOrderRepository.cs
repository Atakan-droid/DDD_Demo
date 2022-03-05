using Order.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Domain.Repository
{
    public interface IOrderRepository:IRepository
    {
        Task<Order.Domain.AggregateModels.OrderModels.Order> GetById(Guid Id);
    }
}
