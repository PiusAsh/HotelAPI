using HotelAPI.Models;
using HotelAPI.Models.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelAPI.Context
{
    public class HotelDbContext : DbContext
    {

        public HotelDbContext(DbContextOptions<HotelDbContext> options): base(options)
        {

        }

        public DbSet<UserModel> UserModels { get; set; }
        public DbSet<RoomModel> RoomModels { get; set; }
        public DbSet<OrderModel> OrderModels { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserModel>().ToTable("Users");
            modelBuilder.Entity<RoomModel>().ToTable("Rooms");
            modelBuilder.Entity<OrderModel>().ToTable("Orders");
           
        }
    }
}
