using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuanLyPhatThuong_ToDanPho_1.Models;
namespace QuanLyPhatThuong_ToDanPho_1.Controllers
{
    public class DangNhapController : Controller
    {

        db_QuanLyPhatThuong_ToDanPhoEntities db = new db_QuanLyPhatThuong_ToDanPhoEntities();
        // GET: DangNhap
        public ActionResult Index()
        {
            Session["TK"] = null;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult KiemTraDangNhap(FormCollection fields)
        {
            var username = fields["username"];
            var password = fields["password"];
            var taikhoan = db.tb_TaiKhoan.Where(s => s.Username == username  && s.Pass == password ).FirstOrDefault();
            if (taikhoan == null)
            {
                Session["LoiDangNhap"] = "Thông tin đăng nhập không chính xác";
                return RedirectToAction("Index", "DangNhap");
            }
            else
            {
                Session["TK"] = taikhoan;
                tb_Log logDangNhap = new tb_Log();
                logDangNhap.ID_TaiKhoan = taikhoan.ID;
                logDangNhap.NgayThaoTac = DateTime.Now;
                logDangNhap.NoiDung = "Đăng nhập tài khoản (" + taikhoan.Username+")";
                logDangNhap.TrangThai = true;
                db.tb_Log.Add(logDangNhap);
                db.SaveChanges();

                return RedirectToAction("Index", "Admin", new { Area = "Admin" });
            } 
            
        }

    }
}