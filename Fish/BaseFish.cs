using System.Drawing.Imaging;

using DesktopAquarium.Settings;

namespace DesktopAquarium.Fish
{
    public partial class BaseFish : Form
    {
        private bool _isFacingLeft;
        private bool _isDragging;

        private Point _targetLocation;
        private Point _dragForm;
        private Point _dragCursor;

        private BaseSettings _settings;
        private ImageHelper _imageHelper;
        private MemoryStream? _memoryStream;
        private Random _rand;

        System.Windows.Forms.Timer _moveTimer;
        System.Windows.Forms.Timer _idleTimer;
        System.Windows.Forms.Timer _idleGifStopTimer;


        public byte[] SwimLGif { get; set; }
        public byte[] SwimRGif { get; set; }

        public byte[] DragLGif { get; set; }
        public byte[] DragRGif { get; set; }

        public byte[] DefaultIdleLGif { get; set; }
        public byte[] DefaultIdleRGif { get; set; }

        public List<byte[]> IdleLGifs { get; set; }
        public List<byte[]> IdleRGifs { get; set; }

        public BaseFish(BaseSettings settings)
        {
            InitializeComponent();

            SwimLGif = [];
            SwimRGif = [];
            DragLGif = [];
            DragRGif = [];
            DefaultIdleLGif = [];
            DefaultIdleRGif = [];
            IdleLGifs = [];
            IdleRGifs = [];

            _settings = settings;
            _imageHelper = new ImageHelper();
            _rand = new Random(DateTime.Now.GetHashCode());

            Text = _settings.Name ?? _settings.FishType.ToString();

            _moveTimer = new System.Windows.Forms.Timer() 
            { 
                Interval = _settings.MoveTimerInterval 
            };
            _moveTimer.Tick += MoveTimer_Elapsed;

            _idleTimer = new System.Windows.Forms.Timer() 
            { 
                Interval= _settings.IdleTimerInterval 
            };
            _idleTimer.Tick += IdleTimer_Elapsed;

            _idleGifStopTimer = new System.Windows.Forms.Timer();

            if (_settings.FollowCursor)
                _moveTimer.Start();
            else 
                _idleTimer.Start();

            TopMost = _settings.AlwaysOnTop;

            pbMain.MouseDown += frmMain_MouseDown;
            pbMain.MouseUp += frmMain_MouseUp;
            pbMain.MouseMove += frmMain_MouseMove;
            MouseDown += frmMain_MouseDown;
            MouseUp += frmMain_MouseUp;
            MouseMove += frmMain_MouseMove;
        }

        #region Public Methods

        public void MoveToRandomLocation()
        {
            int newX, newY;

            Rectangle screen = SystemInformation.VirtualScreen;

            if (_settings.PrimaryScreenOnly)
                screen = Screen.PrimaryScreen?.Bounds ?? SystemInformation.VirtualScreen;

            do
            {
                newX = _rand.Next(screen.Left, screen.Right - Width);
                newY = _rand.Next(screen.Top, screen.Bottom - Height);
            }
            while ((Math.Abs(newX - Location.X) < 100 || Math.Abs(newY - Location.Y) < 100)
            && (Math.Abs(newX - Location.X) > 200 || Math.Abs(newY - Location.Y) > 200));

            _targetLocation = new Point(newX, newY);
            if (newX > Location.X)
            {
                if (_isFacingLeft)
                    _isFacingLeft = false;
                pbMain.Image = _imageHelper.LoadImageFromBytes(SwimRGif);
            }
            else
            {
                if (!_isFacingLeft)
                    _isFacingLeft = true;
                pbMain.Image = _imageHelper.LoadImageFromBytes(SwimLGif);
            }

            _idleTimer.Stop();
            _moveTimer.Start();
        }

        public void SetIdleImage(bool onlyDefault)
        {
            var defaultIdle = DefaultIdleLGif;
            var idleList = IdleLGifs;
            if (!_isFacingLeft)
            {
                defaultIdle = DefaultIdleRGif;
                idleList = IdleRGifs;
            }

            if (onlyDefault)
            {
                pbMain.Image = _imageHelper.LoadImageFromBytes(defaultIdle);
            }
            else
            {
                var defaultOrSpecial = _rand.Next(0, 2);
                if (defaultOrSpecial == 0)
                    pbMain.Image = _imageHelper.LoadImageFromBytes(defaultIdle);
                else
                {
                    var chance = 100 / idleList.Count;
                    var img = _rand.Next(0, 100);
                    for (int i = 0; i < idleList.Count; ++i)
                    {
                        if (img <= chance * i)
                        {
                            var gifLength = _imageHelper.GetGifDuration(idleList[i]);
                            _idleGifStopTimer.Interval = gifLength;
                            pbMain.Image = _imageHelper.LoadImageFromBytes(idleList[i]);
                            _idleGifStopTimer.Start();
                            break;
                        }
                    }
                }
            }
        }

        #endregion
        #region Timers

        public void StartIdleTimer()
        {
            if (_idleTimer == null)
                return;
            _idleTimer.Start();
        }

        public void StopIdleTimer()
        {
            if (_idleTimer == null)
                return;
            _idleTimer.Stop();
        }

        public void StartMoveTimer()
        {
            if (_moveTimer == null) 
                return;
            _moveTimer.Start();
        }

        public void StopMoveTimer()
        {
            if (_moveTimer == null)
                return;
            _moveTimer.Stop();
        }

        private void IdleTimer_Elapsed(object? sender, EventArgs e)
        {
            MoveToRandomLocation();
        }

        private void MoveTimer_Elapsed(object? sender, EventArgs e)
        {
            if (_settings.FollowCursor)
            {
                _targetLocation = Cursor.Position;
            }

            int deltaX = _targetLocation.X - Location.X;
            int deltaY = _targetLocation.Y - Location.Y;

            // Move the form 5 pixels closer to the target
            if (Math.Abs(deltaX) > 5 || Math.Abs(deltaY) > 5)
            {
                int moveX = Math.Sign(deltaX) * Math.Min(5, Math.Abs(deltaX));
                int moveY = Math.Sign(deltaY) * Math.Min(5, Math.Abs(deltaY));

                Location = new Point(Location.X + moveX, Location.Y + moveY);
            }
            else
            {
                if (!_settings.FollowCursor)
                {
                    _moveTimer.Stop();
                    SetIdleImage(true);
                    _idleTimer.Start();
                }
            }
        }

        private void IdleGifStopTimer_Elapsed(object? sender, EventArgs e)
        {
            if (_isFacingLeft)
                pbMain.Image = _imageHelper.LoadImageFromBytes(DefaultIdleLGif);
            else
                pbMain.Image = _imageHelper.LoadImageFromBytes(DefaultIdleRGif);

            if (_idleGifStopTimer.Interval <= _settings.IdleTimerInterval)
            {
                _idleTimer.Interval = _settings.IdleTimerInterval - _idleGifStopTimer.Interval;
                _idleTimer.Start();
            }
            else
            {
                _moveTimer.Start();
            }
        }

        #endregion
        #region Events

        public void KillFish_Raised(object? sender, KillFishEventArgs e)
        {
            if (e.FishID != _settings.FishID)
                return;

            _moveTimer.Stop();
            _idleGifStopTimer.Stop();
            _idleTimer.Stop();
            Close();
            Dispose();
        }

        private void frmMain_MouseDown(object? sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                _moveTimer.Stop();
                _idleTimer.Stop();
                if (_isFacingLeft)
                    pbMain.Image = _imageHelper.LoadImageFromBytes(DragLGif);
                else
                    pbMain.Image = _imageHelper.LoadImageFromBytes(DragRGif);
                
                _isDragging = true;
                _dragCursor = Cursor.Position;
                _dragForm = Location;
            }
        }

        private void frmMain_MouseMove(object? sender, MouseEventArgs e)
        {
            if (_isDragging)
            {
                Point dif = Point.Subtract(Cursor.Position, new Size(_dragCursor));
                Location = Point.Add(_dragForm, new Size(dif));
            }
        }

        private void frmMain_MouseUp(object? sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                _isDragging = false;
                SetIdleImage(true);
                if (_settings?.FollowCursor ?? false)
                    _moveTimer.Start();
                else
                    _idleTimer.Start();
            }
        }

        #endregion
    }
}
