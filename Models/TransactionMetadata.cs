using inventoryProject.Data;
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
            List<Transaction> result = db.Transactions.Where(q => q.IsDeleted != true).ToList();
            return result;
        }
    }
}