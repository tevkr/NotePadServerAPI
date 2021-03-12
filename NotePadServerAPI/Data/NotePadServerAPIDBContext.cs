using Microsoft.EntityFrameworkCore;
using NotePadServerAPI.Models;

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
