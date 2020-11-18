using MyShop.Core.Contracts;
using MyShop.Core.Models;
using MyShop.DataAccess.InMemory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyShop.WebUI.Controllers
{
    public class ProductCategoryManagerController : Controller
    {
        IRepository<ProductCategory> context;

        public ProductCategoryManagerController(IRepository<ProductCategory> productCategoryContext)
        {
            context = productCategoryContext;
        }
        // GET: ProductCategoryManager
        public ActionResult Index()
        {
            List<ProductCategory> ProductCategories = context.Collection().ToList();
            return View(ProductCategories);
        }

        public ActionResult Create()
        {
            ProductCategory ProductCategory = new ProductCategory();
            return View(ProductCategory);
        }
        [HttpPost]
        public ActionResult Create(ProductCategory ProductCategory)
        {
            if (!ModelState.IsValid)
            {
                return View(ProductCategory);
            }
            else
            {
                context.Insert(ProductCategory);
                context.Commit();

                return RedirectToAction("Index");
            }
        }

        public ActionResult Edit(string Id)
        {
            ProductCategory ProductCategory = context.Find(Id);
            if (ProductCategory == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(ProductCategory);
            }
        }

        [HttpPost]
        public ActionResult Edit(ProductCategory ProductCategory, string Id)
        {
            ProductCategory ProductCategoryToEdit = context.Find(Id);

            if (ProductCategoryToEdit == null)
            {
                return HttpNotFound();
            }
            else
            {
                if (!ModelState.IsValid)
                {
                    return View(ProductCategory);
                }

                ProductCategoryToEdit.Category = ProductCategory.Category;
                

                context.Commit();

                return RedirectToAction("Index");
            }
        }


        public ActionResult Delete(string Id)
        {
            ProductCategory ProductCategoryToDelete = context.Find(Id);

            if (ProductCategoryToDelete == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(ProductCategoryToDelete);
            }
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult confirmDelete(string Id)
        {
            ProductCategory ProductCategoryToDelete = context.Find(Id);

            if (ProductCategoryToDelete == null)
            {
                return HttpNotFound();
            }
            else
            {
                context.Delete(Id);
                context.Commit();
                return RedirectToAction("Index");
            }
        }
    }
}