﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OrnekSite.DataAccess.Repository.IRepository;
using OrnekSite.Diger;
using OrnekSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrnekSite.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]
    public class CategoryController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public CategoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            return View();
        }    
        public IActionResult Upsert(int? id)
        {
            Category category = new Category();
            if (id == null)
            {                
                return View(category);
            }

            category = _unitOfWork.Category.Get(id.GetValueOrDefault());
            if (category == null)
            {
                return NotFound();
            }
            return View(category);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(Category category)
        {
            if (ModelState.IsValid)
            {
                if (category.Id == 0)
                {
                    _unitOfWork.Category.Add(category);

                }
                else
                {
                    _unitOfWork.Category.Update(category);
                }
                _unitOfWork.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var nesne = _unitOfWork.Category.Get(id);
            if (nesne == null)
            {
                return Json(new { success = false, message = "Silme işlemi başarısız" });
            }
            _unitOfWork.Category.Remove(nesne);
            _unitOfWork.Save();
            return Json(new { success = true, message = "Silme işlemi başarılı" });
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var nesne = _unitOfWork.Category.GetAll();
            return Json(new { data = nesne });
        }
    }
}
