using Alienlab.Framework.Design;
using Alienlab.WPF.Helpers;
using FileInfoMagic.Infrastructure;
using FileInfoMagic.Services.Interfaces;
using FileInfoMagic.Infrastructure.ViewModels;
using System;
using System.IO;
using System.Windows;
using System.Windows.Input;
using WinForm = System.Windows.Forms;
using Unity;
using FileInfoMagic.Models;

namespace FileInfoMagic.ViewModels
{
    public abstract class TabBaseViewModel : CommonViewModel
    {
        private readonly IServiceFactory<IDialogService> dialogServiceFactory;

        private readonly IServiceFactory<IEditorService> editorServiceFactory;

        private readonly IDialogService dialogService;

        private readonly IEditorService editorService;

        public CommonViewModel ParentViewModel { get; }

        public TabBaseViewModel(CommonViewModel Parent)
        {
            this.ParentViewModel = Parent;
            dialogServiceFactory = UnityConfig.Container.Resolve<IServiceFactory<IDialogService>>();
            editorServiceFactory = UnityConfig.Container.Resolve<IServiceFactory<IEditorService>>();
            dialogService = dialogServiceFactory.Resolve(this.TabName);
            editorService = editorServiceFactory.Resolve(this.TabName);
        }

        public abstract string TabName { get; }

        private string tabHeader;

        public string TabHeader
        {
            get
            {
                var header = string.IsNullOrWhiteSpace(tabHeader) ? TabName : tabHeader;
                return header;
            }
            set
            {
                tabHeader = value;
                OnPropertyChanged(nameof(TabHeader));
            }
        }

        public string PathLabel => $"{TabName} Path";

        public string CurrentPath { get; set; }

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
            this.Browse();
        }

        public ICommand BrowseCommand
        {
            get
            {
                browseCommand = browseCommand ?? new RelayCommand(param => executeBrowseCommand(), param => true);
                return browseCommand;
            }
        }

        public void Browse()
        {
            var selectedPath = dialogService.BrowsePath();
            this.LoadPath(selectedPath);
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

        public void LoadPath(string selectedPath)
        {
            if (!string.IsNullOrWhiteSpace(selectedPath) && editorService.Exists(selectedPath))
            {
                CurrentPath = selectedPath;
                TargetPath = selectedPath;
                CreatedDateTime = editorService.GetCreationTime(selectedPath).ToString();
                ModifiedDateTime = editorService.GetLastWriteTime(selectedPath).ToString();
                AccessedDateTime = editorService.GetLastAccessTime(selectedPath).ToString();
                TabHeader = $"{Path.GetFileName(selectedPath)}";
                eventAggregator.PublishEvent(new StatusUpdateEventArgs("Loaded"));
            }
        }

        private ICommand saveCommand;

        private void executeSaveCommand()
        {
            this.Save(true);
        }

        public ICommand SaveCommand
        {
            get
            {
                saveCommand = saveCommand ?? new RelayCommand(param => executeSaveCommand());
                return saveCommand;
            }
        }

        public void Save(bool showPrompt = false)
        {
            this.SavePath(CurrentPath, showPrompt);
        }

        protected void SavePath(string selectedPath, bool showPrompt)
        {
            if (!string.IsNullOrWhiteSpace(selectedPath) && editorService.Exists(selectedPath))
            {
                try
                {
                    if (DateTime.TryParse(CreatedDateTime, out DateTime creationTime))
                        editorService.SetCreationTime(selectedPath, creationTime);
                    if (DateTime.TryParse(ModifiedDateTime, out DateTime modifiedTime))
                        editorService.SetLastWriteTime(selectedPath, modifiedTime);
                    if (DateTime.TryParse(AccessedDateTime, out DateTime accessedTime))
                        editorService.SetLastAccessTime(selectedPath, accessedTime);

                    eventAggregator.PublishEvent(new StatusUpdateEventArgs("Saved"));
                    if (showPrompt)
                        MessageBox.Show($"Changes saved to {TabName} {selectedPath}.",
                            WinForm.Application.ProductName, MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception ex)
                {
                    eventAggregator.PublishEvent(new StatusUpdateEventArgs("Error"));
                    if (showPrompt)
                        MessageBox.Show($"Error while saving to {selectedPath}.\n{ex.Message}",
                            WinForm.Application.ProductName, MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private ICommand closeCommand;

        private void executeCloseCommand()
        {
            var parentVM = this.ParentViewModel as MainViewModel;
            parentVM.RemoveTab(this);
        }

        public ICommand CloseCommand
        {
            get
            {
                closeCommand = closeCommand ?? new RelayCommand(param => executeCloseCommand());
                return closeCommand;
            }
        }
    }
}
