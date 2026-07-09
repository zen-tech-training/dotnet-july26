using Microsoft.AspNetCore.Mvc;
using Ops.Application.DTOs.Product;
using Ops.Application.Interfaces;
using Ops.Domain.Entities;

namespace Ops.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken token)
        {
            var products =
                await _unitOfWork.Products.GetAllAsync(token);


            var productDtos = products.Select(p => new ProductDto
            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description,
                Price = p.Price,
                StockQuantity = p.StockQuantity,
                SKU = p.SKU
            });

            return Ok(productDtos);


            //return Ok(products);
            //return Ok();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id, CancellationToken token)
        {
            var product =
                await _unitOfWork.Products.GetByIdAsync(id, token);

            if (product == null)
                return NotFound();

            //return Ok(product);
            //return Ok(productDto);
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> Create(
            CreateProductDto dto, CancellationToken token)
        {

            //Need Automapper - _mapper.Map<Product>(dto);
            var product = new Product
            {
                Name = dto.Name,
                Description = dto.Description,
                Price = dto.Price,
                StockQuantity = dto.StockQuantity,
                SKU = dto.SKU
            };

            await _unitOfWork.Products.AddAsync(product, token);

            await _unitOfWork.SaveAsync();

            return CreatedAtAction(
                nameof(Get),
                new { id = product.Id },
                product //Return DTO
           );
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(
            int id,
            UpdateProductDto dto, CancellationToken cancellationToken)
        {
            var product =
                await _unitOfWork.Products.GetByIdAsync(id, cancellationToken);

            if (product == null)
                return NotFound();

            product.Name = dto.Name;
            product.Description = dto.Description;
            product.Price = dto.Price;
            product.StockQuantity = dto.StockQuantity;
            product.SKU = dto.SKU;

            _unitOfWork.Products.Update(product, cancellationToken);

            await _unitOfWork.SaveAsync();

            return NoContent();
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> Patch(
            int id,
            ProductPatchDto dto, CancellationToken cancellationToken)
        {
            var product =
                await _unitOfWork.Products.GetByIdAsync(id, cancellationToken);

            if (product == null)
                return NotFound();

            if (dto.Name != null)    // Prefer JsonPatchDocument<ProductPatchDto>
                product.Name = dto.Name;

            if (dto.Description != null)
                product.Description = dto.Description;

            if (dto.Price.HasValue)
                product.Price = dto.Price.Value;

            if (dto.StockQuantity.HasValue)
                product.StockQuantity = dto.StockQuantity.Value;

            if (dto.SKU != null)
                product.SKU = dto.SKU;

            _unitOfWork.Products.Update(product, cancellationToken);

            await _unitOfWork.SaveAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
        {
            var product =
                await _unitOfWork.Products.GetByIdAsync(id, cancellationToken);

            if (product == null)
                return NotFound();

            _unitOfWork.Products.Delete(product, cancellationToken);

            await _unitOfWork.SaveAsync();

            return NoContent();
        }
    }
}
