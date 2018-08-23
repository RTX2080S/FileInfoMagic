using FileInfoMagic.Infrastructure.ViewModels;

namespace FileInfoMagic.ViewModels
{
    public class DirectoryTabViewModel : TabBaseViewModel
    {
        public override string TabName => "Directory";

        public DirectoryTabViewModel(CommonViewModel Parent) : base(Parent)
        {
        }
    }
}
