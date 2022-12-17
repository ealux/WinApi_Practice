using System;
using System.Diagnostics;
using System.Threading;
using WinApi.Windows;

namespace ConsoleTests
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var notepad_process = Process.Start("notepad");

            Console.WriteLine("Wait...");
            Console.ReadLine();

            var window = new Window(notepad_process.MainWindowHandle);
            Console.WriteLine("Text = {0}", window.Text);
            Console.WriteLine("Location = {0}", window.Rectangle);

            //for(var x = window.X; x < 1236; x += 10)
            //{
            //    window.X = x;
            //    Thread.Sleep(100);
            //}

            //Console.ReadLine();
            //window.Close(); 

            window.SetTopMost(false);

            Console.WriteLine("End.");
            Console.ReadLine();

            notepad_process.CloseMainWindow();
        }
    }
}