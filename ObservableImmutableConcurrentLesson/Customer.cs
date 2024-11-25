using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObservableImmutableConcurrentLesson
{
    internal class Customer : IObserver
    {
        
        private readonly string _customerName;

        public Customer(string visitorName)
        {
            _customerName = visitorName;
        }

        public void OnItemChanged(string eventDetails)
        {
            Console.WriteLine($"{_customerName}, {eventDetails}");
        }
    }
}
