﻿using System;
using System.Runtime.InteropServices;

namespace MMPinger
{
    // Binding to User32 functions.
    internal static class User32
    {
        public  const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
    }
}
