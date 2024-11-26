using Newtonsoft.Json;
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
            bool is_debug = false;
            string mall_code = "";
            bool get_mall_code = false;
            bool is_formtest = false;
            foreach(string arg in args)
            {
                if (arg == "-debug" && !is_debug)
                    is_debug = true;
                if (arg.StartsWith("-mall=") && !get_mall_code)
                {
                    mall_code = arg.Substring(6);
                    get_mall_code = true;
                }
                if (arg == "-formtest" && !is_formtest)
                    is_formtest = true;
            }

            if(is_debug)
            {
                Global.debugging = true;
                AllocConsole();
                //FreeConsole();
                Log.Open();
            }
            if(get_mall_code)
            {
                Global.get_mall_code = true;
                Global.mall_code = mall_code;
                Log.Debug($"Get mall code with {Global.mall_code}.");
                Global.web_url = $"http://y{Global.mall_code}.yun.youcaihua.net:88";
            }
            if(is_formtest)
            {
                Global.is_formtest = true;
                Log.Warn("You are in the form testing mode! Please check all forms which could working well!");
            }

            Log.Debug($"debug={Global.debugging}, mall_code={Global.mall_code}, get_mall_code={Global.get_mall_code}");
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new login_Form());
            //Application.Run(new daily_Form(new Login_Info()));
        }

        private static System.Reflection.Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
        {
            string resourceName = "youcaihua.Resources." + new AssemblyName(args.Name).Name + ".dll";
            using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(resourceName))
            {
                byte[] assemblyData = new byte[stream.Length];
                stream.Read(assemblyData, 0, assemblyData.Length);
                return Assembly.Load(assemblyData);
            }
        }
    }
}
