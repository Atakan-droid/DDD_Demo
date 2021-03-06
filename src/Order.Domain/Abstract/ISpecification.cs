using Order.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Domain.Abstract
{
    public interface ISpecification<T>where T:IAggregateRoot
    {
        bool IsSatisfiedBy(T o);
       
    }
}
