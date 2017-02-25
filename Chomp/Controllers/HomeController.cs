using Chomp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Chomp.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        private static MatrixTable GameTable;
        public static bool PlayerTurn;
        public static bool isPlayingComputer;
        public ActionResult Index()
        {
            return View();
        }
         [HttpPost]
        public ActionResult StartGame(int x, int y, string selection )
        {

            GameTable = new MatrixTable(x, y);
            if (selection.Equals("computer"))
            {
                isPlayingComputer = true;
            }
            else
            {
                isPlayingComputer = false;
            }
            PlayerTurn = true; //true ilk oyuncu
            return PartialView("GameTable", GameTable);
        }

         //[HttpPost]
         //public bool SelectItem(int x, int y)
         //{

         //    GameTable.Table[y, x].isEaten = !GameTable.Table[y, x].isEaten;

         //    return GameTable.Table[y, x].isEaten;
         //}

         [HttpPost]
         public ActionResult EatItems(int x, int y)
         {
             if (isPlayingComputer)
             {
                 
                     GameTable.EatLeft(x, y);
                     PlayerTurn = !PlayerTurn;
                     GameTable.ComputerEatRandom();
                     PlayerTurn = !PlayerTurn;
                 
             }
             else
             {
                 GameTable.EatLeft(x, y);
                 PlayerTurn = !PlayerTurn;
             }
             
            

             return PartialView("GameTable", GameTable);
         }

    }
}
