using MyShop.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.DataAccess.InMemory
{
   public class ProductCategoryRepository
    {
        ObjectCache cache = MemoryCache.Default;
        List<ProductCategory> productsCategories ;

        public ProductCategoryRepository()
        {
            productsCategories = cache["productsCategories"] as List<ProductCategory>;

            if (productsCategories == null)
            {
                productsCategories = new List<ProductCategory>();
            }
        }

        public void Commit()
        {
            cache["productsCategories"] = productsCategories;
        }

        public void Insert(ProductCategory p)
        {
            productsCategories.Add(p);
        }

        public void Update(ProductCategory productsCategory)
        {
            ProductCategory productToUpdate = productsCategories.Find(p => p.Id == productsCategory.Id);

            if (productToUpdate != null)
            {
                productToUpdate = productsCategory;
            }
            else
            {
                throw new Exception("Product Category Not Found");
            }
        }

        public ProductCategory Find(string Id)
        {
            ProductCategory productsCategory = productsCategories.Find(p => p.Id == Id);

            if (productsCategory != null)
            {
                return productsCategory;
            }
            else
            {
                throw new Exception("Product Category Not Found");
            }
        }

        public IQueryable<ProductCategory> Collection()
        {
            return productsCategories.AsQueryable();
        }


        public void Delete(string Id)
        {
            ProductCategory productToDelete = productsCategories.Find(p => p.Id == Id);

            if (productToDelete != null)
            {
                productsCategories.Remove(productToDelete);
            }
            else
            {
                throw new Exception("Product Category Not Found");
            }
        }
    }
}
