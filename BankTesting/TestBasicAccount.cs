using BankingSystem;
using BankingSystem.Interfaces;
using System.Diagnostics;

namespace BankTesting
{
    public class TestBasicAccount
    {
        BasicAccount account;

        [SetUp]
        public void Setup()
        {
            account = new BasicAccount(0, "Test");
        }

        [Test]
        public void CreateBasicAccount()
        {            
            Assert.IsNotNull(account);
            Assert.AreEqual("Test", account.Name);
            Assert.AreEqual(0, account.Id);
            Assert.AreEqual(0, account.Balance);
            Assert.AreEqual(0, account.Transactions.Count);
        }
        [Test]
        public void Diposit()
        {
            TransactionType disposit = TransactionType.Deposit;

            account.CreateTransaction(100M, disposit);
            Assert.AreEqual(100M, account.Balance);
            Assert.AreEqual(1, account.Transactions.Count);

            account.CreateTransaction(160.50M, disposit);
            Assert.AreEqual(260.50M, account.Balance);
            Assert.AreEqual(2, account.Transactions.Count);

            Assert.Throws<ArgumentOutOfRangeException>(() => account.CreateTransaction(-10M, disposit));
            Assert.AreEqual(2, account.Transactions.Count);
        }

        [Test]
        public void Withdrawal() {
            account.Balance = 150.99M;

            TransactionType withdrawal = TransactionType.Withdraw;

            account.CreateTransaction(100M, withdrawal);
            Assert.AreEqual(50.99M, account.Balance);
            Assert.AreEqual(1, account.Transactions.Count);

            account.CreateTransaction(50.50M, withdrawal);
            Assert.AreEqual(.49M, account.Balance);
            Assert.AreEqual(2, account.Transactions.Count);

            Assert.Throws<InsufficientFundsException>(() => account.CreateTransaction(10M, withdrawal));
            Assert.AreEqual(.49M, account.Balance);
            Assert.AreEqual(2, account.Transactions.Count);

            Assert.Throws<ArgumentOutOfRangeException>(() => account.CreateTransaction(-10M, withdrawal));
            Assert.AreEqual(.49M, account.Balance);
            Assert.AreEqual(2, account.Transactions.Count);
        }

    }
}