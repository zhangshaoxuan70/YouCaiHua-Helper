﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Threading;
using System.Runtime.InteropServices;
using System.Drawing;
using System.Reflection;

namespace youcaihua
{
    internal static class Program
    {

        [DllImport("kernel32.dll", SetLastError = true)]
        internal static extern bool AllocConsole();
        [DllImport("kernel32.dll", SetLastError = true)]
        internal static extern bool FreeConsole();

        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            AppDomain.CurrentDomain.AssemblyResolve += new ResolveEventHandler(CurrentDomain_AssemblyResolve);
            int argnum = args.Length;
            for(int i = 0; i < argnum; i++)
            {
                if (args[i] == "-debug" && Global.debugging==false)
                {
                    Global.debugging = true;
                    AllocConsole();
                    //FreeConsole();
                    Log.Open();
                }
                if (args[i].StartsWith("-mallcode=") && Global.mall_code_set==false)
                {
                    Global.mall_code = args[i].Substring(10);
                    Log.Debug("Get mall code.");
                    
                    Global.mall_code_set = true;
                }
            }

            Log.Debug($"debug={Global.debugging}, mall_code={Global.mall_code}, mall_code_set={Global.mall_code_set}");
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Info.Get_Account("029743", "123456");
            Application.Run(new login_Form());
            //Application.Run(new daily_Form());
        }

        private static System.Reflection.Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
        {
            string resourceName = "youcaihua." + new AssemblyName(args.Name).Name + ".dll";
            using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(resourceName))
            {
                byte[] assemblyData = new byte[stream.Length];
                stream.Read(assemblyData, 0, assemblyData.Length);
                return Assembly.Load(assemblyData);
            }
        }
    }
}
