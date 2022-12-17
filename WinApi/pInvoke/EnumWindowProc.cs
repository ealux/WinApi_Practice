using System;
using System.Runtime.InteropServices;

namespace WinApi.pInvoke
{
    [Serializable]
    [return: MarshalAs(UnmanagedType.Bool)]
    public delegate bool EnumWindowProc(IntPtr hWnd, IntPtr lParam);
}