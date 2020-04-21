using System.Windows;
using System.Windows.Controls;

namespace LazyLoadTreeView
{
    public class LazyTreeView : TreeView
    {
        protected override DependencyObject GetContainerForItemOverride()
        {
            return new LazyTreeViewItem();
        }

        protected override bool IsItemItsOwnContainerOverride(object item)
        {
            return item is LazyTreeViewItem;
        }
    }
}
