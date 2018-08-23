using System;

namespace FileInfoMagic.Services.Interfaces
{
    public interface IEditorService
    {
        bool Exists(string path);
        DateTime GetCreationTime(string path);
        DateTime GetLastAccessTime(string path);
        DateTime GetLastWriteTime(string path);
        void SetCreationTime(string path, DateTime creationTime);
        void SetLastAccessTime(string path, DateTime lastAccessTime);
        void SetLastWriteTime(string path, DateTime lastWriteTime);
    }
}
