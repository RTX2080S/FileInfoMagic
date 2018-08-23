using Alienlab.WPF.ViewModels;
using WinForm = System.Windows.Forms;

namespace FileInfoMagic.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public string WindowTitle => $"{WinForm.Application.ProductName} [Version {WinForm.Application.ProductVersion}]";
    }
}
