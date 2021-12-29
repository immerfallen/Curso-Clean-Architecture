﻿using CleanArchMvc.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMvc.Application.Products.Commands
{
    class ProductRemoveCommand : IRequest<Product> 
    {
        public ProductRemoveCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
        
    }
}
