using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AST_ynov.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ListGivenCode(string email, string password)
        {
            if (email == "benoit.garreau@ynov.com" && password == "XXXXXXXXXX")
            {
                using (Entities context = new Entities())
                {
                    ViewBag.DistributedTokens = (from tok in context.Tokens.Include("User")
                                                 where tok.User != null
                                                 select tok).ToList();
                    ViewBag.AvailableTokens = (from tok in context.Tokens.Include("User")
                                               where tok.User == null
                                               select tok).ToList();
                }

                return View();
            }

            return View("Error");
        }
    }
}