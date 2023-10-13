using Microsoft.AspNetCore.Mvc.Rendering;


namespace Bookworm.Models.ViewModels

{
    public class BookViewModel
    {
        public Book Book { get; set; }
        public IEnumerable<SelectListItem> CategoryList { get; set; }
    }
}
