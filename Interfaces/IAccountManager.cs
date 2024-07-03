namespace BankingSystem.Interfaces
{
    public interface IAccountManager
    {
        public void AddAccount();
        public void DepositMoney();
        public void WithdrawMoney();
        public void GetAccountDetails();
        public void GetAccountTransactions();


    }
}
