using inventoryProject.Data;
using inventoryProject.Models;
using Microsoft.AspNetCore.Mvc;
using myFirstProject.Models;

namespace inventoryProject.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductController : ControllerBase
{
    private InventoryContext _db = new InventoryContext();
    private readonly ILogger<ProductController> _logger;

    public ProductController(ILogger<ProductController> logger)
    {
        _logger = logger;
    }

    public struct ProductCreate
    {
        /// <summary>
        /// Name of the Product
        /// </summary>
        /// <example>เสื้อ</example>
        /// <required>true</required>
        public string? Name { get; set; }

        /// <summary>
        /// Description of the Product
        /// </summary>
        /// <example>Uniqlo</example>
        /// <required>true</required>
        public string? Description { get; set; }

        /// <summary>
        /// CategoryId of the Product
        /// </summary>
        /// <example>2</example>
        /// <required>true</required>
        public int? CategoryId { get; set; }

        /// <summary>
        /// StockQuantity of the Product
        /// </summary>
        /// <example>10</example>
        /// <required>true</required>
        public int? StockQuantity { get; set; }

        /// <summary>
        /// Price of the Product
        /// </summary>
        /// <example>300</example>
        /// <required>true</required>
        public int? Price { get; set; }
    }

    public class ProductQuantity
    {
        public int Id { get; set; }
        public int? Quantity { get; set; }
    }

    [HttpPost(Name = "CreateProduct")]
    public ActionResult CreateProduct(ProductCreate productCreate)
    {
        Product product = new Product
        {
            Name = productCreate.Name,
            Description = productCreate.Description,
            CategoryId = productCreate.CategoryId,
            StockQuantity = productCreate.StockQuantity,
            Price = productCreate.Price,
        };


        product = Product.Create(_db, product);
        return Ok(product);
    }

    [HttpGet(Name = "GetAllProduct")]
    public ActionResult GetAllProduct()
    {
        // List<Product> products = Product.GetAll(_db).OrderBy(q => q.Price).ToList(); // น้อย -> มาก
        // List<Product> products = Product.GetAll(_db).OrderByDescending(q => q.Price).ToList(); // มาก -> น้อย
        List<Product> products = Product.GetAll(_db).OrderBy(q => q.Id).ToList(); // ตามลำดับ
        
        return Ok(new Response
        {
            Code = 200,
            Message = "Success",
            Data = products
        });
    }

    [HttpGet("{id}", Name = "GetIdProduct")]
    public ActionResult GetIdProduct(int id)
    {
        Product product = Product.GetById(_db, id);
        return Ok(new Response
        {
            Code = 200,
            Message = "Success",
            Data = product
        });
    }

    /// <summary>
    /// Update Product
    /// </summary>
    /// <remarks>
    /// Sample request:
    /// ```json
    /// GET /products
    /// {
    ///     "id": 1,
    ///     "name": "รองเท้า",
    ///     "description": "nike",
    ///     "categoryId": 2,
    ///     "stockQuantity": 100,
    ///     "price": 1500
    /// }
    /// ```
    /// </remarks>
    /// <param name="product"></param>
    /// <returns></returns>
    /// <response code="200">
    /// Success
    /// <br/>
    /// <br/>
    /// Example response:
    ///  ```json
    /// {
    ///     "Code": 200,
    ///     "Message": "Success",
    ///     "Data": {
    ///         "id": 1
    ///         "name": "รองเท้า",
    ///         "description": "nike",
    ///         "categoryId": 2,
    ///         "stockQuantity": 100,
    ///         "price": 1500,
    ///         "category": {
    ///             "id": 2,
    ///             "name": "เสื้อผ้า"
    ///         },
    ///         "transactions": []
    ///      }
    /// }
    /// ```
    /// </response>
    /// <response code="400">Bad Request</response>
    /// <response code="500">Internal Server Error</response>
    [HttpPut(Name = "UpdateProduct")]
    public ActionResult UpdateProduct(Product product)
    {
        product = Product.Update(_db, product);
        return Ok(new Response
        {
            Code = 200,
            Message = "Success",
            Data = product
        });
    }

    [HttpDelete("{id}", Name = "DeleteProductById")]
    public ActionResult DeleteProductById(int id)
    {
        Product product = Product.Delete(_db, id);
        return Ok(product);
    }


    /// <summary>
    /// Update Stock Quantity
    /// </summary>
    /// <remarks>
    /// Sample request:
    /// ```json
    /// PUT /Product/UpdateQuantity
    /// {
    ///     "id": 1,
    ///     "stockQuantity": 10,
    /// }
    /// ```
    /// </remarks>
    /// <param name="product"></param>
    /// <returns></returns>
    /// <response code="200">Success</response>
    /// <response code="400">Bad Request</response>
    /// <response code="500">Internal Server Error</response>
    [HttpPut("UpdateQuantity")]
    public ActionResult UpdateStockQuantity(ProductQuantity productQuantity)
    {
        Product productStock = Product.UpdateStockQuantity(_db, productQuantity);

        Transaction transaction = new Transaction
        {
            ProductId = productStock.Id,
            TransactionTypeId = 3,
            Quantity = productQuantity.Quantity
        };

        Transaction.Create(_db, transaction);

        return Ok(new Response
        {
            Code = 200,
            Message = "Success",
            Data = productQuantity
        });
    }

    [HttpPut("AddQuantity")]
    public ActionResult AddStockQuantity(ProductQuantity productQuantity)
    {
        Product productStock = Product.AddStockQuantity(_db, productQuantity);

        Transaction transaction = new Transaction
        {
            ProductId = productStock.Id,
            TransactionTypeId = 2,
            Quantity = productQuantity.Quantity
        };

        Transaction.Create(_db, transaction);

        return Ok(new Response
        {
            Code = 200,
            Message = "Success",
            Data = productQuantity
        });
    }

    [HttpPut("SaleQuantity")]
    public ActionResult SaleQuantity(ProductQuantity productQuantity)
    {
        Product productStock = Product.SaleQuantity(_db, productQuantity);

        Transaction transaction = new Transaction
        {
            ProductId = productStock.Id,
            TransactionTypeId = 1,
            Quantity = productQuantity.Quantity
        };

        Transaction.Create(_db, transaction);

        return Ok(new Response
        {
            Code = 200,
            Message = "Success",
            Data = productQuantity
        });
    }
}