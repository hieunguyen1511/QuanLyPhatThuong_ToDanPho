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
    public class DanhMucPhanThuongController : Controller
    {
        private db_QuanLyPhatThuong_ToDanPhoEntities db = new db_QuanLyPhatThuong_ToDanPhoEntities();

        // GET: Admin/DanhMucPhanThuong
        public ActionResult Index()
        {
            return View(db.tb_LoaiPhanThuong.ToList());
        }


        private int get_IDTaiKhoan()
        {
            var taikhoan = Session["TK"] as tb_TaiKhoan;
            return taikhoan.ID;
        }

        // GET: Admin/DanhMucPhanThuong/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_LoaiPhanThuong tb_LoaiPhanThuong = db.tb_LoaiPhanThuong.Find(id);
            if (tb_LoaiPhanThuong == null)
            {
                return HttpNotFound();
            }
            return View(tb_LoaiPhanThuong);
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ThemDanhMuc(FormCollection fields)
        {
            var tenDanhMuc = fields["TenDanhMuc"];

            var tb_LoaiPhanThuong = new tb_LoaiPhanThuong();
            tb_LoaiPhanThuong.TenLoai = tenDanhMuc;

            if (ModelState.IsValid)
            {

                var taikhoan = Session["TK"] as tb_TaiKhoan;
                tb_Log log_DanhMucPhanThuong = new tb_Log();
                log_DanhMucPhanThuong.ID_TaiKhoan = taikhoan.ID;
                log_DanhMucPhanThuong.NoiDung = "Thêm danh mục (" + tb_LoaiPhanThuong.TenLoai+")";
                log_DanhMucPhanThuong.NgayThaoTac = DateTime.Now;

                
                try
                {
                    db.tb_LoaiPhanThuong.Add(tb_LoaiPhanThuong);
                    db.SaveChanges();
                    log_DanhMucPhanThuong.TrangThai = true;
                    db.tb_Log.Add(log_DanhMucPhanThuong);
                    db.SaveChanges();
                    Session["ThemDanhMuc"] = "Thêm danh mục " + tb_LoaiPhanThuong.TenLoai + " thành công";


                }
                catch
                {
                    log_DanhMucPhanThuong.TrangThai = false;
                    db.tb_Log.Add(log_DanhMucPhanThuong);
                    db.SaveChanges();
                    Session["LoiThemDanhMuc"] = "Lỗi thêm danh mục";
                }
               
            }
            return RedirectToAction("Index");
        }




      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SuaDanhMuc(FormCollection fields)
        {

            var ID = int.Parse(fields["ID"]);
            var tenDanhMuc = fields["TenDanhMuc"];
            
            var danhmuc = db.tb_LoaiPhanThuong.Find(ID);

            var log_SuaDanhMuc = new tb_Log();
            log_SuaDanhMuc.ID_TaiKhoan = get_IDTaiKhoan();
            log_SuaDanhMuc.NoiDung = "Sửa danh mục (" + danhmuc.TenLoai + ") thành (" + tenDanhMuc+")";
            log_SuaDanhMuc.NgayThaoTac = DateTime.Now;

            if (danhmuc != null)
            {
                danhmuc.TenLoai = tenDanhMuc;
                try
                {
                    db.Entry(danhmuc).State = EntityState.Modified;
                    db.SaveChanges();
                    Session["SuaDanhMuc"] = "Sửa danh mục phần thưởng thành công";
                    log_SuaDanhMuc.TrangThai = true;
                    db.tb_Log.Add(log_SuaDanhMuc);
                    db.SaveChanges();

                }
                catch
                {
                    Session["LoiSuaDanhMuc"] = "Không thể sửa danh mục";
                    log_SuaDanhMuc.TrangThai = false;
                    db.tb_Log.Add(log_SuaDanhMuc);
                    db.SaveChanges();
                }
            }

            return RedirectToAction("Index");
        }


        public ActionResult XoaDanhMuc(int id)
        {
            tb_LoaiPhanThuong tb_LoaiPhanThuong = db.tb_LoaiPhanThuong.Find(id);
            var log_XoaDanhMuc = new tb_Log();
            log_XoaDanhMuc.ID_TaiKhoan = get_IDTaiKhoan();
            log_XoaDanhMuc.NgayThaoTac = DateTime.Now;
            log_XoaDanhMuc.NoiDung = "Xóa danh mục (" + tb_LoaiPhanThuong.TenLoai+")";
            try
            {
                db.tb_LoaiPhanThuong.Remove(tb_LoaiPhanThuong);
                db.SaveChanges();
                Session["XoaDanhMuc"] = "Xóa danh mục " + tb_LoaiPhanThuong.TenLoai + " thành công";
                log_XoaDanhMuc.TrangThai = true;
                db.tb_Log.Add(log_XoaDanhMuc);
                db.SaveChanges();
            }
            catch
            {
                Session["XoaDanhMuc"] = "Không thể xóa danh mục " + tb_LoaiPhanThuong.TenLoai;
                log_XoaDanhMuc.TrangThai = false;
                db.tb_Log.Add(log_XoaDanhMuc);
                db.SaveChanges();
            }
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
