﻿namespace SquareMinecraftLauncher.Core
{
    using System;
    using System.Net.NetworkInformation;
    using System.Runtime.InteropServices;

    public sealed class ping
    {
        private const int INTERNET_CONNECTION_LAN = 2;
        private const int INTERNET_CONNECTION_MODEM = 1;

        public static bool CheckServeStatus()
        {
            if (!LocalConnectionStatus())
            {
                Console.WriteLine("网络异常~无连接");
                return false;
            }
            Console.WriteLine("网络正常");
            return true;
        }

        [DllImport("winInet.dll")]
        private static extern bool InternetGetConnectedState(ref int dwFlag, int dwReserved);
        private static bool LocalConnectionStatus()
        {
            int dwFlag = 0;
            if (!InternetGetConnectedState(ref dwFlag, 0))
            {
                Console.WriteLine("LocalConnectionStatus--未连网!");
                return false;
            }
            if ((dwFlag & 1) != 0)
            {
                Console.WriteLine("LocalConnectionStatus--采用调制解调器上网。");
                return true;
            }
            if ((dwFlag & 2) != 0)
            {
                Console.WriteLine("LocalConnectionStatus--采用网卡上网。");
                return true;
            }
            return false;
        }

        public static bool MyPing(string[] urls, out int errorCount)
        {
            bool flag = true;
            Ping ping = new Ping();
            errorCount = 0;
            try
            {
                for (int i = 0; i < urls.Length; i++)
                {
                    PingReply reply = ping.Send(urls[i]);
                    if (reply.Status != IPStatus.Success)
                    {
                        flag = false;
                        errorCount++;
                    }
                    Console.WriteLine("Ping " + urls[i] + "    " + reply.Status.ToString());
                }
            }
            catch
            {
                flag = false;
                errorCount = urls.Length;
            }
            return flag;
        }
    }
}

