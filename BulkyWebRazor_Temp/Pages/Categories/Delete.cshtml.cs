using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BulkyWebRazor_Temp.Data;
using BulkyWebRazor_Temp.Models;

namespace BulkyWebRazor_Temp.Pages.Categories
{
    [BindProperties]
    public class DeleteModel : PageModel
    {
        //Constructor to display categories:
        private readonly ApplicationDbContext _db;

        public Category Category { get; set; } //S� se usa uma categoria, sendo assim n�o � list
        
        //constructor
        public DeleteModel (ApplicationDbContext db)
        {
            _db = db;
        }


        public void OnGet(int id)
        {
            if (id != null && id != 0)
            {
                Category = _db.Categories.Find(id);
            }
        }
        public IActionResult OnPost()
        {
            Category? obj = _db.Categories.Find(Category.Id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.Categories.Remove(obj);
            _db.SaveChanges();
            TempData["Success"] = "Deleted Successfully";
            return RedirectToPage("Index");

        }
    }
}

