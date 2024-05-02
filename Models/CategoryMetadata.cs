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
        public static List<Category> GetAll(InventoryContext db)
        {
            List<Category> result = db.Categories.Where(Queryable => Queryable.IsDeleted != true).ToList();
            return result;
        }

        //Get ID Action
        public static Category GetById(InventoryContext db, int id)
        {
            Category? result = db.Categories.Where(q => q.Id == id && q.IsDeleted != true).FirstOrDefault();
            return result ?? new Category();
        }
    }
}