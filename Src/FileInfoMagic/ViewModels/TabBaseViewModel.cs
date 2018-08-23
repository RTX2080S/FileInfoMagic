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

        private readonly IServiceFactory<IEditorService> editorServiceFactory;

        private readonly IDialogService dialogService;

        private readonly IEditorService editorService;

        public TabBaseViewModel()
        {
            dialogServiceFactory = UnityConfig.Container.Resolve<IServiceFactory<IDialogService>>();
            editorServiceFactory = UnityConfig.Container.Resolve<IServiceFactory<IEditorService>>();
            dialogService = dialogServiceFactory.Resolve(this.TabName);
            editorService = editorServiceFactory.Resolve(this.TabName);
        }

        public abstract string TabName { get; }

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
