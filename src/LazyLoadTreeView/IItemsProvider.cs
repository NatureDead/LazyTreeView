using System.Collections.ObjectModel;

namespace LazyLoadTreeView
{
    public interface IItemsProvider
    {
        ObservableCollection<AnotherExampleModel> GetItems();
    }
}
