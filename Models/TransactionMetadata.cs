using inventoryProject.Data;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace inventoryProject.Models
{
    public class TransactionMetadata
    {

    }

    [MetadataType(typeof(TransactionMetadata))]
    public partial class Transaction
    {
        //Create Action
        public static Transaction Create(InventoryContext db, Transaction transaction)
        {
            transaction.UpdateDate = DateTime.Now;
            transaction.IsDeleted = false;
            db.Transactions.Add(transaction);
            db.SaveChanges();
            return transaction;
        }

        //Get All
        public static List<Transaction> GetAll(InventoryContext db)
        {
            // List<Transaction> result = db.Transactions.Where(q => q.IsDeleted != true).ToList();
            List<Transaction> result = db.Transactions
                               .Include(t => t.Product) // เพิ่ม Include เพื่อให้ EF Core อ่านข้อมูล Product ที่เกี่ยวข้อง
                               .Include(t => t.TransactionType) // เพิ่ม Include เพื่อให้ EF Core อ่านข้อมูล TransactionType ที่เกี่ยวข้อง
                               .Where(q => q.IsDeleted != true)
                               .ToList();

            return result;
        }
    }
}