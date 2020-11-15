using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SuperMarketConsumer.Models;

namespace SuperMarketConsumer.Controllers
{
    public class CategoryController : Controller
    {
        SeviceClient servicesClient = new SeviceClient();
        // GET: Location
        public ViewResult Index(string sortOrder, string search, string currentFilter, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.listCategory = servicesClient.getAllCategory();

            if (search != null)
            {
                page = 1; // nếu search có giá trị trả về page = 1
            }
            else
            {
                search = currentFilter; //  nếu có thì render phần dữ liệu search ra
            }
            ViewBag.CurrentFilter = search;
            var categories = from s in servicesClient.getAllCategory() select s;
            if (!String.IsNullOrEmpty(search)) // check nếu search string có thì in ra hoặc không thì không in ra
            {
                categories = categories.Where(s => s.Name.Contains(search) || s.Description.Contains(search)); // contains là để check xem lastname hoặc firstName có chứa search string ở trên 
            }
            switch (sortOrder)
            {
                case "name desc":
                    categories = categories.OrderByDescending(s => s.Name); // các case tương đương với các cột muốn sort
                    break;

                default:
                    categories = categories.OrderBy(s => s.Name);
                    break;
            }

            return View(categories.ToList());
            
        }

        // GET: Location/Details/5
        public ActionResult Details(int id)
        {
            var Category = servicesClient.getAllCategory().Where(b => b.ID == id).FirstOrDefault();
            return View(Category);
        }

        // GET: Location/Create

        public ActionResult Create()
        {
            return View();
        }

        // POST: Location/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Category newCategory)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    servicesClient.AddCategory(newCategory);
                    return RedirectToAction("Index", "Category");
                }

                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Location/Edit/5
        public ActionResult Edit(int id)
        {
            var location = servicesClient.getAllCategory().Where(b => b.ID == id).FirstOrDefault();
            return View(location);
        }

        // POST: Location/Edit/5
        [HttpPost]
        public ActionResult Edit(Category newCategory)
        {
            try
            {
                servicesClient.EditCategory(newCategory);
                // TODO: Add update logic here

                return RedirectToAction("Index", "Category");
            }
            catch
            {
                return View();
            }
        }

        // GET: Location/Delete/5
        public ActionResult Delete(string id)
        {
            servicesClient.DeleteCategory(id);
            return View();
        }

        // POST: Location/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
