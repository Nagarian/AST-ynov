using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace AST_ynov.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult RequestCode(string email)
        {
            email = email.ToLowerInvariant();
            if (!Regex.IsMatch(email, @"^(([a-z]|\-)+)\.(([a-z]|\-)+)@ynov\.com$"))
            {
                return View("Error");
            }

            using (Entities context = new Entities())
            {
                bool emailUsed = (from user in context.Users
                                  where user.Email == email
                                  select user).FirstOrDefault() != null;

                if (emailUsed)
                {
                    return View("Error");
                }

                var nextToken = (from token in context.Tokens
                                    where token.User == null
                                    select token).FirstOrDefault();

                context.Users.Add(new User { Email = email, Token = nextToken, CreatedAt = DateTime.Now });
                context.SaveChanges();

                ViewBag.Token = nextToken.Token1;
                return View();
            }
        }
    }
}