


namespace BankingSystem.Interfaces
{
    public interface IAccount: IDisplayable
    {
        public void CreateTransaction(decimal amount, TransactionType transactionType);
        public void DisplayTransactionHistory();
        public bool Equals(object? obj);
    }
}
