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
    public class QuanLyPhanThuongController : Controller
    {
        private db_QuanLyPhatThuong_ToDanPhoEntities db = new db_QuanLyPhatThuong_ToDanPhoEntities();

        // GET: Admin/QuanLyPhanThuong
        public ActionResult Index()
        {
            var tb_PhanThuong = db.tb_PhanThuong.Include(t => t.tb_LoaiPhanThuong);
            return View(tb_PhanThuong.ToList());
        }

        // GET: Admin/QuanLyPhanThuong/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_PhanThuong tb_PhanThuong = db.tb_PhanThuong.Find(id);
            if (tb_PhanThuong == null)
            {
                return HttpNotFound();
            }
            return View(tb_PhanThuong);
        }

        // GET: Admin/QuanLyPhanThuong/Create
        public ActionResult Create()
        {
            ViewBag.ID_LoaiPhanThuong = new SelectList(db.tb_LoaiPhanThuong, "ID", "TenLoai");
            return View();
        }

        // POST: Admin/QuanLyPhanThuong/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,ID_LoaiPhanThuong,TenPhanThuong,DVT,TriGia")] tb_PhanThuong tb_PhanThuong)
        {
            if (ModelState.IsValid)
            {
                db.tb_PhanThuong.Add(tb_PhanThuong);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_LoaiPhanThuong = new SelectList(db.tb_LoaiPhanThuong, "ID", "TenLoai", tb_PhanThuong.ID_LoaiPhanThuong);
            return View(tb_PhanThuong);
        }

        // GET: Admin/QuanLyPhanThuong/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_PhanThuong tb_PhanThuong = db.tb_PhanThuong.Find(id);
            if (tb_PhanThuong == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_LoaiPhanThuong = new SelectList(db.tb_LoaiPhanThuong, "ID", "TenLoai", tb_PhanThuong.ID_LoaiPhanThuong);
            return View(tb_PhanThuong);
        }

        // POST: Admin/QuanLyPhanThuong/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,ID_LoaiPhanThuong,TenPhanThuong,DVT,TriGia")] tb_PhanThuong tb_PhanThuong)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tb_PhanThuong).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_LoaiPhanThuong = new SelectList(db.tb_LoaiPhanThuong, "ID", "TenLoai", tb_PhanThuong.ID_LoaiPhanThuong);
            return View(tb_PhanThuong);
        }

        // GET: Admin/QuanLyPhanThuong/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_PhanThuong tb_PhanThuong = db.tb_PhanThuong.Find(id);
            if (tb_PhanThuong == null)
            {
                return HttpNotFound();
            }
            return View(tb_PhanThuong);
        }

        // POST: Admin/QuanLyPhanThuong/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tb_PhanThuong tb_PhanThuong = db.tb_PhanThuong.Find(id);
            db.tb_PhanThuong.Remove(tb_PhanThuong);
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
