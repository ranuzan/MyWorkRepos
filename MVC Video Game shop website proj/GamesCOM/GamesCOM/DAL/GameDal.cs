using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using GamesCOM.Models;

namespace GamesCOM.DAL
{
    public class GameDal : DbContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Game>().ToTable("games");
        }
        public DbSet<Game> Games { get; set; }

        //recives a game name and retuns a matching game with that name
        public Game findGame(string name)
        {
            foreach (Game obj in Games)
            {
                if (name == obj.name)
                {
                    return obj;
                }
            }
            return null;
        }

    }
}