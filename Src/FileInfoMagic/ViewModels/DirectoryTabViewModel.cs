using FileInfoMagic.Infrastructure.ViewModels;

namespace FileInfoMagic.ViewModels
{
    public class DirectoryTabViewModel : TabBaseViewModel
    {
        public static DirectoryTabViewModel Create(CommonViewModel Parent)
        {
            return new DirectoryTabViewModel(Parent);
        }

        public override string TabName => "Directory";

        public DirectoryTabViewModel(CommonViewModel Parent) : base(Parent)
        {
        }
    }
}
