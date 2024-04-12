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
    public class QuanLyThanhVienController : Controller
    {
        private db_QuanLyPhatThuong_ToDanPhoEntities db = new db_QuanLyPhatThuong_ToDanPhoEntities();

        // GET: Admin/QuanLyThanhVien
        public ActionResult Index()
        {
            var tb_ThanhVien = db.tb_ThanhVien.Include(t => t.tb_HoGiaDinh);
            return View(tb_ThanhVien.ToList());
        }

        // GET: Admin/QuanLyThanhVien/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_ThanhVien tb_ThanhVien = db.tb_ThanhVien.Find(id);
            if (tb_ThanhVien == null)
            {
                return HttpNotFound();
            }
            return View(tb_ThanhVien);
        }

        // GET: Admin/QuanLyThanhVien/Create
        public ActionResult Create()
        {
            ViewBag.ID_HoGiaDinh = new SelectList(db.tb_HoGiaDinh, "ID", "MaHoGiaDinh");
            return View();
        }

        // POST: Admin/QuanLyThanhVien/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,ID_HoGiaDinh,HoTen,NgaySinh,SDT,Email,GioiTinh,DanToc,TonGiao,CCCD,ChuHo")] tb_ThanhVien tb_ThanhVien)
        {
            if (ModelState.IsValid)
            {
                db.tb_ThanhVien.Add(tb_ThanhVien);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_HoGiaDinh = new SelectList(db.tb_HoGiaDinh, "ID", "MaHoGiaDinh", tb_ThanhVien.ID_HoGiaDinh);
            return View(tb_ThanhVien);
        }

        // GET: Admin/QuanLyThanhVien/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_ThanhVien tb_ThanhVien = db.tb_ThanhVien.Find(id);
            if (tb_ThanhVien == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_HoGiaDinh = new SelectList(db.tb_HoGiaDinh, "ID", "MaHoGiaDinh", tb_ThanhVien.ID_HoGiaDinh);
            return View(tb_ThanhVien);
        }

        // POST: Admin/QuanLyThanhVien/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,ID_HoGiaDinh,HoTen,NgaySinh,SDT,Email,GioiTinh,DanToc,TonGiao,CCCD,ChuHo")] tb_ThanhVien tb_ThanhVien)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tb_ThanhVien).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_HoGiaDinh = new SelectList(db.tb_HoGiaDinh, "ID", "MaHoGiaDinh", tb_ThanhVien.ID_HoGiaDinh);
            return View(tb_ThanhVien);
        }

        // GET: Admin/QuanLyThanhVien/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_ThanhVien tb_ThanhVien = db.tb_ThanhVien.Find(id);
            if (tb_ThanhVien == null)
            {
                return HttpNotFound();
            }
            return View(tb_ThanhVien);
        }

        // POST: Admin/QuanLyThanhVien/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tb_ThanhVien tb_ThanhVien = db.tb_ThanhVien.Find(id);
            db.tb_ThanhVien.Remove(tb_ThanhVien);
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
