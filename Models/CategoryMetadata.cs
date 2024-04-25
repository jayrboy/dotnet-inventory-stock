using inventoryProject.Data;
using System.ComponentModel.DataAnnotations;

namespace inventoryProject.Models
{
    public class CategoryMetadata
    {

    }

    [MetadataType(typeof(CategoryMetadata))]
    public partial class Category
    {
        //Create Action
        public static Category Create(InventoryContext db, Category category)
        {
            category.CreateDate = DateTime.Now;
            category.UpdateDate = DateTime.Now;
            category.IsDeleted = false;
            db.Categories.Add(category);
            db.SaveChanges();
            return category;
        }

        //Get All
        public static List<Product> GetAll(InventoryContext db)
        {
            List<Product> result = db.Products.Where(Queryable => Queryable.IsDeleted != true).ToList();
            return result;
        }
    }
}