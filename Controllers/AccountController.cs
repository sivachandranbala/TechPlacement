using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TechPlacement.Model;
using TechPlacement.Service.Interface;

namespace TechPlacement.Controllers
{
    public class AccountController : Controller
    {

        private IUserRepository _userRepository;

        public AccountController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Login()
        {

            return View();
        }

        public ActionResult CollegeRegister()
        {

            return View();
        }

        public ActionResult CompanyRegister()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Login(UserInfo model)
        {


            if (ModelState.IsValid)
            {
                UserInfo getUserInfo = _userRepository.GetUserDetails(model);

                string type = model.Type;

                if (getUserInfo != null && !string.IsNullOrEmpty(getUserInfo.UserId))
                {
                    Session["UserId"] = getUserInfo.UserId;
                    Session["Type"] = type;
                    if (type =="COMPANY")
                    {
                        return RedirectToAction("Index", "Dashboard");
                    }
                    else
                    {
                        return RedirectToAction("CollegeIndex", "Dashboard");
                    }
                 
                }
                else
                {
                    ModelState.AddModelError("CustomError", "Username or Password is not valid");
                    return View(model);
                }
            }


            return View(model);
        }

        [HttpPost]
        public ActionResult CollegeRegister(CollegeMasterModel model)
        {


            if (ModelState.IsValid)
            {
                int returnUserId = _userRepository.CollegeRegister(model);
              
                if (returnUserId > 0)
                {
                    return RedirectToAction("Login", "Account");
                }

                else
                {
                    ModelState.AddModelError("CustomError", "Username or Password is not valid");
                    return View(model);

                }
               
            }


            return View(model);
        }

        [HttpPost]
        public ActionResult CompanyRegister(CompanyMasterModel model)
        {


            if (ModelState.IsValid)
            {
                int returnUserId = _userRepository.CompanyRegister(model);

                if (returnUserId > 0)
                {
                    return RedirectToAction("Login", "Account");
                }

                else
                {
                    ModelState.AddModelError("CustomError", "Username or Password is not valid");
                    return View(model);

                }

            }


            return View(model);
        }
        public ActionResult LogOff()
        {
            Session["UserId"] = null;
            Response.Cookies.Add(new HttpCookie("ASP.NET_SessionId", ""));
            Session.Abandon();
            Session.Clear();
            Session.RemoveAll();
            Session.Abandon();
            return RedirectToLocal("/Account/Login");
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("Login", "Account");
        }
    }
}
