using FileInfoMagic.Infrastructure.ViewModels;
using FileInfoMagic.Models;
using System.Windows;
using WinForm = System.Windows.Forms;

namespace FileInfoMagic.ViewModels
{
    public class MainWindowViewModel : CommonViewModel
    {
        public string WindowTitle => $"{WinForm.Application.ProductName} [Version {WinForm.Application.ProductVersion}]";

        public void OnFileDropped(DataObject dataObject)
        {
            if (dataObject.ContainsFileDropList())
            {
                var droppedFiles = dataObject.GetFileDropList();
                eventAggregator.PublishEvent(new FileDroppedEventArgs(droppedFiles));
            }
        }
    }
}
