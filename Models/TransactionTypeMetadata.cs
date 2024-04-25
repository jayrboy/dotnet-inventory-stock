using inventoryProject.Data;
using System.ComponentModel.DataAnnotations;

namespace inventoryProject.Models
{
    public class TransactionTypeMetadata
    {

    }

    [MetadataType(typeof(TransactionTypeMetadata))]
    public partial class TransactionType
    {
        //Create Action
        public static TransactionType Create(InventoryContext db, TransactionType transactionType)
        {
            transactionType.CreateDate = DateTime.Now;
            transactionType.UpdateDate = DateTime.Now;
            transactionType.IsDeleted = false;
            db.TransactionTypes.Add(transactionType);
            db.SaveChanges();
            return transactionType;
        }

        //Get All
        public static List<TransactionType> GetAll(InventoryContext db)
        {
            List<TransactionType> result = db.TransactionTypes.Where(q => q.IsDeleted != true).ToList();
            return result;
        }
    }
}