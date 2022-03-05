using Order.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Domain.AggregateModels.AccountModels
{
    public class Account:BaseEntityForEventDemo,IAggregateRoot
    {
        private decimal CurrentAmount;
        private StateEnum CurrentState { get; set; } = StateEnum.NotSet;

        private void Apply(AccountOpened evt) => CurrentState = StateEnum.Opened;
        private void Apply(MoneyTransfered evt) => CurrentAmount = evt.Amount;

        public void Open(string Owner,string Iban)
        {
            var evt = new AccountOpened(Id, Owner, Iban);
            UncommittedEvents.Add(evt);
            Apply(evt);
        }
        
        public void TransferMoney(decimal amount,string iban)
        {
            if (CurrentAmount < amount)
                throw new InvalidOperationException("Not enough money avalible");
            var evt = new MoneyTransfered(Id, amount, iban);
            UncommittedEvents.Add(evt);
            Apply(evt);
        }
        public void Close()
        {
            if (StateEnum.Opened != CurrentState)
            {
                throw new Exception();
            }
        }
    }

    internal class MoneyTransfered:IEvent
    {
        public Guid Id { get; set; }
        public decimal Amount { get; set; }
        private string Iban { get; set; }

        public MoneyTransfered(Guid Id, decimal Amount, string Iban)
        {
            this.Id = Id;
            this.Amount = Amount;
            this.Iban = Iban;
        }
    }

    internal class AccountOpened:IEvent
    {
        private Guid Id;
        private string owner;
        private string ıban;

        public AccountOpened(Guid Id, string owner, string ıban)
        {
            this.Id = Id;
            this.owner = owner;
            this.ıban = ıban;
        }
    }
}
