using Application.Models;
using Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers;

[ApiController]
[Route("[controller]")]
public class CategoriesController : ControllerBase
{
    private readonly CategoryService _categoryService;

    public CategoriesController(CategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var categories = _categoryService.GetAll();
        return Ok(categories);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        try
        {
            var category = _categoryService.GetById(id);
            return Ok(category);
        }
        catch (KeyNotFoundException ex)
        {
            // Captura si el recurso no fue encontrado (HTTP 404)
            return NotFound(ex.Message);
        }
    }

    [HttpPost]
    public IActionResult Create([FromBody] PostCategoryRequest request)
    {
        try
        {
            var newCategory = _categoryService.Create(request);
            return CreatedAtAction(nameof(GetById), new { id = newCategory.Id }, newCategory);
        }
        catch (ArgumentException ex)
        {
            // Captura errores de validación de argumentos (HTTP 400)
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        try
        {
            _categoryService.Delete(id);
            return NoContent(); // HTTP 204
        }
        catch (KeyNotFoundException ex)
        {
            // Captura si se intentó eliminar un registro que no existe (HTTP 404)
            return NotFound(ex.Message);
        }
    }
}