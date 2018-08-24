using System.Windows;
using System.Windows.Input;
using WinForm = System.Windows.Forms;
using Alienlab.WPF.Helpers;
using FileInfoMagic.Infrastructure.ViewModels;
using System.Text;

namespace FileInfoMagic.ViewModels
{
    public class ToolbarTrayViewModel : CommonViewModel
    {
        private ICommand aboutCommand;

        private void executeAboutCommand()
        {
            var aboutContent = new StringBuilder();
            aboutContent.AppendLine($"{WinForm.Application.CompanyName} {WinForm.Application.ProductName}");
            aboutContent.AppendLine($"Version {WinForm.Application.ProductVersion}");
            aboutContent.AppendLine($"By {WinForm.Application.CompanyName}");
            aboutContent.AppendLine("All rights reserved.");
            MessageBox.Show($"{aboutContent.ToString()}", $"About {WinForm.Application.ProductName}",
                MessageBoxButton.OK, MessageBoxImage.Information);
        }

        public ICommand AboutCommand
        {
            get
            {
                aboutCommand = aboutCommand ?? new RelayCommand(param => executeAboutCommand());
                return aboutCommand;
            }
        }
    }
}
