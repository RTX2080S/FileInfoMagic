using System.Windows;
using System.Windows.Controls;

namespace FileInfoMagic.Views
{
    /// <summary>
    /// Interaction logic for ToolbarTrayView.xaml
    /// </summary>
    public partial class ToolbarTrayView : UserControl
    {
        public ToolbarTrayView()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Remove Toolbar OverflowGrid
        /// <see cref="https://stackoverflow.com/questions/1050953/wpf-toolbar-how-to-remove-grip-and-overflow/1051264#1051264" />
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolBar_Loaded(object sender, RoutedEventArgs e)
        {
            var toolBar = sender as ToolBar;
            var overflowGrid = toolBar.Template.FindName("OverflowGrid", toolBar) as FrameworkElement;
            if (overflowGrid != null)
                overflowGrid.Visibility = Visibility.Collapsed;
            var mainPanelBorder = toolBar.Template.FindName("MainPanelBorder", toolBar) as FrameworkElement;
            if (mainPanelBorder != null)
                mainPanelBorder.Margin = new Thickness();
        }
    }
}
