using BankingSystem.Interfaces;

namespace BankingSystem
{
    class Program 
    {

        static void Main(string[] args)
        {
            IAccountManager accountManager = new AccountManager();
            IMenu menu = new Menu();
            IMediator mediator = new Mediator(accountManager);

            // Set up some basic event aggregation so we don't have console commands in the "backend"
            BasicEventAggregator.Instance.DisplayData += UI_DisplayData;
            BasicEventAggregator.Instance.RequestClear += UI_RequestClear;
            BasicEventAggregator.Instance.GetSingleUserInput = Console.ReadKey;
            BasicEventAggregator.Instance.GetUserInput = Console.ReadLine;

            Event option = Event.AddAccount;
            while (option != Event.Exit)
            {
                menu.Display();
                option = menu.SelectOption();

                if (Event.Exit != option)
                {
                    mediator.Notify(null, option);
                }
            }
        }

        private static void UI_RequestClear(object? sender, EventArgs e)
        {
            Console.Clear();
        }

        private static void UI_DisplayData(object? sender, DisplayDataEventArgs e)
        {
            Console.WriteLine(e.DisplayData);
        }
    }

}
