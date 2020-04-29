using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Models;
using AutoMapper;
using BLL.DTOs;
using BLL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productsService;
        private readonly IMapper _mapper;
        public ProductsController(IProductService productService)
        {
            _productsService = productService;
            _mapper = new MapperConfiguration(x => x.CreateMap<ProductDTO, ProductModel>()).CreateMapper();
        }

        [HttpGet]
        public async Task<IEnumerable<ProductModel>> GetAllProducts()
        {
            var productDTOs = await _productsService.GetAllAsync();
            return _mapper.Map<IEnumerable<ProductDTO>, IEnumerable<ProductModel>>(productDTOs);
        }
    }
}