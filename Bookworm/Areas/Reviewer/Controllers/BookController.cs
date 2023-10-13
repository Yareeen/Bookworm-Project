using Bookworm.Data.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Bookworm.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;

namespace Bookworm.Areas.Admin.Controllers
{
    [Area("Reviewer")]
    public class BookController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public BookController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Index()
        {
            var BookList = _unitOfWork.Book.GetAll();
            return View(BookList);
        }

        //Creat And Update
        [Authorize]
        public IActionResult Crup(int? id)
        {
            //Categoryler gelmesi için view oluşturduk.
            BookViewModel bookWM = new()
            {
                Book = new(),
                CategoryList = _unitOfWork.Category.GetAll().Select(l => new SelectListItem
                {
                    Text = l.Name,
                    Value = l.ID.ToString()
                })

            };


            if (id == null || id <= 0)
            {
                return View(bookWM); //Bulunamazsa
            }
            bookWM.Book = _unitOfWork.Book.GetFirstOrDefault(x => x.ID == id);

            if (bookWM.Book == null)
            {
                return NotFound();
            }

            return View(bookWM);
        }

        [HttpPost]
        public IActionResult Crup(BookViewModel bookVM, IFormFile file)
        {

            //Resim
            string wwwRootPath = _webHostEnvironment.WebRootPath;

            if (file != null)
            {
                //Rastgele isim üretmek için
                string fileName = Guid.NewGuid().ToString();
                var uploadRoot = Path.Combine(wwwRootPath, @"img\books");
                var extension = Path.GetExtension(file.FileName);

                //edit işlemi. Resim güncellenecekse sileriz.
                if (bookVM.Book.Picture != null)
                {
                    var oldPicPath = Path.Combine(wwwRootPath, bookVM.Book.Picture);
                    if (System.IO.File.Exists(oldPicPath))
                    {
                        System.IO.File.Delete(oldPicPath);
                    }
                }

                using (var fileStream = new FileStream(Path.Combine(uploadRoot, fileName + extension),
                    FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }

                bookVM.Book.Picture = @"\img\books\" + fileName + extension;
            }


            if (bookVM.Book.ID <= 0)
            {
                _unitOfWork.Book.Add(bookVM.Book);
            }
            else
            {
                _unitOfWork.Book.Update(bookVM.Book);
            }
            _unitOfWork.Save();
            return RedirectToAction("Index" ,"Home");
          
        }


        public IActionResult Delete(int? id)
        {
            if (id == null || id <= 0)
            {
                return NotFound();
            }
            var book = _unitOfWork.Book.GetFirstOrDefault(x => x.ID == id);

            if (book == null)
            {
                return NotFound();
            }
            _unitOfWork.Book.Remove(book);
            _unitOfWork.Save();
            return RedirectToAction("Index");
        }


    }
}
