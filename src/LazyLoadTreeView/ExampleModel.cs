using System;
using System.Collections;

namespace LazyLoadTreeView
{
    public class ExampleModel
    {
        public Lazy<IEnumerable> Items { get; }

        public ExampleModel(IItemsProvider itemsProvider)
        {
            Items = new Lazy<IEnumerable>(() =>
            {
                return itemsProvider.GetItems();
            });
        }
    }

    public class AnotherExampleModel
    {
        public Guid Guid { get; } = Guid.NewGuid();
    }
}
