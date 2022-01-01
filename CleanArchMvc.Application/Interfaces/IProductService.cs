﻿using CleanArchMvc.Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMvc.Application.Interfaces
{
    public interface IProductService
    {
        Task<ProductDTO> GetById(int? id);

        Task<IEnumerable<ProductDTO>> GetProducts();

        //Task<ProductDTO> GetProductCategory(int? id);

        Task Add(ProductDTO productDto);

        Task Update(ProductDTO productDto);

        Task Remove(int? id);
    }
}
