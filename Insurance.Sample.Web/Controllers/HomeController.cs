using Insurance.Sample.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Insurance.Sample.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICustomerService customerService;
        private readonly IIntegrationService integrationService;

        public HomeController(
            ICustomerService customerService,
            IIntegrationService integrationService
            )
        {
            this.customerService = customerService;
            this.integrationService = integrationService;
        }

        public ActionResult Index()
        {

            //sadece db initialize olması için
            var comp = customerService.IsCustomerExists("123456789");

            return View();
        }
    }
}