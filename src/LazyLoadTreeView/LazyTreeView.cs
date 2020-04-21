using System;
using System.Collections;
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

    public class LazyTreeViewItem : TreeViewItem
    {
        public static readonly DependencyProperty LazyItemsSourceProperty =
            DependencyProperty.Register(nameof(LazyItemsSource), typeof(Lazy<IEnumerable>),
                typeof(LazyTreeViewItem), new PropertyMetadata(default(Lazy<IEnumerable>), (sender, args) => 
                { 
                }));

        public Lazy<IEnumerable> LazyItemsSource
        {
            get { return (Lazy<IEnumerable>)GetValue(LazyItemsSourceProperty); }
            set { SetValue(LazyItemsSourceProperty, value); }
        }

        public LazyTreeViewItem()
        {
            Expanded += OnExpanded;
        }

        private void OnExpanded(object sender, RoutedEventArgs eventArgs)
        {
            if (IsExpanded && LazyItemsSource != null)
                ItemsSource = LazyItemsSource.Value;
        }

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
