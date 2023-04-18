using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Assignment3Morgenmadbuffeten.Models.Users;

namespace Assignment3Morgenmadbuffeten.Data
{
    public class BreakfastBuffetContext : DbContext
    {
        public BreakfastBuffetContext(DbContextOptions<BreakfastBuffetContext> options) : base(options)
        {
        }

        public DbSet<Kitchen> Kitchens { get; set; }
        public DbSet<Reception> Receptions { get; set; }
        public DbSet<Reception> Receptions { get; set; }
    }
}