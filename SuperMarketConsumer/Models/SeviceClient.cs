using SuperMarketConsumer.SuperMarketService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace SuperMarketConsumer.Models
{
    
    public class SeviceClient
    {
        SuperMarketServiceClient client = new SuperMarketServiceClient();
        public List<Category> getAllCategory()
        {
            var list = client.GetCategories().ToList();
            var rt = new List<Category>();
            list.ForEach(b => rt.Add(new Category()
            {
                ID = b.ID,
                Name = b.Name,
                Description = b.Description, 
            }
            )) ;
            return rt;
        }
        public bool AddCategory(Category newCategory)
        {
            var category = new SuperMarketService.Category()
            {
                ID = newCategory.ID,
                Name = newCategory.Name,
                Description = newCategory.Description,
            };
            return client.AddCategory(category);
        }

        public bool EditCategory(Category newCategory)
        {
            var category = new SuperMarketService.Category()
            {
                ID = newCategory.ID,
                Name = newCategory.Name,
                Description = newCategory.Description,
            };
            return client.EditCategory(category.ID.ToString(), category);
        }

        public bool DeleteCategory(string id)
        {
            return client.DeleteCategory(id);

        }
    }
}