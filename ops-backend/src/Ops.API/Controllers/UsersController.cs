using Microsoft.AspNetCore.Mvc;
using Ops.Application.DTOs.Product;
using Ops.Application.DTOs.User;
using Ops.Application.Interfaces;
using Ops.Domain.Entities;

namespace Ops.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public UsersController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        //[HttpGet]
        //public async Task<IActionResult> GetAll(CancellationToken token)
        //{
        //    var users =
        //        await _unitOfWork.Users.GetAllAsync(token);


        //    var userDtos = users.Select(p => new UserDto
        //    {
        //        Id = p.Id,
        //        Name = p.Name,
        //        Description = p.Description,
        //        Price = p.Price,
        //        StockQuantity = p.StockQuantity,
        //        SKU = p.SKU
        //    });

        //    return Ok(productDtos);


        //    //return Ok(products);
        //    //return Ok();
        //}

        //[HttpGet("{id}")]
        //public async Task<IActionResult> Get(int id, CancellationToken token)
        //{
        //    var product =
        //        await _unitOfWork.Products.GetByIdAsync(id, token);

        //    if (product == null)
        //        return NotFound();

        //    //return Ok(product);
        //    //return Ok(productDto);
        //    return Ok();
        //}

        [HttpPost]
        public async Task<IActionResult> Create(
            CreateUserDto dto, CancellationToken token)
        {

            //Need Automapper - _mapper.Map<Product>(dto);
            var user = new User
            {
                UserName = dto.UserName,
                Password = dto.Password,
                Role = dto.Role,
                MobileNumber = dto.MobileNumber,
                Email = dto.Email
            };

            await _unitOfWork.Users.AddAsync(user, token);

            await _unitOfWork.SaveAsync();

            return Ok();
            //return CreatedAtAction(
                //nameof(Get),
                //new { id = user.Id },
                //user //Return DTO
           //);
        }

        
    }
}
