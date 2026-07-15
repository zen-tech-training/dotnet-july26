using Microsoft.AspNetCore.Mvc;
using Ops.Application.DTOs.Product;
using Ops.Application.Interfaces;

namespace Ops.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductsController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll(
        CancellationToken cancellationToken)
    {
        var products =
            await _productService.GetAllAsync(cancellationToken);

        return Ok(products);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(
        int id,
        CancellationToken cancellationToken)
    {
        var product =
            await _productService.GetByIdAsync(
                id,
                cancellationToken);

        if (product == null)
            return NotFound();

        return Ok(product);
    }

    [HttpPost]
    public async Task<IActionResult> Create(
        CreateProductDto dto,
        CancellationToken cancellationToken)
    {
        var product =
            await _productService.CreateAsync(
                dto,
                cancellationToken);

        return CreatedAtAction(
            nameof(GetById),
            new { id = product.Id },
            product);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(
        int id,
        UpdateProductDto dto,
        CancellationToken cancellationToken)
    {
        await _productService.UpdateAsync(
            id,
            dto,
            cancellationToken);

        return NoContent();
    }

    [HttpPatch("{id:int}")]
    public async Task<IActionResult> Patch(
        int id,
        PatchProductDto dto,
        CancellationToken cancellationToken)
    {
        await _productService.PatchAsync(
            id,
            dto,
            cancellationToken);

        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(
        int id,
        CancellationToken cancellationToken)
    {
        await _productService.DeleteAsync(
            id,
            cancellationToken);

        return NoContent();
    }
}