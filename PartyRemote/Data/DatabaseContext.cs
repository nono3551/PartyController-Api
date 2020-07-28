using Microsoft.EntityFrameworkCore;
using PartyRemote.Data.Models;

namespace PartyRemote.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }

        public DbSet<PartySession> PartySessions { get; set; }
    }
}
