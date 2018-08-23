using System.Windows;
using System.Windows.Controls;

namespace FileInfoMagic.ViewModels
{
    public class TabPageTemplateSelector : DataTemplateSelector
    {
        public DataTemplate FileTabTemplate { get; set; }
        public DataTemplate DirectoryTabTemplate { get; set; }

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            var customer = item as TabBaseViewModel;
            if (customer == null)
                return base.SelectTemplate(item, container);

            if (item is FileTabViewModel)
                return FileTabTemplate;
            if (item is DirectoryTabViewModel)
                return DirectoryTabTemplate;

            return FileTabTemplate;
        }
    }
}
