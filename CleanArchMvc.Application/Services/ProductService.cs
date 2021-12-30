using AutoMapper;
using CleanArchMvc.Application.DTO;
using CleanArchMvc.Application.Interfaces;
using CleanArchMvc.Application.Products.Queries;
using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMvc.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public ProductService(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        //public async Task Add(ProductDTO productDto)
        //{
        //    var productEntity = _mapper.Map<Product>(productDto);
        //    await _productRepository.CreateAsync(productEntity);
        //}

        //public async Task<ProductDTO> GetById(int? id)
        //{
        //    var productEntity = await _productRepository.GetByIdAsync(id);
        //    return _mapper.Map<ProductDTO>(productEntity);
        //}

        //public async Task<ProductDTO> GetProductCategory(int? id)
        //{
        //    var productEntity = await _productRepository.GetProductCategoryAsync(id);
        //    return _mapper.Map<ProductDTO>(productEntity);
        //}

        public async Task<IEnumerable<ProductDTO>> GetProducts()
        {
            var productsQuery = new GetProductsQuery();

            if (productsQuery == null)
            {
                throw new ApplicationHandleException($"Entity could not be loaded.");
            }
            var result = await _mediator.Send(productsQuery);
            return _mapper.Map<IEnumerable<ProductDTO>>(result);
        }

        //public async Task Remove(int? id)
        //{
        //    var productEntity = await _productRepository.GetByIdAsync(id);
        //    await _productRepository.RemoveAsync(productEntity);
        //}

        //public async Task Update(ProductDTO productDto)
        //{

        //    var productEntity = _mapper.Map<Product>(productDto);
        //    await _productRepository.UpdateAsync(productEntity);
        //}
    }
}
