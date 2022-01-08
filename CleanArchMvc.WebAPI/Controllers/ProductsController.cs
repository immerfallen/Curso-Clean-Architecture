using CleanArchMvc.Application.DTO;
using CleanArchMvc.Application.Interfaces;
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
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _prodService;

        public ProductsController(IProductService prodService)
        {
            _prodService = prodService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> Get()
        {
            var products = await _prodService.GetProducts();

            if (products == null)
            {
                return NotFound("Products not found.");
            }
            else
            {
                return Ok(products);
            }
        }

        [HttpGet("{id:int}", Name = "GetProduct")]
        public async Task<ActionResult<ProductDTO>> Get(int id)
        {
            var product = await _prodService.GetById(id);

            if (product == null)
            {
                return NotFound("Product not found.");
            }
            else
            {
                return Ok(product);
            }
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ProductDTO product)
        {

            if (product == null)
            {
                return BadRequest("Invalid Data");
            }

            await _prodService.Add(product);

            return new CreatedAtRouteResult("GetProduct", new { id = product.Id }, product);
        }


        [HttpPut]
        public async Task<ActionResult> Put(int id, [FromBody] ProductDTO product)
        {
            if (id != product.Id)
            {
                return BadRequest("Invalid Data");
            }

            if (product == null)
            {
                return BadRequest();
            }

            await _prodService.Update(product);

            return Ok(product);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<ProductDTO>> Delete(int id)
        {
            var product = await _prodService.GetById(id);

            if (product == null)
            {
                return NotFound("Category not found.");
            }
            await _prodService.Remove(id);

            return Ok(product);
        }
    }
}
