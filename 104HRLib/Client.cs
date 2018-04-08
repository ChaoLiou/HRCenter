using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Web;

namespace _104HRLib
{
    public class Client
    {
        private string _baseURL = "http://www.104.com.tw/i/apis/jobsearch.cfm";

        public string RequestURL { get; set; }

        public Client(FormatType ft, PageInfo pi, KeywordInfo ki, ExperienceInfo ei, SalaryInfo si)
        {
            RequestURL = $"{_baseURL}?fmt={(int)ft}&{pi}&{ki}&{ei}&{si}";
        }

        public string Get()
        {
            using (var wc = new WebClient())
            {
                var json = wc.DownloadData(RequestURL);
                var jsonStr = Encoding.UTF8.GetString(json);
                return jsonStr;
            }
        }

        public enum FormatType
        {
            Rss = 1,
            CountOnly = 2,
            CodeList = 3,
            ListInXml = 4,
            CountOnlyInJson1 = 6,
            CountOnlyInJson2 = 7,
            ListInJson = 8,
            ParamInfo = 9
        }

        public enum OrderType
        {
            Relative1 = 0,
            Relative2 = 1,
            UpdateDate = 2,
            Experience = 3,
            Education = 4,
            Area = 5,
            Salary = 6,
            ApplicationFrequency = 7
        }

        public class PageInfo
        {
            public int Index { get; set; } = 1;
            public int Size { get; set; } = 50;
            public OrderType OrderType { get; set; } = OrderType.UpdateDate;
            /// <summary>
            /// 0: descend, 1: ascend
            /// </summary>
            public int Direction { get; set; } = 0;

            public override string ToString()
            {
                return $"page={Index}&pgsz={Size}&order={(int)OrderType}&asc={Direction}";
            }
        }

        public class KeywordInfo
        {
            public string Keywords { get; set; }
            public KeywordSearchRangeType KeywordSearchRangeType { get; set; } = KeywordSearchRangeType.All;

            public override string ToString()
            {
                return $"kws={HttpUtility.UrlEncode(Keywords)}&kwop={(int)KeywordSearchRangeType}";
            }
        }

        public enum KeywordSearchRangeType
        {
            JobName = 1,
            JobName_JobDescription_CompanyName_CompanyProduct_CompanyDescription_Walfare_IndustryType_IDEs_SKills = 2,
            All = 3,
            JobName_JobDescription_CompanyDescription_IndustryType = 4
        }

        public enum ExperienceType
        {
            Below1Year = 0,
            Above1Year = 1,
            Above2Year = 2,
            Above3Year = 3,
            Above4Year = 4,
            Above5Year = 5,
            Above6Year = 6,
            Above7Year = 7,
            Above8Year = 8,
            Above9Year = 9,
            Above10Year = 10,
        };

        public enum ExperienceSearchRange
        {
            RightOnIt = 0,
            Above = 1,
            Below = 2
        }

        public class ExperienceInfo
        {
            public ExperienceType ExperienceType { get; set; } = ExperienceType.Below1Year;
            public ExperienceSearchRange ExperienceSearchRange { get; set; } = ExperienceSearchRange.Above;

            public override string ToString()
            {
                return $"exp={(int)ExperienceType}&exp_all={(int)ExperienceSearchRange}";
            }
        }

        public class SalaryInfo
        {
            public SalaryType SalaryType { get; set; } = SalaryType.SalaryEachMonth;
            public int SalaryMin { get; set; } = 0;
            public int SalaryMax { get; set; } = 999999;
            public override string ToString()
            {
                var salaryTypeMapping = new Dictionary<int, string>
                {
                    {0, "D"},
                    {1, "R"},
                    {2, "C"},
                    {3, "S"},
                };
                return $"sltp={salaryTypeMapping[(int)SalaryType]}&slmin={SalaryMin}&slmax={SalaryMax}";
            }
        }

        public enum SalaryType
        {
            Negotiable = 0,
            AccordingToCompanyPolicy = 1,
            ByCaseAmount = 2,
            SalaryEachMonth = 3
        }
    }
}