using System;
using System.Runtime.CompilerServices;
using W = ConsoleHelperLibrary.Classes.WindowUtility;

// ReSharper disable once CheckNamespace
namespace Demo
{
    partial class Program
    {
        [ModuleInitializer]
        public static void Init()
        {
            Console.Title = "Dictionary code sample";
            W.SetConsoleWindowPosition(W.AnchorWindow.Center);
        }
    }
}





