using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using wut2eat_Web.Models;

namespace wut2eat_Web.Controllers
{
    public class WTEController : Controller
    {
        readonly dbWhatToEatEntities _db = new dbWhatToEatEntities();

        // GET: WTE
        public ActionResult Index()
        {
            var records = _db.tWhatToEatList.OrderBy(r => Guid.NewGuid()).FirstOrDefault();
            return View(records);
        }

        /// <summary>
        /// 列表
        /// </summary>
        /// <returns></returns>
        public ActionResult List()
        {
            var records = _db.tWhatToEatList.OrderBy(r => r.Id).ToList();
            return View(records);
        }
    }
}