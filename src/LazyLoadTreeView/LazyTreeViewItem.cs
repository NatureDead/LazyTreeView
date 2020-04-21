using System;
using System.Collections;
using System.Windows;
using System.Windows.Controls;

namespace LazyLoadTreeView
{
    public class LazyTreeViewItem : TreeViewItem
    {
        public static readonly DependencyProperty LazyItemsSourceProperty =
            DependencyProperty.Register(nameof(LazyItemsSource), typeof(Lazy<IEnumerable>),
                typeof(LazyTreeViewItem), new PropertyMetadata(default(Lazy<IEnumerable>)));

        public static readonly DependencyProperty IsExpanderVisibleProperty =
            DependencyProperty.Register(nameof(IsExpanderVisible), typeof(bool),
                typeof(LazyTreeViewItem), new PropertyMetadata(default(bool)));

        public Lazy<IEnumerable> LazyItemsSource
        {
            get { return (Lazy<IEnumerable>)GetValue(LazyItemsSourceProperty); }
            set { SetValue(LazyItemsSourceProperty, value); }
        }

        public bool IsExpanderVisible
        {
            get { return (bool)GetValue(IsExpanderVisibleProperty); }
            set { SetValue(IsExpanderVisibleProperty, value); }
        }

        static LazyTreeViewItem()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(LazyTreeViewItem),
                new FrameworkPropertyMetadata(typeof(LazyTreeViewItem)));
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
