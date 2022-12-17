using System;

namespace WinApi.pInvoke
{
    /// <summary>Window handles (HWND) used for hWndInsertAfter</summary>
    public static class InsertAfterEnumHWND
    {
        public static readonly IntPtr NoTopMost = new IntPtr(-2);
        public static readonly IntPtr TopMost = new IntPtr(-1);
        public static readonly IntPtr Top = new IntPtr(0);
        public static readonly IntPtr Bottom = new IntPtr(1);
    }
}