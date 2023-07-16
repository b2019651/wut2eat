using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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

        /// <summary>
        /// 新增項目
        /// </summary>
        /// <returns></returns>
        public ActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// [POST]新增項目
        /// </summary>
        /// <param name="record"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Create(tWhatToEatList record)
        {
            if (ModelState.IsValid)
            {
                _db.tWhatToEatList.Add(record);
                _db.SaveChanges();
            }
            return RedirectToAction("List");
        }

        /// <summary>
        /// 刪除
        /// TODO: 應該弄個POST method
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public ActionResult Delete(int? Id)
        {
            if (Id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var record = _db.tWhatToEatList.Where(r => r.Id == Id).FirstOrDefault();
            if (record == null)
            {
                return HttpNotFound();
            }

            _db.tWhatToEatList.Remove(record);
            _db.SaveChanges();
            return RedirectToAction("List");
        }

        /// <summary>
        /// 查看
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public ActionResult Details(int? Id)
        {
            if (Id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var record = _db.tWhatToEatList.Where(r => r.Id == Id).FirstOrDefault();
            if (record == null)
            {
                return HttpNotFound();
            }

            return View(record);
        }
    }
}