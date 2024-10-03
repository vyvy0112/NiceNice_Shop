using NiceNice_Shop.Data;
using Microsoft.AspNetCore.Mvc;
using NiceNice_Shop.ViewModels;

namespace NiceNice_Shop.ViewComponents
{
    public class MenuLoaiViewComponent : ViewComponent
    {
        // db tên biến local
        private readonly NiceNiceShopContext db;
        public MenuLoaiViewComponent(NiceNiceShopContext context) => db = context;

        public IViewComponentResult Invoke()
        {
            // lấy tên loại từ danh mục sản phẩm 
            var data = db.LoaiSps.Select(loai => new MenuLoaiVM
            {
                MaLoaiSp = loai.MaLoaiSp, 
                TenSp = loai.TenLoaiSp, 
                SoLuong = loai.HangHoas.Count
            });
            return View(data);


        }     
    }
}
