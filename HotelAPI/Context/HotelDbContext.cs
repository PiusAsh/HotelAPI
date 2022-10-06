using HotelAPI.Models;
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserModel>().ToTable("Registered Users");
            modelBuilder.Entity<RoomModel>().ToTable("Hotel Rooms");
        }
    }
}
