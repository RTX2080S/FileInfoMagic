using Alienlab.Framework.Design;
using FileInfoMagic.Services.EditorServices;
using FileInfoMagic.Services.Interfaces;

namespace FileInfoMagic.Infrastructure.Factories
{
    public class EditorServiceFactory : ServiceFactoryBase<IEditorService>, IServiceFactory<IEditorService>
    {
        public EditorServiceFactory()
        {
            base.Register("File", typeof(FileInfoEditorService));
            base.Register("Directory", typeof(DirectoryInfoEditorService));
        }
    }
}
