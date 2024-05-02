using inventoryProject.Controllers;
using inventoryProject.Data;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static inventoryProject.Controllers.ProductController;

namespace inventoryProject.Models
{
    public class ProductMetadata
    {

    }


    [MetadataType(typeof(ProductMetadata))]
    public partial class Product
    {
        //Create Action
        public static Product Create(InventoryContext db, Product product)
        {
            product.CreateDate = DateTime.Now;
            product.UpdateDate = DateTime.Now;
            product.IsDeleted = false;
            db.Products.Add(product);
            db.SaveChanges();
            return product;
        }

        //Get All Action
        public static List<Product> GetAll(InventoryContext db)
        {
            List<Product> result = db.Products.Where(q => q.IsDeleted != true).ToList();
            return result;
        }

        //Get ID Action
        public static Product GetById(InventoryContext db, int id)
        {
            Product? result = db.Products.Include(i => i.Category).Where(q => q.Id == id && q.IsDeleted != true).FirstOrDefault();
            return result ?? new Product();
        }

        //Update Action
        public static Product Update(InventoryContext db, Product product)
        {
            Product oldProduct = GetById(db, product.Id);
            oldProduct.Name = product.Name;
            oldProduct.Description = product.Description;
            oldProduct.CategoryId = product.CategoryId;
            oldProduct.StockQuantity = product.StockQuantity;
            oldProduct.Price = product.Price;
            oldProduct.UpdateDate = DateTime.Now;

            // db.Entry(oldProduct).State = EntityState.Modified;
            db.SaveChanges();

            return oldProduct;
        }

        //Delete Action
        public static Product Delete(InventoryContext db, int id)
        {
            Product product = GetById(db, id);

            product.IsDeleted = true;
            db.Entry(product).State = EntityState.Modified;

            // db.Products.Remove(product);

            db.SaveChanges();
            return product;
        }


        //Update Quantity Action
        public static Product UpdateStockQuantity(InventoryContext db, ProductQuantity product)
        {
            Product oldProduct = GetById(db, product.Id);

            oldProduct.StockQuantity -= product.Quantity;

            db.SaveChanges();

            return oldProduct;
        }
    }

}