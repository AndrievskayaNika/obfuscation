using System.Windows;
using Prism.Modularity;
using Prism.Mvvm;
using Prism.Unity;
using Microsoft.Practices.Unity;
using ModuleA;
using TabControlRegion.Views;
using Prism.Regions;
using TabControlRegion.Core.Prism;

namespace TabControlRegion
{
    public class Bootstrapper : UnityBootstrapper
    {
        protected override DependencyObject CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void InitializeShell()
        {
            Application.Current.MainWindow.Show();
        }

        protected override void ConfigureModuleCatalog()
        {
            ModuleCatalog catalog = (ModuleCatalog)ModuleCatalog;
            catalog.AddModule(typeof(ModuleAModule));
        }

        protected override void ConfigureContainer()
        {
            base.ConfigureContainer();
            ViewModelLocationProvider.SetDefaultViewModelFactory((type) => Container.Resolve(type));

            Container.RegisterType<IRegionNavigationContentLoader, ScopedRegionNavigationContentLoader>(new ContainerControlledLifetimeManager());
        }

        protected override IRegionBehaviorFactory ConfigureDefaultRegionBehaviors()
        {
            IRegionBehaviorFactory behaviors = base.ConfigureDefaultRegionBehaviors();
            behaviors.AddIfMissing(RegionManagerAwareBehavior.BehaviorKey, typeof(RegionManagerAwareBehavior));
            return behaviors;
        }
    }
}
