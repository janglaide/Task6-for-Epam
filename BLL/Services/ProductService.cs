using AutoMapper;
using BLL.DTOs;
using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace BLL.Services
{
    public class ProductService : IService<ProductDTO>
    {
        private IUnitOfWork _uow;
        public ProductService(IUnitOfWork unitOfWork)
        {
            _uow = unitOfWork;
        }
        public void Add(ProductDTO item)
        {
            var newItem = new Product
            {
                Id = item.Id,
                Name = item.Name,
                Price = item.Price
            };
            _uow.Products.Add(newItem);
            _uow.Save();
        }

        public ProductDTO Get(int id)
        {
            var mapper = new MapperConfiguration(x => x.CreateMap<Product, ProductDTO>()).CreateMapper();
            return mapper.Map<Product, ProductDTO>(_uow.Products.Get(id));
        }

        public IEnumerable<ProductDTO> GetAll()
        {
            var mapper = new MapperConfiguration(x => x.CreateMap<Product, ProductDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Product>, IEnumerable<ProductDTO>>(_uow.Products.GetAll());
        }
    }
}
