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
                db.ProductCategories.Add(new ProductCategory() { Id = 1, Name = "工具" });
                db.ProductCategories.Add(new ProductCategory() { Id = 2, Name = "禮品" });
                db.ProductCategories.Add(new ProductCategory() { Id = 3, Name = "書籍" });
                db.ProductCategories.Add(new ProductCategory() { Id = 4, Name = "美勞用具" });
                db.ProductCategories.Add(new ProductCategory() { Id = 5, Name = "美勞用具1" });
                db.ProductCategories.Add(new ProductCategory() { Id = 6, Name = "美勞用具2" });
                db.ProductCategories.Add(new ProductCategory() { Id = 7, Name = "美勞用具3" });
                db.ProductCategories.Add(new ProductCategory() { Id = 8, Name = "美勞用具4" });
                db.ProductCategories.Add(new ProductCategory() { Id = 9, Name = "美勞用具5" });
                db.ProductCategories.Add(new ProductCategory() { Id = 10, Name = "美勞用具6" });
                db.ProductCategories.Add(new ProductCategory() { Id = 11, Name = "美勞用具7" });
                db.ProductCategories.Add(new ProductCategory() { Id = 12, Name = "美勞用具8" });
                db.ProductCategories.Add(new ProductCategory() { Id = 13, Name = "美勞用具9" });
                db.ProductCategories.Add(new ProductCategory() { Id = 14, Name = "美勞用1" });
                db.ProductCategories.Add(new ProductCategory() { Id = 15, Name = "美勞用2" });
                db.ProductCategories.Add(new ProductCategory() { Id = 16, Name = "美勞用3" });
                db.ProductCategories.Add(new ProductCategory() { Id = 17, Name = "美勞用4" });
                db.ProductCategories.Add(new ProductCategory() { Id = 18, Name = "美勞用5" });
                db.ProductCategories.Add(new ProductCategory() { Id = 19, Name = "美勞用6" });
                db.ProductCategories.Add(new ProductCategory() { Id = 20, Name = "美勞用7" });
                db.ProductCategories.Add(new ProductCategory() { Id = 21, Name = "美勞用8" });
                db.ProductCategories.Add(new ProductCategory() { Id = 22, Name = "美勞用9" });

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



        public ActionResult GetJsonData(int id)//,int p =1)
        {

            var productCategory = db.ProductCategories.Find(id);
            var data = productCategory.Products.ToList();

           // return Json(data, JsonRequestBehavior.AllowGet); 
            return Json(
                         data.Select(x => new {
                         id = x.Id,
                         name = x.Name,
                         price = x.Price
                        })); 
            
        }

    }
}
