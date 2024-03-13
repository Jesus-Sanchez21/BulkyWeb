using BulkyWebRazor_Temp.Data;
using BulkyWebRazor_Temp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BulkyWebRazor_Temp.Pages.Categories
{
    public class IndexModel : PageModel
    {
        //Constructor to display categories:
        private readonly ApplicationDbContext _db;
        public List<Category> CategoryList { get; set; }
        //constructor
        public IndexModel(ApplicationDbContext db)
        {
            _db = db; 
        }


        public void OnGet() //OnGet is required
        {
            CategoryList = _db.Categories.ToList();
        }
    }
}
