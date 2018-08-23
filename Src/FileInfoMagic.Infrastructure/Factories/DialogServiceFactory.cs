using Alienlab.Framework.Design;
using FileInfoMagic.Services.DialogServices;
using FileInfoMagic.Services.Interfaces;

namespace FileInfoMagic.Infrastructure.Factories
{
    public class DialogServiceFactory : ServiceFactoryBase<IDialogService>, IServiceFactory<IDialogService>
    {
        public DialogServiceFactory()
        {
            base.Register("File", typeof(FileDialogService));
            base.Register("Directory", typeof(DirectoryDialogService));
        }
    }
}
