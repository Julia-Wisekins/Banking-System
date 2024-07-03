namespace BankingSystem.Interfaces
{
    public interface IMediator
    {
        /// <summary>
        /// Notify the underlying objects of the specified event
        /// </summary>
        /// <param name="sender">The sender of the event</param>
        /// <param name="ev">The event type</param>
        void Notify(object sender, Event ev);

    }
}
