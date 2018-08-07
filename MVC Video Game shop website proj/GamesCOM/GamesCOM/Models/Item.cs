using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GamesCOM.Models
{
    public class Item
    {

        public Item(int oId, string name)
        {
            this.orderID = oId;
            this.gameName = name;
        }

        public int orderID { get; set; }

        public string gameName { get; set; }

        [Key]
        public int index { get; set; }
    }
}