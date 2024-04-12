using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuanLyPhatThuong_ToDanPho_1.Models;
namespace QuanLyPhatThuong_ToDanPho_1.Areas.Admin.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin/Admin


        db_QuanLyPhatThuong_ToDanPhoEntities db = new db_QuanLyPhatThuong_ToDanPhoEntities();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult DangXuat()
        {
            var taikhoan = Session["TK"] as tb_TaiKhoan;
            if (taikhoan != null)
            {
                var log_DangNhap = new tb_Log();

                log_DangNhap.ID_TaiKhoan = taikhoan.ID;
                log_DangNhap.NoiDung = "Đăng xuất tài khoản (" + taikhoan.Username + ")";
                log_DangNhap.NgayThaoTac = DateTime.Now;
                log_DangNhap.TrangThai = true;

                db.tb_Log.Add(log_DangNhap);
                db.SaveChanges();
                Session["TK"] = null;
            }
           

            return RedirectToRoute("Default",new { controller = "DangNhap", action = "Index", id = UrlParameter.Optional });

        }

    }
}