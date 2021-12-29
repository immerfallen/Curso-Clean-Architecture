﻿using CleanArchMvc.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMvc.Application.DTO
{
    public class ProductDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "The name is required.")]
        [MinLength(3)]
        [MaxLength(100)]
        public string Name { get;  set; }
        [Required(ErrorMessage = "The description is required.")]
        [MinLength(5)]
        [MaxLength(100)]
        public string Description { get;  set; }
        [Required(ErrorMessage = "The price is required.")]
        [Column(TypeName="decimal(18,2)")]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        [DataType(DataType.Currency)]
        [DisplayName("Price")]
        [MaxLength(100)]
        public decimal Price { get;  set; }

        [Required(ErrorMessage = "The stock is required.")]
        [Range(1,9999)]
        [DisplayName("Stock")]
        public int Stock { get;  set; }
        [MaxLength(250)]
        [DisplayName("Product Image")]
        public string Image { get;  set; }

        public Category Category { get; set; }

        [DisplayName("Categories")]
        public int CategoryId { get; set; }
    }
}