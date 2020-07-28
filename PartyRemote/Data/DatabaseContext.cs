using Microsoft.EntityFrameworkCore;
using PartyRemote.Data.Models;

namespace PartyRemote.Data
{
    public class DatabaseContext : DbContext
    {
        public DbSet<PartySession> PartySessions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options) => options.UseSqlite("Data Source=database.db");
    }
}
