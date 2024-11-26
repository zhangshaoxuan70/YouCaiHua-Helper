using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace youcaihua
{
    public class ResponseStatus
    {
        /// <summary>
        /// 0
        /// </summary>
        public string ErrorCode { get; set; }
        /// <summary>
        /// None
        /// </summary>
        public string Message { get; set; }
    }

    public class SysInfo
    {
        /// <summary>
        /// 30950021
        /// </summary>
        public string MallCode { get; set; }
        /// <summary>
        /// 真快活北京领展购物广场店
        /// </summary>
        public string MallName { get; set; }
        /// <summary>
        /// V10.3.7240 (连锁版)
        /// </summary>
        public string CurrVersion { get; set; }
        /// <summary>
        /// V10.3.7240 (连锁版)
        /// </summary>
        public string LastVersion { get; set; }
        /// <summary>
        /// 2025-07-31
        /// </summary>
        public string SysExpireDate { get; set; }
        /// <summary>
        /// 291
        /// </summary>
        public string RemainDays { get; set; }
        /// <summary>
        /// © Copyright 2024 广州油菜花信息科技有限公司 版权所有
        /// </summary>
        public string Copyright { get; set; }
        /// <summary>
        /// 400-9999-261
        /// </summary>
        public string ContactWay { get; set; }
        /// <summary>
        /// False
        /// </summary>
        public string IsMultiLanguage { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public ResponseStatus ResponseStatus { get; set; }
    }

    public class Data
    {
        /// <summary>
        /// 
        /// </summary>
        public string LoginName { get; set; }
        /// <summary>
        /// 黎雄
        /// </summary>
        public string RealName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string PeriodName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string CurrentBussinessID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string IsMainPage { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string IsGlobalRight { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Type { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<int> RightList { get; set; }
    }

    public class PageInfo
    {
        /// <summary>
        /// 
        /// </summary>
        public int PageIndex { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int PageSize { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int TotalCount { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int Take { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool NotGetTotle { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int Skip { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Sort { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool Ascending { get; set; }
    }

    public class StatisticsTotal
    {
        /// <summary>
        /// 
        /// </summary>
        public string FormatMoney { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string TicketNumber { get; set; }
    }

    public class Sale_Sum
    {
        /// <summary>
        /// 
        /// </summary>
        public PageInfo PageInfo { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public StatisticsTotal StatisticsTotal { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public ResponseStatus ResponseStatus { get; set; }
    }

    public class Login_Info
    {
        /// <summary>
        /// 
        /// </summary>
        public Data Data { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public ResponseStatus ResponseStatus { get; set; }
    }

    public class Only_Status
    {
        /// <summary>
        /// 
        /// </summary>
        public ResponseStatus ResponseStatus { get; set; }
    }

    /// <summary>
    /// Here's config loader
    /// </summary>
    public class Config
    {
        public string Code { get; set; } = null;
        public bool? AutoAuth { get; set; } = null;
        public string Account { get; set; } = null;
        public string Password { get; set; } = null;
    }
}