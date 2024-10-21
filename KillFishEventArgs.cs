using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopAquarium
{
    public class KillFishEventArgs : EventArgs
    {
        public int FishID { get; set; }
        public KillFishEventArgs(int fishID)
        {
            FishID = fishID;
        }
    }
}
