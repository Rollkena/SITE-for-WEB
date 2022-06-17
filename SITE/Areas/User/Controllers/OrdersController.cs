using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyCompany.Service;
using SITE.Domain;
using SITE.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SITE.Areas.User.Controllers
{
    [Area("User")]
    public class OrdersController : Controller
    {
        private readonly DataManager dataManager;
        private readonly IWebHostEnvironment hostingEnvironment;
        public OrdersController(DataManager dataManager, IWebHostEnvironment hostingEnvironment)
        {
            this.dataManager = dataManager;
            this.hostingEnvironment = hostingEnvironment;
        }


        public IActionResult Edit(Guid id)
        {
            var entity = id == default ? new Order() : dataManager.Orders.GetOrderById(id);
            return View(entity);
        }
        [HttpPost]
        public IActionResult Edit(Order model)
        {
            if (ModelState.IsValid)
            {
                dataManager.Orders.SaveOrder(model);
                return RedirectToAction(nameof(HomeController.Index), nameof(HomeController).CutController());
            }
            return View(model);
        }
        [HttpPost]
        public IActionResult Delete(Guid id)
        {
            dataManager.Orders.DeleteOrder(id);
            return RedirectToAction(nameof(HomeController.Index), nameof(HomeController).CutController());
        }


        public IActionResult Index(Guid id)
        {
            if (id != default)
            {
                return View("Show", dataManager.Orders.GetOrderById(id));
            }
            //ViewBag.TextField = dataManager.TextFields.GetTextFieldByCodeWord("PageServices");
            return View(dataManager.Orders.GetOrders());
        }
    }
}
