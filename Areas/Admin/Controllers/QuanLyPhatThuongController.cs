using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using QuanLyPhatThuong_ToDanPho_1.Models;

namespace QuanLyPhatThuong_ToDanPho_1.Areas.Admin.Controllers
{
    public class QuanLyPhatThuongController : Controller
    {
        private db_QuanLyPhatThuong_ToDanPhoEntities db = new db_QuanLyPhatThuong_ToDanPhoEntities();

        // GET: Admin/QuanLyPhatThuong
        public ActionResult Index()
        {
            var tb_PhatThuong = db.tb_PhatThuong.Include(t => t.tb_DanhMucPhatThuong);
            return View(tb_PhatThuong.ToList());
        }

        // GET: Admin/QuanLyPhatThuong/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_PhatThuong tb_PhatThuong = db.tb_PhatThuong.Find(id);
            if (tb_PhatThuong == null)
            {
                return HttpNotFound();
            }
            return View(tb_PhatThuong);
        }

        // GET: Admin/QuanLyPhatThuong/Create
        public ActionResult Create()
        {
            ViewBag.ID_DanhMucPhatThuong = new SelectList(db.tb_DanhMucPhatThuong, "ID", "TenDanhMuc");
            return View();
        }

        // POST: Admin/QuanLyPhatThuong/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,ID_DanhMucPhatThuong,NgayTao,NgayPhat,GhiChu")] tb_PhatThuong tb_PhatThuong)
        {
            if (ModelState.IsValid)
            {
                db.tb_PhatThuong.Add(tb_PhatThuong);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_DanhMucPhatThuong = new SelectList(db.tb_DanhMucPhatThuong, "ID", "TenDanhMuc", tb_PhatThuong.ID_DanhMucPhatThuong);
            return View(tb_PhatThuong);
        }

        // GET: Admin/QuanLyPhatThuong/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_PhatThuong tb_PhatThuong = db.tb_PhatThuong.Find(id);
            if (tb_PhatThuong == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_DanhMucPhatThuong = new SelectList(db.tb_DanhMucPhatThuong, "ID", "TenDanhMuc", tb_PhatThuong.ID_DanhMucPhatThuong);
            return View(tb_PhatThuong);
        }

        // POST: Admin/QuanLyPhatThuong/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,ID_DanhMucPhatThuong,NgayTao,NgayPhat,GhiChu")] tb_PhatThuong tb_PhatThuong)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tb_PhatThuong).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_DanhMucPhatThuong = new SelectList(db.tb_DanhMucPhatThuong, "ID", "TenDanhMuc", tb_PhatThuong.ID_DanhMucPhatThuong);
            return View(tb_PhatThuong);
        }

        // GET: Admin/QuanLyPhatThuong/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_PhatThuong tb_PhatThuong = db.tb_PhatThuong.Find(id);
            if (tb_PhatThuong == null)
            {
                return HttpNotFound();
            }
            return View(tb_PhatThuong);
        }

        // POST: Admin/QuanLyPhatThuong/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tb_PhatThuong tb_PhatThuong = db.tb_PhatThuong.Find(id);
            db.tb_PhatThuong.Remove(tb_PhatThuong);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
