using AutoMapper;
using CleanArchMvc.Application.DTO;
using CleanArchMvc.Application.Products.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMvc.Application.Mappings
{
    public class DTOToCommandoMappingProfile : Profile
    {
        public DTOToCommandoMappingProfile()
        {
            CreateMap<ProductDTO, ProductCreateCommand>();
            CreateMap<ProductDTO, ProductUpdateCommand>();
        }
    }
}
