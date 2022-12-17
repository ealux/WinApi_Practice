using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using WinApi.pInvoke;

namespace WinApi.Windows
{
    public class Window
    {
        // Pointer num
        public IntPtr Handle { get; }

        // Title
        public string Text
        {
            get => GetWindowText();
            set
            {                
                if (!SetWindowText(value))
                    Marshal.ThrowExceptionForHR(Marshal.GetHRForLastWin32Error()); // Throw if error
            }
        }

        // ctor
        public Window(IntPtr handle) => this.Handle = handle;

        /// <summary> Return text of handled window </summary>
        private string GetWindowText()
        {
            var buffer = new StringBuilder(User32.GetWindowTextLength(Handle) + 1);
            if (buffer.Capacity > 0)
                User32.GetWindowText(Handle, buffer, (uint)buffer.Capacity);
            return buffer.ToString();
        }

        /// <summary>
        /// Find window by selector
        /// </summary>
        /// <param name="selector">Func to find Window</param>
        public static Window[] FindWindows(Func<Window, bool> selector)
        {
            var result = new List<Window>();

            // Enumerate windows
            bool WindowSelector(IntPtr hWnd, IntPtr lParam)
            {
                var window = new Window(hWnd);
                if(selector(window))
                    result.Add(window);
                return true;
            }

            User32.EnumWindows(WindowSelector, IntPtr.Zero);

            return result.ToArray();
        }

        /// <summary> Set window text (title) </summary>
        private bool SetWindowText(string text) => User32.SetWindowText(Handle, text);
    }
}