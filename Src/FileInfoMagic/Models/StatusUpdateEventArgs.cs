using System;

namespace FileInfoMagic.Models
{
    public class StatusUpdateEventArgs : EventArgs
    {
        public string StatusText { get; set; }

        public StatusUpdateEventArgs(string StatusText)
        {
            this.StatusText = StatusText;
        }
    }
}
