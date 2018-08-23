using System;
using System.Collections.Specialized;

namespace FileInfoMagic.Models
{
    public class FileDroppedEventArgs : EventArgs
    {
        public StringCollection FileDropList { get; }

        public FileDroppedEventArgs(StringCollection FileDropList)
        {
            this.FileDropList = FileDropList;
        }
    }
}
