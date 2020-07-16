
using ShooesStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShooesStore.Controllers
{
    public class HomeController : Controller
    {
        ShoesContext dbContext = new ShoesContext();
        public int pageSize = 4;
        [Authorize]
        public ActionResult Index(string shoesType,int page =1)
        {
            ShoesListViewModel model = new ShoesListViewModel
            {
                Shoess = dbContext.Shoess
                .Where(b => shoesType == null || b.ShoesType == shoesType)
                .OrderBy(shoes => shoes.ShoesId)
                .Skip((page - 1) * pageSize)
                .Take(pageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemPerPage = pageSize,
                    TotalItems = shoesType == null? dbContext.Shoess.Count() 
                    : dbContext.Shoess.Where(shoes => shoes.ShoesType == shoesType).Count()
                },
                CurrentShoesType = shoesType
            };

            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        public ActionResult GetCreate()
        {
            return View("Create");
        }
        [HttpPost]
        public ActionResult Create(Shoes sh)
        {
            dbContext.Shoess.Add(sh);
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}