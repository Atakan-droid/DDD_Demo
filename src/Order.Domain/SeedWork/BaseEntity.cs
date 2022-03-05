using MediatR;
using Order.Domain.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Domain.SeedWork
{
    public abstract class BaseEntity
    {
        public Guid Id { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime UpdatedDate { get; set; } = DateTime.Now;
        public bool IsDeleted { get; set; }

        private ICollection<IDomainEvent> domainEvents;
        public ICollection<IDomainEvent> DomainEvent => domainEvents;

        public void AddDomainEvents(IDomainEvent notification)
        {
            domainEvents ??= new List<IDomainEvent>();
            domainEvents.Add(notification);
        }
        public void RemoveDomainEvent(IDomainEvent notification)
        {
           
            domainEvents?.Remove(notification);
        }
        public void ClearDomainEvent()
        {
            domainEvents.Clear();
        }
    }
}
