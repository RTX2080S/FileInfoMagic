using Alienlab.WPF.Helpers;
using FileInfoMagic.Infrastructure.ViewModels;
using FileInfoMagic.Models;
using System.Windows;
using System.Windows.Input;
using WinForm = System.Windows.Forms;

namespace FileInfoMagic.ViewModels
{
    public class MainWindowViewModel : CommonViewModel
    {
        public string WindowTitle => $"{WinForm.Application.ProductName} [Version {WinForm.Application.ProductVersion}]";

        public void OnWindowLoaded()
        {
            eventAggregator.PublishEvent(new StatusUpdateEventArgs("Ready"));
        }

        public void OnFileDropped(DataObject dataObject)
        {
            if (dataObject.ContainsFileDropList())
            {
                var droppedFiles = dataObject.GetFileDropList();
                eventAggregator.PublishEvent(new FileDroppedEventArgs(droppedFiles));
            }
        }

        private ICommand saveCommand;

        private void executeSaveCommand()
        {
            eventAggregator.PublishEvent(new ToolbarCommandEventArgs(ToolbarCommand.Save));
        }

        public ICommand SaveCommand
        {
            get
            {
                saveCommand = saveCommand ?? new RelayCommand(param => executeSaveCommand());
                return saveCommand;
            }
        }
    }
}
