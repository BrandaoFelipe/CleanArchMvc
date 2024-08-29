using Application.DTOs;
using Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    [Authorize]
    public class CategoriesController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }


        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var result = await _categoryService.GetAllCategories();
            return View(result);
        }

        [HttpGet()]
        public IActionResult Create()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoryDTO = await _categoryService.GetCategoryById(id);

            if (categoryDTO == null)
            {
                return NotFound();
            }
            return View(categoryDTO);
        }

        [HttpPost]
        public async Task<ActionResult> Create(CategoryDTO categoryDTO)
        {
            if (ModelState.IsValid)
            {
                await _categoryService.Add(categoryDTO);
                return RedirectToAction(nameof(Index));
            }

            return View(categoryDTO);

        }

        [HttpGet()]
        public async Task<IActionResult> Edit(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            var categoryDTO = await _categoryService.GetCategoryById(id);
            if(categoryDTO == null)
            {
                return NotFound();
            }
            return View(categoryDTO);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(CategoryDTO categoryDTO)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _categoryService.Update(categoryDTO);
                }
                catch (Exception)
                {
                    throw;
                } 

                return RedirectToAction(nameof(Index));
            }
            return View(categoryDTO);
        }
        [Authorize("Admin")]
        [HttpGet()]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var categoryDTO = await _categoryService.GetCategoryById(id);
            if (categoryDTO == null)
            {
                return NotFound();
            }
            return View(categoryDTO);
        }
        
        [HttpPost(), ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {            
                try
                {
                    await _categoryService.Delete(id);
                }
                catch (Exception)
                {
                    throw;
                }            

            return RedirectToAction(nameof(Index));
        }


    }
}
