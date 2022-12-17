using System;
using System.Diagnostics;

namespace ConsoleTests
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var notepad = Process.Start("notepad");


            Console.WriteLine("End.");
            Console.ReadLine();

            notepad.CloseMainWindow();
        }
    }
}