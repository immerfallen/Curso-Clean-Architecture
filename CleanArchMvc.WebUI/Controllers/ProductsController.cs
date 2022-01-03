using CleanArchMvc.Application.DTO;
using CleanArchMvc.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanArchMvc.WebUI.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductService _prodService;
        private readonly ICategoryService _catService;

        public ProductsController(IProductService prodService, ICategoryService catService)
        {
            _prodService = prodService;
            _catService = catService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var products = await _prodService.GetProducts();
            return View(products);
        }
        [HttpGet()]

        public async Task<IActionResult> Create()
        {
            ViewBag.CategoryId = new SelectList(await _catService.GetCategories(), "Id", "Name");
            return View(ViewBag.CategotyId);
        }

        public async Task<IActionResult> Create(ProductDTO product)
        {
            if (ModelState.IsValid)
            {
                await _prodService.Add(product);
                return RedirectToAction(nameof(Index));
            }
            
            return View(product);
        }
    }
}
