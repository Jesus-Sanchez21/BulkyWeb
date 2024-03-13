using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BulkyWebRazor_Temp.Data;
using BulkyWebRazor_Temp.Models;

namespace BulkyWebRazor_Temp.Pages.Categories
{
    [BindProperties]
    public class EditModel : PageModel
    {
        //Constructor to display categories:
        private readonly ApplicationDbContext _db;


        public Category Category { get; set; } //Só se usa uma categoria, sendo assim não é list
        //constructor
        public EditModel(ApplicationDbContext db)
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
            if (ModelState.IsValid) //Examina as validações dentro de Category MODEL
            {
                _db.Categories.Update(Category);
                _db.SaveChanges();
                //TempData["Success"] = "Updated Successfully";
                return RedirectToPage("Index");
            }
            return Page();
            
        }
    }
}
