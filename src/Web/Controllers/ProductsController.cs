using Microsoft.AspNetCore.Mvc;
using Domain.Entities;
using Domain.Interfaces;
using Application.Models;

namespace Web.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductsController : ControllerBase
{
    // Dependencia que el controlador necesita para trabajar con productos
    private IProductRepository _productRepository;

    // Inyeccion de dependencias del repositorio de productos
    public ProductsController(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    // Registra un nuevo producto recibiendo el objeto request desde el body
    [HttpPost]
    public ActionResult<ProductDto> Post([FromBody] PostProductRequest prPostProductRequest)
    {
        Product newProduct = new Product
        {
            Name = prPostProductRequest.Name,
            Description = prPostProductRequest.Description,
            Price = prPostProductRequest.Price,
            Stock = prPostProductRequest.Stock,
            Category = prPostProductRequest.Category,
            Image = prPostProductRequest.Image,
            Active = true
        };

        _productRepository.Add(newProduct);

        return ProductDto.Create(newProduct);
    }

    // Obtiene la lista de todos los productos y los convierte a DTO
    [HttpGet]
    public ActionResult<List<ProductDto>> Get()
    {
        var result = _productRepository.List();

        return ProductDto.Create(result);
    }

    // Busca un producto por su id pasado por la ruta
    [HttpGet("{id}")]
    public ActionResult<ProductDto> GetById([FromRoute] int id)
    {
        var result = _productRepository.GetById(id);

        if (result == null)
        {
            return NotFound(); // Genera una respuesta HTTP con el codigo de estado 404 Not Found
        }

        return ProductDto.Create(result);
    }

    // Elimina un producto de la base de datos segun su id
    [HttpDelete("{id}")]
    public IActionResult Delete([FromRoute] int id)
    {
        var product = _productRepository.GetById(id);

        if (product == null)
        {
            return NotFound(); // Genera una respuesta HTTP con el codigo de estado 404 Not Found
        }

        _productRepository.Delete(product);

        return NoContent(); // Genera una respuesta HTTP con el codigo de estado 204 No Content
    }
}