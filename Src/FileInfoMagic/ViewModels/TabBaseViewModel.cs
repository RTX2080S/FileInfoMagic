using Alienlab.Framework.Design;
using Alienlab.WPF.Helpers;
using FileInfoMagic.Infrastructure;
using FileInfoMagic.Services.Interfaces;
using FileInfoMagic.Infrastructure.ViewModels;
using System;
using System.Windows;
using System.Windows.Input;
using WinForm = System.Windows.Forms;
using Unity;

namespace FileInfoMagic.ViewModels
{
    public abstract class TabBaseViewModel : CommonViewModel
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

        public string PathLabel => $"{TabName} Path";

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

        private string createdDateTime;

        public string CreatedDateTime
        {
            get
            {
                return createdDateTime;
            }
            set
            {
                createdDateTime = value;
                OnPropertyChanged(nameof(CreatedDateTime));
            }
        }

        private string modifiedDateTime;

        public string ModifiedDateTime
        {
            get
            {
                return modifiedDateTime;
            }
            set
            {
                modifiedDateTime = value;
                OnPropertyChanged(nameof(ModifiedDateTime));
            }
        }

        private string accessedDateTime;

        public string AccessedDateTime
        {
            get
            {
                return accessedDateTime;
            }
            set
            {
                accessedDateTime = value;
                OnPropertyChanged(nameof(AccessedDateTime));
            }
        }

        private ICommand browseCommand;

        private void executeBrowseCommand()
        {
            var selectedPath = dialogService.BrowsePath();
            this.LoadPath(selectedPath);
        }

        public ICommand BrowseCommand
        {
            get
            {
                browseCommand = browseCommand ?? new RelayCommand(param => executeBrowseCommand(), param => true);
                return browseCommand;
            }
        }

        private ICommand loadCommand;

        private void executeLoadCommand()
        {
            this.LoadPath(TargetPath);
        }

        public ICommand LoadCommand
        {
            get
            {
                loadCommand = loadCommand ?? new RelayCommand(param => executeLoadCommand(), param => true);
                return loadCommand;
            }
        }

        protected void LoadPath(string selectedPath)
        {
            if (!string.IsNullOrWhiteSpace(selectedPath) && editorService.Exists(selectedPath))
            {
                TargetPath = selectedPath;
                CreatedDateTime = editorService.GetCreationTime(selectedPath).ToString();
                ModifiedDateTime = editorService.GetLastWriteTime(selectedPath).ToString();
                AccessedDateTime = editorService.GetLastAccessTime(selectedPath).ToString();
            }
        }

        private ICommand saveCommand;

        private void executeSaveCommand()
        {
            this.SavePath(TargetPath);
        }

        public ICommand SaveCommand
        {
            get
            {
                saveCommand = saveCommand ?? new RelayCommand(param => executeSaveCommand());
                return saveCommand;
            }
        }

        protected void SavePath(string selectedPath)
        {
            if (!string.IsNullOrWhiteSpace(selectedPath) && editorService.Exists(selectedPath))
            {
                if (DateTime.TryParse(CreatedDateTime, out DateTime creationTime))
                    editorService.SetCreationTime(selectedPath, creationTime);
                if (DateTime.TryParse(ModifiedDateTime, out DateTime modifiedTime))
                    editorService.SetLastWriteTime(selectedPath, modifiedTime);
                if (DateTime.TryParse(AccessedDateTime, out DateTime accessedTime))
                    editorService.SetLastAccessTime(selectedPath, accessedTime);
                MessageBox.Show($"Saved to {selectedPath}.", WinForm.Application.ProductName, MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}
