using GamesCOM.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace GamesCOM.DAL
{
    public class UserDal : DbContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>().ToTable("users");
        }
        public DbSet<User> Users { get; set; }


        //recives a user and validates password and user name
        public User checkLogin(User user)
        {
            foreach (User obj in Users)
            {
                if (user.userName == obj.userName && user.password == obj.password)
                {
                    return obj;
                }
            }
            return null;
        }
       // recives a username and check if it exist in DB
        public Boolean checkExits(string name)
        {
            foreach (User obj in Users)
            {
                if (name == obj.userName)
                    return true;
            }
            return false;
        }

    }
}
