using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace HRCenter.Models
{
    public class Datum
    {
        public string ADDRESS { get; set; }
        public string ADDR_INDZONE { get; set; }
        public string ADDR_NO_DESCRIPT { get; set; }
        public string APPEAR_DATE { get; set; }
        public string APPEAR_TIME { get; set; }
        public string C { get; set; }
        public string CERT_ALL_DESCRIPT { get; set; }
        public string DESCRIPTION { get; set; }
        public string DIS_LEVEL { get; set; }
        public string DIS_LEVEL2 { get; set; }
        public string DIS_LEVEL3 { get; set; }
        public string DIS_ROLE { get; set; }
        public string DIS_ROLE2 { get; set; }
        public string DIS_ROLE3 { get; set; }
        public string DRIVER { get; set; }
        public string HANDICOMPENDIUM { get; set; }
        public string INDCAT { get; set; }
        public string J { get; set; }
        public string JOB { get; set; }
        public string JOBCAT_DESCRIPT { get; set; }
        public string JOBSKILL_ALL_DESC { get; set; }
        public string JOB_ADDRESS { get; set; }
        public string JOB_ADDR_NO_DESCRIPT { get; set; }
        public string LANGUAGE1 { get; set; }
        public string LANGUAGE2 { get; set; }
        public string LANGUAGE3 { get; set; }
        public string LAT { get; set; }
        public string LINK { get; set; }
        public string LON { get; set; }
        public string MAJOR_CAT_DESCRIPT { get; set; }
        public string MINBINARY_EDU { get; set; }
        public string NAME { get; set; }
        public string NEED_EMP { get; set; }
        public string NEED_EMP1 { get; set; }
        public string OTHERS { get; set; }
        public string PCSKILL_ALL_DESC { get; set; }
        public string PERIOD { get; set; }
        public string PERIOD_formatted
        {
            get { return PERIOD.TrimStart('0'); }
        }
        public string PRODUCT { get; set; }
        public string PROFILE { get; set; }
        public string ROLE { get; set; }
        public string ROLE_STATUS { get; set; }
        public string S2 { get; set; }
        public string S3 { get; set; }
        public string SAL_MONTH_HIGH { get; set; }
        public string SAL_MONTH_HIGH_formatted
        {
            get { return formatMoney(SAL_MONTH_HIGH.TrimStart('0')); }
        }

        private string formatMoney(string money)
        {
            if (!string.IsNullOrWhiteSpace(money) && Regex.IsMatch(money, @"\d+"))
            {
                var money_double = double.Parse(money);
                var money_kunit = (money_double / 1000).ToString("0.0");
                return money_kunit.Insert(money_kunit.IndexOf("."), "K").Replace(".0", "");
            }
            else
            {
                return "0";
            }
        }

        public string SAL_MONTH_LOW { get; set; }
        public string SAL_MONTH_LOW_formatted
        {
            get { return formatMoney(SAL_MONTH_LOW.TrimStart('0')); }
        }
        public string STARTBY { get; set; }
        public string WELFARE { get; set; }
        public string WORKTIME { get; set; }
        public string URLToCompanyPage
        {
            get
            {
                return $"https://www.104.com.tw/jobbank/custjob/index.php?j={J}";
            }
        }
    }

    public class RootObject
    {
        public string RECORDCOUNT { get; set; }
        public string PAGECOUNT { get; set; }
        public string PAGE { get; set; }
        public string TOTALPAGE { get; set; }
        public List<Datum> data { get; set; }
    }
}