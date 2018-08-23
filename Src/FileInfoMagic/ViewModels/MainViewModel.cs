using FileInfoMagic.Infrastructure.ViewModels;

namespace FileInfoMagic.ViewModels
{
    public class MainViewModel : CommonViewModel
    {
        private int tabIndex;

        public int TabIndex
        {
            get
            {
                return tabIndex;
            }
            set
            {
                tabIndex = value;
                OnPropertyChanged(nameof(TabIndex));
            }
        }
    }
}
