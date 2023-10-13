using Bookworm.Data.Repository.IRepository;
using Bookworm.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Bookworm.Areas.Reviewer.Controllers
{
    [Area("Reviewer")]
    public class HomeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public HomeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            IEnumerable<Book> booklist = _unitOfWork.Book.GetAll(includeProperties: "Category");
            return View(booklist);
        }


        public IActionResult Details(int bookId)
        {
            CommantBook Book = new CommantBook()
            {

                Book_ID = bookId,
                Book = _unitOfWork.Book.GetFirstOrDefault(p => p.ID == bookId, includeProperties: "Category"),
            };

            return View(Book);
        }

        [HttpPost]
        [Authorize]
        public IActionResult Details(CommantBook commant)
        {
            var claimIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimIdentity.FindFirst(ClaimTypes.NameIdentifier);
            commant.Reader_ID = claim.Value;
            CommantBook commantdb = _unitOfWork.CommantBook.GetFirstOrDefault(p => p.Reader_ID == claim.Value && p.Book_ID == commant.Book_ID);
            if (commantdb == null)
            {
                _unitOfWork.CommantBook.Add(commant);
                _unitOfWork.Save();
              
            }
      
            _unitOfWork.Save();
            
            return RedirectToAction("Index");
        }

       
       
        [HttpPost]
        public IActionResult Yorum(int id) { 
            if(id==null || id <= 0)
            {
                return NotFound();
            }

            var yor = _unitOfWork.CommantBook.GetFirstOrDefault(p => p.Book_ID == id);
            if(yor == null)
            {
                return NotFound();
            }

            return View(yor);
        }


        public IActionResult Yorum(CommantBook book)
        {
        
            _unitOfWork.CommantBook.Update(book);
            _unitOfWork.Save();
            return RedirectToAction("Details");
        }

    }






}
