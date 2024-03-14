using Bulky.DataAccess.Data;
using Bulky.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Bulky.DataAccess.Repository.IRepository;
using Bulky.DataAccess.Repository;

namespace BulkyWeb.Controllers
{
    public class CategoryController : Controller
    {
        //Instance to get data from ApplicationDbContext

        private readonly ICategoryRepository _categoryRepo;
        public CategoryController(ICategoryRepository db) {
            _categoryRepo = db;
        }

        //Action Methods
        public IActionResult Index()
        {
            //Criar a listagem(sem passar à view ainda)
            List<Category> objCategoryList = _categoryRepo.GetAll().ToList();
            return View(objCategoryList); //Aplicar à view
        }

        //Action Method to add catergory
        public IActionResult Create() //Para criar a view clicar em Create rato direito e add view
        {

            return View(); 
        }

        [HttpPost]
        public IActionResult Create(Category obj)
        {
            //if (obj.Name == obj.DisplayOrder.ToString())
            //{
            //    ModelState.AddModelError("name", "The Display Order cannot match Name");
            //}

            if (ModelState.IsValid) //Examina as validações dentro de Category MODEL
            {
                _categoryRepo.Add(obj);
                _categoryRepo.Save();
                TempData["Success"] = "Created Successfully";
                return RedirectToAction("Index", "Category");
            }

            return View();
        }

        //----- Edit ---------------------------------------------------------------------------

        //Action Method to edit catergory
        public IActionResult Edit( int? id) //Para criar a view clicar em Create rato direito e add view
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }
            Category? categoryFromDb = _categoryRepo.Get(u=>u.Id==id); //Só funciona em Id
            //Category? categoryFromDb2 = _db.Categories.FirstOrDefault( u=>u.Id == id); //Only workds on primary keys
            //Category? categoryFromDb3 = _db.Categories.Where( u=>u.Id == id).FirstOrDefault;


            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }

        [HttpPost]
        public IActionResult Edit(Category obj)
        {
            if (ModelState.IsValid) //Examina as validações dentro de Category MODEL
            {
                _categoryRepo.Update(obj);
                _categoryRepo.Save();
                TempData["Success"] = "Updated Successfully";
                return RedirectToAction("Index", "Category");
            }

            return View();
        }

        //----- Delete ---------------------------------------------------------------------------

        //Action Method to delete catergory
        public IActionResult Delete(int? id) //Para criar a view clicar em Create rato direito e add view
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Category? categoryFromDb = _categoryRepo.Get(u => u.Id == id);
            //Category? categoryFromDb2 = _db.Categories.FirstOrDefault( u=>u.Id == id); //Only workds on primary keys
            //Category? categoryFromDb3 = _db.Categories.Find(id);


            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            Category? obj = _categoryRepo.Get(u => u.Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            _categoryRepo.Remove(obj);
            _categoryRepo.Save();
            TempData["Success"] = "Deleted Successfully";
            return RedirectToAction("Index", "Category");
        }
    }
}
