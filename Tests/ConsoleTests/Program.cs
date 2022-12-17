using System;
using System.Diagnostics;
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


            // Take text
            var window = new Window(notepad_process.MainWindowHandle);
            Console.WriteLine("Text: {0}", window.Text);

            // Set text
            window.Text = Console.ReadLine();
            Console.WriteLine("Text now: {0}", window.Text);

            Console.WriteLine("End.");
            Console.ReadLine();

            notepad_process.CloseMainWindow();
        }
    }
}