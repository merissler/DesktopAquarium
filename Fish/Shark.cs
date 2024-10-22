using DesktopAquarium.Settings;

namespace DesktopAquarium.Fish
{
    public partial class Shark : BaseFish
    {
        private bool _isChasing;

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
            Icon = ImageHelper.LoadIconFromBytes(Properties.Resources.SharkIcon);
        }

        public override void MoveTimer_Elapsed(object? sender, EventArgs e)
        {
            var chance = Rand.Next(0, 20);
            if (chance == 17 && !_isChasing)
            {
                _isChasing = true;
                TargetLocation = Cursor.Position;
                if (IsFacingLeft)
                    PbMain.Image = ImageHelper.LoadImageFromBytes(Properties.Resources.SharkChaseL);
                else
                    PbMain.Image = ImageHelper.LoadImageFromBytes(Properties.Resources.SharkChaseR);
                
                base.MoveTimer_Elapsed(sender, e);
            }
            else
            {
                if (_isChasing)
                {
                    TargetLocation = Cursor.Position;
                    int deltaX = TargetLocation.X - Location.X;
                    int deltaY = TargetLocation.Y - Location.Y;
                    if (deltaX < 5 && deltaY < 5)
                    {
                        SetIdleImage(false);
                        _isChasing = false;
                    }
                }
                base.MoveTimer_Elapsed(sender, e);
            }
        }
    }
}
