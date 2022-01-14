using CleanArchMvc.Application.DTO;
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
    [Authorize]
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

        [HttpGet("{id:int}", Name = "GetCategory")]
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

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CategoryDTO category)
        {

            if (category == null)
            {
                return BadRequest("Invalid Data");
            }

            await _catService.Add(category);

            return new CreatedAtRouteResult("GetCategory", new { id = category.Id }, category);
        }

        [HttpPut]
        public async Task<ActionResult> Put(int id, [FromBody] CategoryDTO category)
        {
            if (id != category.Id)
            {
                return BadRequest("Invalid Data");
            }

            if (category == null)
            {
                return BadRequest();
            }

            await _catService.Update(category);

            return Ok(category);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<CategoryDTO>> Delete(int id)
        {
            var category = await _catService.GetById(id);

            if (category == null)
            {
                return NotFound("Category not found.");
            }
            await _catService.Remove(id);

            return Ok(category);
        }
    }
}




