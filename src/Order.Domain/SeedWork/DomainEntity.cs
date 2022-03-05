using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Domain.SeedWork
{
    public abstract class DomainEntity : IDomainEntity
    {
        private List<IEvent> events = new List<IEvent>();
        public void ClearEvents()
        {
            events.Clear();
        }

        public IEnumerable<IEvent> GetEvents()
        {
            return events;
        }

        public void RaiseEvent(IEvent @event)
        {
            events.Add(@event);
        }
    }
}
