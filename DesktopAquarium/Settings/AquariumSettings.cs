using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopAquarium.Settings
{
    public class AquariumSettings
    {
        public List<BaseSettings> FishList { get; set; }

        public AquariumSettings()
        {
            FishList = [];
        }
    }
}
