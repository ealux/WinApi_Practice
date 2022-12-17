﻿using System;
using System.Runtime.InteropServices;
using System.Text;

namespace WinApi.pInvoke
{
    public static class User32
    {
        public const string FileName = "user32.dll";

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

        /// <summary>
        /// Enumerate system windows
        /// </summary>
        [DllImport(FileName, SetLastError = true)]
        public static extern int EnumWindows(EnumWindowProc hWnd, IntPtr lParam);
    }
}