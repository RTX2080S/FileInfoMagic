using Alienlab.Practices.Utilities;
using FileInfoMagic.Infrastructure.ViewModels;
using FileInfoMagic.Models;
using System.Collections.ObjectModel;
using System.IO;

namespace FileInfoMagic.ViewModels
{
    public class MainViewModel : CommonViewModel, ISubscriber<FileDroppedEventArgs>
    {
        public MainViewModel()
        {
            TabPages = new ObservableCollection<TabBaseViewModel>();
            TabPages.Add(new FileTabViewModel());
            TabPages.Add(new DirectoryTabViewModel());
        }

        private ObservableCollection<TabBaseViewModel> tabPages;

        public ObservableCollection<TabBaseViewModel> TabPages
        {
            get
            {
                return tabPages;
            }
            set
            {
                tabPages = value;
                OnPropertyChanged(nameof(TabPages));
            }
        }

        private int tabIndex;

        public int TabIndex
        {
            get
            {
                return tabIndex;
            }
            set
            {
                tabIndex = value;
                OnPropertyChanged(nameof(TabIndex));
            }
        }

        public void OnEventHandler(FileDroppedEventArgs e)
        {
            var firstFile = e.FileDropList[0];
            if (!string.IsNullOrWhiteSpace(firstFile) && File.Exists(firstFile))
                TabIndex = 0;
            else if (!string.IsNullOrWhiteSpace(firstFile) && Directory.Exists(firstFile))
                TabIndex = 1;
        }
    }
}
