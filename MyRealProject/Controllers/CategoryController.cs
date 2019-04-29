using MyRealProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyRealProject.Repository;
using MyRealProject.Class;

namespace MyRealProject.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _repository;

        public CategoryController(ICategoryRepository repository)
        {
            _repository = repository;
        }

        public ActionResult Index()
        {
            var model = _repository.GetAll().ToList();
            return View(model);
        }
        [HttpGet]
        public ActionResult CategoryInsert()
        {
            return View();
        }
        [HttpPost]
        public JsonResult CategoryInsert(Category category) 
        {
            try
            {
                _repository.Insert(category);
                _repository.Save();
                return Json(new ResultJson {Success = true, Message = "Has been added"});
            }
            catch (Exception ex)
            {
                ViewBag.ex = ex;
                return Json(new ResultJson {Success = false, Message = "Hasn't been added"});
            }
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            Category category = _repository.GetById(id);
            if (category !=null)
            {
                return View(category);
            }
            return View();
        }

        [HttpPost]
        public JsonResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                Category currentCategory = _repository.GetById(category.Id);
                currentCategory.CategoryName = category.CategoryName;
                currentCategory.News = category.News;
                currentCategory.IsActive = category.IsActive;
                currentCategory.URL = category.URL;
                _repository.Save();
                return Json(new ResultJson { Success = true, Message = "Successful editing works" });
            }
            return Json(new ResultJson { Success = false, Message = "An error occurred during the editing process" });
        }

       


        public JsonResult Delete(int id)
        {
            Category category = _repository.GetById(id);
            if (category == null)
            {
                return Json(new ResultJson { Success = false, Message = "Category not found" });
            }

            _repository.Delete(id);
            _repository.Save();
            return Json(new ResultJson { Success = true, Message = "Category deletion successful" });

        }

    }
}