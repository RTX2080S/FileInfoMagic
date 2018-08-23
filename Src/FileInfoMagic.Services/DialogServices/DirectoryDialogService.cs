using FileInfoMagic.Services.Interfaces;
using System.Windows.Forms;

namespace FileInfoMagic.Services.DialogServices
{
    public class DirectoryDialogService : IDialogService
    {
        public string BrowsePath()
        {
            using (FolderBrowserDialog openDialog = new FolderBrowserDialog())
            {
                openDialog.Description = "Browse Folder";
                openDialog.ShowDialog();
                return openDialog.SelectedPath;
            }
        }
    }
}
