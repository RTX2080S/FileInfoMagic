using FileInfoMagic.Infrastructure.ViewModels;

namespace FileInfoMagic.ViewModels
{
    public class FileTabViewModel : TabBaseViewModel
    {
        public override string TabName => "File";

        public FileTabViewModel(CommonViewModel Parent) : base(Parent)
        {
        }
    }
}
