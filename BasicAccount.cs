using System.Text;
using BankingSystem.Interfaces;

namespace BankingSystem
{
    public class BasicAccount : IAccount
    {
        /// <summary>
        /// Unique Identifier of the account
        /// </summary>
        public int Id { get; init; }

        /// <summary>
        /// Name of the person the bank account belongs to
        /// </summary>
        public string Name { get; init; } = string.Empty;

        /// <summary>
        /// The amount of money in the account
        /// </summary>
        public decimal Balance { get; set; } = 0M;

        /// <summary>
        /// The transactions that have taken place on the account since creation
        /// </summary>
        public List<Transaction> Transactions { get; init; } = [];

        /// <summary>
        /// Ctor for the basic account
        /// </summary>
        /// <param name="Id">Unique Identifier for the bank account</param>
        /// <param name="name">Name of the owner of the bank account</param>
        public BasicAccount(int Id, string name)
        {
            this.Id = Id;
            this.Name = name;
        }

        /// <summary>
        /// Creates a transaction and stores it to the account for later access
        /// </summary>
        /// <param name="amount">The amount of money that the transaction will be for</param>
        /// <param name="transactionType">The type normally <see cref="TransactionType.Deposit"/> or <see cref="TransactionType.Withdraw"/></param>
        /// <exception cref="InvalidOperationException">If there is an invalid <see cref="TransactionType"/></exception>
        /// <exception cref="ArgumentOutOfRangeException">If the <paramref name="amount"/> is negative</exception>
        public void CreateTransaction(decimal amount, TransactionType transactionType)
        {
            ArgumentOutOfRangeException.ThrowIfNegative(amount);

            switch (transactionType)
            {
                case TransactionType.Deposit:
                    UpdateFunds(amount);
                    break;
                case TransactionType.Withdraw:
                    ValidateFunds(amount);
                    UpdateFunds(amount * -1);
                    break;
                default:
                    throw new InvalidOperationException("Invalid Transaction");
            }

            Transactions.Add(new Transaction(amount, transactionType));
        }

        /// <summary>
        /// Attempts to display all the accounts transaction history
        /// </summary>
        public void DisplayTransactionHistory()
        {
            int i = 1;
            var sb = new StringBuilder();

            foreach (Transaction transaction in Transactions)
            {
                sb.AppendLine($"{i}. {transaction.ToString()}");


            }
            sb.AppendLine($"Total Transactions: {Transactions.Count}");
            BasicEventAggregator.Instance.PublishDisplayData(sb.ToString());
        }

        /// <summary>
        /// Attempts to display information about the account for the user
        /// </summary>
        public void Display()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"ID: {Id}");
            sb.AppendLine($"Name: {Name}");
            sb.AppendLine($"Balance: £{Balance}");

            BasicEventAggregator.Instance.PublishDisplayData(sb.ToString());
        }

        /// <summary>
        /// Simple override to check if the ID is the same for quick comparisons
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object? obj)
        {
            return obj.Equals(Id);
        }

        /// <summary>
        /// Validates that the account has enough money
        /// </summary>
        /// <param name="amount">The amount of money to check against the balance</param>
        /// <exception cref="InsufficientFundsException">If the <paramref name="amount"/> is higher than <see cref="Balance"/></exception>
        private void ValidateFunds(decimal amount)
        {
            if (amount > Balance)
            {
                throw new InsufficientFundsException();
            }
        }

        /// <summary>
        /// Adds the <paramref name="amount"/> to the current <see cref="Balance"/> total
        /// </summary>
        /// <param name="amount">The amount of money to add to the <see cref="Balance"/></param>
        private void UpdateFunds(decimal amount)
        {
            Balance += amount;

        }
    }
}
