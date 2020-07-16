using ShooesStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShooesStore.Controllers
{
    public class AdminController : Controller
    {
        ShoesContext dbContext = new ShoesContext();
        SelectList shoesType;

        public AdminController()
        {
            shoesType = new SelectList(new List<string>() { "Кросовки", "Ботинки", "Сапоги" });
        }

        public ViewResult Index()
        {

            return View(dbContext.Shoess.ToList());

        }

        public ViewResult Edit(int shoesId)
        {
            ViewBag.shoesType = shoesType;
            Shoes shoes = dbContext.Shoess.FirstOrDefault(sh => sh.ShoesId == shoesId);
            return View(shoes);
        }

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.shoesType = shoesType;
            return View();
        }

        [HttpPost]
        public ActionResult Create(Shoes shoes, HttpPostedFileBase upload)
        {

            Upload(upload, shoes);
            dbContext.Shoess.Add(shoes);
            dbContext.SaveChanges();
            TempData["messageCreate"] = string.Format("Товар добавлен", shoes.NameShoes);
            return RedirectToAction("Index");
        }


        public ActionResult Delete(int shoesId)
        {
            Shoes sh = dbContext.Shoess.Find(shoesId);
            if (sh != null)
            {
                dbContext.Shoess.Remove(sh);
                dbContext.SaveChanges();
                TempData["messageDelete"] = string.Format("Товар удален", sh.NameShoes);
            }

            return RedirectToAction("Index");
        }


        [HttpPost]
        public ActionResult Edit(Shoes shoes, HttpPostedFileBase upload)
        {
            if (shoes.ShoesId == 0)
            {
                dbContext.Shoess.Add(shoes);
            }
            else
            {
                Shoes dbEntry = dbContext.Shoess.Find(shoes.ShoesId);
                if (dbEntry != null)
                {
                    dbEntry.NameShoes = shoes.NameShoes;
                    dbEntry.ShoesType = shoes.ShoesType;
                    dbEntry.Manufacturer = shoes.Manufacturer;
                    dbEntry.Price = shoes.Price;
                    dbEntry.Discription = shoes.Discription;
                    Upload(upload, dbEntry);
                }
            }


            dbContext.SaveChanges();
            TempData["message"] = string.Format("Изменения информации товара \"{0}\" сохранены ", shoes.NameShoes);
            return RedirectToAction("Index");
        }


        void Upload(HttpPostedFileBase upload, Shoes shoes)
        {
            if (upload != null)
            {
                // получаем имя файла
                string fileName = System.IO.Path.GetFileName(upload.FileName);
                // сохраняем файл в папку Files в проекте
                upload.SaveAs(Server.MapPath("~/Files/" + fileName));
                shoes.ImgPath = "Files/" + fileName;
            }

        }
    }




}