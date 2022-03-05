using Order.Domain.Abstract;
using Order.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Domain.Specification
{
    public abstract class GenericSpecification<T> : ISpecification<T> where T : IAggregateRoot
    {
        public abstract bool IsSatisfiedBy(T o);

     
    }
}
