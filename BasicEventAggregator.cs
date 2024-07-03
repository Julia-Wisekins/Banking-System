namespace BankingSystem
{
    /// <summary>
    /// Simple event aggregator to show how the front end and the backend could be seperated a little more
    /// </summary>
    public class BasicEventAggregator
    {
        // Singleton
        private static BasicEventAggregator _instance;

        private BasicEventAggregator() { }

        public static BasicEventAggregator Instance
        {
            get
            {
                _instance ??= new BasicEventAggregator();

                return _instance;
            }
        }

        /// <summary>
        /// Event called when the backend wishes to display some data to the front end
        /// </summary>
        public event EventHandler<DisplayDataEventArgs> DisplayData;
        /// <summary>
        /// Publishes the event to display data with the specified text in <paramref name="data"/>
        /// </summary>
        /// <param name="data">The exact data that will be sent to the front end to be displayed</param>
        public void PublishDisplayData(string data)
        {
            DisplayData?.Invoke(this, new DisplayDataEventArgs() { DisplayData = data });
        }

        /// <summary>
        /// Event called when the backend wishes to clear the display (normally for consoles)
        /// </summary>
        public event EventHandler RequestClear;

        /// <summary>
        /// Publishes the event to clear the front end of any prompts
        /// </summary>
        public void PublishRequestClear()
        {
            RequestClear?.Invoke(this, EventArgs.Empty);
        }

        /// <summary>
        /// Function passthrough to get a single key input from the front end
        /// </summary>
        public Func<ConsoleKeyInfo> GetSingleUserInput { get; set; }
        
        /// <summary>
        /// Function passthrough to get a string from the front end
        /// </summary>
        public Func<string> GetUserInput { get; set; }
    }
}
