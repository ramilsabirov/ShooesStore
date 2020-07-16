using ShooesStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShooesStore.Controllers
{
    public class CartController : Controller
    {
        ShoesContext dbContext = new ShoesContext();
        EmailOrderProcessor emailSettings = new EmailOrderProcessor(new EmailSettings());
        public ViewResult Index(Cart cart, string returnUrl)
        {

            return View(new CartIndexViewModel
            {
                Cart = cart,
                ReturnUrl = returnUrl
            });
        }


        public RedirectToRouteResult AddToCart(Cart cart, int shoesId, string returnUrl)
        {
            Shoes shoes = dbContext.Shoess
                .FirstOrDefault(b => b.ShoesId == shoesId);
            if (shoes != null)
            {
                cart.AddItem(shoes, 1);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        public RedirectToRouteResult RemoveFromCart(Cart cart, int shoesId, string returnUrl)
        {
            Shoes shoes = dbContext.Shoess
                .FirstOrDefault(b => b.ShoesId == shoesId);
            if (shoes != null)
            {
                cart.RemoveLine(shoes);
            }
            return RedirectToAction("Index");
        }

        public PartialViewResult Summary(Cart cart)
        {

            return PartialView(cart);
        }


        public ViewResult Checkout()
        {
            return View(new ShippingDetails());
        }

        [HttpPost]
        public ViewResult Checkout(Cart cart, ShippingDetails shipingDetails)
        {
            if (cart.Lines.Count() == 0)
            {
                ModelState.AddModelError("", "Извените, корзина пуста");
            }
            if (ModelState.IsValid)
            {
                emailSettings.ProcessOrder(cart, shipingDetails);
                cart.Clear();
                return View("Completed");
            }
            return View(new ShippingDetails());
        }
    }
}