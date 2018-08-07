using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GamesCOM.Models;
using GamesCOM.DAL;
using GamesCOM.ModelView;
using System.Threading;

namespace GamesCOM.Controllers
{

    public class ShopController : Controller
    {
        // GET: Shop
        public ActionResult ShopHomePage()
        {
            //reset sum if nothing in cart
            if (Global.sum == 0)
                Session["sum"] = "0";

            //if has cookies remembers user
            HttpCookie cookie = Request.Cookies["Name"];
            HttpCookie percookie = Request.Cookies["permission"];

            if (cookie!=null)//case has cookies 
            {
                //saves user name and permission to display current information
                Session["userName"] = Request.Cookies["Name"].Value;
                if(percookie!=null)
                    Session["permission"] = Request.Cookies["permission"].Value;

            }

            //gets the current cart
            Session["cart"] = Global.cart;

            //game view model display all games
            GameDal dal = new GameDal();
            List<Game> objGames = dal.Games.ToList<Game>();
            GameViewModel gvm = new GameViewModel();
            gvm.game = new Game();
            gvm.games = objGames;
            return View(gvm);
        }
        public ActionResult addToCart(string name)
        {
            //game dal refrense to add a game to cart
            GameDal dal = new GameDal();
            Game g = new Game();

            //find game by game name
            g = dal.findGame(name);

            //adds the found game to cart
            Global.cart.Add(g);
            //updates sum
            Global.sum +=Int32.Parse(g.price);
            Session["sum"] = Global.sum.ToString();

            //shows current cart
            return View("viewcart");
        }
        public ActionResult delete(string id)//removes an item from cart
        {
            //find the game index to delete
            int index = Global.findGameIndex(id);
            Global.sum -= Int32.Parse(Global.cart[index].price);

            //updates sum
            if (Global.sum == 0)
                Session["sum"] = "0";
            else
                Session["sum"] = Global.sum.ToString();

            //remove from cart
            Global.cart.RemoveAt(index);

            //shows new cart
            return View("viewcart");

        }
        public ActionResult viewCart()
        {
            //shows current cart
            return View();
        }

        public ActionResult AddGame()
        {
            GameViewModel gvm = new GameViewModel();
            Game objGame = new Game();
            if (Request.Form["game.name"] == null)
                return View("AddGame", gvm);
            objGame.name = Request.Form["game.name"].ToString();
            objGame.console = Request.Form["game.console"].ToString();
            objGame.genre = Request.Form["game.genre"].ToString();
            objGame.price = Request.Form["game.price"].ToString();
            objGame.coverLink = Request.Form["game.coverLink"].ToString();
            objGame.stock = Request.Form["game.stock"].ToString();
            GameDal dal = new GameDal();

            //data validation before updating db
            if (ModelState.IsValid)
            {
                dal.Games.Add(objGame);
                dal.SaveChanges();
                gvm.game = new Game();
            }
            else
                gvm.game = objGame;

            gvm.games = dal.Games.ToList<Game>();
            return View("AddGame", gvm);
        }

        public ActionResult Search()
        {
            GameDal dal = new GameDal();
            string searchName = "";
            string searchConsole = "";
            if (Request.Form["txtName"] != null)
                searchName = Request.Form["txtName"].ToString();
            if (Request.Form["ddConsole"] != null)
                searchConsole = Request.Form["ddConsole"].ToString();
            //Searching by passed criteria
            List<Game> objGames =
                (from x in dal.Games
                 where x.name.Contains(searchName) where x.console.Contains(searchConsole)
                 select x).ToList();
            GameViewModel gvm = new GameViewModel();
            gvm.games = objGames;
            return View(gvm);
        }

        public ActionResult Game(string name)
        {
            //display a game onto the user when selecting order now
            GameDal dal = new GameDal();
            Game g = new Game();
            g = dal.findGame(name);
            return View(g);
        }
        
        public ActionResult checkOut()
        {
            //updates stock
            GameDal dal = new GameDal();
            GameViewModel gvm = new GameViewModel();
            gvm.games = new List<Game>();


            //create game view model
            foreach (Game g in dal.Games)
                gvm.games.Add(g);

            //updates the stock for each game purchesed
            for (int j = 0; j < Global.cart.Count(); j++)
            {
                for (int i = 0; i < gvm.games.Count(); i++)
                {

                   if( gvm.games[i].name == Global.cart[j].name)
                    {
                        if (Int32.Parse(gvm.games[i].stock) == 0)
                            gvm.games[i].stock = "0";
                        else
                            gvm.games[i].stock = (Int32.Parse(gvm.games[i].stock) - 1).ToString();

                        break;
                    }

                }
            }
            //saves the updates
            dal.SaveChanges();

            //addes a new order
            OrderDal odal = new OrderDal();
            string uname = Session["userName"].ToString();
            Order or = new Order();
            or.userName = uname;
            int sum = Int32.Parse(Session["sum"].ToString());
            or.sum = sum;

            odal.orders.Add(or);
            odal.SaveChanges();
            Order o = odal.getLastOrder();


            //connect all cart items to the above order
            ItemsDal idal = new ItemsDal();
            foreach (Game g in Global.cart)
                idal.items.Add(new Item(o.id,g.name));
            idal.SaveChanges();

            //resets cart and global variables
            Global.cart = new List<Game>();
            Global.sum = 0;
            Session["sum"] = "0";

            //retuns thank you for your purchese
            return View();
        }

        public ActionResult Orders()
        {
            //display to admin all orders made
            GameDal dal = new GameDal();
            Game o = new Game();
            return View();
        }

        public ActionResult GetOrdersByJson()
        {
            //display to user all orders by json
            OrderDal dal = new OrderDal();
            Thread.Sleep(3000);
            List<Order> objOrders = dal.orders.ToList<Order>();
            return Json(objOrders, JsonRequestBehavior.AllowGet);
        }
    }
}