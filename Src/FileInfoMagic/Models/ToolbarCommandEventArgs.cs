using System;

namespace FileInfoMagic.Models
{
    public class ToolbarCommandEventArgs : EventArgs
    {
        public ToolbarCommand Command { get; set; }

        public ToolbarCommandEventArgs(ToolbarCommand Command)
        {
            this.Command = Command;
        }
    }
}
