using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GamesCOM.DAL;
using GamesCOM.Models;
using System.Diagnostics;
using GamesCOM.ModelView;

namespace GamesCOM.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Register()
        {
            //returns register view
            return View(new User());
        }

        public ActionResult submitRegister(User u)
        {
            UserDal dal = new UserDal();
            //check form is valid
            if (ModelState.IsValid)
            {
                //check user name is not taken
                if (dal.checkExits(u.userName))
                {
                    //case user name taken return the register page again
                    Session["register"] = "USERNAME TAKEN TRY A DIFFRENT ONE";
                    return View("Register", u);
                }
                //encrtypt password
                string oldpass = u.password;
                u.password = Global.encrypt(u.password);

                //addes user to DB
                dal.Users.Add(u);
                dal.SaveChanges();


                u.password = oldpass;

                //make error messege null
                Session["register"] = null;
                Session["error"] = null;

                return RedirectToAction("submitLogin",u);
            }
            //case regiser not valid retuns regiser page again
            Session["register"] = "";
            Session["error"] = "";
            return View("Register",u);
        }
        public ActionResult Login()
        {
            //return the login view
            return View(new User());
        }
        public ActionResult submitLogin(User u)
        {
            //creates Dal to user
            UserDal dal = new UserDal();
            u.password = Global.encrypt(u.password);

            //check login after encrypting recived password
            u = dal.checkLogin(u);
            if (u == null)//case wrong username or password
            {
                ModelState.AddModelError("", "User name or password invalid");
                Session["error"] = "INVALID USERNAME OR PASSWORD";
                
                return View("Login",new User());
            }
            else//case username and password valid
            {
                //makes new shopping cart and resets global displey variables
                Global.cart = new List<Game>();
                Global.sum = 0;
                Session["sum"] = "0";
                Session["error"] = null;
                Session["userName"] = u.userName.ToString();
                Session["permission"] = u.permission;

                //cookies
                    //username cookie
                HttpCookie cookie = new HttpCookie("Name");
                cookie.Value = u.userName;
                cookie.Expires = DateTime.Now.AddDays(7);
                    //permission cookie
                HttpCookie percookie = new HttpCookie("permission");
                percookie.Value = u.permission.ToString();
                percookie.Expires = DateTime.Now.AddDays(7);

                    //add cookie to browser
                HttpContext.Response.Cookies.Add(cookie);
                HttpContext.Response.Cookies.Add(percookie);


                return RedirectToAction("Shophomepage", "Shop");
            }
        }
        public ActionResult logout()
        {
            //case user logged out and has cookies DELETE old cookies and next login save new ones
            if (Request.Cookies["Name"] != null)
            {
                var c = new HttpCookie("Name");
                c.Expires = DateTime.Now.AddDays(-1);
                Response.Cookies.Add(c);
                if(Request.Cookies["permission"] !=null)
                {
                    var pc = new HttpCookie("Name");
                    pc.Expires = DateTime.Now.AddDays(-1);
                    Response.Cookies.Add(pc);
                }
            }

            //each logout cart reset with global disply variables
            Global.cart = new List<Game>();
            Global.sum = 0;
            Session["register"] = null;
            Session["error"] = null;
            Session["userName"] = null;

            //returns the homepage
            return RedirectToAction("ShopHomePage", "Shop");
        }
        public ActionResult Users()
        {
            //display all user in web grid view
            UserViewModel uvm = new UserViewModel();
            UserDal dal = new UserDal();
            uvm.users = dal.Users.ToList<User>();
            return View(uvm);
        }
    }
}