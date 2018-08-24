using FileInfoMagic.ViewModels;
using System.Windows;

namespace FileInfoMagic
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        protected MainWindowViewModel ViewModel => this.DataContext as MainWindowViewModel;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Drop(object sender, DragEventArgs e)
        {
            var dataObject = e.Data as DataObject;
            ViewModel.OnFileDropped(dataObject);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ViewModel.OnWindowLoaded();
        }
    }
}
