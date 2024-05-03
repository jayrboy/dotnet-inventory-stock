using inventoryProject.Data;
using inventoryProject.Models;
using Microsoft.AspNetCore.Mvc;
using myFirstProject.Models;

namespace inventoryProject.Controllers;

[ApiController]
[Route("[controller]")]
public class TransactionController : ControllerBase
{
    private InventoryContext _db = new InventoryContext();
    private readonly ILogger<TransactionController> _logger;

    public TransactionController(ILogger<TransactionController> logger)
    {
        _logger = logger;
    }

    public struct TransactionCreate
    {
        /// <summary>
        /// ProductId of the Transaction
        /// </summary>
        /// <example>1</example>
        /// <required>true</required>
        public int? ProductId { get; set; }

        /// <summary>
        /// ProductId of the Transaction
        /// </summary>
        /// <example>2</example>
        /// <required>true</required>
        public int? TransactionTypeId { get; set; }

        /// <summary>
        /// ProductId of the Transaction
        /// </summary>
        /// <example>100</example>
        /// <required>true</required>
        public int? Quantity { get; set; }
    }

    [HttpPost(Name = "CreateTransaction")]
    public ActionResult CreateTransaction(TransactionCreate transactionCreate)
    {
        Transaction transaction = new Transaction
        {
            ProductId = transactionCreate.ProductId,
            TransactionTypeId = transactionCreate.TransactionTypeId,
            Quantity = transactionCreate.Quantity
        };
        transaction = Transaction.Create(_db, transaction);
        return Ok(transaction);
    }

    [HttpGet(Name = "ViewTransaction")]
    public ActionResult ViewTransaction()
    {
        List<Transaction> transaction = Transaction.GetAll(_db);
        return Ok(transaction);
    }

}
