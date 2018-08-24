using Alienlab.Practices.Utilities;
using FileInfoMagic.Infrastructure.ViewModels;
using FileInfoMagic.Models;

namespace FileInfoMagic.ViewModels
{
    public class StatusBarViewModel : CommonViewModel, ISubscriber<StatusUpdateEventArgs>
    {
        private string statusText;

        public string StatusText
        {
            get
            {
                return statusText;
            }
            set
            {
                statusText = value;
                OnPropertyChanged(nameof(StatusText));
            }
        }

        public void OnEventHandler(StatusUpdateEventArgs e)
        {
            StatusText = e.StatusText;
        }
    }
}
