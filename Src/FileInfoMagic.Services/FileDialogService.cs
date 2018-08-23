using FileInfoMagic.Services.Interfaces;

namespace FileInfoMagic.Services
{
    public class FileDialogService : IDialogService
    {
        public string BrowsePath()
        {
            return "File";
        }
    }
}
