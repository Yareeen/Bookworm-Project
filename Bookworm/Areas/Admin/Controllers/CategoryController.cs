using Bookworm.Data.Repository.IRepository;
using Bookworm.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Bookworm.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {

        private readonly IUnitOfWork _unitOfWork;

        public CategoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            IEnumerable<Category> CategoryList = _unitOfWork.Category.GetAll();
            return View(CategoryList);
        }

        //Creat Action
        [Authorize(Roles="Admin")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Category category)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Category.Add(category);
                _unitOfWork.Save();
                return RedirectToAction("Index");
                //Indexe geri dönüş yapar.
            }
            return View(category);
        }





        [Authorize(Roles = "Admin")]
        public IActionResult Edit(int? id)
        {
            if (id == null || id <= 0)
            {
                return NotFound();
            }
            var category = _unitOfWork.Category.GetFirstOrDefault(x => x.ID == id);

            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Category.Update(category);
                _unitOfWork.Save();
                return RedirectToAction("Index");
            }
            return View(category);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int id)
        {
            if (id == null || id <= 0)
            {
                return NotFound();
            }
            var category = _unitOfWork.Category.GetFirstOrDefault(x => x.ID == id);

            if (category == null)
            {
                return NotFound();
            }
            _unitOfWork.Category.Remove(category);
            _unitOfWork.Save();
            return RedirectToAction("Index");
        }



    }
}
