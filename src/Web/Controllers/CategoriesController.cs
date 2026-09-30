using Domain.Interfaces;
using Application.Models;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers;

[ApiController]
[Route("[controller]")]
public class CategoriesController : ControllerBase
{
    private readonly IRepository<Category> _categoryRepository;

    public CategoriesController(IRepository<Category> categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var categories = _categoryRepository.List();
        return Ok(CategoryDto.Create(categories));
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var category = _categoryRepository.GetById(id);
        if (category == null)
            return NotFound();

        return Ok(CategoryDto.Create(category));
    }

    [HttpPost]
    public IActionResult Create([FromBody] PostCategoryRequest request)
    {
        var category = new Category
        {
            Name = request.Name
        };

        _categoryRepository.Add(category);

        return CreatedAtAction(nameof(GetById), new { id = category.Id }, CategoryDto.Create(category));
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var category = _categoryRepository.GetById(id);
        if (category == null)
            return NotFound();

        _categoryRepository.Delete(category);
        return NoContent();
    }
}