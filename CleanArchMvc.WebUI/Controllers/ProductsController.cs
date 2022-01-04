using CleanArchMvc.Application.DTO;
using CleanArchMvc.Application.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CleanArchMvc.WebUI.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductService _prodService;
        private readonly ICategoryService _catService;
        private readonly IWebHostEnvironment _enviroment;

        public ProductsController(IProductService prodService, ICategoryService catService, IWebHostEnvironment enviroment)
        {
            _prodService = prodService;
            _catService = catService;
            _enviroment = enviroment;
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

        [HttpPost]
        public async Task<IActionResult> Create(ProductDTO product)
        {
            if (ModelState.IsValid)
            {
                await _prodService.Add(product);
                return RedirectToAction(nameof(Index));
            }
            
            return View(product);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var productDto = await _prodService.GetById(id);

            if (productDto == null) return NotFound();

            var categories = await _catService.GetCategories();

            ViewBag.CategoriesId = new SelectList(categories, "Id", "Name", productDto.CategoryId);

            return View(productDto);
            
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ProductDTO product)
        {
            if (ModelState.IsValid)
            {
                await _prodService.Update(product);
                return RedirectToAction(nameof(Index));
            }

            return View(product);
        }

        [HttpGet()]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var productDto = await _prodService.GetById(id);
            if (productDto == null) return NotFound();

            return View(productDto);
        }

        [HttpPost(), ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _prodService.Remove(id);
            return RedirectToAction("Index");
        }

        [HttpGet()]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var productDto = await _prodService.GetById(id);
            if (productDto == null) return NotFound();

            var wwwroot = _enviroment.WebRootPath;
            var image = Path.Combine(wwwroot, "images\\" + productDto.Image);
            var exists = System.IO.File.Exists(image);
            ViewBag.ImageExist = exists;

            return View(productDto);
        }
    }
}
