using Microsoft.EntityFrameworkCore;
using NotePadServerAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotePadServerAPI.Data
{
    public class NotePadServerAPIDBContext : DbContext
    {
        public NotePadServerAPIDBContext(DbContextOptions<NotePadServerAPIDBContext> options)
            : base(options) { }
        public DbSet<User> users { get; set; }
        public DbSet<Purchase> purchases { get; set; }
    }
}
