using BankingSystem;
using BankingSystem.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankTesting
{
    public class FakeAccountManager : IAccountManager
    {
        public List<IAccount> Accounts { get; set; } = new List<IAccount>();

        public int AccountId { get; set; }
        public decimal TransactionAmount { get; set; }
        public decimal ExpectedAmount { get; set; }

        public void AddAccount()
        {
            Accounts.Add(new BasicAccount(AccountId, "TestName"));
        }

        public void DepositMoney()
        {
            Accounts.FirstOrDefault(x => x.Equals(AccountId))?.CreateTransaction(TransactionAmount, TransactionType.Deposit);
        }

        public void GetAccountDetails()
        {
            IAccount account = Accounts.FirstOrDefault(x => x.Equals(AccountId));
            Assert.IsNotNull(account);
            if (account is BasicAccount a) {
                Assert.That(a.Id, Is.EqualTo(AccountId));
                Assert.That(a.Balance, Is.EqualTo(ExpectedAmount));
                Assert.That(a.Name, Is.EqualTo("TestName"));
            }
        }

        public void GetAccountTransactions()
        {
            throw new NotImplementedException();
        }

        public void WithdrawMoney()
        {
            Accounts.FirstOrDefault(x => x.Equals(AccountId))?.CreateTransaction(TransactionAmount, TransactionType.Withdraw);
        }
    }
}
