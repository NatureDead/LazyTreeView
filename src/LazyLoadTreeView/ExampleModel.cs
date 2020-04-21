using System;
using System.Collections;

namespace LazyLoadTreeView
{
    public class ExampleModel
    {
        public Lazy<IEnumerable> Items { get; }
        public bool HasVisibleChildren { get; set; }

        public ExampleModel(IItemsProvider itemsProvider)
        {
            Items = new Lazy<IEnumerable>(() =>
            {
                return itemsProvider.GetItems();
            });
        }
    }
}
