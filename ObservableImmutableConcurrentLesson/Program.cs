using System.Collections.ObjectModel;

namespace ObservableImmutableConcurrentLesson
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Permanent customer
            var shop = new Shop();
            var customer = new Customer("John");
            var unsubscribedCustomer = new Customer("BobDylan");

            shop.RegisterObserver(customer);
            //shop.RegisterObserver(unsubscribedCustomer);

            //var item1 = new Item(Guid.NewGuid(), "Помидорки");
            //var item2 = new Item(Guid.NewGuid(), "Колбаски");
            //var item3 = new Item(Guid.NewGuid(), "Молоко");

            //shop.Add(item1);
            //shop.Add(item2);
            //shop.Add(item3);

            //shop.Remove(item3);
            //shop.Remove(item2);
            //shop.Remove(item1);

            while (true)
            {
                var userCommand = Console.ReadLine();

                switch (userCommand)
                {
                    case "a" or "A" or "ф" or "Ф":
                        Console.WriteLine($"Введите наименование товара:\n");
                        var item = new Item(Guid.NewGuid(), Console.ReadLine());
                        shop.Add(item);
                        break;
                    case "d" or "D" or "в" or "В":
                        Console.WriteLine($"Введите идентификатор товара, который нужно удалить:\n");
                        shop.Remove(Console.ReadLine());
                        break;
                    case "x":
                        Console.WriteLine($"Пока!");
                        return;
                    default:
                        Console.WriteLine($"Пока!");
                        return;
                }
            }
        }
    }
}
