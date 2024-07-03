using BankingSystem.Interfaces;

namespace BankingSystem
{
    /// <summary>
    /// Mediates between the front end and the account managers
    /// This could be used to expand the functionality in the future like having a transaction manager
    /// </summary>
    public class Mediator : IMediator
    {
        private readonly IAccountManager _accountManager;
        
        /// <summary></summary>
        /// <param name="accountManager">The account manager that will control the <see cref="IAccount"/> data</param>
        public Mediator(IAccountManager accountManager)
        {
            _accountManager = accountManager;
        }

        /// <summary>
        /// Notify the underlying account manager of the specified event
        /// </summary>
        /// <param name="sender">The sender of the event</param>
        /// <param name="ev">The event type</param>
        /// <exception cref="ArgumentException">Unknown Event type</exception>
        public void Notify(object sender, Event ev)
        {
            switch (ev)
            {
                case Event.AddAccount:
                    _accountManager.AddAccount();
                    return; 
                case Event.DepositMoney:
                    _accountManager.DepositMoney();
                    return; 
                case Event.WithdrawMoney:
                    _accountManager.WithdrawMoney();
                    return; 
                case Event.DisplayAccountDetails:
                    _accountManager.GetAccountDetails();
                    return; 
                case Event.DisplayAccountTransactions:
                    _accountManager.GetAccountTransactions();
                    return;
                default:
                    throw new ArgumentException("Invalid Event");
            }
        }
    }
}
