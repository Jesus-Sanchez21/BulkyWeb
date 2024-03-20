using Bulky.DataAccess.Data;
using Bulky.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Bulky.DataAccess.Repository.IRepository;
using Bulky.DataAccess.Repository;
using Microsoft.AspNetCore.Authorization;
using Bulky.Utility;

namespace BulkyWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    //[Authorize(Roles = SD.Role_Admin)]
    public class CategoryController : Controller
    {
        //Instance to get data from ApplicationDbContext

        private readonly IUnitOfWork _unitOfWork;
        public CategoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        //Action Methods
        public IActionResult Index()
        {
            //Criar a listagem(sem passar à view ainda)
            List<Category> objCategoryList = _unitOfWork.Category.GetAll().ToList();
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
                _unitOfWork.Category.Add(obj);
                _unitOfWork.Save();
                TempData["Success"] = "Created Successfully";
                return RedirectToAction("Index", "Category");
            }

            return View();
        }

        //----- Edit ---------------------------------------------------------------------------

        //Action Method to edit catergory
        public IActionResult Edit(int? id) //Para criar a view clicar em rato direito e add view
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Category? categoryFromDb = _unitOfWork.Category.Get(u => u.Id == id); //Só funciona em Id
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
                _unitOfWork.Category.Update(obj);
                _unitOfWork.Save();
                TempData["Success"] = "Updated Successfully";
                return RedirectToAction("Index", "Category");
            }

            return View();
        }

        //----- Delete ---------------------------------------------------------------------------

        //Action Method to delete catergory
        public IActionResult Delete(int? id) //Para criar a view clicar em rato direito e add view
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Category? categoryFromDb = _unitOfWork.Category.Get(u => u.Id == id);
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
            Category? obj = _unitOfWork.Category.Get(u => u.Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            _unitOfWork.Category.Remove(obj);
            _unitOfWork.Save();
            TempData["Success"] = "Deleted Successfully";
            return RedirectToAction("Index", "Category");
        }
    }
}
