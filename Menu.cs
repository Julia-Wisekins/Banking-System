using BankingSystem.Interfaces;
using System.Text;

namespace BankingSystem
{
    /// <summary>
    /// Simple menu system that displays the options to the user
    /// </summary>
    public class Menu : IMenu
    {
        /// <summary>
        /// Display the basic menu
        /// </summary>
        public void Display()
        {
            var sb = new StringBuilder();
            sb.AppendLine("-----Menu-----");
            sb.AppendLine("1. Add Account");
            sb.AppendLine("2. Deposit Money");
            sb.AppendLine("3. Withdraw Money");
            sb.AppendLine("4. Display Account Details");
            sb.AppendLine("5. Display Account Transactions");
            sb.AppendLine("6. Exit");

            BasicEventAggregator.Instance.PublishRequestClear();
            BasicEventAggregator.Instance.PublishDisplayData(sb.ToString());
        }

        /// <summary>
        /// Get the correct event based off of the input of the user
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ArgumentException">If the input was not a valid option</exception>
        public Event SelectOption()
        {
            var option = BasicEventAggregator.Instance.GetSingleUserInput?.Invoke().Key;

            return option switch
            {
                ConsoleKey.D1 or ConsoleKey.NumPad1 => Event.AddAccount,
                ConsoleKey.D2 or ConsoleKey.NumPad2 => Event.DepositMoney,
                ConsoleKey.D3 or ConsoleKey.NumPad3 => Event.WithdrawMoney,
                ConsoleKey.D4 or ConsoleKey.NumPad4 => Event.DisplayAccountDetails,
                ConsoleKey.D5 or ConsoleKey.NumPad5 => Event.DisplayAccountTransactions,
                ConsoleKey.D6 or ConsoleKey.NumPad6 => Event.Exit,
                _ => throw new ArgumentException("Invalid Menu Option"),
            };
        }
    }
}
