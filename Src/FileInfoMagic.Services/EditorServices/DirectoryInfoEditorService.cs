using FileInfoMagic.Services.Interfaces;
using System;
using System.IO;

namespace FileInfoMagic.Services.EditorServices
{
    public class DirectoryInfoEditorService : IEditorService
    {
        public DateTime GetCreationTime(string path)
        {
            return Directory.GetCreationTime(path);
        }

        public DateTime GetLastAccessTime(string path)
        {
            return Directory.GetLastAccessTime(path);
        }

        public DateTime GetLastWriteTime(string path)
        {
            return Directory.GetLastWriteTime(path);
        }

        public void SetCreationTime(string path, DateTime creationTime)
        {
            Directory.SetCreationTime(path, creationTime);
        }

        public void SetLastAccessTime(string path, DateTime lastAccessTime)
        {
            Directory.SetLastAccessTime(path, lastAccessTime);
        }

        public void SetLastWriteTime(string path, DateTime lastWriteTime)
        {
            Directory.SetLastWriteTime(path, lastWriteTime);
        }
    }
}
