
using Order.Domain.AggregateModels.BuyerModels;

namespace Order.Application.DomainEventHandlers
{
    public interface IEmailSenderHelper
    {
        void SendEmail(Buyer buyer);
    }
}