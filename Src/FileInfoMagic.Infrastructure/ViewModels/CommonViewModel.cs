using Alienlab.Practices.Utilities;
using Alienlab.WPF.ViewModels;
using Unity;

namespace FileInfoMagic.Infrastructure.ViewModels
{
    public abstract class CommonViewModel : ViewModelBase
    {
        protected readonly IEventAggregator eventAggregator;

        protected CommonViewModel()
        {
            eventAggregator = UnityConfig.Container.Resolve<IEventAggregator>();
            eventAggregator.SubscribeEvent(this);
        }
    }
}
