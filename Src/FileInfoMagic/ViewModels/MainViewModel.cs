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
            this.AddTab(new FileTabViewModel(this));
            this.AddTab(new DirectoryTabViewModel(this));
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

        public void AddTab(TabBaseViewModel tab)
        {
            if (tab != null)
                TabPages.Add(tab);
        }

        public void RemoveTab(TabBaseViewModel tab)
        {
            if (tab != null)
                TabPages.Remove(tab);
        }

        public void OnEventHandler(FileDroppedEventArgs e)
        {
            var firstFile = e.FileDropList[0];
            if (!string.IsNullOrWhiteSpace(firstFile) && File.Exists(firstFile))
            {
                var fileTab = new FileTabViewModel(this);
                fileTab.LoadPath(firstFile);
                this.AddTab(fileTab);
                TabIndex = TabPages.Count - 1;
            }
            else if (!string.IsNullOrWhiteSpace(firstFile) && Directory.Exists(firstFile))
            {
                var dirTab = new DirectoryTabViewModel(this);
                dirTab.LoadPath(firstFile);
                this.AddTab(dirTab);
                TabIndex = TabPages.Count - 1;
            }
        }
    }
}
