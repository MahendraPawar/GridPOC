using PayMaster.Framework.Business;
using PayMaster.Framework.Model;
using System.Collections.Generic;
using System.Web.Caching;
using System.Web.Mvc;
using System.Web.UI;
using GridMvcPOC.Util;
using GridMvcPOC.Filters;

namespace GridMvcPOC.Controllers
{
    public class HomeController : Controller
    {
        private Cache cache = new Cache();
        //
        // GET: /Home/

        public ActionResult Index()
        {
            var items = OpCodeBa.Get(new PayMaster.Framework.Model.OpCode());

            return View(items);
        }

        public ActionResult BootstrapTable()
        {
            return View();
        }

        [HttpGet]
        public JsonResult GetData(FormCollection obj = null)
        {
            var items = OpCodeBa.Get(new PayMaster.Framework.Model.OpCode());

            return Json(items, JsonRequestBehavior.AllowGet);
        }

        /*
         * With inbuilt caching*/
        [HttpGet]
        [OutputCache(Duration = 10, VaryByParam = "none", Location = OutputCacheLocation.Client)]
        public ActionResult WebGridSample(int? page, string sort)
        {
            var configSection = GridConfig.GridParams.HeaderStyle;
            var opcodeCache = HttpContext.Cache["Opcode"] as ICollection<OpCode>;
            if (opcodeCache == null)
            {
                var items = OpCodeBa.Get(new PayMaster.Framework.Model.OpCode());
                HttpContext.Cache["Opcode"] = items;
                return View(items);
            }
            else
                return View(opcodeCache);

        }

        /*[HttpGet]
        [OutputCache(Duration = 10, VaryByParam = "none", Location = OutputCacheLocation.Client)]
        public ActionResult WebGridSample(int? page, string sort)
        {
            var opcodeCache = CacheProvider.Instance.Get("Opcode") as ICollection<OpCode>;
            if (opcodeCache == null)
            {
                var items = OpCodeBa.Get(new PayMaster.Framework.Model.OpCode());
                CacheProvider.Instance.Set("Opcode", items, 20);
                return View(items);
            }
            else
                return View(opcodeCache);

        }*/
        public ActionResult Edit(int opcodeid)
        {
            return PartialView();
        }

        [EncryptedActionParameter]
        public ActionResult Delete(int opcodeid)
        {
            return View("WebGridSample");
        }
    }
}