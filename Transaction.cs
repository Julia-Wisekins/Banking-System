using System.Text;

namespace BankingSystem
{
    public class Transaction 
    {
        private Guid Id { get; init; }
        private DateTime Datetime { get; init; }
        private decimal Amount { get; init; }
        private TransactionType Type { get; init; }

        public Transaction(decimal amount, TransactionType type)
        {
            this.Id = Guid.NewGuid();
            this.Datetime = DateTime.Now;
            this.Amount = amount;
            this.Type = type;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"ID: {Id}");
            sb.AppendLine($"Date: {Datetime.ToString("dd-mm-yyyy")} at {Datetime.ToString("t")}");
            sb.AppendLine($"Type: £{Type.ToString()}");
            sb.AppendLine($"Amount: £{Amount}");
            return sb.ToString();
        }
    }
}
