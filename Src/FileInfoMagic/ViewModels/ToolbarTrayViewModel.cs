using System.Windows;
using System.Windows.Input;
using System.Text;
using WinForm = System.Windows.Forms;
using Alienlab.WPF.Helpers;
using FileInfoMagic.Infrastructure.ViewModels;
using FileInfoMagic.Models;

namespace FileInfoMagic.ViewModels
{
    public class ToolbarTrayViewModel : CommonViewModel
    {
        private ICommand newCommand;

        private void executeNewCommand()
        {
            eventAggregator.PublishEvent(new ToolbarCommandEventArgs(ToolbarCommand.New));
        }

        public ICommand NewCommand
        {
            get
            {
                newCommand = newCommand ?? new RelayCommand(param => executeNewCommand());
                return newCommand;
            }
        }

        private ICommand openCommand;

        private void executeOpenCommand()
        {
            eventAggregator.PublishEvent(new ToolbarCommandEventArgs(ToolbarCommand.Open));
        }

        public ICommand OpenCommand
        {
            get
            {
                openCommand = openCommand ?? new RelayCommand(param => executeOpenCommand());
                return openCommand;
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

        private ICommand saveAllCommand;

        private void executeSaveAllCommand()
        {
            eventAggregator.PublishEvent(new ToolbarCommandEventArgs(ToolbarCommand.SaveAll));
        }

        public ICommand SaveAllCommand
        {
            get
            {
                saveAllCommand = saveAllCommand ?? new RelayCommand(param => executeSaveAllCommand());
                return saveAllCommand;
            }
        }

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
