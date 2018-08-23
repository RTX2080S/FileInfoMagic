using Alienlab.Framework.Design;
using Alienlab.WPF.Helpers;
using Alienlab.WPF.ViewModels;
using FileInfoMagic.Infrastructure;
using FileInfoMagic.Services.Interfaces;
using System.Windows.Input;
using Unity;

namespace FileInfoMagic.ViewModels
{
    public abstract class TabBaseViewModel : ViewModelBase
    {
        private readonly IServiceFactory<IDialogService> dialogServiceFactory;

        private readonly IDialogService dialogService;

        public abstract string TabName { get; }

        public TabBaseViewModel()
        {
            dialogServiceFactory = UnityConfig.Container.Resolve<IServiceFactory<IDialogService>>();
            dialogService = dialogServiceFactory.Resolve(this.TabName);
        }

        private string targetPath;

        public string TargetPath
        {
            get
            {
                return targetPath;
            }
            set
            {
                targetPath = value;
                OnPropertyChanged(nameof(TargetPath));
            }
        }

        private ICommand browseCommand;

        private void executeBrowseCommand()
        {
            TargetPath = dialogService.BrowsePath();
        }

        public ICommand BrowseCommand
        {
            get
            {
                browseCommand = browseCommand ?? new RelayCommand(param => executeBrowseCommand(), param => true);
                return browseCommand;
            }
        }
    }
}
