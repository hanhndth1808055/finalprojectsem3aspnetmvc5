using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OfficialFinalProjectSem3.Data;
using OfficialFinalProjectSem3.Models;

namespace OfficialFinalProjectSem3.Controllers
{
    public class ProductsController : Controller
    {
        private MyDBContext db = new MyDBContext();

        // GET: Products
        public ActionResult Index(string keyword, DateTime? start, DateTime? end, int? status, string sortOrder, int? page, int? limit)
        {
            int defaultLimit = 2;
            int defaultPage = 1;
            var itemsList = new List<SelectListItem>();
            itemsList.AddRange(Enum.GetValues(typeof(Product.ProductStatus)).Cast<Product.ProductStatus>().Select(
               (item, index) => new SelectListItem
               {
                   Text = item.ToString(),
                   Value = (index).ToString()
               }).ToList());
            ViewBag.status = itemsList;

            var products = db.Products.AsQueryable();

            if (!string.IsNullOrEmpty(keyword))
            {
                products = products.Where(p => p.Name.Contains(keyword));
            }

            if (start != null)
            {
                var startDate = start.GetValueOrDefault().Date;
                startDate = startDate.Date + new TimeSpan(0, 0, 0);
                products = products.Where(p => p.CreatedAt >= startDate);
            }

            if (end != null)
            {
                var endDate = end.GetValueOrDefault().Date;
                endDate = endDate.Date + new TimeSpan(23, 59, 59);
                products = products.Where(p => p.CreatedAt <= endDate);
            }

            if (status.HasValue)
            {
                products = products.Where(p => (int) p.Status == status.Value);
            }

            if (string.IsNullOrEmpty(sortOrder) || sortOrder.Equals("date-asc"))
            {
                ViewBag.DateSortParam = "date-desc";
                ViewBag.PriceSortParam = "price-desc";
            }
            else if(sortOrder.Equals("date-desc"))
            {
                ViewBag.DateSortParam = "date-asc";
            }
            else if (sortOrder.Equals("price-asc"))
            {
                ViewBag.PriceSortParam = "price-desc";
            }
            else if (sortOrder.Equals("price-desc"))
            {
                ViewBag.PriceSortParam = "price-asc";
            }


            switch (sortOrder)
            {
                case "price-asc":
                    products = products.OrderBy(p => p.Price);
                    break;
                case "price-desc":
                    products = products.OrderByDescending(p => p.Price);
                    break;
                case "date-asc":
                    products = products.OrderBy(p => p.CreatedAt);
                    break;
                case "date-desc":
                    products = products.OrderByDescending(p => p.CreatedAt);
                    break;
                default:
                    products = products.OrderByDescending(p => p.CreatedAt);
                    break;
            }

            if (page.HasValue)
            {
                defaultPage = page.Value;
            }

            if (limit.HasValue)
            {
                defaultLimit = limit.Value;
            }

            int totalItem = products.Count();
            double totalPage = Math.Ceiling((double) totalItem / defaultLimit);
            products = products.Skip((defaultPage - 1) * defaultLimit).Take(defaultLimit);
            ViewBag.totalItem = totalItem;
            ViewBag.totalPage = (int) totalPage;
            ViewBag.currentPage = defaultPage;
            ViewBag.limit = defaultLimit;

            return View(products.ToList());
        }

        // GET: Products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Price,Thumbnails,CreatedAt,Status")] Product product, String[] thumbnails)
        {
            if (ModelState.IsValid)
            {
                if (thumbnails != null && thumbnails.Length > 0)
                {
                    product.Thumbnails = string.Join(",", thumbnails);
                }
                product.CreatedAt = DateTime.Now;
                product.Status = Product.ProductStatus.ACTIVE;
                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(product);
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Price,Thumbnails,CreatedAt,Status")] Product product, String[] thumbnails)
        {
            if (ModelState.IsValid)
            {
                if (thumbnails != null && thumbnails.Length > 0)
                {
                    product.Thumbnails = string.Join(",", thumbnails);
                }
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(product);
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = db.Products.Find(id);
            db.Products.Remove(product);
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
