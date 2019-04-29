using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyRealProject.Class;
using MyRealProject.Filters;
using MyRealProject.Models;
using MyRealProject.Repository;

namespace MyRealProject.Controllers
{
    public class NewsController : Controller
    {
        private readonly INewsRepository _newsRepository;
        private readonly IUserRepository _userRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IPictureRepository _pictureRepository;

        public NewsController(INewsRepository newsRepository, IPictureRepository pictureRepository, IUserRepository userRepository, ICategoryRepository categoryRepository)
        {
            _newsRepository = newsRepository;
            _userRepository = userRepository;
            _categoryRepository = categoryRepository;
            _pictureRepository = pictureRepository;
        }

        // GET: News
        public ActionResult Index()
        {
            var model = _newsRepository.GetAll().ToList() ;
            return View(model);
        }

        [HttpGet]
        [LoginFilter]
        public ActionResult NewsAdd()
        {
            return View();
        }

        [HttpPost]
        [LoginFilter]
        [ValidateInput(false)]
        public ActionResult NewsAdd(News news, HttpPostedFileBase uploadFile, IEnumerable<HttpPostedFileBase> uploadFiles)
        {
            var session = HttpContext.Session["Admin"];

            if (ModelState.IsValid)
            {
                User user = _userRepository.GetById(Convert.ToInt32(session));
                news.UserId = user.Id;
                if (uploadFile != null)
                {
                    string filename = Guid.NewGuid().ToString().Replace("-", "");
                    string extension = Path.GetExtension(uploadFile.FileName);
                    string fullPath = "/Content/Upload/News/" + filename + extension;
                    uploadFile.SaveAs(Server.MapPath(fullPath));
                    news.İmage = fullPath;
                }
                _newsRepository.Insert(news);
                _newsRepository.Save();

                string manyImages = Path.GetExtension(Request.Files[1].FileName);
                if (manyImages != "")
                {
                    foreach (var file in uploadFiles)
                    {
                        if (file.ContentLength > 0)
                        {
                            string filename = Guid.NewGuid().ToString().Replace("-", "");
                            string extension = Path.GetExtension(file.FileName);
                            string fullPath = "/Content/Upload/News/" + filename + extension;
                            file.SaveAs(Server.MapPath(fullPath));

                            var pic = new Picture
                            {
                                ImageUrl = fullPath 

                            };

                            pic.NewsId = news.Id;
                            _pictureRepository.Insert(pic);
                            _pictureRepository.Save();
                        }
                    }
                }

                TempData["Information"] = "Adding news successful";
                return RedirectToAction("Index", "News");
            }

            TempData["Information"] = "Adding news was not successful";
            return View();
        }




        public JsonResult Delete(int id)
        {
            News currentNews = _newsRepository.GetById(id);
            var images = _pictureRepository.GetMany(x => x.NewsId == id);
            if (currentNews == null)
            {
                return Json(new ResultJson { Success = false, Message = "News not found" });
            }

            string fileName = currentNews.İmage;
            string path = Server.MapPath(fileName);
            FileInfo file = new FileInfo(path);
            if (file.Exists)
            {
                file.Delete();
            }
            if (images != null)
            {
                foreach (var item in images)
                {
                    string imagesPath = Server.MapPath(item.ImageUrl);
                    FileInfo files = new FileInfo(imagesPath);
                    if (files.Exists)
                    {
                        files.Delete();
                    }
                }
            }

            _newsRepository.Delete(id);
            _newsRepository.Save();
            return Json(new ResultJson { Success = true, Message = "News deletion successful" });
        }


        public ActionResult ActivePassive(int id)
        {
            News currentNews = _newsRepository.GetById(id);
            if (currentNews.IsActive)
            {
                currentNews.IsActive = false;
                _newsRepository.Save();
                TempData["Information"] = "News is passive";
                return RedirectToAction("Index");
            }
            else if (currentNews.IsActive == false)
            {
                currentNews.IsActive = true;
                _newsRepository.Save();
                TempData["Information"] = "News is active";
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}