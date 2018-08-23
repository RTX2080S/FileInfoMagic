using FileInfoMagic.Services.Interfaces;

namespace FileInfoMagic.Services
{
    public class DirectoryDialogService : IDialogService
    {
        public string BrowsePath()
        {
            return "Dir";
        }
    }
}
