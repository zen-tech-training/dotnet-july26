using AutoMapper;
using Ops.Application.DTOs.Product;
using Ops.Application.Interfaces;
using Ops.Domain.Entities;

namespace Ops.Application.Services;

public class ProductService : IProductService
{
    private readonly IProductRepository _repository;
    private readonly IMapper _mapper;

    public ProductService(
        IProductRepository repository,
        IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<ProductDto>> GetAllAsync(
        CancellationToken cancellationToken = default)
    {
        var products =
            await _repository.GetAllAsync(cancellationToken);

        return _mapper.Map<IEnumerable<ProductDto>>(products);
    }

    public async Task<ProductDto?> GetByIdAsync(
        int id,
        CancellationToken cancellationToken = default)
    {
        var product =
            await _repository.GetByIdAsync(id, cancellationToken);

        return product == null
            ? null
            : _mapper.Map<ProductDto>(product);
    }

    public async Task<ProductDto> CreateAsync(
        CreateProductDto dto,
        CancellationToken cancellationToken = default)
    {
        if (await _repository.ExistsSkuAsync(dto.SKU, cancellationToken))
            throw new InvalidOperationException(
                $"SKU '{dto.SKU}' already exists.");

        var product = _mapper.Map<Product>(dto);

        await _repository.AddAsync(product, cancellationToken);

        await _repository.SaveChangesAsync(cancellationToken);

        return _mapper.Map<ProductDto>(product);
    }

    public async Task UpdateAsync(
        int id,
        UpdateProductDto dto,
        CancellationToken cancellationToken = default)
    {
        var product =
            await _repository.GetByIdAsync(id, cancellationToken);

        if (product == null)
            throw new KeyNotFoundException(
                $"Product {id} not found.");

        _mapper.Map(dto, product);

        _repository.Update(product);

        await _repository.SaveChangesAsync(cancellationToken);
    }

    public async Task PatchAsync(
        int id,
        PatchProductDto dto,
        CancellationToken cancellationToken = default)
    {
        var product =
            await _repository.GetByIdAsync(id, cancellationToken);

        if (product == null)
            throw new KeyNotFoundException(
                $"Product {id} not found.");

        _mapper.Map(dto, product);

        _repository.Update(product);

        await _repository.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteAsync(
        int id,
        CancellationToken cancellationToken = default)
    {
        var product =
            await _repository.GetByIdAsync(id, cancellationToken);

        if (product == null)
            throw new KeyNotFoundException(
                $"Product {id} not found.");

        _repository.Delete(product);

        await _repository.SaveChangesAsync(cancellationToken);
    }
}