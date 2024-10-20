using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using DesktopAquarium.Settings;

namespace DesktopAquarium.Fish
{
    public partial class Shark : BaseFish
    {
        public Shark(SharkSettings baseSettings)
            : base(baseSettings)
        {
            SwimLGif = Properties.Resources.SharkSwimL;
            SwimRGif = Properties.Resources.SharkSwimR;
            DragLGif = Properties.Resources.SharkDragL;
            DragRGif = Properties.Resources.SharkDragR;
            DefaultIdleLGif = Properties.Resources.SharkDefaultIdleL;
            DefaultIdleRGif = Properties.Resources.SharkDefaultIdleR;
            IdleLGifs = [Properties.Resources.SharkIdle1L];
            IdleRGifs = [Properties.Resources.SharkIdle1R];
        }
    }
}
