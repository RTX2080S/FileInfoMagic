using FileInfoMagic.Infrastructure.ViewModels;

namespace FileInfoMagic.ViewModels
{
    public class FileTabViewModel : TabBaseViewModel
    {
        public static FileTabViewModel Create(CommonViewModel Parent)
        {
            return new FileTabViewModel(Parent);
        }

        public override string TabName => "File";

        public FileTabViewModel(CommonViewModel Parent) : base(Parent)
        {
        }
    }
}
