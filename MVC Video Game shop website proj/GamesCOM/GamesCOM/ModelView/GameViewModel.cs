using GamesCOM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GamesCOM.ModelView
{
    public class GameViewModel
    {
        public Game game { get; set; }

        public List<Game> games { get; set; }
    }
}