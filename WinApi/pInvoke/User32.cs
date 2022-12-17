using System;
using System.Runtime.InteropServices;
using System.Text;

namespace WinApi.pInvoke
{
    public static class User32
    {
        public const string FileName = "user32.dll";

        /// <summary> Enumerate system windows </summary>
        [DllImport(FileName, SetLastError = true)]
        public static extern int EnumWindows(EnumWindowProc hWnd, IntPtr lParam);

        #region [Text]

        #region [Getters]

        /// <summary>
        /// Get Window Text (title)
        /// </summary>
        /// <param name="hWnd">Window descriptor</param>
        /// <param name="lpString">Text</param>
        /// <param name="nMaxCount">Symbols count</param>
        /// <returns></returns>
        [DllImport(FileName, CharSet = CharSet.Auto, SetLastError = true)]
        public static extern int GetWindowText(IntPtr hWnd, StringBuilder lpString, uint nMaxCount);

        /// <summary>
        /// Get count of Window Text (title) symbols
        /// </summary>
        /// <param name="hWnd">Window descriptor</param>
        /// <returns></returns>
        [DllImport(FileName, CharSet = CharSet.Auto, SetLastError = true)]
        public static extern int GetWindowTextLength(IntPtr hWnd);

        #endregion [Getters]

        #region [Setters]

        /// <summary>
        /// Set Window text
        /// </summary>
        /// <param name="hWnd">Window descriptor</param>
        /// <param name="lpString">Text</param>
        /// <returns>True if text replaced</returns>
        [DllImport(FileName, SetLastError = true)]
        public static extern bool SetWindowText(IntPtr hWnd, string lpString);

        #endregion [Setters]

        #endregion [Text]

        #region [Geometry]

        [DllImport(FileName, SetLastError = true)]
        public static extern bool GetWindowRect(IntPtr hWnd, ref RECT lpRect);

        [DllImport(FileName, SetLastError = true)]
        public static extern bool MoveWindow(IntPtr hWnd, int X, int Y, int nWidth, int nHeight, bool bRepaint);

        #endregion [Geometry]

        #region [Messages]

        /// <summary>
        /// Send message to the window
        /// </summary>
        /// <param name="hWnd">Descriptor</param>
        /// <param name="Msg">Message</param>
        /// <param name="wParam">Major parameter</param>
        /// <param name="lParam">Minor parameter</param>
        [DllImport(FileName, CharSet = CharSet.Auto, SetLastError = true)]
        public static extern IntPtr SendMessage(IntPtr hWnd, WM Msg, IntPtr wParam, IntPtr lParam);

        /// <summary>
        /// Async SendMessage
        /// </summary>
        [DllImport(FileName, CharSet = CharSet.Auto, SetLastError = true)]
        public static extern IntPtr PostMessage(IntPtr hWnd, WM Msg, IntPtr wParam, IntPtr lParam);

        #endregion [Messages]

        #region [Behavior]

        [DllImport(FileName, SetLastError = true)]
        public static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, SetWindowPosFlags uFlags);

        #endregion [Behavior]
    }
}