namespace ObservableImmutableConcurrentLesson
{
    internal interface ISubject
    {
        void RegisterObserver(IObserver observer);
        void RemoveObserver(IObserver observer);
        void NotifyObservers(string eventMessage);
    }
}
