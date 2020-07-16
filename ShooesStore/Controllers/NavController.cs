using ShooesStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShooesStore.Controllers
{
    public class NavController : Controller
    {
        // GET: Nav

        ShoesContext dbContext = new ShoesContext();


        public PartialViewResult Menu(string shoesType = null)
        {
            ViewBag.SelectedshoesType = shoesType;

            List<string> shType = dbContext.Shoess
                .Select(x => x.ShoesType)
                .Distinct()
                .OrderBy(x => x).ToList();

            return PartialView(shType);
        }
        //.OrderBy(x => x) .... 123456
        //.OrderByDescending(x => x) .... 654321
    }
}