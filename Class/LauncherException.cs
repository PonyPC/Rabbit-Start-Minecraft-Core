﻿using SquareMinecraftLauncher.Core;
using System;
namespace FastX.Core
{
    public sealed class LauncherException : Exception
    {
        public LauncherException(string message) : base(message)
        {
            SquareMinecraftLauncherCore core = new SquareMinecraftLauncherCore();
            core.SetFile("SquareMinecraftLauncher");
            //string file = null;
            //if (core.FileExist(@"SquareMinecraftLauncher\Error.Log") == null)
            //{
            //    file = core.GetFile(@"SquareMinecraftLauncher\Error.Log");
            //    core.wj(@"SquareMinecraftLauncher\Error.Log", file + "\n[" + DateTime.Now.ToString() + "] " + message);
            //}
            //else
            //{
            //    core.wj(@"SquareMinecraftLauncher\Error.Log", "[" + DateTime.Now.ToString() + "] " + message);
            //}
        }
    }
}

