using Microsoft.EntityFrameworkCore;
using Orm_Entity.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Orm_Entity.Data.DAL
{
    class BP_StadionDbContext:DbContext
    {
        public DbSet<Stadion> Stadions { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server = DESKTOP-AJGVV24;database = BP_Stadion; trusted_connection = true");
        }
    }
}
