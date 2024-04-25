using inventoryProject.Data;
using inventoryProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace inventoryProject.Controllers;

[ApiController]
[Route("[controller]")]
public class CategoryController : ControllerBase
{
    private InventoryContext _db = new InventoryContext();
    private readonly ILogger<CategoryController> _logger;

    public CategoryController(ILogger<CategoryController> logger)
    {
        _logger = logger;
    }

    public struct CategoryCreate
    {
        /// <summary>
        /// Name of the Product
        /// </summary>
        /// <example>เครื่องใช้ไฟฟ้า</example>
        /// <required>true</required>
        public string? Name { get; set; }
    }

    [HttpPost(Name = "CreateCategory")]
    public ActionResult CreateCategory(CategoryCreate categoryCreate)
    {
        Category category = new Category
        {
            Name = categoryCreate.Name,
        };
        category = Category.Create(_db, category);
        return Ok(category);
    }

    [HttpGet(Name = "ViewCategory")]
    public ActionResult ViewCategory()
    {
        List<Product> products = Product.GetAll(_db);
        return Ok(products);
    }
}
