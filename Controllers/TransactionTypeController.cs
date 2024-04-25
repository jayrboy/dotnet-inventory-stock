using inventoryProject.Data;
using inventoryProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace inventoryProject.Controllers;

[ApiController]
[Route("[controller]")]
public class TransactionTypeController : ControllerBase
{
    private InventoryContext _db = new InventoryContext();
    private readonly ILogger<TransactionTypeController> _logger;

    public TransactionTypeController(ILogger<TransactionTypeController> logger)
    {
        _logger = logger;
    }

    public struct TransactionTypeCreate
    {
        /// <summary>
        /// Type of the TransactionType
        /// </summary>
        /// <example>เครื่องใช้ไฟฟ้า</example>
        /// <required>true</required>
        public string? Name { get; set; }
    }

    [HttpPost(Name = "CreateTransactionType")]
    public ActionResult CreateTransactionType(TransactionTypeCreate transactionTypeCreate)
    {
        TransactionType transactionType = new TransactionType
        {
            Name = transactionTypeCreate.Name,
        };
        transactionType = TransactionType.Create(_db, transactionType);
        return Ok(transactionType);
    }

    [HttpGet(Name = "ViewTransactionType")]
    public ActionResult ViewTransactionType()
    {
        List<TransactionType> transactionType = TransactionType.GetAll(_db);
        return Ok(transactionType);
    }
}
