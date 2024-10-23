﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopAquarium.Settings
{
    public class BaseSettings
    {
        public int FishID { get; set; }
        public int MoveTimerInterval { get; set; }
        public int IdleTimerInterval { get; set; }
        public bool AlwaysOnTop { get; set; }
        public bool FollowCursor { get; set; }
        public bool PrimaryScreenOnly { get; set; }
        public FishType FishType { get; set; }
        public string? Name { get; set; }

        private const int DefaultMoveTimerInterval = 20;
        private const int DefaultIdleTimerInterval = 3000;

        public BaseSettings()
        {
            MoveTimerInterval = DefaultMoveTimerInterval;
            IdleTimerInterval = DefaultIdleTimerInterval;
        }
    }
}