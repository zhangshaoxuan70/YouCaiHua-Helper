using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;

namespace youcaihua
{
    public class Global
    {
        public static bool debugging = false;
        public static bool is_formtest = false;
        public static string mall_code = "30950021";
        public static bool get_mall_code = true;
        public static string login_token = string.Empty;
        public static bool is_login = false;
        public static CookieContainer cookies = new CookieContainer();
        public static string web_url = $"http://y{mall_code}.yun.youcaihua.net:88";
        public static string UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/128.0.0.0 Safari/537.36 Edg/128.0.0.0";

        public static int current_Num = 0;
        public static int current_Played = 0;
        public static decimal current_Percent = 0m;
    }
    public class Info
    {
        public static Response Check_mall(string MallCode)
        {
            Dictionary<string, bool> unuse = new Dictionary<string, bool>();
            unuse.Add("unuse", false);
            string jsonparam = JsonConvert.SerializeObject(unuse);
            string host = $"{Global.web_url}/DTOGetSysInfo/";
            Log.Debug(host);
            byte[] byteData = Encoding.UTF8.GetBytes(jsonparam);
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(host);
            request.Method = "POST";
            request.Accept = "application/json, text/plain, */*";
            request.ContentType = "application/json";
            request.UserAgent = Global.UserAgent;
            request.ContentLength = byteData.Length;
            request.KeepAlive = true;
            Stream writer = request.GetRequestStream();
            writer.Write(byteData, 0, byteData.Length);
            writer.Close();
            try
            {
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                string responseString = new StreamReader(response.GetResponseStream(), Encoding.UTF8).ReadToEnd();
                int status = (int)response.StatusCode;
                Log.Debug(responseString);
                return new Response(status, responseString);
            }
            catch (WebException e)
            {
                HttpWebResponse response = (HttpWebResponse)e.Response;
                int status = (int)response.StatusCode;
                Log.Debug(status);
                return new Response(status);
            }
        }

        public static Response Get_Account(string account, string password)
        {
            Encoding encoding = new UTF8Encoding();
            string encode_psd = Convert.ToBase64String(encoding.GetBytes(password));
            Log.Debug($"Get password {password}, then encode to {encode_psd}");

            Dictionary<string, bool> unuse = new Dictionary<string, bool>();
            unuse.Add("unuse", false);
            string jsonparam = JsonConvert.SerializeObject(unuse);
            string host = $"{Global.web_url}/DTOWebLogin?username={account}&password={encode_psd}";
            Log.Debug(host);
            byte[] byteData = Encoding.UTF8.GetBytes(jsonparam);
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(host);
            request.Method = "POST";
            request.Accept = "application/json, text/plain, */*";
            request.ContentType = "application/json";
            request.UserAgent = Global.UserAgent;
            request.ContentLength = byteData.Length;
            request.KeepAlive = true;
            Stream writer = request.GetRequestStream();
            writer.Write(byteData, 0, byteData.Length);
            writer.Close();
            request.CookieContainer = Global.cookies;
            try
            {
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                string responseString = new StreamReader(response.GetResponseStream(), Encoding.UTF8).ReadToEnd();
                Only_Status feedback = JsonConvert.DeserializeObject<Only_Status>(responseString);
                if (feedback.ResponseStatus.ErrorCode == "0")
                {
                    Log.Info("Login complete!");
                    Global.is_login = true;
                    Log.Debug(Global.cookies.Count);
                    /*foreach (Cookie cookie in response.Cookies)
                    {
                        Log.Debug($"{cookie.Name}:{cookie.Value}");
                    }*/
                }
                else
                {
                    Log.Info("Login failed.");
                }
                Log.Debug(responseString);
                int status = (int)response.StatusCode;
                Log.Debug(responseString);
                return new Response(status, responseString);
            }
            catch (WebException e)
            {
                HttpWebResponse response = (HttpWebResponse)e.Response;
                int status = (int)response.StatusCode;
                Log.Debug(status);
                return new Response(status);
            }
        }

        /// <summary>
        /// This function don't need input!
        /// Please prepare in Global.
        /// </summary>
        public static Response Get_Login_Info()
        {
            if (!Global.is_login)
                return new Response(401);
            Dictionary<string, bool> unuse = new Dictionary<string, bool>();
            unuse.Add("unuse", false);
            string jsonparam = JsonConvert.SerializeObject(unuse);
            string host = $"{Global.web_url}/Professional/api/v1.0/System/DTOGetLoginInfo";
            Log.Debug(host);
            byte[] byteData = Encoding.UTF8.GetBytes(jsonparam);
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(host);
            request.Method = "POST";
            request.Accept = "application/json, text/plain, */*";
            request.ContentType = "application/json";
            request.UserAgent = Global.UserAgent;
            request.ContentLength = byteData.Length;
            request.KeepAlive = true;
            request.CookieContainer = Global.cookies;
            Stream writer = request.GetRequestStream();
            writer.Write(byteData, 0, byteData.Length);
            writer.Close();
            try
            {
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                string responseString = new StreamReader(response.GetResponseStream(), Encoding.UTF8).ReadToEnd();
                Log.Debug(responseString);
                int status = (int)response.StatusCode;
                return new Response(status, responseString);
            }
            catch (WebException e)
            {
                HttpWebResponse response = (HttpWebResponse)e.Response;
                int status = (int)response.StatusCode;
                Log.Debug(status);
                return new Response(status);
            }
        }

        /// <summary>
        /// This function don't need input!
        /// Please prepare in Global.
        /// </summary>
        public static Response Get_Machine_Sale_Sum()
        {
            if (!Global.is_login)
                return new Response(401);

            string date_first = DateTime.Now.ToString("yyyy-MM-01");
            string date_current = DateTime.Now.ToString("yyyy-MM-dd");

            string query_item = $"{{\"ModelType\":\"View_MachineSaleQuerySum\",\"QueryCode\":\"View_MachineSaleQuerySum\",\"Select\":[{{\"Alias\":\"LeaguerCode\",\"Field\":\"LeaguerCode\",\"StatisticsType\":\"group\",\"ShowTotal\":false,\"ShowTotalType\":\"none\",\"ShowTotalFormat\":null,\"Format\":null}},{{\"Alias\":\"RealName\",\"Field\":\"RealName\",\"StatisticsType\":\"group\",\"ShowTotal\":false,\"ShowTotalType\":\"none\",\"ShowTotalFormat\":null,\"Format\":null}},{{\"Alias\":\"LeaguerID\",\"Field\":\"Leaguer.ID\",\"StatisticsType\":\"group\",\"ShowTotal\":false,\"ShowTotalType\":\"none\",\"ShowTotalFormat\":null,\"Format\":null}},{{\"Alias\":\"StartUpCount\",\"Field\":\"StartUpCount\",\"StatisticsType\":\"sum\",\"ShowTotal\":true,\"ShowTotalType\":\"sum\",\"ShowTotalFormat\":null,\"Format\":\"f0\"}},{{\"Alias\":\"PepaidMoney\",\"Field\":\"PepaidMoney\",\"StatisticsType\":\"sum\",\"ShowTotal\":true,\"ShowTotalType\":\"sum\",\"ShowTotalFormat\":null,\"Format\":\"f2\"}},{{\"Alias\":\"CashMoney\",\"Field\":\"CashMoney\",\"StatisticsType\":\"sum\",\"ShowTotal\":true,\"ShowTotalType\":\"sum\",\"ShowTotalFormat\":null,\"Format\":\"f2\"}},{{\"Alias\":\"CoinMoney\",\"Field\":\"CoinMoney\",\"StatisticsType\":\"sum\",\"ShowTotal\":true,\"ShowTotalType\":\"sum\",\"ShowTotalFormat\":null,\"Format\":\"f2\"}},{{\"Alias\":\"GoldCoinMoney\",\"Field\":\"GoldCoinMoney\",\"StatisticsType\":\"sum\",\"ShowTotal\":true,\"ShowTotalType\":\"sum\",\"ShowTotalFormat\":null,\"Format\":\"f2\"}},{{\"Alias\":\"PackageTicketMoney\",\"Field\":\"PackageTicketMoney\",\"StatisticsType\":\"sum\",\"ShowTotal\":true,\"ShowTotalType\":\"sum\",\"ShowTotalFormat\":null,\"Format\":null}}],\"Wheres\":[{{\"Field\":\"LogTime\",\"Value\":\"{date_first} 00:00:00\",\"ValueBet\":\"{date_current} 23:59:59\",\"Compare\":\"rg\"}},{{\"Field\":\"Status\",\"Value\":\"0\",\"ValueBet\":null,\"Compare\":\"eq\"}}],\"Page\":1,\"Rows\":10,\"Order\":\"desc\",\"Sort\":\"StartUpCount\",\"getTotalCountType\":2,\"Year\":\"0\"}}";
            string host = $"{Global.web_url}/customquery/query";
            Log.Debug(host);
            byte[] byteData = Encoding.UTF8.GetBytes(query_item);
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(host);
            request.Method = "POST";
            request.Accept = "application/json, text/plain, */*";
            request.ContentType = "application/json";
            request.UserAgent = Global.UserAgent;
            request.ContentLength = byteData.Length;
            request.KeepAlive = true;
            request.CookieContainer = Global.cookies;
            Stream writer = request.GetRequestStream();
            writer.Write(byteData, 0, byteData.Length);
            writer.Close();
            try
            {
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                string responseString = new StreamReader(response.GetResponseStream(), Encoding.UTF8).ReadToEnd();
                Log.Debug(responseString);
                int status = (int)response.StatusCode;
                return new Response(status, responseString);
            }
            catch (WebException e)
            {
                HttpWebResponse response = (HttpWebResponse)e.Response;
                int status = (int)response.StatusCode;
                Log.Debug(status); 
                string responseString = new StreamReader(response.GetResponseStream(), Encoding.UTF8).ReadToEnd();
                return new Response(status, responseString);
            }
        }

        /// <summary>
        /// This function don't need input!
        /// Please prepare in Global.
        /// </summary>
        public static Response Get_Total_Ticket_Sum()
        {
            if (!Global.is_login)
                return new Response(401);

            string date_first = DateTime.Now.ToString("yyyy-MM-01");
            string date_current = DateTime.Now.ToString("yyyy-MM-dd");

            string query_item = $"{{\"ModelType\":\"View_LgTotalTicket\",\"QueryCode\":\"View_LgTotalTicket\",\"Select\":[{{\"Alias\":\"OwnedBusiness.ID\",\"Field\":\"OwnedBusiness.ID\",\"StatisticsType\":\"none\",\"ShowTotal\":false,\"ShowTotalType\":\"none\",\"ShowTotalFormat\":null,\"Format\":null}},{{\"Alias\":\"OwnedBusiness\",\"Field\":\"OwnedBusiness.ID\",\"StatisticsType\":\"group\",\"ShowTotal\":false,\"ShowTotalType\":\"none\",\"ShowTotalFormat\":null,\"Format\":null}},{{\"Alias\":\"Leaguer\",\"Field\":\"Leaguer\",\"StatisticsType\":\"group\",\"ShowTotal\":false,\"ShowTotalType\":\"none\",\"ShowTotalFormat\":null,\"Format\":null}},{{\"Alias\":\"LeaguerCode\",\"Field\":\"LeaguerCode\",\"StatisticsType\":\"max\",\"ShowTotal\":false,\"ShowTotalType\":\"none\",\"ShowTotalFormat\":null,\"Format\":null}},{{\"Alias\":\"RealName\",\"Field\":\"RealName\",\"StatisticsType\":\"max\",\"ShowTotal\":false,\"ShowTotalType\":\"none\",\"ShowTotalFormat\":null,\"Format\":null}},{{\"Alias\":\"LevelName\",\"Field\":\"LevelName\",\"StatisticsType\":\"max\",\"ShowTotal\":false,\"ShowTotalType\":\"none\",\"ShowTotalFormat\":null,\"Format\":null}},{{\"Alias\":\"Phone\",\"Field\":\"Phone\",\"StatisticsType\":\"max\",\"ShowTotal\":false,\"ShowTotalType\":\"none\",\"ShowTotalFormat\":null,\"Format\":\"PhoneHide\"}},{{\"Alias\":\"IDCard\",\"Field\":\"IDCard\",\"StatisticsType\":\"max\",\"ShowTotal\":false,\"ShowTotalType\":\"none\",\"ShowTotalFormat\":null,\"Format\":null}},{{\"Alias\":\"TicketNumber\",\"Field\":\"TicketNumber\",\"StatisticsType\":\"sum\",\"ShowTotal\":true,\"ShowTotalType\":\"sum\",\"ShowTotalFormat\":null,\"Format\":\"###,###\"}}],\"Wheres\":[{{\"Field\":\"LogTime\",\"Value\": \"{date_first}\",\"ValueBet\":\"{date_current}\",\"Compare\":\"rg\"}}],\"Page\":1,\"Rows\":10,\"Order\":\"desc\",\"Sort\":\"TicketNumber\",\"Year\":\"0\"}}";
            string host = $"{Global.web_url}/customquery/query";
            Log.Debug(host);
            byte[] byteData = Encoding.UTF8.GetBytes(query_item);
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(host);
            request.Method = "POST";
            request.Accept = "application/json, text/plain, */*";
            request.ContentType = "application/json";
            request.UserAgent = Global.UserAgent;
            request.ContentLength = byteData.Length;
            request.KeepAlive = true;
            request.CookieContainer = Global.cookies;
            Stream writer = request.GetRequestStream();
            writer.Write(byteData, 0, byteData.Length);
            writer.Close();
            try
            {
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                string responseString = new StreamReader(response.GetResponseStream(), Encoding.UTF8).ReadToEnd();
                Log.Debug(responseString);
                int status = (int)response.StatusCode;
                return new Response(status, responseString);
            }
            catch (WebException e)
            {
                HttpWebResponse response = (HttpWebResponse)e.Response;
                int status = (int)response.StatusCode;
                Log.Debug(status);
                string responseString = new StreamReader(response.GetResponseStream(), Encoding.UTF8).ReadToEnd();
                return new Response(status,responseString);
            }
        }
    }
    public class Response
    {
        public int StatusCode = 200;
        public string Result = string.Empty;
        public Response(int StatusCode,string Result=null)
        {
            this.StatusCode = StatusCode;
            this.Result = Result;
        }

    }
    internal class Log
    {
        internal static void Debug(dynamic message)
        {
            Task.Run(() =>
            {
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write($"{DateTime.Now} [DEBUG] ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(message);
            });
        }
        internal static void Info(string message)
        {
            Task.Run(() =>
            {
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write($"{DateTime.Now} [INFO] ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(message);
            });
        }
        internal static void Warn(string message)
        {
            Task.Run(() =>
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write($"{DateTime.Now} [WARN] ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(message);
            });
        }
        internal static void Error(string message)
        {
            Task.Run(() =>
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write($"{DateTime.Now} [ERROR] ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(message);
            });
        }
        internal static void Fatal(string message)
        {
            Task.Run(() =>
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write($"{DateTime.Now} [FATAL] ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(message);
            });
        }
        internal protected static void Open()
        {
            Console.Title = "Logger";
            Console.WriteLine("You opened logger window! Program made by zhangshaoxuan70. View it at: https://github.com/zhangshaoxuan70/YouCaiHua-Helper");
        }
    }
}
