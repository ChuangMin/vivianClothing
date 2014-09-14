using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using vivianClothing.Models;
using System.Drawing;
using PagedList;

namespace vivianClothing.Controllers
{
    public class HomeController : BaseController
    {
        // GET: /Home/
        
        //首頁
        public ActionResult Index()
        {
            var data = db.ProductCategories.ToList();
            
            #if DEBUG
            if (data.Count==0)
            {
                //TODO: just preview fake data on view
                //var data = new List<ProductCategory>()
                //{
                //    new ProductCategory() {Id = 1, Name = "工具" },
                //     new ProductCategory() {Id = 2, Name = "禮品" },
                //      new ProductCategory() {Id = 3, Name = "書籍" },
                //       new ProductCategory() {Id = 4, Name = "美勞用具" },
                //};

                 //TODO:insert test Data to database
                db.ProductCategories.Add(new ProductCategory() { Id = 1, Name = "上身" });
                db.ProductCategories.Add(new ProductCategory() { Id = 2, Name = "下身" });
                db.ProductCategories.Add(new ProductCategory() { Id = 3, Name = "洋裝" });
                db.ProductCategories.Add(new ProductCategory() { Id = 4, Name = "內/泳衣" });
                db.ProductCategories.Add(new ProductCategory() { Id = 5, Name = "鞋/包" });
                db.ProductCategories.Add(new ProductCategory() { Id = 6, Name = "配件" });
                db.ProductCategories.Add(new ProductCategory() { Id = 7, Name = "全" });

                db.SaveChanges();

                data = db.ProductCategories.ToList();
            }
            #endif

            return View(data);
        }
       
        //商品列表
        public ActionResult ProductList(int id, int p =1)
        {
           
            var productCategory = db.ProductCategories.Find(id);

            if (productCategory!= null)
            {
                var data = productCategory.Products.ToList();
                           
                var pagedData = data.ToPagedList(pageNumber: p, pageSize: 10);
                return View(pagedData);
            }
            else
            {
                return HttpNotFound();
            }
            
        }
        
        //商品明細
        public ActionResult ProductDetail(int id )
        {
            //TODO: testData
            //var productCategory = new ProductCategory() { 
            //    Id = 1,
            //    Name = "文具"
            //};

            //var data = new Product(){
            //    Id =id,
            //    ProductCategory = productCategory,
            //    Name = "商品 " + id, Description = "N/A", 
            //    Price =30, 
            //    PublishOn = DateTime.Now, 
            //    Color = Color.Black
            //};

            var data = db.Products.Find(id);

            return View(data);
        }
    }
}
