using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TabControlRegion.Core.Prism
{
    public interface IRegionManagerAware
    {
        IRegionManager RegionManager { get; set; }
    }
}
