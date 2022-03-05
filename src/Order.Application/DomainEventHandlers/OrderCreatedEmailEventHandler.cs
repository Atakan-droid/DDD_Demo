using MediatR;
using Order.Domain.Events;
using Order.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Order.Application.DomainEventHandlers
{
    class OrderCreatedEmailEventHandler : INotificationHandler<OrderCreatedEmailEvent>, IDomainEvent
    {
        private readonly IEmailSenderHelper emailSenderHelper;
        private readonly IBuyerRepository buyerRepo;

        public OrderCreatedEmailEventHandler(IEmailSenderHelper emailSenderHelper,IBuyerRepository buyer)
        {
            this.emailSenderHelper = emailSenderHelper;
            this.buyerRepo = buyer;
        }
        public Task Handle(OrderCreatedEmailEvent notification, CancellationToken cancellationToken)
        {
            var buyer = buyerRepo.GetById(notification.BuyerId).Result;
            emailSenderHelper.SendEmail(buyer);
        }
    }
}
