﻿using CleanArchMvc.Application.DTO;
using CleanArchMvc.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanArchMvc.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {

        private readonly ICategoryService _catService;

        public CategoriesController(ICategoryService catService)
        {
            _catService = catService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryDTO>>> Get()
        {
            var categories = await _catService.GetCategories();

            if (categories == null)
            {
                return NotFound("Categories not found.");
            }
            else
            {
                return Ok(categories);
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<CategoryDTO>> Get(int id)
        {
            var category = await _catService.GetById(id);

            if (category == null)
            {
                return NotFound("Category not found.");
            }
            else
            {
                return Ok(category);
            }
        }

    }
}




