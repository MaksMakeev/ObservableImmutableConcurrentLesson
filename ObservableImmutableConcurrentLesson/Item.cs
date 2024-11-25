using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObservableImmutableConcurrentLesson
{
    internal class Item
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public Item(Guid id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
