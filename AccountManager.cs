using BankingSystem.Interfaces;

namespace BankingSystem
{
    /// <summary>
    /// Manages adding, viewing and transations with an <see cref="IAccount"/>
    /// </summary>
    public class AccountManager : IAccountManager
    {
        private readonly List<IAccount> accounts = new List<IAccount>();

        /// <summary>
        /// Asks for the users input to add an account
        /// </summary>
        public void AddAccount()
        {
            bool isInt = false;
            int id = 0;
            string? name = string.Empty;
            
            do
            {
                BasicEventAggregator.Instance.PublishRequestClear();
                BasicEventAggregator.Instance.PublishDisplayData("Please enter an account ID, or enter -1 to exit");
                isInt = int.TryParse(BasicEventAggregator.Instance.GetUserInput?.Invoke(), out id);

                BasicEventAggregator.Instance.PublishRequestClear();
                BasicEventAggregator.Instance.PublishDisplayData("Please enter name if account holder");
                name = BasicEventAggregator.Instance.GetUserInput?.Invoke();

                if (!isInt
                    || id < 1)
                {
                    if(id == -1)
                    {
                        return;
                    }
                    BasicEventAggregator.Instance.PublishDisplayData($"Please enter a valid ID.");
                    Thread.Sleep(1000);
                }

                if (string.IsNullOrWhiteSpace(name))
                {
                    
                    BasicEventAggregator.Instance.PublishDisplayData($"Please enter a name. ");
                    Thread.Sleep(1000);
                }

                if (accounts.Any(x => x.Equals(id)))
                {
                    BasicEventAggregator.Instance.PublishDisplayData($"Account already exists under ID {id}");
                    Thread.Sleep(1000);
                }

            } while (!isInt || string.IsNullOrWhiteSpace(name));

            accounts.Add(new BasicAccount(id, name));
        }

        /// <summary>
        /// Asks the user for input to deposit money into a specific account
        /// </summary>
        public void DepositMoney()
        {
            bool isInt = false;
            IAccount?  account = null;
            int id = 0;
            do
            {
                do
                {
                    BasicEventAggregator.Instance.PublishRequestClear();
                    BasicEventAggregator.Instance.PublishDisplayData("Please enter an account ID");
                    isInt = int.TryParse(BasicEventAggregator.Instance.GetUserInput?.Invoke(), out id);
                    if (!isInt
                    || id < 1)
                    {
                        if (id == -1)
                        {
                            return;
                        }
                        BasicEventAggregator.Instance.PublishDisplayData($"Please enter a valid ID, -1 to exit");
                        Thread.Sleep(1000);
                    }
                } while (!isInt);

                account = accounts.FirstOrDefault(x => x.Equals(id));

                if(account == null)
                {
                    BasicEventAggregator.Instance.PublishDisplayData($"Unable to find an account under ID {id} please try again, -1 to exit");
                    Thread.Sleep(1000);
                }
            } while (account == null);

            bool validDeposit = false;
            decimal depositAmount = 0;
            do
            {
                BasicEventAggregator.Instance.PublishDisplayData("Please enter the amount to deposit: ");
                validDeposit = decimal.TryParse(BasicEventAggregator.Instance.GetUserInput?.Invoke(), out depositAmount);
                if(!validDeposit
                    || depositAmount < 0)
                {
                    BasicEventAggregator.Instance.PublishDisplayData($"Deposit amount was an invalid number please try again, -1 to exit");
                }

            } while (!validDeposit);

            account.CreateTransaction(depositAmount, TransactionType.Deposit);
        }


        /// <summary>
        /// Asks the user for input to withdraw money from a specific account
        /// </summary>
        public void WithdrawMoney()
        {
            bool isInt = false;
            IAccount? account = null;
            int id = 0;
            do
            {
                do
                {
                    BasicEventAggregator.Instance.PublishRequestClear();
                    BasicEventAggregator.Instance.PublishDisplayData("Please enter an account ID");
                    isInt = int.TryParse(BasicEventAggregator.Instance.GetUserInput?.Invoke(), out id);
                    if (!isInt
                    || id < 1)
                    {
                        if (id == -1)
                        {
                            return;
                        }
                        BasicEventAggregator.Instance.PublishDisplayData($"Please enter a valid ID, -1 to exit");
                        Thread.Sleep(1000);
                    }
                } while (!isInt);

                account = accounts.FirstOrDefault(x => x.Equals(id));

                if (account == null)
                {
                    BasicEventAggregator.Instance.PublishDisplayData($"Unable to find an account under ID {id} please try again, -1 to exit");
                    Thread.Sleep(1000);
                }
            } while (account == null);

            bool validDeposit = false;
            decimal depositAmount = 0;
            do
            {
                BasicEventAggregator.Instance.PublishDisplayData("Please enter the amount to withdraw: ");
                validDeposit = decimal.TryParse(BasicEventAggregator.Instance.GetUserInput?.Invoke(), out depositAmount);
                if (!validDeposit
                    || depositAmount < 0)
                {
                    BasicEventAggregator.Instance.PublishDisplayData($"Withdraw amount was an invalid number please try again.");
                }

            } while (!validDeposit);

            account.CreateTransaction(depositAmount, TransactionType.Withdraw);
        }

        /// <summary>
        /// Gets the transactions from a specific account and displays them
        /// </summary>
        public void GetAccountTransactions()
        {
            bool isInt = false;
            IAccount? account = null;
            int id = 0;
            do
            {
                do
                {
                    BasicEventAggregator.Instance.PublishRequestClear();
                    BasicEventAggregator.Instance.PublishDisplayData("Please enter an account ID");
                    isInt = int.TryParse(BasicEventAggregator.Instance.GetUserInput?.Invoke(), out id);
                    if (!isInt || id < 1)
                    {
                        if (id == -1)
                        {
                            return;
                        }
                        BasicEventAggregator.Instance.PublishDisplayData($"Please enter a valid ID, -1 to exit");
                        Thread.Sleep(1000);
                    }
                } while (!isInt);

                account = accounts.FirstOrDefault(x => x.Equals(id));

                if (account == null)
                {
                    BasicEventAggregator.Instance.PublishDisplayData($"Unable to find an account under ID {id} please try again, -1 to exit");
                    Thread.Sleep(1000);
                }
            } while (account == null);

            account.DisplayTransactionHistory();
            Thread.Sleep(1000);
        }

        /// <summary>
        /// Gets the account details from a specific account and displays them
        /// </summary>
        public void GetAccountDetails()
        {
            bool isInt = false;
            IAccount? account = null;
            int id = 0;
            do
            {
                do
                {
                    BasicEventAggregator.Instance.PublishRequestClear();
                    BasicEventAggregator.Instance.PublishDisplayData("Please enter an account ID");
                    isInt = int.TryParse(BasicEventAggregator.Instance.GetUserInput?.Invoke(), out id);
                    if (!isInt || id < 1)
                    {
                        if (id == -1)
                        {
                            return;
                        }
                        BasicEventAggregator.Instance.PublishDisplayData($"Please enter a valid ID, -1 to exit");
                        Thread.Sleep(1000);
                    }
                } while (!isInt);

                account = accounts.FirstOrDefault(x => x.Equals(id));

                if (account == null)
                {
                    BasicEventAggregator.Instance.PublishDisplayData($"Unable to find an account under ID {id} please try again, -1 to exit");
                    Thread.Sleep(1000);
                }
            } while (account == null);

            account.Display();
            Thread.Sleep(1000);
        }
    }
}
