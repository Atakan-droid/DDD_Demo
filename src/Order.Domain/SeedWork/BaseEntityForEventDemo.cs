using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Domain.SeedWork
{
    public abstract class BaseEntityForEventDemo
    {
        public Guid Id { get; set; }
        public ICollection<IEvent> UncommittedEvents { get; set; } = new List<IEvent>();

        public void Commit() => UncommittedEvents.Clear();

        public void Rehydrate(ICollection<IEvent> events)
        {
            foreach (var evt in events)
            {
                ((dynamic)this).Apply((dynamic) evt);
            }

        }
    }
}
