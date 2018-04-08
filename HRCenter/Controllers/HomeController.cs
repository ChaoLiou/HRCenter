using HRCenter.Models;
using Newtonsoft.Json;
using System.Web.Mvc;

namespace HRCenter.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult List(HomeViewModel vm)
        {
            var client = new _104HRLib.Client(
                _104HRLib.Client.FormatType.ListInJson,
                vm.PageInfo,
                vm.KeywordInfo,
                vm.ExperienceInfo,
                vm.SalaryInfo);
            var json = JsonConvert.DeserializeObject<RootObject>(client.Get());
            return Json(json);
        }
    }
}
