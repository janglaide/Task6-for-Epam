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

        public IEnumerable<ProductDTO> GetAll()
        {
            return _mapper.Map<IEnumerable<Product>, IEnumerable<ProductDTO>>(_uow.Products.GetAll());
        }

        public async Task<IEnumerable<ProductDTO>> GetAllAsync()
        {
            var orders = await _uow.Products.GetAllAsync();
            return _mapper.Map<IEnumerable<Product>, IEnumerable<ProductDTO>>(orders);
        }

        /*public Task<IEnumerable<Product>> GetAllByOrderAsync(int orderId)
        {
            throw new NotImplementedException();
        }

        public Task<ProductDTO> GetProductById(int id)
        {
            throw new NotImplementedException();
        }*/
    }
}
