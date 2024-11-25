namespace ObservableImmutableConcurrentLesson
{
    internal interface IObserver
    {
        void OnItemChanged(string eventDetails);
    }
}
