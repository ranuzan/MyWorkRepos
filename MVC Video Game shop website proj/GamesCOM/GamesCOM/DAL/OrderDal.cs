using GamesCOM.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace GamesCOM.DAL
{
    public class OrderDal : DbContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Order>().ToTable("orders");
        }
        public DbSet<Order> orders { get; set; }


        //returns last order in DB
        public Order getLastOrder()
        {
            int count=0,compare=0;
            foreach (Order obj in orders)
            {
                count++;
            }
            foreach (Order obj in orders)
            {
                compare++;
                if (compare == count)
                    return obj;
            }
            return null;
        }


    }
}