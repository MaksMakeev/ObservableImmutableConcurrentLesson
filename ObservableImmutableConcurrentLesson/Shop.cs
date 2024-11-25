using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObservableImmutableConcurrentLesson
{
    internal class Shop : ISubject
    {
        private readonly List<IObserver> _customers;
        private readonly ObservableCollection<Item> _items;

        public Shop()
        {
            _customers = new List<IObserver>();
            _items = new ObservableCollection<Item>();
        }

        public void RegisterObserver(IObserver customer)
        {
            _customers.Add(customer);
            foreach (var c in _customers)
            {
                _items.CollectionChanged += ItemsCollectionChanged;
            }
        }

        public void RemoveObserver(IObserver customer)
        {
            _customers.Remove(customer);
        }

        public void NotifyObservers(string eventMessage)
        {
            foreach (var customer in _customers)
            {
                customer.OnItemChanged(eventMessage);
            }
        }

        public void Add(Item item)
        {
            _items.Add(item);
            NotifyObservers($"в магазине появился новый товар! Скорее успей купить {item.Name}, {item.Id}");
        }

        public void Remove(string id)
        {
            Guid.TryParse(id, out var guidId);

            var deletingItem = _items.FirstOrDefault(x => x.Id == guidId);
            _items.Remove(deletingItem);
            NotifyObservers($"в магазине пропал товар! Кусай локти! Ты никогда больше не сможешь купить {deletingItem.Name}, {deletingItem.Id}, ва-ха-ха-ха!");
        }

        private static void ItemsCollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    if (e.NewItems?[0] is Item newItem)
                        Console.WriteLine($"Добавлен товар {newItem.Name}, {newItem.Id}");
                    break;
                case NotifyCollectionChangedAction.Remove:
                    if (e.OldItems?[0] is Item oldItem)
                        Console.WriteLine($"Удален товар {oldItem.Name}, {oldItem.Id}");
                    break;
            }
        }
    }
}
