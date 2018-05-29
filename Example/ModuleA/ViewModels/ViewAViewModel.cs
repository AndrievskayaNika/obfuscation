using Prism.Commands;
using Prism.Regions;
using TabControlRegion.Core;
using TabControlRegion.Core.Prism;

namespace ModuleA.ViewModels
{
    public class ViewAViewModel : ViewModelBase, IRegionManagerAware
    {
        public IRegionManager RegionManager { get; set; }

        public DelegateCommand<string> NavigateCommand { get; set; }

        public ViewAViewModel()
        {
            Title = "View A"; 
            NavigateCommand = new DelegateCommand<string>(Navigate);
        }

        void Navigate(string navigationPath)
        {
            RegionManager.RequestNavigate("ChildRegion", navigationPath);
        }
    }
}
