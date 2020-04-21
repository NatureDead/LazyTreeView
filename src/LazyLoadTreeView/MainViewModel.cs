using Prism.Mvvm;
using System.Collections.ObjectModel;

namespace LazyLoadTreeView
{
    public class MainViewModel : BindableBase, IItemsProvider
    {
        public ObservableCollection<ExampleModel> Items { get; } = new ObservableCollection<ExampleModel>();

        public MainViewModel()
        {
            Items.Add(new ExampleModel(this) { HasVisibleChildren = true });
            Items.Add(new ExampleModel(this) { HasVisibleChildren = false });
        }

        public ObservableCollection<AnotherExampleModel> GetItems()
        {
            var items = new ObservableCollection<AnotherExampleModel>();

            for (var i = 0; i < 10; i++)
                items.Add(new AnotherExampleModel());

            return items;
        }
    }
}
