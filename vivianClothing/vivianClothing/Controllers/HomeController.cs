using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using vivianClothing.Models;
using System.Drawing;
namespace vivianClothing.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        
        //首頁
        public ActionResult Index()
        {
            //TODO: fake data
            var data = new List<ProductCategory>()
            {
                new ProductCategory() {Id = 1, Name = "工具" },
                 new ProductCategory() {Id = 2, Name = "禮品" },
                  new ProductCategory() {Id = 3, Name = "書籍" },
                   new ProductCategory() {Id = 4, Name = "美勞用具" },
            };

            return View(data);
        }
       
        //商品列表
        public ActionResult ProductList(int id)
        {
            var productCategory = new ProductCategory() { Id = id, Name = "類別 " + id };

            var data = new List<Product>()
            {
            new Product(){Id=1, ProductCategory =productCategory, Name = "原子筆",
                           Description="N/A",Price = 30, PublishOn = DateTime.Now, Color = Color.Black},
            new Product(){Id=1, ProductCategory =productCategory, Name = "鉛筆",
                           Description="N/A",Price = 5, PublishOn = DateTime.Now, Color = Color.Black}
            };

            return View(data);
        }
        
        //商品明細
        public ActionResult ProductDetail(int id)
        {
            var productCategory = new ProductCategory() { 
                Id = 1,
                Name = "文具"
            };

            var data = new Product(){
                Id =id,
                ProductCategory = productCategory,
                Name = "商品 " + id, Description = "N/A", 
                Price =30, 
                PublishOn = DateTime.Now, 
                Color = Color.Black
            };

            return View(data);
        }
    }
}
