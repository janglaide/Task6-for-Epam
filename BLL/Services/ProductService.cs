using AutoMapper;
using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using BLL.Interfaces;
using System.Threading.Tasks;
using BLL.DTOs;

namespace BLL.Services
{
    public class ProductService : IProductService
    {
        private IUnitOfWork _uow;
        private IMapper _mapper;
        public ProductService(IUnitOfWork unitOfWork)
        {
            _uow = unitOfWork;
            _mapper = new MapperConfiguration(x => x.CreateMap<Product, ProductDTO>()).CreateMapper();
        }

        public async Task AddProduct(ProductDTO productDTO)
        {
            var mapper = new MapperConfiguration(x => x.CreateMap<ProductDTO, Product>()).CreateMapper();
            var product = mapper.Map<ProductDTO, Product>(productDTO);

            await _uow.Products.AddAsync(product);
            await _uow.CommitAsync();
        }

        public async Task<IEnumerable<ProductDTO>> GetAllAsync()
        {
            var orders = await _uow.Products.GetAllAsync();
            return _mapper.Map<IEnumerable<Product>, IEnumerable<ProductDTO>>(orders);
        }

    }
}
