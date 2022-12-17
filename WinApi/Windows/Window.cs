using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using WinApi.pInvoke;

namespace WinApi.Windows
{
    public class Window
    {
        // Pointer num
        public IntPtr Handle { get; }

        // ctor
        public Window(IntPtr handle) => this.Handle = handle;

        #region [Title]

        // Title
        public string Text
        {
            get => GetWindowText();
            set
            {
                if (!SetWindowText(value))
                    ThrowLastWin32Error();
            }
        }

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
                if (selector(window))
                    result.Add(window);
                return true;
            }

            User32.EnumWindows(WindowSelector, IntPtr.Zero);

            return result.ToArray();
        }

        /// <summary> Set window text (title) </summary>
        private bool SetWindowText(string text) => User32.SetWindowText(Handle, text);

        #endregion [Title]

        #region [Geometry]

        public Rectangle Rectangle
        {
            get
            {
                var rect = new RECT();
                if (!User32.GetWindowRect(Handle, ref rect))
                    ThrowLastWin32Error();
                return rect;
            }
            set
            {
                if(!User32.MovieWindow(Handle, value.Left, value.Top, value.Width, value.Height, true))
                    ThrowLastWin32Error();
            }
        }

        public Point Location { get => Rectangle.Location; set => Rectangle = new Rectangle(value, Rectangle.Size); }

        public int X { get => Location.X; set => Location = new Point(value, Location.Y); }

        public int Y { get => Location.Y; set => Location = new Point(Location.X, value); }

        public Size Size { get => Rectangle.Size; set => Rectangle = new Rectangle(Location, value); }

        public int Width { get => Rectangle.Width; set => Size = new Size(value, Height); }

        public int Height { get => Rectangle.Height; set => Size = new Size(Width, value); }

        #endregion

        #region [Error]

        private static void ThrowLastWin32Error() => Marshal.ThrowExceptionForHR(Marshal.GetHRForLastWin32Error());

        #endregion [Error]
    }
}