using Microsoft.AspNetCore.Mvc;
using SITE.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SITE.Areas.User.Controllers
{
    public class OrderController : Controller
    {
        private readonly DataManager dataManager;
        public OrderController(DataManager dataManager)
        {
            this.dataManager = dataManager;
        }

        public IActionResult Index(Guid id)
        {
            if (id != default)
            {
                return View("Show", dataManager.Order.GetOrderById(id));
            }
            //ViewBag.TextField = dataManager.TextFields.GetTextFieldByCodeWord("PageServices");
            return View(dataManager.Order.GetOrder());
        }
    }
}
