using FileInfoMagic.Services.Interfaces;
using System.Windows.Forms;

namespace FileInfoMagic.Services
{
    public class FileDialogService : IDialogService
    {
        public string BrowsePath()
        {
            using (OpenFileDialog openDialog = new OpenFileDialog())
            {
                openDialog.Filter = "All Files (*.*)|*.*";
                openDialog.Title = "Browse File";
                openDialog.ShowDialog();
                return openDialog.FileName;
            }
        }
    }
}
